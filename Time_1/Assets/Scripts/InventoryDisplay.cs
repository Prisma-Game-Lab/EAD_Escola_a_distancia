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

    void OnEnable() 
    {
        Start();
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator UpdateSprites()
    {
        int myCount = 0;
        List<Item> itemList= inventory.itemList;
        while(true)
        {
            myCount = itemList.Count;
            int childCount = transform.childCount;
            Assert.IsTrue(childCount >= myCount, "not enough children");
            for (int i = 0; i < myCount; i++)
            {
                var correspondingButton = transform.GetChild(i);
                var correspondingImg = correspondingButton.GetChild(0);

                if (itemList[i]==null)
                {
                    correspondingImg.gameObject.SetActive(false);
                    continue;
                }

                correspondingImg.gameObject.SetActive(true);
                var img = correspondingImg.GetComponent<Image>();
                Assert.IsNotNull(img,"inventory display child missing Image component");
                img.sprite = itemList[i].sprite;
            }
            inventory.changed = false;
            yield return new WaitUntil(()=> inventory.changed);
        }
    }
}
