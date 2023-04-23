using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    public enum DecisionType
    {
        Explore,
        Interact,
        Talk
    }

    public DecisionType currentDecision;

    public void MakeDecision()
    {
        switch (currentDecision)
        {
            case DecisionType.Explore:
                Debug.Log("You decide to explore the area!");
                // Execute code for exploring the area
                break;
            case DecisionType.Interact:
                Debug.Log("You decide to interact with the environment.");
                // Execute code for interacting with the environment
                break;
            case DecisionType.Talk:
                Debug.Log("You decide to talk to an NPC.");
                // Execute code for talking to an NPC
                break;
            default:
                Debug.LogError("Invalid decision type!");
                break;
        }
    }
}
