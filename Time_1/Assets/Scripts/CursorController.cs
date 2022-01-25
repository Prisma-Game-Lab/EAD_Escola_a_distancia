using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    //troca cursor
    public Texture2D cursorPadrao;
    public Texture2D cursorDrag;
    public Texture2D cursorInteract;
    public Texture2D cursorDrop;
    private Texture2D currentCursor;
    private Texture2D lastCursor;
    
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public LayerMask unwalkableLayer;
    public static CursorController instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Cursor Repetido");
            Destroy(this);
        }
    }

    void Start()
    {
        SetComum();
    }
    public void SetCursor(Texture2D cursor)
    {
        Cursor.SetCursor(cursor, hotSpot, cursorMode);
        currentCursor = cursor;
        lastCursor = cursor;
    }

    public void SetComum()
    {
        Cursor.SetCursor(cursorPadrao, hotSpot, cursorMode);
        currentCursor = cursorPadrao;
        lastCursor = cursorPadrao;

    }

    public void SetDrag()
    {
        Cursor.SetCursor(cursorDrag, hotSpot, cursorMode);
        currentCursor = cursorDrag;
        lastCursor = cursorDrag;
    }

    public void SetDrop()
    {
        StartCoroutine(Drop());
    }

    public void SetInteract()
    {
        Cursor.SetCursor(cursorInteract, hotSpot, cursorMode);
    }

    private IEnumerator Drop()
    {
        Cursor.SetCursor(cursorDrop, hotSpot, cursorMode);
        currentCursor = cursorDrop;
        lastCursor = cursorDrop;
        yield return new WaitForSeconds(.2f);
        SetComum();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, unwalkableLayer))
        {
            Collider col = hit.collider;
            Interactable receiver = col.gameObject.GetComponent(typeof(Interactable)) as Interactable;
            if (receiver)
            {
                if (currentCursor == cursorInteract)
                {
                    return;
                }
                else
                {
                    SetInteract();
                }
            }
            else
            {
                SetCursor(lastCursor);
            }
        }
    }
}
