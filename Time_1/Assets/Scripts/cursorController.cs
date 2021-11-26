using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Update()
    {

        if (Input.GetButton("Walk"))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
