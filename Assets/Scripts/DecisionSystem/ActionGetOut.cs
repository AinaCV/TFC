using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGetOut : Action
{
    public override void Act()
    {
        Console.WriteLine("Has salido de la caba�a.");
    }
}

public class ActionExplorarCasa : Action
{
    public override void Act()
    {
        Console.WriteLine("Est�s explorando la caba�a.");
    }
}
}
