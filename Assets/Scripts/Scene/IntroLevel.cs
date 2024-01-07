using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLevel : MonoBehaviour
{
    public List<NPCConversation> conversations;
    void Start()
    {
        Invoke("StartConversation", 0.1f);
    }

    private void StartConversation()
    {
        ConversationManager.Instance.StartConversation(conversations[InitPlayer.index]);
    }
}
