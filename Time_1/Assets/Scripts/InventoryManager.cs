using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public Inventory origem;
    public Inventory destino;

    public GameObject globalInventory;

    public void Swap()
    {
        globalInventory.SetActive(!globalInventory.activeSelf);
    }

    public void SetOrigem(Inventory inv)
    {
        origem = inv;
    }

    public void SetDestino(Inventory inv)
    {
        destino = inv;
    }

    public void MoveItem(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);


        List<Item> itemList= origem.itensList;
        int index = button.transform.GetSiblingIndex();

        if (!globalInventory.activeSelf || index >= itemList.Count)
            return;

        var item = itemList[index];
        origem.RemoveItem(item);
        destino.AddItem(item);
    }
}
