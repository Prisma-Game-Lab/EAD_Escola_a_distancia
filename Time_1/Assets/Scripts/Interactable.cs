using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;


[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    static int _locks;
    public static void LockInteraction()
    {
        _locks += 1;
    }
    public static void UnlockInteraction()
    {
        _locks -= 1;
    }
    Collider _col;
    private void Start()
    {
        _col = GetComponent<Collider>();
        Assert.IsTrue(_col.isTrigger);
        _locks = 0;
    }

    bool playerIsNear = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (playerIsNear && other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
    public UnityEvent onInteract;

    protected virtual void Interact()
    {
        onInteract.Invoke();
    }
    protected virtual bool CanInteract()
    {
        return playerIsNear && _locks <= 0;
    }
    private void Update()
    {
        if (CanInteract() &&
            Input.GetButtonUp("Interact"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1<<gameObject.layer))
            {
                if (hit.collider == _col)
                {
                    Interact();
                }
            }

        }
    }
}
