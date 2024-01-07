using System.Text;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    private readonly string saveFilePath = Application.persistentDataPath + "/savefile.json";
    private readonly string encryptionKey = "Dr34m#B0undUOC23+"; // Asegúrate de elegir una clave segura

    private string EncryptDecrypt(string text)
    {
        var encrypted = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char character = (char)(text[i] ^ encryptionKey[i % encryptionKey.Length]);
            encrypted.Append(character);
        }

        return encrypted.ToString();
    }

    public void SaveGameData(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        string encryptedJson = EncryptDecrypt(json);
        File.WriteAllText(saveFilePath, encryptedJson);
    }

    public GameData LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            string encryptedJson = File.ReadAllText(saveFilePath);
            string json = EncryptDecrypt(encryptedJson);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            // Si no existe el archivo, crea uno nuevo con datos por defecto
            GameData newData = new GameData();
            newData.unlockedLevels.Add("Nivel 1");
            SaveGameData(newData);
            return newData;
        }
    }
}



