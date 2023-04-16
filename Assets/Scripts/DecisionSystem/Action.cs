using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : DecisionTreeNode
{
    public bool activated = false;

    public override DecisionTreeNode MakeDecision() //override es necesario para ampliar o modificar la implementaci�n abstracta o virtual de un m�todo, propiedad, indexador o evento heredado.
    {
        return this;
    }
    public virtual void LateUpdate()
    {
        if (!activated)
            return;
        // Implememntar los comportamientos a continuaci�n :D
    }
}
