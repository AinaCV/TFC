using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTree : DecisionTreeNode
{
    public DecisionTreeNode root;
    private Action newAction;
    private Action oldAction;

    public override DecisionTreeNode MakeDecision() //overrride la función MakeDecision
    {
        return root.MakeDecision();
    }

    void Update()
    {
        newAction.activated = false;
        oldAction = newAction;
        newAction = root.MakeDecision() as Action;
        if (newAction == null)
            newAction = oldAction;
        newAction.activated = true;
    }
}