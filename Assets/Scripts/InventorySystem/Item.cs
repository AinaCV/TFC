using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemCount;
    public Sprite itemIcon;

    // Constructor
    public Item(string itemName, int itemCount, Sprite itemIcon)
    {
        this.itemName = itemName;
        this.itemCount = itemCount;
        this.itemIcon = itemIcon;
    }

    public static Item GetItem(string itemName, List<Item> itemList)
    {
        // Busca el objeto Item correspondiente al nombre dado en la lista de objetos Item
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemName == itemName)
            {
                return itemList[i];
            }
        }
        // Si no se encontró el objeto Item, devuelve null
        return null;
    }
}
