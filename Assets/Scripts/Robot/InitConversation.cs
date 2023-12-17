using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConversation : MonoBehaviour
{
    public InteractRobot interactRobot;
    private static string playerName;

    private void Start()
    {
        playerName = InitPlayer.playerName;
        SetConversations(playerName);
    }

    private void SetConversations(string playerName)
    {
        Transform conversationsPlayer = gameObject.transform.Find(playerName);
        if (conversationsPlayer != null)
        {
            interactRobot.conversations = conversationsPlayer.GetComponentsInChildren<NPCConversation>();
        }
    }
}
