using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
[CreateAssetMenu(fileName = "Inventory", menuName = "Item/Create a new Item Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList;

    [System.NonSerialized]
    public bool changed = true;

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

    public void RemoveItem(Item item)
    {
        var index = itemList.IndexOf(item);

        // item not present
        if(index == -1) return;

        itemList[index] = null;
        changed = true;
    }


    public void AddItem(Item item)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if(itemList[i]==null)
            {
                itemList[i] = item;
                changed = true;
                return;
            }
        }
    }

    public bool AddItemAt(Item item, int index)
    {
        // slot full
        if(itemList[index]!=null) return false;

        itemList[index]=item;

        changed = true;
        return true;
    }

    public Item PeekItemAt(int index)
    {
        return itemList[index];
    }

    public Item PopItemAt(int index)
    {
        var ret = itemList[index];
        itemList[index] = null;

        changed = true;
        return ret;
    }

    public int GetFreeSlots()
    {
        int slots = 0;
        for (int i = 0; i < itemList.Count; i++)
        {
            if(itemList[i] == null)
            {
                slots += 1;
            }
        }
        return slots;
    }
    public int GetTotalSlots()
    {
        return itemList.Count;
    }
    public int GetTotalItems()
    {
        return GetTotalSlots() - GetFreeSlots();
    }

}
