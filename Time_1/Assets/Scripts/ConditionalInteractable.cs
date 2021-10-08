using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;


[RequireComponent(typeof(Collider))]
public class CondicionalInteractable : Interactable
{
    public Inventory inventory;
    public List<Item> requiredItems;

    protected override bool CanInteract()
    {
        foreach (var item in requiredItems)
        {
            if(! inventory.itensList.Contains(item))
            {
                return false;
            }
        }
        return base.CanInteract();
    }
}
