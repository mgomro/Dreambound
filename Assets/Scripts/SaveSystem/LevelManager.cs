using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public TMPro.TMP_Dropdown levelDropdown;
    private GameData gameData;
    private SaveSystem saveSystem;
    private Dictionary<string, int> levelNameToSceneIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            saveSystem = new SaveSystem();
            gameData = saveSystem.LoadGameData();
            UpdateLevelDropdown();
        }
        else
        {
            Destroy(gameObject);
        }

            levelNameToSceneIndex = new Dictionary<string, int>
        {
            { "Nivel 1", 3 },
            { "Nivel 2", 1 }, // Créditos
            // Agrega más niveles en futuras actualizaciones
        };
    }

    private void Start()
    {
        saveSystem = new SaveSystem();
        gameData = saveSystem.LoadGameData();

        UpdateLevelDropdown();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public int GetSelectedLevel()
    {
        string selectedLevelName = levelDropdown.options[levelDropdown.value].text;
        levelNameToSceneIndex.TryGetValue(selectedLevelName, out int sceneIndex);
        return sceneIndex;
    }

    public void UpdateLevelDropdown()
    {
        levelDropdown.ClearOptions();
        levelDropdown.AddOptions(gameData.unlockedLevels);
    }

    public void UnlockNextLevel(string completedLevel)
    {
        string nextLevel = "Nivel " + (int.Parse(completedLevel.Substring(6)) + 1).ToString();
        if (!gameData.unlockedLevels.Contains(nextLevel))
        {
            gameData.unlockedLevels.Add(nextLevel);
            saveSystem.SaveGameData(gameData);
            UpdateLevelDropdown();
        }
    }
}

