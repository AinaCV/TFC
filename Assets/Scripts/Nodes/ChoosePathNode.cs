using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePathNode : DecisionTreeNode
{
    public override DecisionTreeNode MakeDecision()
    {
        // Esperar la entrada del usuario para elegir el camino
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Has elegido adentrarte en el bosque.");
            return new ForestNode();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Has elegido adentrarte en el pueblo.");
            return null;/*new TownNode();*/
        }

        // Si no se ha elegido ningún camino, seguir en el mismo nodo
        return this;
    }
}