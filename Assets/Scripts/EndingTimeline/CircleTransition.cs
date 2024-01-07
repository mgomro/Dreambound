using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ActiveCircle()
    {
        gameObject.SetActive(true);
    }

}
