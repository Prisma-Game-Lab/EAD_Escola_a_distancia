using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 initialPosition;
    public int locks = 0;
    public LayerMask groundLayer;
    private Camera cam;
    private NavMeshAgent agent;

    public static PlayerMovement instance = null;

    public void LockMovement()
    {
        //Debug.Log("playerMovLocked");
        Assert.IsTrue(locks >= 0);
        locks += 1;
        Stop();
    }

    public void UnlockMovement()
    {
        //Debug.Log("playerMovUnlocked");
        Assert.IsTrue(locks >= 1);
        locks -= 1;
    }

    private void Awake()
    {
        Assert.IsNull(instance);
        instance = this;
        locks = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        CurrentSpeed();
        if (locks > 0) return;

        if (Input.GetButtonUp("Walk"))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                WalkTo(hit.point);
            }

        }

    }

    public void WalkTo(Vector3 target)
    {
        if (agent != null)
        {
            agent.SetDestination(target);
        }
    }

    public void Stop()
    {
        if (agent != null)
        {
            agent.ResetPath();
        }
        StopAllCoroutines();
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    public bool IsMoving()
    {
        if (agent.velocity != Vector3.zero)
        {
            return true;
        }
        return false;
    }

    public float CurrentSpeed()
    {
        return agent.velocity.magnitude / agent.speed;
    }
}

