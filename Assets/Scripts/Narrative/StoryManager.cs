using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static SoundFXMananger;

public class StoryManager : MonoBehaviour
{
    public class Story 
    {
        public TextMeshProUGUI narrative;
        public TextMeshProUGUI instructions;
    }
    
    public GameObject histories;
    public RectTransform uiNextEndPanel;
    public GameObject nextButton;
    public GameObject EndButton;
    public GameObject GameButton;
    


    private Dictionary<int, Story> storyDictionary = new Dictionary<int, Story>();
    private Story story;
    private GameActivable game;
    private TextMeshProUGUI text;
    private bool isActive = false;

    void Start()
    {
        SetStories();
        text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        TurnOffGUI();
    }

    private void SetStories()
    {
        int idStory= 0;
        foreach (Transform child in histories.transform)
        {
            TextMeshProUGUI narrative = null;
            TextMeshProUGUI instructions = null;

            narrative = child.GetComponent<TextMeshProUGUI>();

            if (child.childCount > 0)
                instructions = child.GetChild(0).GetComponent<TextMeshProUGUI>();
                
            AddStory(idStory, narrative, instructions);
            idStory++;
        }
    }

    private void AddStory(int idStory, TextMeshProUGUI narrativeText, TextMeshProUGUI instructionsText)
    {
        Story story = new Story();
        story.narrative = narrativeText;
        story.instructions = instructionsText;

        if (!storyDictionary.ContainsKey(idStory))
        {
            storyDictionary.Add(idStory, story);
        }
    }

    private Story GetStoryByID(int idStory)
    {
        if (storyDictionary.ContainsKey(idStory))
        {
            return storyDictionary[idStory];
        }

        return null;
    }

    public void ShowNarrative(int idStory)
    {
        isActive = true;

        TurnOnGUI();
        story = GetStoryByID(idStory);
        text.text = story.narrative.text;

        if (hasInstructions(story))
            nextButton.SetActive(true);
        else
            EndButton.SetActive(true);
    }

    public bool IsActive()
    {
        return isActive;
    }

    private bool hasInstructions(Story story)
    {
        return story.instructions != null;
    }

    public void SetInstruction()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.TurnPage);
        ClearClipBoard();
        text.text = story.instructions.text;
        EndButton.SetActive(true);
    }

    public void ContainsGame(GameActivable gameActivable)
    {
        game = gameActivable;
    }


    public void CloseClipboad()
    {
        if (game != null)
            game.Activate();

        isActive = false;

        TurnOffGUI();
        GameManager.instance.SetDefaultCursor();
        InitPlayer.playerObject.GetComponent<InteractController>().InteractingOff();
        ClearGame();
    }

    private void ClearClipBoard()
    {
        text.text = "";
        nextButton.SetActive(false);
        EndButton.SetActive(false);
    }

    private void ClearGame()
    {
        game = null;
    }

    private void TurnOnGUI()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<ResizeImage>().StartResize();
    }

    private void TurnOffGUI()
    {
        ClearClipBoard();
        gameObject.SetActive(false);
    }
}
