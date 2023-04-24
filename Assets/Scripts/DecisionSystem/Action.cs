using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : DecisionTreeNode
{
    public bool activated = false;
    private List<Action> _actions;
    private string _ID; // cambiar el nombre de la variable a _ID para seguir la convención de nombres

    public override DecisionTreeNode MakeDecision()
    {
        return this;
    }

    public virtual void LateUpdate()
    {
        if (!activated)
            return;
        // Implementar los comportamientos aquí :D
    }

    public Action(List<Action> actions, string ID) // agregar el parámetro ID en el constructor
    {
        _actions = actions;
        _ID = ID; // asignar el valor del parámetro ID a la variable de clase correspondiente
    }

    public Action GetAction(string actionID)
    {
        foreach (Action action in _actions)
        {
            if (action._ID == actionID) // acceder a la variable _ID de la acción actual en la iteración
            {
                return action;
            }
        }
        return null;
    }
}
