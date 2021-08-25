using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectItem : MonoBehaviour
{
    public List<ItemBase> inventoryList2 = new List<ItemBase>();
    public GameObject inventoryItemPrefab;
    public GameObject inventoryPlace;
    
    void Start() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject Other = other.gameObject;
        if (Other.CompareTag("Item")) {
            Other.SetActive(false);
            GameObject collectedItem = Instantiate(inventoryItemPrefab, inventoryPlace.transform);
            collectedItem.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = inventoryList2[0].sprite;
            collectedItem.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = inventoryList2[0].name;
            
        }
        
    }
}
