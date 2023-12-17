using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SoundFXMananger;

public class LightersController : MonoBehaviour
{
    public GameObject[] defaultLighters;
    public GameObject[] lightersWithFlask;
    public GameObject door;

    private int allflaskset = 0;
    private void Start()
    {
        foreach (GameObject lighter in lightersWithFlask)
        {
            lighter.SetActive(false);
        }
    }

    public void CompareLightersId(int lighterId, GameObject lighter)
    {
        if (lighterId == GetLighterId(lighter))
        {
            ChangeLighter(lighter);
        }
    }

    private int GetLighterId(GameObject lighter)
    {
        ItemId lighterId = lighter.GetComponent<ItemId>();

        if (lighterId != null)
            return lighterId.id;
        else
            return -1;
    }

    private void ChangeLighter(GameObject lighter)
    {
        int index = 0;

        foreach (GameObject _lighter in defaultLighters)
        {
            if (lighter == _lighter)
            {
                defaultLighters[index].SetActive(false);
                DestroyItemInventory();
                SoundFXMananger.Instance.PlaySound(SoundType.FlaskInLighter);
                lightersWithFlask[index].SetActive(true);
                allflaskset++;
                break;
            }
            index++;
        }
        AllFlasksSet();
    }

    private void DestroyItemInventory()
    {
        int index = InventoryManager.Instance.GetSelectedSlot();
        Destroy(InventoryManager.Instance.GetItem(index));
    }

    private void AllFlasksSet()
    {
        if (allflaskset == 4)
            Invoke(nameof(DisableDoor), 1f);
    }

    private void DisableDoor()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.OpenDoor);
        door.SetActive(false);
    }
}
