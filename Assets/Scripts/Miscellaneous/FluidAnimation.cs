using UnityEngine;

public class FluidAnimation : MonoBehaviour
{
    public float velocidad = 0.5f;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float offset = Time.time * velocidad;
        material.mainTextureOffset = new Vector2(offset, 0);
    }
}
