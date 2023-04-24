using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionHouse : Decision
{
    public override Action GetBranch()
    {
        // Muestra al jugador un mensaje con las opciones que tiene
        Debug.Log("Estás en tu cabaña. ¿Quieres salir de la casa o explorarla?");

        // Espera la respuesta del jugador
        bool inputReceived = false;
        bool exploreHouse = false;
        bool exitHouse = false;

        while (!inputReceived)
        {
            // Comprueba si el jugador ha presionado la tecla correspondiente para cada opción
            if (Input.GetKeyDown(KeyCode.E))
            {
                exploreHouse = true;
                inputReceived = true;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                exitHouse = true;
                inputReceived = true;
            }
        }

        // Devuelve la acción correspondiente según la elección del jugador
        if (exploreHouse)
        {
            return nodeTrue;
        }
        else if (exitHouse)
        {
            return nodeFalse;
        }
        else
        {
            // Si algo ha ido mal, devuelve null
            return null;
        }
    }
}