using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class InitAnimation : MonoBehaviour
{
    public PlayableDirector director;
    public List<TimelineAsset> timelines;
    public List<Sprite> characterSprites;
    public GameObject characterSpriteHolder;

    void Awake()
    {
        int characterIndex = PlayerPrefs.GetInt("PlayerIndex");
        if (characterIndex >= 0 && characterIndex < timelines.Count)
        {
            SetCharacterSprite(characterIndex);
            director.playableAsset = timelines[characterIndex];
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        StartTimeline();
    }

    private void SetCharacterSprite(int index)
    {
        if (index >= 0 && index < characterSprites.Count)
        {
            SpriteRenderer spriteRenderer = characterSpriteHolder.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = characterSprites[index];
        }
    }

    private void StartTimeline()
    {
        director.Play();
    }
}
