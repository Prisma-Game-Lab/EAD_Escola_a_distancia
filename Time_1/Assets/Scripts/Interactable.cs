using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;


[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    private LayerMask player;

    [SerializeField]
    private string destroyIf;

    void Awake()
    {
        player = LayerMask.GetMask("Player");
        if(destroyIf != "" && VariableManager.instance.HasCompletedPuzzle(destroyIf))
        {
            Destroy(this);
        }
    }

    public void Destroy()
    {
        Destroy(this);
    }

    static int _locks;
    public static void LockInteraction()
    {
        _locks += 1;
        //Debug.Log(_locks);
    }
    public static void UnlockInteraction()
    {
        _locks -= 1;
        //Debug.Log(_locks);
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
        if (_locks <= 0 && Input.GetButtonUp("Interact"))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1<<gameObject.layer))
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~player))
            {
                if (hit.collider == _col)
                {
                    if (!playerIsNear)
                    {
                        _locks++;
                        StartCoroutine(WaitForPlayer());
                        return;
                    }
                    Interact();
                }
            }

        }
    }

    private IEnumerator WaitForPlayer()
    {
        while (!playerIsNear)
        {
            yield return new WaitForFixedUpdate();
        }
        _locks--;
        Interact();
    }
}
