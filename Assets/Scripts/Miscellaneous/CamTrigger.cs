using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos, newPlayerPos;

    private CamController camControl;

    void Start()
    {
        camControl = Camera.main.GetComponent<CamController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camControl.minPos += newCamPos;
            camControl.maxPos += newCamPos;

            collision.transform.position += newPlayerPos;
        }
    }
}
