using Unity.VisualScripting;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D actionCursor;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(actionCursor, Vector2.zero, CursorMode.Auto);
        
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

}

