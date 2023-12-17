using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static SoundFXMananger;

public class SelectionCharacter : MonoBehaviour
{
    public LoadingScene loadingScene;
    private int index;

    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;

        index = PlayerPrefs.GetInt("PlayerIndex");

        if (index > gameManager.characters.Count - 1)
        {
            index = 0;
        }

        ChangeCharacter();

    }

    private void ChangeCharacter()
    {
        PlayerPrefs.SetInt("PlayerIndex", index);
        imagen.sprite = gameManager.characters[index].imagen;
        nombre.text = gameManager.characters[index].nombre;
    }

    public void NextCharacter()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ClickMenu);
        if (index == gameManager.characters.Count -1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        ChangeCharacter();
    }

    public void PrevCharacter()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ClickMenu);
        if (index == 0)
        {
            index = gameManager.characters.Count - 1;
        }
        else
        {
            index -= 1;
        }

        ChangeCharacter();
    }

    public void StartGame()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ClickMenu);
        Invoke("LoadNextScene", 0.2f);
    }

    private void LoadNextScene()
    {
        loadingScene.StartLoading();
    }

}
