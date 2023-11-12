using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public float distanciaRaycast = 1.0f;
    public Vector2[] right, left, up, down;
    private Rigidbody2D rb2d;
    private bool collisionPlayer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collisionPlayer = false;
    }
    private void Update()
    {
        if (collisionPlayer)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput > 0) 
            {
                CheckNeighbour(Vector2.right, right);
            } 
            else if (horizontalInput < 0)
            {
                CheckNeighbour(Vector2.left, left);
            }
            else if (verticalInput > 0)
            {
                CheckNeighbour(Vector2.up, up);
            }
            else if (verticalInput < 0)
            {
                CheckNeighbour(Vector2.down, down);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.collider.CompareTag("Player"))
        {
            collisionPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null && collision.collider.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            collisionPlayer = false;
        }
        
    }

    private void CheckNeighbour(Vector2 direccion, Vector2[] vectors)
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        bool isObstacle = IsObstacle(direccion, vectors);

        if (isObstacle)
        {
            if (direccion.x != 0)
            {
                rb2d.constraints |= RigidbodyConstraints2D.FreezePositionX;
            }  
            else if (direccion.y != 0)
            {
                rb2d.constraints |= RigidbodyConstraints2D.FreezePositionY;
            }
            collisionPlayer = false;
        }
    }

    private bool IsObstacle(Vector2 direccion, Vector2[] vectors)
    {
        foreach (Vector2 vector in vectors)
        {
            Vector2 origin = (Vector2)transform.position + vector;
            RaycastHit2D hit = Physics2D.Raycast(origin, direccion, distanciaRaycast);
            Debug.DrawRay(origin, direccion * distanciaRaycast, Color.red, 0.5f);

            if (hit.collider != null && hit.collider.CompareTag("Box"))
            {
                return true;
            }
        }

        return false;
    }
}
