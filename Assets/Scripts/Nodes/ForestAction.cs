using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAction : Action
{
    private bool hasMetNpc = false;
    private bool hasGivenItem = false;
    public DialogueManager dialogueManager;

    public override void LateUpdate()
    {
        if (!activated)
            return;

        if (!hasMetNpc)
        {
            // Encuentra al NPC
            NPC npc = FindObjectOfType<NPC>();
            if (npc != null)
            {
                hasMetNpc = true;
                npc.StartDialogue();
            }
        }
        else if (!hasGivenItem)
        {
            // Si el jugador tiene al menos un objeto en su inventario, 
            // muestra un mensaje para pedir uno y espera la respuesta del jugador.
            InventorySlot[] inventorySlots = FindObjectOfType<Inventory>().slots;
            bool hasItem = false;
            foreach (InventorySlot slot in inventorySlots)
            {
                if (slot.item != null)
                {
                    hasItem = true;
                    break;
                }
            }

            if (hasItem)
            {
                // Muestra el mensaje y espera la respuesta del jugador
                dialogueManager.ShowDialogue("NPC: Hola, ¿tendrías un objeto para prestarme? Tengo algo que ofrecerte a cambio.",
                                                       new List<string>() { "Sí", "No" },
                                                       new List<DialogueAction>() { GiveItemToNpc, IgnoreNpc });
            }
            else
            {
                // Si el jugador no tiene ningún objeto, informa al jugador y termina el diálogo.
                dialogueManager.ShowDialogue("NPC: Parece que no tienes nada que prestarme... Vuelve cuando tengas algo que ofrecer.",
                                                       new List<string>() { "Salir" },
                                                       new List<DialogueAction>() { EndDialogue });
                hasMetNpc = false;
            }
        }
        else
        {
            // Muestra la recompensa y termina el diálogo.
            dialogueManager.ShowDialogue("NPC: ¡Muchas gracias por tu ayuda! Aquí tienes tu recompensa.",
                                                   new List<string>() { "Aceptar" },
                                                   new List<DialogueAction>() { EndDialogue });
            // Otorga la recompensa al jugador
            //FindObjectOfType<Player>().AddExperiencePoints(100);
            hasMetNpc = false;
            hasGivenItem = false;
        }
    }

    private void GiveItemToNpc()
    {
        // Busca el primer objeto que encuentre en el inventario y se lo da al NPC
        InventorySlot[] inventorySlots = FindObjectOfType<Inventory>().slots;
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.item != null)
            {
                slot.item = null;
                hasGivenItem = true;
                break;
            }
        }
    }

    private void IgnoreNpc()
    {
        // Si el jugador ignora al NPC, termina el diálogo.
        dialogueManager.ShowDialogue("NPC: Vaya... Bueno, gracias de todas formas.",
                                               new List<string>() { "Salir" },
                                               new List<DialogueAction>() { EndDialogue });
        hasMetNpc = false;
    }

    private void EndDialogue()
    {
        // Termina el diálogo y desactiva esta acción
        activated = false;
        dialogueManager.HideDialogue();
    }
}