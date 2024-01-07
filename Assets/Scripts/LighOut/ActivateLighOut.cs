using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class ActivateLighOut : GameActivable
{
    public AudioClip gameAudio;
    public LightOutController game;
    public float delay;
    public override void Activate()
    {
        if (!game.IsStarting())
            StartCoroutine(StartLighOut());
    }

    IEnumerator StartLighOut()
    {
        SoundManager.Instance.ChangeMusicGradually(gameAudio, 1f);
        yield return new WaitForSeconds(delay);
        SoundFXMananger.Instance.PlaySound(SoundType.ActivateLightOut);
        game.StartGame();
    }

}
