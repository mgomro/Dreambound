using UnityEngine;
using UnityEngine.UI;

public class BouncingButtonEnd : MonoBehaviour
{
    public Button button;
    public float bounceHeight = 10f;
    public float bounceSpeed = 2f;

    private RectTransform buttonRectTransform;

    private void Awake()
    {
        buttonRectTransform = button.GetComponent<RectTransform>();
    }

    private void Update()
    {
        float newY = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        buttonRectTransform.anchoredPosition = new Vector2(buttonRectTransform.anchoredPosition.x, newY);
    }
}

