using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ShowDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    static ItemDescription descriptionObj;
    public Inventory inventory;

    private void Awake()
    {
        if (descriptionObj == null)
        {
            descriptionObj = GameObject.FindObjectOfType<ItemDescription>(true);
        }
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        var item = inventory.PeekItemAt(transform.GetSiblingIndex());
        if (item != null)
        {
            descriptionObj.objName.text = item.itemName;
            descriptionObj.description.text = item.description;
            descriptionObj.gameObject.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        descriptionObj.gameObject.SetActive(false);
    }
}
