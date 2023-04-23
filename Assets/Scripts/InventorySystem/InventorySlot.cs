using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public GameObject slotUI;

    public void UpdateSlotUI()
    {
        // actualizar la interfaz de usuario de la ranura de inventario
        if (slotUI != null)
        {
            // busca los componentes de imagen y texto que representan el icono y el nombre del objeto de inventario
            Image slotImage = slotUI.transform.Find("ItemImage").GetComponent<Image>();
            Text slotText = slotUI.transform.Find("ItemText").GetComponent<Text>();

            if (item != null)
            {
                slotImage.sprite = item.itemIcon;
                slotImage.enabled = true;
                slotText.text = item.itemName;
            }
            else
            {
                slotImage.sprite = null;
                slotImage.enabled = false;
                slotText.text = "";
            }
        }
    }
}