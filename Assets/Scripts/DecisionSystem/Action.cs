using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : DecisionTreeNode
{
    public bool activated = false;

    public override DecisionTreeNode MakeDecision() //override es necesario para ampliar o modificar la implementación abstracta o virtual de un método, propiedad, indexador o evento heredado.
    {
        return this;
    }
    public virtual void LateUpdate()
    {
        if (!activated)
            return;
        // Implememntar los comportamientos a continuación :D
    }
}
