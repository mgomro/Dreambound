using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoards : GameActivable
{
    public BoxCollider2D initBoardGame;
    public AudioClip gamesound;

    private bool isStarting = false;
    public override void Activate()
    {
        if (!isStarting)
        {
            SoundManager.Instance.ChangeMusicGradually(gamesound, 2f);
            initBoardGame.enabled = true;
            isStarting = true;
        }
        
    }
}
