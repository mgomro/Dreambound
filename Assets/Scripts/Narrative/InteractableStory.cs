using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class InteractableStory : Interactable
{
    public StoryManager storyManager;
    public int idStory;
    public bool containsGame;
    public override void Interact()
    {
        if (!storyManager.IsActive())
        {
            InitPlayer.playerObject.GetComponent<InteractController>().InteractingOn();
            storyManager.ShowNarrative(idStory);
            SoundFXMananger.Instance.PlaySound(SoundType.TakeClipboard);
            if (containsGame)
                storyManager.ContainsGame(gameObject.GetComponent<GameActivable>());
        }
        
    }

}
