using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItens : MonoBehaviour
{
    public GameObject itemPrefab;
    public List<ItemBase> inventoryList = new List<ItemBase>();

    void Start() {
        GameObject Obj = Instantiate(itemPrefab);
        Obj.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = inventoryList[0].sprite;
        
    }
}
