using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractFlask : InteractableInventory
{
    public LightersController lightersController;
    private Rigidbody2D rgbd2d;
    private void Start()
    {
        rgbd2d = InitPlayer.playerObject.GetComponent<Rigidbody2D>();
    }
    public override void Interact(Item item)
    {
        Vector2 origin = rgbd2d.position * 1;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.up);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Lighter"))
            {
                lightersController.CompareLightersId(item.id, hit.collider.gameObject);
            }
        }
    }
}
