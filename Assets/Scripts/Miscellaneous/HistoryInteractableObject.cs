using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryInteractableObject : Interactable
{
    public GameObject door;
    public override void Interact()
    {
        Debug.Log("Hello");
        StartCoroutine(DisableDoor(10f));
    }

    IEnumerator DisableDoor(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        door.SetActive(false);
    }
}
