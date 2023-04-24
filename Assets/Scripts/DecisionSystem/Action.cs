using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : DecisionTreeNode
{
    public bool activated = false;
    private List<Action> _actions;
    private string _ID; // cambiar el nombre de la variable a _ID para seguir la convenci�n de nombres

    public override DecisionTreeNode MakeDecision()
    {
        return this;
    }

    public virtual void LateUpdate()
    {
        if (!activated)
            return;
        // Implementar los comportamientos aqu� :D
    }

    public Action(List<Action> actions, string ID) // agregar el par�metro ID en el constructor
    {
        _actions = actions;
        _ID = ID; // asignar el valor del par�metro ID a la variable de clase correspondiente
    }

    public Action GetAction(string actionID)
    {
        foreach (Action action in _actions)
        {
            if (action._ID == actionID) // acceder a la variable _ID de la acci�n actual en la iteraci�n
            {
                return action;
            }
        }
        return null;
    }
}
