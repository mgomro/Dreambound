using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [Range(1f, 20f)]
    public float ScrollSpeed = 1;
    public float ScrollOfSet;

    Vector2 StartPos;

    float NewPos;

    private void Start()
    {
        StartPos = transform.position;
    }

    private void Update()
    {
        NewPos = Mathf.Repeat(Time.time * ScrollSpeed, ScrollOfSet);
        transform.position = StartPos + Vector2.right * NewPos;
    }
}

