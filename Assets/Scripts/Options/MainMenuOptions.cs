using UnityEngine;
using UnityEngine.UI;
using static SoundFXMananger;

public class MainMenuOptions : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider soundEffectsVolumeSlider;

    private void Start()
    {
        // SoundMusic
        musicVolumeSlider.value = SoundManager.Instance.musicVolume;
        // FXs
        soundEffectsVolumeSlider.value = SoundFXMananger.Instance.volumeFX;
    }

    public void OnMusicVolumeChanged()
    {
        SoundManager.Instance.SetVolume(musicVolumeSlider.value);
    }

    public void OnSoundEffectsVolumeChanged()
    {
        float volume = soundEffectsVolumeSlider.value;
        SoundFXMananger.Instance.SetVolume(volume);
    }

    public void CloseOptions()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ClickMenu);
    }
}
