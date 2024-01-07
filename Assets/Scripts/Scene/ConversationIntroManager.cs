using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationIntroManager : MonoBehaviour
{
    public RectTransform dialogueBox;
    public NPCConversation[] conversations;

    private string playerName;
    private Vector3 newPosition = new Vector3(532, -274, 0);

    private void Awake()
    {
        int index = PlayerPrefs.GetInt("PlayerIndex");
        playerName = GameManager.Instance.characters[index].Character.name;
        SetConversations(playerName);
    }

    public void StartFirstConversation()
    {
        ConversationManager.Instance.StartConversation(conversations[0]);
    }

    public void StartSecondConversation()
    {
        SetPositionDialogue();
        ConversationManager.Instance.StartConversation(conversations[1]);
    }
    private void SetPositionDialogue()
    {
        dialogueBox.localPosition = newPosition;
    }

    private void SetConversations(string playerName)
    {
        Transform conversationsPlayer = gameObject.transform.Find(playerName);
        if (conversationsPlayer != null)
        {
            conversations = conversationsPlayer.GetComponentsInChildren<NPCConversation>();
        }
    }
}
