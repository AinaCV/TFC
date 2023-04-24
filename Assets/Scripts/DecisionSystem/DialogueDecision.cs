using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDecision : Decision
{
    private string _dialogueText;

    public DialogueDecision(string dialogueText, Action nodeTrue, Action nodeFalse)
    {
        _dialogueText = dialogueText;
        this.nodeTrue = nodeTrue;
        this.nodeFalse = nodeFalse;
    }

    public override Action GetBranch()
    {
        // mostrar un cuadro de diálogo con el texto correspondiente y esperar a que el jugador elija una opción
        bool playerChoice = ShowDialogue(_dialogueText);

        if (playerChoice)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }

    private bool ShowDialogue(string dialogueText)
    {
        // mostrar un cuadro de diálogo con el texto y las opciones para que el jugador elija
        // y devolver true o false dependiendo de la opción elegida
        return false;
    }
}

