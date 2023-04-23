using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestNode : DecisionTreeNode
{
    public override DecisionTreeNode MakeDecision()
    {
        // Presentar la situación peligrosa en el bosque y posibles decisiones
        Debug.Log("Te has encontrado con una manada de lobos agresivos. ¿Quieres pelear o huir?");

        // Devolver el nodo que llevará a la siguiente decisión
        return null;/*new FightOrFlightNode();*/
    }
}
