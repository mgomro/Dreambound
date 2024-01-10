using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SoundFXMananger;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsUI;
    private InteractController interactPlayer;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        interactPlayer = InitPlayer.playerObject.GetComponent<InteractController>();
    }

    public void ResumeGame()
    {
        interactPlayer.InteractingOff();
        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        DefaultCursor();
        //Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        interactPlayer.InteractingOn();
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        isPaused = true;

    }

    private void DefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OpenOptions()
    {
        optionsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        DefaultCursor();
    }

    public void ReturnToGameFromOptions()
    {
        optionsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        DefaultCursor();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        DestroyObject();

        //Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SoundClickButton()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ClickMenu);
    }

    private void DestroyObject()
    {
        LevelManager.Instance.DestroySelf();
        GameManager.Instance.DestroySelf();
    }
}
