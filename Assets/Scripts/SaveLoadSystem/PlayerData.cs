using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class PlayerData
    {
        public List<string> inventory = new List<string>();
        public Vector3 position;
        public string characterName;
        public List<DecisionData> decisions = new List<DecisionData>();
    }
}