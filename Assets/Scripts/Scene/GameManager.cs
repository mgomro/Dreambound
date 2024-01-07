using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Characters> characters;
    
    private void Awake()
    {
         if (GameManager.Instance == null) 
         {
             GameManager.Instance = this;
             DontDestroyOnLoad(this.gameObject);
         }
         else
         {
             Destroy(gameObject);
         }

         SetDefaultCursor();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
