using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static SoundFXMananger;

public class StoryManager : MonoBehaviour
{
    public class Story
    {
        public TextMeshProUGUI[] narrative;
    }

    public GameObject chapters;
    public RectTransform uiNextEndPanel;
    public GameObject nextButton;
    public GameObject EndButton;
    public GameObject GameButton;
    


    private Dictionary<int, Story> storyDictionary = new Dictionary<int, Story>();
    private Story story;
    private int currentPage = 0;
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
        int idStory = 0;
        foreach (Transform chapter in chapters.transform)
        {
            List<TextMeshProUGUI> narrative = new List<TextMeshProUGUI>();
            narrative.Add(chapter.GetComponent<TextMeshProUGUI>());

            foreach (Transform page in chapter)
            {
                narrative.Add(page.GetComponent<TextMeshProUGUI>());
            }

            AddStory(idStory, narrative.ToArray());
            idStory++;
        }
    }


    private void AddStory(int idStory, TextMeshProUGUI[] narrativeText)
    {
        Story story = new Story();
        story.narrative = narrativeText;

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
        currentPage = 0;
        text.text = story.narrative[currentPage].text;

        UpdatePageButtons();
    }

    public void SetNextPage()
    {
        if (story != null && currentPage < story.narrative.Length - 1)
        {
            SoundFXMananger.Instance.PlaySound(SoundType.TurnPage);
            currentPage++;
            text.text = story.narrative[currentPage].text;
            UpdatePageButtons();
        }
    }

    private void UpdatePageButtons()
    {
        if (story != null && currentPage < story.narrative.Length - 1)
        {
            nextButton.SetActive(true);
            EndButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(false);
            EndButton.SetActive(true);
        }
    }

    public bool IsActive()
    {
        return isActive;
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
        SoundFXMananger.Instance.PlaySound(SoundType.TakeClipboard);
        TurnOffGUI();
        GameManager.Instance.SetDefaultCursor();
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
