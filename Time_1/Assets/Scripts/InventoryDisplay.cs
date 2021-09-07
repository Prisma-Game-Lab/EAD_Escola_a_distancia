using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    void Start()
    {
        Assert.IsNotNull(inventory,"inventory not set in inventoryDisplay!");
        StartCoroutine(UpdateSprites());
    }

    private IEnumerator UpdateSprites()
    {
        int myCount = 0;
        List<Item> itemList= inventory.itensList;
        while(true)
        {
            yield return new WaitUntil(()=>itemList.Count != myCount);
            myCount = itemList.Count;
            int childCount = transform.childCount;
            Assert.IsTrue(childCount >= myCount, "not enough children");
            for (int i = 0; i < myCount; i++)
            {
                var correspondingChild = transform.GetChild(i);
                correspondingChild.gameObject.SetActive(true);
                var img = correspondingChild.GetComponent<Image>();
                Assert.IsNotNull(img,"inventory display child missing Image component");
                img.sprite = itemList[i].sprite;
            }
            for (int i = myCount; i < childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
