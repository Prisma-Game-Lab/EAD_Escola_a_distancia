using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float scrollIntensity;
    [SerializeField] private float minDist;
    [SerializeField] private float maxDist;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        cam.orthographicSize -= Input.GetAxisRaw("Mouse ScrollWheel") * scrollIntensity;
        if (cam.orthographicSize < minDist)
            cam.orthographicSize = minDist;

        if (cam.orthographicSize > maxDist)
            cam.orthographicSize = maxDist;
    }
}
