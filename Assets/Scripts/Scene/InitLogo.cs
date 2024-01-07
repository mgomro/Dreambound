using UnityEngine;

public class ShowLogoAfterTime : MonoBehaviour
{
    public float delay = 30.0f;

    void Start()
    {
        gameObject.SetActive(false);
        Invoke("ShowLogo", delay);
    }

    void ShowLogo()
    {
        gameObject.SetActive(true);
    }
}

