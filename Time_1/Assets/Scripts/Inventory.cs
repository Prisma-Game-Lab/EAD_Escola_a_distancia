using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
[CreateAssetMenu(fileName = "Inventory", menuName = "Item/Create a new Item Inventory")]
public class Inventory : ScriptableObject
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public List<Item> itensList = new List<Item>();

    public void RemoveItem(Item i)
    {
        Assert.IsTrue(itensList.Contains(i));
        itensList.Remove(i);
    }

    public void AddItem(Item i)
    {
        itensList.Add(i);
    }

}
