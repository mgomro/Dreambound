using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class  Interactable : MonoBehaviour
{
    public virtual void Interact()
    {

    }
}

public class InteractableInventory : MonoBehaviour
{
    public virtual void Interact(Item item)
    {

    }
}

public class InteractController : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] float umbralInteraccion = 1.2f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GetDistanceInteract())
            {
                Interact();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            HandleInventoryInteraction();
        }
    }

    public bool GetDistanceInteract()
    {
        Vector3 posicionPersonaje = transform.position;

        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicionRaton.z = 0;

        float distancia = Vector3.Distance(posicionPersonaje, posicionRaton);

        return distancia < umbralInteraccion;
    }

    private void Interact()
    {
        Vector2 position = rgbd2d.position + playerController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact();
                break;
            }
        }
    }

    private void HandleInventoryInteraction()
    {
        InventoryManager inventoryManager = InventoryManager.Instance;
        int index = inventoryManager.GetSelectedSlot();
        GameObject item = inventoryManager.GetItem(index);

        if (item != null)
        {
            Item _item = item.GetComponent<InventoryItem>().item;
            switch (_item.type)
            {
                case ItemType.Flask:
                    item.GetComponent<InteractFlask>().Interact(_item);
                    break;
                case ItemType.Robot:
                    item.GetComponent<InteractCell>().Interact(_item);
                    break;
                case ItemType.Note:
                    item.GetComponent<InteractNote>().Interact(_item);
                    break;
            }
        }
    }

    public void InteractingOff()
    {
        InitPlayer.playerObject.GetComponent<PlayerController>().canMove = true;
    }

    public void InteractingOn()
    {
        InitPlayer.playerObject.GetComponent<PlayerController>().canMove = false;
    }
}
