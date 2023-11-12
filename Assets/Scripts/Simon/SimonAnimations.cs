using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonAnimations : MonoBehaviour
{
    public GameObject[] teslaCoils;
    public AnimationClip[] animations;
    public void EnabledAnimations()
    {
        int numAnimations = animations.Length;
        int numTeslaCoils = 3;
        int index = 0;

        for (int i = 0; i < numAnimations; i++)
        {
            for (int j = index; j < numTeslaCoils; j++)
            {
                teslaCoils[j].GetComponent<Animator>().Play(animations[i].name);
            }
            numTeslaCoils += 3;
            index += 3;
        }
    }
}
