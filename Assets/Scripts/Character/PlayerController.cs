using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float speed;
    //[HideInInspector]
    public Vector2 lastMotionVector;
    private Rigidbody2D rb2D;
    private Animator playerAnimator;
    private bool moving;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
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
        }
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + lastMotionVector * speed * Time.deltaTime);
    }
}
