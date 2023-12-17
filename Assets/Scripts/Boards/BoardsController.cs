using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SoundFXMananger;

public class BoardsController : MonoBehaviour
{
    public GameObject panelBoard;
    public GameObject door;
    public BoxCollider2D mainBoard;

    private GameObject[] boards;
    private int correctAnswers;
    private int numBoard;
    private int numAnswers;
    private bool isGameFinish;

    void Start()
    {
        panelBoard.SetActive(false);
        SetBoards();
        mainBoard.enabled = false;
        correctAnswers  = 0; 
        numBoard = 0;
        numAnswers = 0;
        isGameFinish = false;
    }

    private void SetBoards()
    {
        int childCount = panelBoard.transform.childCount;
        boards = new GameObject[childCount];

        int index = 0;
        foreach (Transform childTransform in panelBoard.transform)
        {
            boards[index] = childTransform.gameObject;
            index++;
        }
        DisableBoards();
    }

    private void DisableBoards()
    {
        foreach (GameObject child in boards)
        {
            child.SetActive(false);
        }
    }

    public void StartGame()
    {
        if (!isGameFinish)
            TurnOnGUI();
    }

    public void TurnOnGUI()
    {
        if (numBoard == 3)
            numBoard = 0;

        panelBoard.SetActive(true);
        boards[numBoard].SetActive(true);
    }
    public void TurnOffGUI(int numBoard)
    {
        panelBoard.SetActive(false);
        boards[numBoard].SetActive(false);
    }

    public void SaveAnswer(bool isCorrect)
    {
        SoundFXMananger.Instance.PlaySound(SoundType.AnswerBoard);
        correctAnswers += isCorrect ? 1 : (correctAnswers > 0 ? -1 : 0);
        numAnswers++;

        TurnOffGUI(numBoard);

        if (numAnswers == 3)
        {
            InitPlayer.playerObject.GetComponent<InteractController>().InteractingOff();

            if (correctAnswers == 3)
            {
                SoundManager.Instance.EndMiniGame();
                isGameFinish = true;
                Invoke(nameof(OpenDoor), 1.5f);
            }
            else
            {
                correctAnswers = 0;
                numAnswers = 0;
                numBoard = 0;
                SoundFXMananger.Instance.PlaySound(SoundType.Incorrect);
            }
        }
        else
        {
            numBoard++;
            StartCoroutine(NextQuestion());
        }
    }

    public IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(1f);
        TurnOnGUI();
    }

    private void OpenDoor()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.OpenDoor);
        door.SetActive(false);
    }
}
