using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGetOut : Action
{
    public override void Act()
    {
        Console.WriteLine("Has salido de la cabaña.");
    }
}

public class ActionExplorarCasa : Action
{
    public override void Act()
    {
        Console.WriteLine("Estás explorando la cabaña.");
    }
}
}
