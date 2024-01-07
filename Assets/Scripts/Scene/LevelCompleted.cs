using UnityEngine;
using static SoundFXMananger;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public GameObject levelCompleted;
    public string level;
    private InteractController interactPlayer;

    private void Start()
    {
        levelCompleted.SetActive(false);
        interactPlayer = InitPlayer.playerObject.GetComponent<InteractController>();
    }

    public void LevelComplete()
    {
        interactPlayer.InteractingOn();
        levelCompleted.SetActive(true);
        LevelManager.Instance.UnlockNextLevel(level);

    }

    public void NextLevel()
    {
        DestroyObject();
        SceneManager.LoadScene("00_Credits"); // Fase beta: Ir a creditos, proxima actualización siguiente nivel con pantalla de carga.
    }

    public void GoToMainMenu()
    {
        DestroyObject();
        SceneManager.LoadScene(0);
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
