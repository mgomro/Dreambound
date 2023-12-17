using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitPlayer : MonoBehaviour
{
    public static GameObject playerObject;
    public static string playerName;
    void Awake()
    {
        int index = PlayerPrefs.GetInt("PlayerIndex");
        playerObject = Instantiate(GameManager.instance.characters[index].Character, transform.position, Quaternion.identity);

        playerName = GameManager.instance.characters[index].Character.name;

        int numScene = SceneManager.GetActiveScene().buildIndex;
        if (numScene == 3)
        {
            playerObject.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            playerObject.GetComponent<PlayerController>().speed = 5f;
        }
        SoundManager.Instance.PlayMainAudio(); // Eliminar antes de compilar el juego.
    }
}
