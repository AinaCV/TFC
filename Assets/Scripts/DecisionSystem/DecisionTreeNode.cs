using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTreeNode : MonoBehaviour
{
    public virtual DecisionTreeNode MakeDecision() //al contrario de abstract, virtual tiene la opción se sobreescribir las clases que heredan de este metodo
    {
        return null;
    }

}