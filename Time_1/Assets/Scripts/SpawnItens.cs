using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnItens : MonoBehaviour
{
    public GameObject itemPrefab;
    public List<ItemBase> inventoryList = new List<ItemBase>();

    void Start() {

        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 1 || PlayerPrefs.GetInt("key", 0) == 1)
            return;

        GameObject Obj = Instantiate(itemPrefab);
        Obj.SetActive(true);
        Obj.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = inventoryList[0].sprite;
        Obj.transform.position = new Vector3(5,0,5);
        Obj.transform.rotation = Quaternion.Euler(0, 45, 0); 
    }
}
