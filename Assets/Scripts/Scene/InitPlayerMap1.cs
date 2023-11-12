using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerMap1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int index = PlayerPrefs.GetInt("PlayerIndex");
        GameObject playerObject = Instantiate(GameManager.instance.characters[index].Character, transform.position, Quaternion.identity);

        playerObject.transform.localScale = new Vector3(1.5f, 1.5f, 1f);

        playerObject.GetComponent<PlayerController>().speed = 5f;
    }
}
