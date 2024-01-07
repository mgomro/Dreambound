using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitPlayer : MonoBehaviour
{
    public static GameObject playerObject;
    public static string playerName;
    public static int index;
    void Awake()
    {
        index = PlayerPrefs.GetInt("PlayerIndex");
        playerName = GameManager.Instance.characters[index].Character.name;

        playerObject = Instantiate(GameManager.Instance.characters[index].Character, transform.position, Quaternion.identity);
        playerObject.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        playerObject.GetComponent<PlayerController>().speed = 5f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
