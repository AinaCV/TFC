using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DecisionData
{
    public string decisionName;
    public int decisionValue;
}

[System.Serializable]
public class DecisionManagerData
{
    public List<DecisionData> decisions = new List<DecisionData>();
}

public class DecisionManager
{
    public static DecisionManagerData decisionData = new DecisionManagerData();

    public static void AddDecision(string decisionName, int decisionValue)
    {
        foreach (DecisionData decision in decisionData.decisions)
        {
            if (decision.decisionName == decisionName)
            {
                decision.decisionValue = decisionValue;
                return;
            }
        }

        DecisionData newDecision = new DecisionData();
        newDecision.decisionName = decisionName;
        newDecision.decisionValue = decisionValue;
        decisionData.decisions.Add(newDecision);
    }

    public static int GetDecisionValue(string decisionName)
    {
        foreach (DecisionData decision in decisionData.decisions)
        {
            if (decision.decisionName == decisionName)
            {
                return decision.decisionValue;
            }
        }

        return 0;
    }
}
