using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    private SpriteRenderer[] childLayers;
    private void Start()
    {
        if (transform.childCount > 0)
        {
            childLayers = new SpriteRenderer[transform.childCount];
            int i = 0;
            foreach (Transform child in transform)
            {
                childLayers[i] = child.GetComponent<SpriteRenderer>();
                ++i;
            }
        }
    }
    private void SetSortingLayer(string sortingLayerName)
    {
        if (childLayers != null)
        {
            foreach (SpriteRenderer layer in childLayers)
            {
                layer.sortingLayerName = sortingLayerName;
            }
        }
        GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetSortingLayer("UpDecoration");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetSortingLayer("Decoration");
        }
    }
}


