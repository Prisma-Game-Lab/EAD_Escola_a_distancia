using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Create a new item")]
public class ItemBase : ScriptableObject
{
    public new string name;
    public Sprite sprite;
}
