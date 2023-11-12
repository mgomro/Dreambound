using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonController : MonoBehaviour
{
    //public GameObject[] buttons;
    public GameObject[] teslaCoils, buttons;
    public Sprite[] spriteButtons;
    public AnimationClip[] animations;
    public List<int> pattern = new List<int>();
    public List<int> playerPattern = new List<int>();
    public float flashDuration = 2f;

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
        Invoke("EnabledButtons", 2f);
    }


    void FlashButton(int colorIndex)
    {
        int index = Random.Range(0, 4);
        SpriteRenderer spriteRenderer = teslaCoils[index].GetComponent<SpriteRenderer>();
        Animator animator = teslaCoils[index].GetComponent<Animator>();


        Sprite originalSprite = spriteRenderer.sprite;


        animator.Play(animations[colorIndex].name);

        StartCoroutine(RevertSpriteAfterDelay(animator, spriteRenderer, originalSprite));
        //StopCoroutine(RevertSpriteAfterDelay(animator, spriteRenderer, originalSprite));
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
            button.GetComponent<InteractButtonSimon>().enabledButton = true;
            index++;
        }
    }

    void DisableButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<InteractButtonSimon>().enabledButton = false;
            button.GetComponent<SpriteRenderer>().sprite = spriteButtons[4];
        }
    }

    public void OnButtonClick(int colorIndex)
    {
        playerPattern.Add(colorIndex);
        if (CheckWinCondtion())
        {
            Debug.Log("Has Ganado");

            DisableButtons();
            gameObject.GetComponent<SimonAnimations>().EnabledAnimations();
        }
        else if (!CheckPlayerInput())
        {
            DisableButtons();
            Debug.Log("¡Te equivocaste! Reiniciando...");
            playerPattern.Clear();
            Invoke("StartGame", 2f);
        }
        else if (playerPattern.Count == pattern.Count)
        {
            DisableButtons();
            Debug.Log("¡Secuencia correcta! Añadiendo nuevo color...");
            playerPattern.Clear();
            AddColorToPattern();
            StartCoroutine(PlayPattern());
        }

    }
    private bool CheckWinCondtion()
    {
        return playerPattern.Count == 6;
    }
    public void StartGame()
    {
        pattern.Clear();
        playerPattern.Clear();
        AddColorToPattern();
        StartCoroutine(PlayPattern());
    }
}
