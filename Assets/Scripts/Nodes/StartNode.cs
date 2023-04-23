using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : DecisionTreeNode
{
    public override DecisionTreeNode MakeDecision()
    {
        // Presentar al jugador la decisi�n inicial
        Debug.Log("Te encuentras en una encrucijada, �quieres adentrarte en el bosque o en el pueblo?");

        // Devolver el nodo que llevar� a la siguiente decisi�n
        return new ChoosePathNode();
    }
}