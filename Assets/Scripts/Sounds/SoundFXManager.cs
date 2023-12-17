using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXMananger : MonoBehaviour
{
    public enum SoundType
    {
        ActivateLightOut,
        ActivateRobot,
        ActivateTesla,
        ActiveCodePanel,
        ActiveNote,
        AnswerBoard,
        ButtonLightOut,
        ButtonPanel,
        ClickMenu,
        CorrectCode,
        CountDown,
        DisableCapsule,
        FlaskInLighter,
        GetFlask,
        GetObject,
        Incorrect,
        OpenDoor,
        SimonDo,
        SimonMi,
        SimonSi,
        SimonSol,
        TakeClipboard,
        TurnPage
    }

    public float volumeFX = 0.2f;
    private Dictionary<SoundType, AudioClip> soundDictionary;
    private const string SoundFolderPath = "Audio/SoundFX/";

    private static SoundFXMananger instance;

    public static SoundFXMananger Instance
     {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SoundFXMananger").AddComponent<SoundFXMananger>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        soundDictionary = new Dictionary<SoundType, AudioClip>();
        StartCoroutine(LoadSoundsAsync());
    }

    private IEnumerator LoadSoundsAsync()
    {
        foreach (SoundType soundType in Enum.GetValues(typeof(SoundType)))
        {
            string path = SoundFolderPath + soundType.ToString();
            ResourceRequest request = Resources.LoadAsync<AudioClip>(path);
            yield return request;

            if (request.asset != null)
            {
                soundDictionary[soundType] = (AudioClip)request.asset;
            }
            else
            {
                Debug.LogError("Error loading sound: " + soundType.ToString());
            }
        }
    }

    public void PlaySound(SoundType soundType)
    {
        if (soundDictionary.ContainsKey(soundType))
        {
            AudioSource.PlayClipAtPoint(soundDictionary[soundType], Camera.main.transform.position, volumeFX);
        }
    }
}

