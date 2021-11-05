using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;

public class ItemReceiver : MonoBehaviour
{
    public List<Item> expectedItems;
    public List<Item> receivedItems;
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

    public void Receive(Item item, Vector3 target)
    {

        receivedItems.Add(item);

        bool check = true;

        foreach (Item expected in expectedItems)
        {
            if (!receivedItems.Contains(expected))
            {
                check = false;
            }
        }
        if(check)
        {
            if (!playerIsNear)
            {
                _locks++;
                StartCoroutine(WaitForPlayer(target));
                return;
            }
            Interact();
        }
    }

    private IEnumerator WaitForPlayer(Vector3 target)
    {
        PlayerMovement.instance.WalkTo(target);
        while (!playerIsNear)
        {
            yield return new WaitForFixedUpdate();
        }
        _locks--;
        Interact();
    }
}