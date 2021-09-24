using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "Item/Create a new Item Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itensList = new List<Item>();

}
