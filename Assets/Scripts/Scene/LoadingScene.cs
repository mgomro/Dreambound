using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private TextMeshProUGUI loadingText;
    private bool loadingAnimationScene = true;
    private int selectedLevel;

    private void Awake()
    {
        loadingText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartLoadingIntro()
    {
        this.gameObject.SetActive(true);
        selectedLevel = LevelManager.Instance.GetSelectedLevel();
        StartCoroutine(LoadScene());
    }

    public void StartLoadingLevel()
    {
        this.gameObject.SetActive(true);
        selectedLevel = SceneManager.GetActiveScene().buildIndex + 1; // Nivel correspondiente a la intro
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        int times = 0;
        while (loadingAnimationScene)
        {
            loadingText.text = "Cargando";
            yield return new WaitForSeconds(0.4f);

            loadingText.text = "Cargando .";
            yield return new WaitForSeconds(0.4f);

            loadingText.text = "Cargando . .";
            yield return new WaitForSeconds(0.4f);

            loadingText.text = "Cargando . . .";
            yield return new WaitForSeconds(0.4f);

            times++;

            if (times == 3)
            {
                StopLoadingScene();
            }
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(selectedLevel);
    }

    private void StopLoadingScene()
    {
        SoundManager.Instance.LoadNextSound(0.5f);
        loadingAnimationScene = false;
    }
}
