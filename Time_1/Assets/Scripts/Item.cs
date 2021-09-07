using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Create a new item")]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string description;
    public Sprite sprite;
}
