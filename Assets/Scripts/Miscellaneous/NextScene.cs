using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public LoadingScene loadingScene;
    public void LoadingNextScene()
    {
        loadingScene.StartLoadingLevel();
    }
}

