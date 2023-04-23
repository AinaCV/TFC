using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Inventory inventory;
    public Item requiredItem;
    public Item rewardItem;
    public DialogueManager dialogueManager;

    private bool hasRequestedItem = false;
    private bool hasGivenReward = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hasGivenReward)
            {
                dialogueManager.StartDialogue("�Gracias por tu ayuda anterior! No necesito nada m�s por ahora.");
            }
            else if (hasRequestedItem)
            {
                if (inventory.Contains(requiredItem))
                {
                    inventory.RemoveItem(requiredItem);
                    inventory.AddItem(rewardItem);
                    dialogueManager.StartDialogue("�Gracias! Aqu� tienes tu recompensa.");
                    hasGivenReward = true;
                }
                else
                {
                    dialogueManager.StartDialogue("�Tienes algo que pueda interesarme? Necesito un " + requiredItem.itemName + ".");
                }
            }
            else
            {
                dialogueManager.StartDialogue("�Hola! �C�mo est�s?");
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    // Repetir la l�gica del OnTriggerEnter() para que el di�logo se actualice mientras el jugador est� cerca del NPC
    //}

    private void OnTriggerExit(Collider other)
    {
        dialogueManager.EndDialogue();
    }
}
