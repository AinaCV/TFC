using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DecisionData //los datos de una decision

{
    public string decisionName;
    public int decisionValue; // para determinar qué opciones están disponibles para el jugador más adelante en el juego,
                              // qué diálogos pueden ser desbloqueados o cómo se desarrolla la historia en general
}

[System.Serializable]
public class DecisionManagerData //datos del manager de decisiones

{
    public List<DecisionData> decisions = new List<DecisionData>();
}

public class DecisionManager
{
    public static DecisionManagerData decisionData = new DecisionManagerData();

    public static void AddDecision(string decisionName, int decisionValue) // Agrega una decision a la lista de decisiones. Si la decision ya existe, actualiza su valor.
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

    public static int GetDecisionValue(string decisionName)// Obtiene el valor asociado a una decision en particular
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

    public List<DecisionData> GetDecisionData()// Devuelve la lista de DecisionData
    {
        return decisionData.decisions;
    }
    public static void SetDecisionData(List<DecisionData> decisionDataList) // Establece la lista de DecisionData
    {
        decisionData.decisions = decisionDataList;
    }

    public void ResetDecisions()
    {
        decisionData.decisions.Clear();
    }
}