using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SoundFXMananger;

public class SceneButtons : MonoBehaviour
{

    public void SelectionCharacter()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SoundClick()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ClickMenu);
    }
}
