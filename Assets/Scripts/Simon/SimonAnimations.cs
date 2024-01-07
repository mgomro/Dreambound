using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class SimonAnimations : MonoBehaviour
{
    public GameObject[] teslaCoils;
    public AnimationClip[] animations;
    public GameObject door;
    public IEnumerator EnabledAnimations()
    {
        SoundManager.Instance.RestoreVolume(0.9f, 3f); // Restaurar el 90% del volumen
        int numAnimations = animations.Length;
        int numTeslaCoils = 3;
        int index = 0;

        for (int i = 0; i < numAnimations; i++)
        {
            SoundFXMananger.Instance.PlaySound(SoundType.ActivateTesla);
            for (int j = index; j < numTeslaCoils; j++)
            {
                teslaCoils[j].GetComponent<Animator>().Play(animations[i].name);
            }
            numTeslaCoils += 3;
            index += 3;
            yield return new WaitForSeconds(0.8f);
        }

        SoundFXMananger.Instance.PlaySound(SoundType.OpenDoor);
        door.SetActive(false);
    }
}
