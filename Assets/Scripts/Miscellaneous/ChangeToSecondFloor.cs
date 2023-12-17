using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeToSecondFloor : MonoBehaviour
{
    public TilemapRenderer[] LayerObjects;
    public Collider2D barrier, decorCollider;
    public SpriteRenderer cell;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "Player")
         {

            foreach (TilemapRenderer layer in LayerObjects)
            {
                layer.sortingLayerName = "Decoration";
            }

            if (cell != null)
                cell.sortingLayerName = "Decoration";
            decorCollider.enabled = true;
            barrier.enabled = false;
        }
    }
}
