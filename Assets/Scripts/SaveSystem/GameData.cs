using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public List<string> unlockedLevels;

    public GameData()
    {
        unlockedLevels = new List<string>();
    }
}
