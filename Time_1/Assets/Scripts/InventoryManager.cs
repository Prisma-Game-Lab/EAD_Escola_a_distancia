using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public Inventory origem;
    public Inventory destino;
    public Item item;
    public Item item2;
    public int indOrigem;
    public int indDestino;

    public GameObject globalInventory;

    public void Swap()
    {
        globalInventory.SetActive(!globalInventory.activeSelf);
    }

    public void MoveItem(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);


        List<Item> itemList= origem.itemList;
        int index = button.transform.GetSiblingIndex();

        if (!globalInventory.activeSelf || index >= itemList.Count)
            return;

        var item = itemList[index];
        origem.PopItemAt(index);
        destino.AddItem(item);
    }

    public void MoveItemTo()
    {
        if (!origem.PeekItemAt(indOrigem))
        {
            return;
        }

        if (destino.PeekItemAt(indDestino))
        {
            item = origem.PopItemAt(indOrigem);
            item2 = destino.PopItemAt(indDestino);
            destino.AddItemAt(item, indDestino);
            origem.AddItemAt(item2, indOrigem);

        }
        else
        {
            item = origem.PopItemAt(indOrigem);
            destino.AddItemAt(item, indDestino);
        }
    }
}
