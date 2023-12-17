using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SoundFXMananger;

public class SceneButtons : MonoBehaviour
{

    public void StartGame()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ClickMenu);
        Invoke("LoadNextScene", 0.2f);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ClickMenu);
        Application.Quit();
    }
}
