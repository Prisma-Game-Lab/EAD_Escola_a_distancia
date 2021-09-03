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
    private GameObject collectedItem;
    public GameObject key;

    private void Start()
    {
        if (PlayerPrefs.GetInt("key", 0) == 1)
        {
            key.SetActive(false);
            GameObject collectedItem = Instantiate(inventoryItemPrefab, inventoryPlace.transform);
            collectedItem.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = inventoryList2[0].sprite;
            collectedItem.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = inventoryList2[0].name;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        GameObject Other = other.gameObject;
        if (Other.CompareTag("Item")) 
        {
            Other.SetActive(false);
            GameObject collectedItem = Instantiate(inventoryItemPrefab, inventoryPlace.transform);
            collectedItem.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = inventoryList2[0].sprite;
            collectedItem.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = inventoryList2[0].name;
            PlayerPrefs.SetInt("key", 1);
        }
        if (Other.CompareTag("end"))
        {
            var inventario = GameObject.Find("Inventory");
            StartCoroutine(ExecuteAfterTime(inventario, 0.2f));
        }
    }

    IEnumerator ExecuteAfterTime(GameObject inventario, float time)
    {
        yield return new WaitForSeconds(time);
        inventario.SetActive(false);
        
    }
    

}


