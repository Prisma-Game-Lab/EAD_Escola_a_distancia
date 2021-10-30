using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Create a new item")]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string description;
    public Sprite sprite;
}
