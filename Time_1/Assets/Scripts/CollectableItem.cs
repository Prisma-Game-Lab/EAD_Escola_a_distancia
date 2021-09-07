using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
[RequireComponent(typeof(Collider))]
public class CollectableItem : MonoBehaviour
{
    public Item item;
    private void Start() {
        Assert.IsNotNull(item, "Item not set!");
        var col = GetComponent<Collider>();
        if(!col.isTrigger)
        {
            Debug.LogWarning("Setting CollectableItem Collider to Trigger");
            col.isTrigger=true;
        }
    }
    public void Dispose(){
        //Animações e efeitos sonoros podem entrar aqui
        Destroy(this.gameObject);
    }
}
