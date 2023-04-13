using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> items = new Dictionary<string, int>();
    public Dictionary<Flag, int> flags = new Dictionary<Flag, int>();

    public void AddItem(InventoryItem item, int quantity = 1)
    {
        InventoryItem inventoryItem = new InventoryItem(item.itemName);
        inventoryItem.quantity = item.quantity;

        if (items.ContainsKey(inventoryItem.itemName))
        {
            items[inventoryItem.itemName] += inventoryItem.quantity;
        }
        else
        {
            items.Add(inventoryItem.itemName, inventoryItem.quantity);
        }
    }


    public void AddFlag(Flag flag)
    {
        if (flags.ContainsKey(flag))
        {
            flags[flag] += 1;
        }
        else
        {
            flags.Add(flag, 1);
        }
    }

    public bool HasItem(string itemName)
    {
        return items.ContainsKey(itemName) && items[itemName] > 0;
    }

    public bool HasFlag(Flag flag)
    {
        return flags.ContainsKey(flag) && flags[flag] > 0;
    }

    public void RemoveItem(string itemName, int quantity = 1)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] -= quantity;
            if (items[itemName] <= 0)
            {
                items.Remove(itemName);
            }
        }
    }

    public void RemoveFlag(Flag flag)
    {
        if (flags.ContainsKey(flag))
        {
            flags[flag] -= 1;
            if (flags[flag] <= 0)
            {
                flags.Remove(flag);
            }
        }
    }
}


[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;

    public InventoryItem(string itemName)
    {
        this.itemName = itemName;
    }
}

