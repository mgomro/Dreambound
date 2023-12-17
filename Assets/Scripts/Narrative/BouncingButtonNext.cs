using UnityEngine;
using UnityEngine.UI;

public class BouncingButtonNext : MonoBehaviour
{
    public Button button;
    public float bounceWidth = 10f;
    public float bounceSpeed = 2f;

    private RectTransform buttonRectTransform;

    private void Awake()
    {
        buttonRectTransform = button.GetComponent<RectTransform>();
    }

    private void Update()
    {
        float newX = Mathf.Sin(Time.time * bounceSpeed) * bounceWidth;

        buttonRectTransform.anchoredPosition = new Vector2(newX, buttonRectTransform.anchoredPosition.y);
    }
}
