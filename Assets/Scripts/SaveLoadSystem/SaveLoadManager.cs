using System.IO;
using UnityEngine;

public static class SaveLoadManager
{
    public static void SaveGameData(GameData gameData)
    {
        string jsonData = JsonUtility.ToJson(gameData);
        string savePath = Application.persistentDataPath + "/gameData.json";
        File.WriteAllText(savePath, jsonData);
        Debug.Log("Game data saved!");
    }

    public static GameData LoadGameData()
    {
        string savePath = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);
            Debug.Log("Game data loaded!");
            return gameData;
        }
        else
        {
            Debug.LogWarning("No game data found.");
            return null;
        }
    }
}

