using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    public override void Interact()
    {
        gameObject.SetActive(false);
    }
}
