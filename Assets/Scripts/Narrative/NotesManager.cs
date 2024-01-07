using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static SoundFXMananger;

public class NotesManager : MonoBehaviour
{

    public GameObject notes;
    public GameObject EndButton;

    private TextMeshProUGUI[] _notes;
    private bool isActive = false;

    void Start()
    {
        _notes = new TextMeshProUGUI[notes.transform.childCount];
        SetNotes();
        TurnOffGUI();
    }

    private void SetNotes()
    {
        int idNote = 0;
        foreach (Transform child in notes.transform)
        {
            _notes[idNote] = child.GetComponent<TextMeshProUGUI>();
            idNote++;
        }
    }

    public void ShowNote(int index)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _notes[index].text;
        isActive = true;
        TurnOnGUI();
    }

    public void CloseNotes()
    {
        TurnOffGUI();
        isActive = false;
        GameManager.Instance.SetDefaultCursor();
    }

    public bool IsActive()
    {
        return isActive;
    }

    private void ClearClipBoard()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }

    public void TurnOnGUI()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ActiveNote);
        gameObject.SetActive(true);
        EndButton.SetActive(true);
    }

    public void TurnOffGUI()
    {
        ClearClipBoard();
        gameObject.SetActive(false);
        EndButton.SetActive(false);
    }
}
