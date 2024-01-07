using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class BoxesController : MonoBehaviour
{
    public Vector2[] targetPositions;
    public float tolerance = 0.2f;
    public CircleCollider2D resetBoxes;
    public int winConditions;
    public GameObject door;
    public int boxesInTarget = 0;
    private Coroutine checkBoxCoroutine;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            checkBoxCoroutine = StartCoroutine(CheckBoxPosition(other.transform));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            if (checkBoxCoroutine != null)
            {
                StopCoroutine(checkBoxCoroutine);
                checkBoxCoroutine = null;
            }
            else
            {
                if (boxesInTarget > 0)
                    boxesInTarget--;
            }
        }
        
    }

    IEnumerator CheckBoxPosition(Transform boxTransform)
    {
        bool boxInCorrectPosition = false;

        while (!boxInCorrectPosition)
        {
            yield return new WaitForFixedUpdate();

            Vector2 boxPosition = new Vector2(boxTransform.position.x, boxTransform.position.y);

            for (int i = 0; i < targetPositions.Length; i++)
            {
                float xDifference = Mathf.Abs(boxPosition.x - targetPositions[i].x);
                float yDifference = Mathf.Abs(boxPosition.y - targetPositions[i].y);

                if (xDifference <= tolerance && yDifference <= tolerance)
                {
                    boxesInTarget++;
                    boxInCorrectPosition = true;
                    break;
                }
            }
        }

        if (checkBoxCoroutine != null)
        {
            StopCoroutine(checkBoxCoroutine);
            checkBoxCoroutine = null;
        }

        if (AllBoxesPlaced())
        {
            if (boxesInTarget == 8)
            {
                SoundManager.Instance.EndMiniGame();
            }

            resetBoxes.enabled = false;

            SoundFXMananger.Instance.PlaySound(SoundType.OpenDoor);
            door.SetActive(false);
        }
            
    }

    private bool AllBoxesPlaced()
    {
        return boxesInTarget == winConditions;
    }
}
