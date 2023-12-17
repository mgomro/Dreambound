using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class InteractButtonSimon : Interactable
{
    public int colorIndex;
    public SimonController simonController;
    public override void Interact()
    {
        switch (colorIndex)
        {
            case 0:
                SoundFXMananger.Instance.PlaySound(SoundType.SimonDo);
                break;
            case 1:
                SoundFXMananger.Instance.PlaySound(SoundType.SimonMi);
                break;
            case 2:
                SoundFXMananger.Instance.PlaySound(SoundType.SimonSol);
                break;
            case 3:
                SoundFXMananger.Instance.PlaySound(SoundType.SimonSi);
                break;
        }
        simonController.OnButtonClick(colorIndex);
    }
}
