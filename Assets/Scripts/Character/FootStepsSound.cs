using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsSound : MonoBehaviour
{
    public AudioSource soundPlayer;
    public AudioClip WoodenFootstep;
    public AudioClip LabFootstep;
    public AudioClip MetalLadderFootstep;
    public AudioClip PlayerDragBox;


    private void Start()
    {
        soundPlayer.volume = SoundFXMananger.Instance.volumeFX;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WoodenFloor"))
        {
            soundPlayer.clip = WoodenFootstep;
        }
        else if (other.CompareTag("LabFloor"))
        {
            soundPlayer.clip = LabFootstep;
        }
        else if (other.CompareTag("MetalLadder"))
        {
            soundPlayer.clip = MetalLadderFootstep;
        }

        if (!soundPlayer.isPlaying)
            soundPlayer.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            soundPlayer.clip = PlayerDragBox;

            if (!soundPlayer.isPlaying)
                soundPlayer.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            soundPlayer.clip = LabFootstep;

            if (!soundPlayer.isPlaying)
                soundPlayer.Play();
        }                
    }
}
