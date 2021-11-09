using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance = null;
    private Camera cam;
    private NavMeshAgent agent;
    private LayerMask player;

    private void Awake() 
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        player = LayerMask.GetMask("Player");
    }

    private void Update () 
    {
        if (Input.GetButtonDown("Walk"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //TODO: CREATE LAYERMASK FOR PORTALS
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~player))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}

