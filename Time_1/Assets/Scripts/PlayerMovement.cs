using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    Vector2 clickedPosition;
    bool moving;

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
        if (moving && (Vector2) transform.position != clickedPosition)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, clickedPosition, step);
        }
        else
        {
            moving = false;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        clickedPosition = transform.position;
    }
    void OnCollisionStay2D(Collision2D col)
    {
        clickedPosition = transform.position;
    }
}
