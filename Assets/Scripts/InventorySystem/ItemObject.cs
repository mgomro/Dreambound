using UnityEngine;
using static SoundFXMananger;

public class ItemObject : Interactable
{
    public Item itemData;

    public override void Interact()
    {
        OnHandlePickUp();
    }

    public void OnHandlePickUp()
    {
        InitSoundFX();
        InventoryManager.Instance.AddItem(itemData);
        GameManager.Instance.SetDefaultCursor();
        Destroy(gameObject);
    }

    private void InitSoundFX()
    {
        SoundType soundType = SoundType.GetObject; // Default

        switch(itemData.type)
        {
            case ItemType.Note:
                soundType = SoundType.ActiveNote;
                break;
            case ItemType.Flask:
                soundType = SoundType.GetFlask;
                break;
            case ItemType.Robot:
                soundType = SoundType.GetObject;
                break;

        }
        SoundFXMananger.Instance.PlaySound(soundType);
    }

}
