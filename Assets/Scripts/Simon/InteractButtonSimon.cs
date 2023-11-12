using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonSimon : Interactable
{
    public int colorIndex;
    public SimonController simonController;
    public bool enabledButton = false;
    public override void Interact()
    {
        if (colorIndex == -1)
        {
            simonController.StartGame();
        }
        
        if (enabledButton)
        {
            simonController.OnButtonClick(colorIndex);
        }
    }
}
