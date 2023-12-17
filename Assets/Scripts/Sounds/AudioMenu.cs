using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayMenuAudio();
    }
}
