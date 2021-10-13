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
        if (Input.GetButtonDown("RotateCameraLeft")) 
        {
            Left();
        } 
        else if (Input.GetButtonDown("RotateCameraRight")) 
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
