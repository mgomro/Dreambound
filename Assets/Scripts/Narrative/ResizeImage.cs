using System.Collections;
using UnityEngine;

public class ResizeImage : MonoBehaviour
{
    public float animationTime = 1f;

    private bool increasing = false;

    public void StartResize()
    {
        if (gameObject.activeSelf && !increasing)
        {
            increasing = true;
            transform.localScale = Vector3.zero;
            StartCoroutine(IncreaseSize());
        }
    }

    IEnumerator IncreaseSize()
    {
        float elapsedTime = 0f;
        Vector3 initialScale = transform.localScale;
        Vector3 finalScale = new Vector3(1f, 1f, 1f);

        while (elapsedTime < animationTime)
        {
            transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / animationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = finalScale;
        increasing = false;
    }
}
