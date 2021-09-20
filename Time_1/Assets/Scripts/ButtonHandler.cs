using UnityEngine;
using UnityEngine.EventSystems;
    
public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerMovement playerMovement;

    public void OnPointerDown(PointerEventData data)
    {
        playerMovement.frozen = true;
    }
    
    public void OnPointerUp(PointerEventData data)
    {
        playerMovement.frozen = false;
    }
}
