using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionBox : Interactable
{
    public GameObject[] boxes;

    private List<Vector3> initialBoxPositions = new List<Vector3>();

    void Start()
    {
        StoreInitialBoxPositions();
    }

    public override void Interact()
    {
        InitBoxesPosition();
    }

    private void StoreInitialBoxPositions()
    {
        foreach (GameObject box in boxes)
        {
            initialBoxPositions.Add(box.transform.position);
        }
    }

    private void InitBoxesPosition()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i].transform.position = initialBoxPositions[i];
        }
    }
}
