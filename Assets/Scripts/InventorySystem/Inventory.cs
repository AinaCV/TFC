using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Item> items = new List<Item>();

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
}