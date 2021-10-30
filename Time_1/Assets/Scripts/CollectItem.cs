using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
[RequireComponent(typeof(Collider))]
public class CollectItem : MonoBehaviour
{
    public Inventory inventory;

    private void Start() {
        var col = GetComponent<Collider>();
        Assert.IsNotNull(col, "Collider not found");
        Assert.IsTrue(col.enabled, "Collider not enabled");
    }

    private void OnTriggerEnter(Collider other) {
        GameObject otherGO = other.gameObject;
        if (otherGO.CompareTag("Item")) {
            CollectableItem colItem = otherGO.GetComponent<CollectableItem>();
            Assert.IsNotNull(colItem);
            inventory.itemList.Add(colItem.item);
            colItem.Dispose();
        }
    }
}
