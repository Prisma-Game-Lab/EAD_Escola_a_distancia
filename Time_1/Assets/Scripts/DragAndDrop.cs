using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rect;
    public Canvas canvas;
    private RectTransform canvasRect;
    private Vector2 startPos;
    public GameObject dragItem;
    private Transform child;
    public InventoryManager invManager;
    public Inventory inv;
    private CanvasGroup canvasGroup;
    public LayerMask unwalkableLayer;

    void Start()
    {   
        dragItem.SetActive(false);
        child = transform.GetChild(0);
        canvasRect = canvas.GetComponent<RectTransform>();
        rect = dragItem.GetComponent<RectTransform>();
        canvasGroup = dragItem.GetComponent<CanvasGroup>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {

        var childImg = child.GetComponent<Image>();
        var dragImg = dragItem.GetComponent<Image>();
        dragImg.sprite = childImg.sprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rect.anchoredPosition = eventData.position/canvas.scaleFactor; 
        if (child.gameObject.activeSelf)
        {
            dragItem.SetActive(true);
            child.gameObject.SetActive(false);
        }  

        canvasGroup.blocksRaycasts = false;

        invManager.origem = inv;
        invManager.indOrigem = transform.GetSiblingIndex();

    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition = eventData.position/canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragItem.activeSelf)
        {
            child.gameObject.SetActive(true);
            dragItem.SetActive(false);
        }
        canvasGroup.blocksRaycasts = true;

                
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, unwalkableLayer) && !inv.changed)
        {   
            Collider col = hit.collider;
            ItemReceiver receiver = col.GetComponent(typeof(ItemReceiver)) as ItemReceiver;
            if (receiver)
            {
                receiver.Receive(invManager.origem.PeekItemAt(invManager.indOrigem), hit.point);
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        invManager.destino = inv;
        invManager.indDestino = transform.GetSiblingIndex();
        invManager.MoveItemTo();
    }
}
