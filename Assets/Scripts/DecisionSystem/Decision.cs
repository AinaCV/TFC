using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : DecisionTreeNode
{
    public Action nodeTrue;
    public Action nodeFalse;

    public virtual Action GetBranch() //al contrario de abstract, virtual se implementa y tiene la opción se sobreescribir las clases que heredan de este metodo
    {
        return null;
    }
}