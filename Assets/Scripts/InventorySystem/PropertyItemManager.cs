using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyItemManager : MonoBehaviour
{
    public static PropertyItemManager Instance;
    [Header("Property Notes")]
    public NotesManager notesManager;

    [Header("Property QuestFlask")]
    public LightersController lightersController;

    [Header("Property QuestRobot")]
    public InteractRobot interactRobot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPropertyItem(GameObject item, ItemType type)
    {
        switch (type)
        {
            case ItemType.Flask:
                SetQuestFlask(item);
                break;
            case ItemType.Robot:
                SetQuestRobot(item);
                break;
            case ItemType.Note:
                SetItemNote(item);
                break;
        }
    }

    private void SetQuestFlask(GameObject item)
    {
        InteractFlask interactNoteComponent = item.AddComponent<InteractFlask>();

        item.GetComponent<InteractFlask>().lightersController = lightersController;
    }

    private void SetQuestRobot(GameObject item)
    {
        InteractCell interactRobotComponent = item.AddComponent<InteractCell>();

        item.GetComponent<InteractCell>().interactRobot = interactRobot;
    }

    private void SetItemNote(GameObject item)
    {
        InteractNote interactNoteComponent = item.AddComponent<InteractNote>();

        interactNoteComponent.noteGUI = notesManager;
    }

}
