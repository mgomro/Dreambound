using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class InteractLightOut : Interactable
{
    public LightsOutGame lightsOutGame;
    public override void Interact()
    {
        int index = System.Array.IndexOf(lightsOutGame.lights, gameObject);

        if (index != -1)
        {
            lightsOutGame.ToggleLight(index);
        }
    }
}
