using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Characters> characters;
    
    private void Awake()
    {
         if (GameManager.instance == null) 
         {
             GameManager.instance = this;
             DontDestroyOnLoad(this.gameObject);
         }
         else
         {
             Destroy(gameObject);
         }

         SetDefaultCursor();
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
