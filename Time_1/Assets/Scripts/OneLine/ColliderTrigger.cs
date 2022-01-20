using UnityEngine;
using UnityEngine.Events;


public class ColliderTrigger : MonoBehaviour {
    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other) {
        onTrigger.Invoke();
    }
}