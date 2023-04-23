using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData
{
    public string dialogID; // identificador �nico del di�logo
    public string characterName; // nombre del personaje que habla
    public string dialogText; // texto del di�logo
    public bool isPlayer; // indica si el di�logo es del jugador o del personaje no jugador (NPC)

    // constructor por defecto
    public DialogData() { }

    // constructor con par�metros
    public DialogData(string id, string name, string text, bool player)
    {
        dialogID = id;
        characterName = name;
        dialogText = text;
        isPlayer = player;
    }
}
