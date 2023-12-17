using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static SoundFXMananger;

public class InteractLightOut : Interactable
{
    public LightOutController lightsOutGame;
    public override void Interact()
    {
        int index = System.Array.IndexOf(lightsOutGame.lights, gameObject);

        if (index != -1)
        {
            SoundFXMananger.Instance.PlaySound(SoundType.ButtonLightOut);
            lightsOutGame.ToggleLight(index);
        }
    }
}
