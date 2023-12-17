using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float speed;
    [HideInInspector]
    public Vector2 lastMotionVector;
    public bool canMove = true;
    private FootStepsSound footStepsSound;
    private AudioSource fsAudioSource;
    private Rigidbody2D rb2D;
    private Animator playerAnimator;
    private bool moving;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        footStepsSound = gameObject.GetComponent<FootStepsSound>();
        fsAudioSource = footStepsSound.soundPlayer;
    }

    private void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            lastMotionVector = new Vector2(horizontal, vertical).normalized;

            moving = horizontal != 0 || vertical != 0;
            playerAnimator.SetBool("moving", moving);

            playerAnimator.SetFloat("Horizontal", horizontal);
            playerAnimator.SetFloat("Vertical", vertical);

            if (horizontal != 0 || vertical != 0)
            {
                playerAnimator.SetFloat("LastHorizontal", horizontal);
                playerAnimator.SetFloat("LastVertical", vertical);

                if (!fsAudioSource.isPlaying)
                {
                    fsAudioSource.Play();
                }
            }
            else
            {
                fsAudioSource.Stop();
            }
        }
        else
        {
            playerAnimator.SetBool("moving", false);
            fsAudioSource.Stop();
        }

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb2D.MovePosition(rb2D.position + lastMotionVector * speed * Time.deltaTime);
        }
    }
}
