using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class DisableLabyrinth : MonoBehaviour
{
    public LabyrinthController labyrinthController;
    public GameObject labyrinth;
    public GameObject door;

    private bool firstTime = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && firstTime)
        {
            SoundManager.Instance.EndMiniGame();
            labyrinthController.DisableLabyrinth();
            labyrinthController.enabled = false;
            labyrinth.SetActive(false);
            firstTime = false;
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(1f);
        SoundFXMananger.Instance.PlaySound(SoundType.OpenDoor);
        door.SetActive(false);
    }


}
