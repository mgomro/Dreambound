using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class ActivateDoor : GameActivable
{
    public GameObject door;
    public float delay;
    public override void Activate()
    {
        if (door.activeSelf)
            StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(delay);
        SoundFXMananger.Instance.PlaySound(SoundType.OpenDoor);
        door.SetActive(false);
    }
}
