using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetObject;
    private float targetAngle = 0;
    [SerializeField] private float rotationAmount = 1f;
    [SerializeField] private float scrollIntensity;
    [SerializeField] private float minDist;
    [SerializeField] private float maxDist;
    private Camera cam;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }
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

        cam.orthographicSize -= Input.GetAxisRaw("Mouse ScrollWheel") * scrollIntensity;
        if (cam.orthographicSize < minDist)
            cam.orthographicSize = minDist;

        if (cam.orthographicSize > maxDist)
            cam.orthographicSize = maxDist;
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
