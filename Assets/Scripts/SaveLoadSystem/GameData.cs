using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentScene;
    public float playerPosX;
    public float playerPosY;
    public List<string> inventoryItems = new List<string>();
    public List<string> decisions = new List<string>();
}