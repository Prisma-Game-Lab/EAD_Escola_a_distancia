using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private int myLocks = 0;
    public void OnPointerDown(PointerEventData data)
    {
        myLocks += 1;
        PlayerMovement.instance.LockMovement();
    }

    public void OnPointerUp(PointerEventData data)
    {
        StartCoroutine(UnlockMovement());
    }
    private IEnumerator UnlockMovement()
    {
        yield return null;
        yield return null;
        PlayerMovement.instance.UnlockMovement();
        myLocks -= 1;
    }

    private void OnDisable() {
        StopAllCoroutines();
        for (int i = 0; i < myLocks; i++)
        {
            PlayerMovement.instance.UnlockMovement();
        }
        myLocks=0;
    }
    private void OnEnable() {
        myLocks=0;
    }
}
