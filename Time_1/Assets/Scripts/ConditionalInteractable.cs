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

    public UnityEvent defaultBehaviour;

    protected override void Interact()
    {
        var hasRequirements = true;
        foreach (var item in requiredItems)
        {
            hasRequirements = hasRequirements && inventory.itensList.Contains(item);
        }
        if(hasRequirements)
        {
            onInteract.Invoke();
        }
        else
        {
            defaultBehaviour.Invoke();
        }
    }
}
