using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class SimonController : MonoBehaviour
{
    public GameObject[] teslaCoils, buttons;
    public Sprite[] spriteButtons;
    public AnimationClip[] animations;
    public List<int> pattern = new List<int>();
    public List<int> playerPattern = new List<int>();
    public float flashDuration = 0.8f;
    public int winCondition;

    private bool startingGame = false;
    private SimonAnimations startAnimations;

    private void Start()
    {
        startAnimations = gameObject.GetComponent<SimonAnimations>();
        DisableButtons();
    }

    void AddColorToPattern()
    {
        int randomColor = Random.Range(0, 4);
        pattern.Add(randomColor);
    }

    IEnumerator PlayPattern()
    {
        foreach (int color in pattern)
        {
            yield return new WaitForSeconds(flashDuration);
            FlashButton(color);
        }
        Invoke("EnabledButtons", 1.5f);
    }


    void FlashButton(int colorIndex)
    {
        int index = Random.Range(0, 4);
        SpriteRenderer spriteRenderer = teslaCoils[index].GetComponent<SpriteRenderer>();
        Animator animator = teslaCoils[index].GetComponent<Animator>();


        Sprite originalSprite = spriteRenderer.sprite;

        switch (colorIndex)
        {
            case 0:
                SoundFXMananger.Instance.PlaySound(SoundType.SimonDo);
                break;
            case 1:
                SoundFXMananger.Instance.PlaySound(SoundType.SimonMi);
                break;
            case 2:
                SoundFXMananger.Instance.PlaySound(SoundType.SimonSol);
                break;
            case 3:
                SoundFXMananger.Instance.PlaySound(SoundType.SimonSi);
                break;
        }
        animator.Play(animations[colorIndex].name);

        StartCoroutine(RevertSpriteAfterDelay(animator, spriteRenderer, originalSprite));
    }

    IEnumerator RevertSpriteAfterDelay(Animator animator, SpriteRenderer spriteRenderer, Sprite originalSprite)
    {
        yield return new WaitForSeconds(0.5f);
        animator.Play("GreyAnim");

        spriteRenderer.sprite = originalSprite;
    }

    bool CheckPlayerInput()
    {

        for (int i = 0; i < playerPattern.Count; i++)
        {
            if (playerPattern[i] != pattern[i])
            {
                return false;
            }
        }

        return true;
    }

    void EnabledButtons()
    {
        int index = 0;
        foreach (GameObject button in buttons)
        {
            button.GetComponent<SpriteRenderer>().sprite = spriteButtons[index];
            button.GetComponent<CircleCollider2D>().enabled = true;
            index++;
        }
    }

    void DisableButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<CircleCollider2D>().enabled = false;
            button.GetComponent<SpriteRenderer>().sprite = spriteButtons[4];
        }
    }

    public void OnButtonClick(int colorIndex)
    {
        playerPattern.Add(colorIndex);
        if (CheckWinCondtion())
        {
            DisableButtons();
            StartCoroutine(startAnimations.EnabledAnimations());
        }
        else if (!CheckPlayerInput())
        {
            SoundFXMananger.Instance.PlaySound(SoundType.Incorrect);
            DisableButtons();
            playerPattern.Clear();
            Invoke("StartGame", 2f);
        }
        else if (playerPattern.Count == pattern.Count)
        {
            DisableButtons();
            playerPattern.Clear();
            AddColorToPattern();
            StartCoroutine(PlayPattern());
        }

    }
    private bool CheckWinCondtion()
    {
        return playerPattern.Count == winCondition;
    }

    public bool IsStarting()
    {
        return startingGame;
    }

    public void SetStarting()
    {
        startingGame = true;
    }

    public void StartGame()
    {
        pattern.Clear();
        playerPattern.Clear();
        AddColorToPattern();
        StartCoroutine(PlayPattern());
    }
}
