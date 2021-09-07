using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter(Collider other) {
        GameObject otherGO = other.gameObject;
        if (otherGO.CompareTag("Item")) {
            CollectableItem colItem = otherGO.GetComponent<CollectableItem>();
            Assert.IsNotNull(colItem);

            inventory.itensList.Add(colItem.item);
            colItem.Dispose();
        }
    }
}
