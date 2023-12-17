using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoxes : GameActivable
{
    public Rigidbody2D[] boxes;
    public AudioClip gameAudio;
    private bool isStarting = false;

    void Start()
    {
        foreach (Rigidbody2D box in boxes)
        {
            box.bodyType = RigidbodyType2D.Static;
        }
    }

    public override void Activate()
    {
        if (!isStarting)
        {
            SoundManager.Instance.ChangeMusicGradually(gameAudio, 3f);

            foreach (Rigidbody2D box in boxes)
            {
                box.bodyType = RigidbodyType2D.Dynamic;
            }

            isStarting = true;
        }        
    }
}
