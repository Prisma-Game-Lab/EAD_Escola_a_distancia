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
        PlayerMovement.instance.UnlockMovement();
    }
}
