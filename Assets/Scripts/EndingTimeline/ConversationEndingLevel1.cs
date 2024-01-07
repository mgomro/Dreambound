using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationEndingLevel1 : MonoBehaviour
{
    public NPCConversation[] conversations;

    private string playerName;

    private void Start()
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
        ConversationManager.Instance.StartConversation(conversations[1]);
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
