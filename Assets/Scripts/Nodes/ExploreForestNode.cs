using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreForestNode : DecisionTreeNode
{
    public override DecisionTreeNode MakeDecision()
    {
        // Esperar la entrada del usuario para elegir la siguiente acci�n
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Has decidido explorar m�s a fondo el bosque.");
            // Devolver el nodo correspondiente a la situaci�n que se presenta
            return new ForestNode();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Has decidido volver al camino principal.");
            // Devolver el nodo correspondiente a la situaci�n que se presenta
            return new ForestNode();
        }

        // Si no se ha elegido ninguna acci�n, seguir en el mismo nodo
        return this;
    }
}