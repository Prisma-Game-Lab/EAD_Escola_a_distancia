using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
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
    }
}
