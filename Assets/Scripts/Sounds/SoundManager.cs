using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip SoundMenu;
    public AudioClip SoundIntro;
    public AudioClip SoundMain;
    public float originalVolume = 0.3f;

    private static SoundManager instance;
    private AudioSource audioSource;
    

    private AudioClip originalSceneClip;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SoundManager").AddComponent<SoundManager>();
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
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.volume = originalVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenuAudio()
    {
        PlayAudio(SoundMenu);
    }

    public void PlayIntroAudio()
    {
        PlayAudio(SoundIntro);
    }

    public void PlayMainAudio()
    {
        PlayAudio(SoundMain);
    }

    public void LowerVolume(float amount, float duration)
    {
        StartCoroutine(LowerVolumeCoroutine(amount, duration));
    }

    public void RestoreVolume(float amount, float duration)
    {
        StartCoroutine(RestoreVolumeCoroutine(amount, duration));
    }

    private IEnumerator LowerVolumeCoroutine(float amount, float duration)
    {
        float targetVolume = audioSource.volume - amount;

        while (audioSource.volume > targetVolume)
        {
            audioSource.volume -= amount / duration * Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    private IEnumerator RestoreVolumeCoroutine(float amount, float duration)
    {
        float targetVolume = audioSource.volume + amount;

        while (audioSource.volume < targetVolume)
        {
            audioSource.volume += amount / duration * Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    public void LoadNextSound(float fadeDuration)
    {
        AudioClip nextSound = null;
        int nextIndexScene = SceneManager.GetActiveScene().buildIndex + 1;

        switch (nextIndexScene)
        {
            case (2):
                nextSound = SoundIntro;
                break;
            case (3):
                nextSound = SoundMain;
                break;
        }
        if (nextSound != null)
            ChangeMusicGradually(nextSound, fadeDuration);
    }

    public void ChangeMusicGradually(AudioClip newClip, float fadeDuration)
    {
        StartCoroutine(FadeOutAndIn(newClip, fadeDuration));
    }

    public void EndMiniGame()
    {
        ChangeMusicGradually(originalSceneClip, 2f);
    }
    private IEnumerator FadeOutAndIn(AudioClip newClip, float fadeDuration)
    {
        float originalVolumeCopy = audioSource.volume;
        float elapsedTime = 0f;

        // Fade out
        while (elapsedTime < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(originalVolumeCopy, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        audioSource.Stop();
        audioSource.volume = originalVolumeCopy;

        // Change clip
        originalSceneClip = audioSource.clip;
        audioSource.clip = newClip;
        audioSource.Play();

        // Fade in
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(0f, originalVolumeCopy, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        audioSource.volume = originalVolumeCopy;
    }

    private void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.volume = originalVolume;
        audioSource.Play();
    }
}


