using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetObject;
    [SerializeField] private float scrollIntensity;
    [SerializeField] private float minDist;
    [SerializeField] private float maxDist;
    private Camera cam;
    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - targetObject.transform.position;
    }
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        cam.orthographicSize -= Input.GetAxisRaw("Mouse ScrollWheel") * scrollIntensity;
        if (cam.orthographicSize < minDist)
            cam.orthographicSize = minDist;

        if (cam.orthographicSize > maxDist)
            cam.orthographicSize = maxDist;
    }

    void LateUpdate()
    {
        transform.position = targetObject.transform.position + offset;
    }
}
