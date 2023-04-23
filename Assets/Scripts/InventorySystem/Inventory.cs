using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Item> items = new List<Item>();
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public bool HasItem(Item item)
    {
        return items.Contains(item);
    }

    public int GetItemCount(Item item)
    {
        int count = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                count++;
            }
        }
        return count;
    }

    public void Clear()
    {
        items.Clear();
    }

    public List<string> GetInventoryData()
    {
        List<string> itemNames = new List<string>();
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.item != null)
            {
                itemNames.Add(slot.item.itemName);
            }
            else
            {
                itemNames.Add("");
            }
        }
        return itemNames;
    }

    public void SetInventoryData(List<string> itemNames, List<Item> itemList)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (itemNames[i] != "")
            {
                InventorySlot slot = inventorySlots[i];
                slot.item = Item.GetItem(itemNames[i], itemList);
                slot.UpdateSlotUI();
            }
        }
    }

    public void ResetInventory()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            slot.item = null;
            slot.UpdateSlotUI();
        }
    }
}