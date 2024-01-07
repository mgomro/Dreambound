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
        Alien,
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

    public float volumeFX = 0.08f;
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
    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        volumeFX = volume;
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

