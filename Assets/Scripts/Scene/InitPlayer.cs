using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int index = PlayerPrefs.GetInt("PlayerIndex");
        Instantiate(GameManager.instance.characters[index].Character, transform.position, Quaternion.identity);
    }
}
