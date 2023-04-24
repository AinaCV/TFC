using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : DecisionTreeNode
{
    public string decisionPrompt;
    public string trueText;
    public string falseText;
    public DecisionTreeNode trueNode;
    public DecisionTreeNode falseNode;

    public override DecisionTreeNode MakeDecision()
    {
        Debug.Log(decisionPrompt);
        bool choice = UnityEngine.Random.value > 0.5f;
        Debug.Log(choice ? trueText : falseText);
        return choice ? trueNode : falseNode;
    }
    protected override DecisionTreeNode GetBranch()
    {
        bool choice = UnityEngine.Random.value > 0.5f;
        return choice ? trueNode : falseNode;
    }
}