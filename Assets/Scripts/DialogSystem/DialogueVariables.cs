using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables
{
    private Dictionary<string, Ink.Runtime.Object> var;
    public void StartListening(Story story)
    {
        story.variablesState.variableChangedEvent += VarChanged;
    }
    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VarChanged;
    }
    private void VarChanged(string name, Ink.Runtime.Object value)
    {
        Debug.Log("Variable changed:" + name + "=" + value);
    }

}