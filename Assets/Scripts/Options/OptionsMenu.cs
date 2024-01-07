using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using DialogueEditor;

public class OptionsMenu : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider soundEffectsVolumeSlider;
    public Slider dialogueSpeedSlider;

    private AudioSource playerFootstep;

    private void Start()
    {
        // SoundMusic
        musicVolumeSlider.value = SoundManager.Instance.musicVolume;
        // FXs
        soundEffectsVolumeSlider.value = SoundFXMananger.Instance.volumeFX;
        playerFootstep = InitPlayer.playerObject.GetComponent<AudioSource>();
        // Dialogue
        dialogueSpeedSlider.value = ConversationManager.Instance.ScrollSpeed;
    }

    public void OnMusicVolumeChanged()
    {
        SoundManager.Instance.SetVolume(musicVolumeSlider.value);
    }

    public void OnSoundEffectsVolumeChanged()
    {
        SoundFXMananger.Instance.SetVolume(soundEffectsVolumeSlider.value);
        playerFootstep.volume = soundEffectsVolumeSlider.value;
    }

    public void OnDialogueSpeedChanged()
    {
        ConversationManager.Instance.ScrollSpeed = dialogueSpeedSlider.value;
    }
}
