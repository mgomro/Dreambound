using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabyrinthController : MonoBehaviour
{
    public SpriteRenderer darkSprite;
    public float darkenSpeed = 2f;
    public SpriteRenderer TransitionSprite;
    public GameObject mask;
    public AudioClip gameAudio;
    public GameObject helpButton;

    private Transform playerPosition;
    private Transform initPlayerPosition;
    private Transform maskPlayer;

    private bool startGame = false;
    private bool firstTime = false;

    private Vector3 lastPlayerPosition;

    private void Start()
    {
       playerPosition = InitPlayer.playerObject.transform;
       initPlayerPosition = InitPlayer.playerObject.transform;
       maskPlayer = mask.transform;
       darkSprite.gameObject.SetActive(false);
       TransitionSprite.gameObject.SetActive(false);
       maskPlayer.gameObject.SetActive(false);
       helpButton.SetActive(false);
    }

    private void Update()
    {
        if (startGame)
        {
            maskPlayer.position = playerPosition.position;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !firstTime)
        {
            helpButton.SetActive(true);
            SoundManager.Instance.ChangeMusicGradually(gameAudio, 2f);
            lastPlayerPosition = playerPosition.position;
            initPlayerPosition.position = lastPlayerPosition;

            StartLabyrinth();
            firstTime = true;
        }
    }
    public void InitPositionPlayer()
    {
        StartCoroutine(SetInitPositionPlayer());
    }

    private IEnumerator SetInitPositionPlayer()
    {
        StartCoroutine(AlphaTransitionEffect(250, 255f, 1f));
        yield return new WaitForSeconds(2f);
        playerPosition.position = lastPlayerPosition;
        StartCoroutine(AlphaTransitionEffect(255, 250f, 1f));
    }

    IEnumerator DarkenGradually()
    {
        Vector3 initialPosition = darkSprite.transform.position;
        Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + 5f, initialPosition.z);
        Vector3 initialScale = darkSprite.transform.localScale;

        darkSprite.gameObject.SetActive(true);
        float timer = 0f;

        while (timer < 1f)
        {
            timer += darkenSpeed * Time.deltaTime;

            darkSprite.transform.localScale = Vector3.Lerp(initialScale, new Vector3(22f, 12f, 1f), timer);

            darkSprite.transform.position = Vector3.Lerp(initialPosition, targetPosition, timer);

            yield return null;
        }
        StartCoroutine(AlphaTransitionEffect(100f, 250f, 1f));
    }

    IEnumerator AlphaTransitionEffect(float initialAlpha, float targetAlpha, float duration)
    {
        TransitionSprite.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        startGame = true;
        maskPlayer.gameObject.SetActive(true);

        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            float currentAlpha = Mathf.Lerp(initialAlpha, targetAlpha, t);

            Color spriteColor = TransitionSprite.color;
            spriteColor.a = currentAlpha / 255f;
            TransitionSprite.color = spriteColor;

            yield return null;
        }

        Color finalColor = TransitionSprite.color;
        finalColor.a = targetAlpha / 255f;
        TransitionSprite.color = finalColor;
    }

    private void StartLabyrinth()
    {
        StartCoroutine(DarkenGradually());
        
    }

    public void DisableLabyrinth()
    {
        StartCoroutine(AlphaTransitionEffect(250f, 0f, 1f));
        darkSprite.gameObject.SetActive(false);
        maskPlayer.gameObject.SetActive(false);
        helpButton.SetActive(false);
        startGame = false;
    }



}
