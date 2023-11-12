using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCursorButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D actionCursor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(actionCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
