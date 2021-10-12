using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetObject;
    private float targetAngle = 0;
    public float rotationAmount = 1f;


    // Update is called once per frame
    void Update()
    {

        // Trigger functions if Rotate is requested
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            Left();
        } 
        else if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            Right();
        }
    }

    void FixedUpdate() 
    {
        if(targetAngle !=0)
        {
            Rotate();
        }      
    }

    public void Right()
    {
        targetAngle += 90.0f;
    }

    public void Left()
    {
        targetAngle -= 90.0f;
    }


    protected void Rotate()
    {
        if (targetAngle>0)
        {
            transform.RotateAround(targetObject.transform.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if(targetAngle <0)
        {
            transform.RotateAround(targetObject.transform.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }
    }
}
