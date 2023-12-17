using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private TextMeshProUGUI loadingText;
    private bool loadingAnimationScene = true;

    private void Awake()
    {
        loadingText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartLoading()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(LoadScene());
    }
    private IEnumerator LoadScene()
    {
        int times = 0;
        while (loadingAnimationScene)
        {
            loadingText.text = "Cargando";
            yield return new WaitForSeconds(0.5f);

            loadingText.text = "Cargando .";
            yield return new WaitForSeconds(0.5f);

            loadingText.text = "Cargando . .";
            yield return new WaitForSeconds(0.5f);

            loadingText.text = "Cargando . . .";
            yield return new WaitForSeconds(0.5f);

            times++;

            if (times == 3)
            {
                StopLoadingScene();
            }
        }
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void StopLoadingScene()
    {
        SoundManager.Instance.LoadNextSound(3f);
        loadingAnimationScene = false;
    }
}
