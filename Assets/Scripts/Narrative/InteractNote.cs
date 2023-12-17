using UnityEngine;

public class InteractNote : InteractableInventory
{
    public NotesManager noteGUI;
    public override void Interact(Item item)
    {
        if (!noteGUI.IsActive())
            noteGUI.ShowNote(item.id);
    }
}
