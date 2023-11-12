using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeToFirstFloor : MonoBehaviour
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
                layer.sortingLayerName = "UpDecoration";
            }

            cell.sortingLayerName = "UpDecoration";

            decorCollider.enabled = false;
            barrier.enabled = true;
        }
    }

}
