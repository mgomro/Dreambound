using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBoards : Interactable
{
   public BoardsController boardsController;

    public override void Interact()
    {
        boardsController.StartGame();
        InitPlayer.playerObject.GetComponent<InteractController>().InteractingOn();
    }
}
