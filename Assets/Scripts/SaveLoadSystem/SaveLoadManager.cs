using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveLoadManager
    {
        public static PlayerData currentSaveData = new PlayerData();
        public const string SaveDirectory = "/SaveData";
        public const string fileName = "/SaveGame.txt";

        public static bool Save()
        {
            string dir = Application.persistentDataPath + SaveDirectory;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            string json = JsonUtility.ToJson(currentSaveData, true);

            File.WriteAllText(dir + fileName, json);

            GUIUtility.systemCopyBuffer = dir;
            return true;
        }

        public static bool Load()
        {
            string fullPath = Application.persistentDataPath + SaveDirectory + fileName;
            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                currentSaveData = JsonUtility.FromJson<PlayerData>(json);
                return true;
            }
            else
            {
                Debug.LogError("Save file not found.");
                return false;
            }
        }
    }
}