using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPuzzle : MonoBehaviour
{
    public List<Item> ordemFinal;
    public Inventory bookInventory;
    public Inventory personalInventory;
    public Item chave;


    private void FixedUpdate() {

        bool check = true;
        for (int i = 0; i<3; i++)
        {
            if(bookInventory.itemList[i] != ordemFinal[i])
                check = false;
        }

        if(check)
        {
            personalInventory.AddItem(chave);
            this.gameObject.SetActive(false);
        }
    }
}
