using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPuzzleLuca : MonoBehaviour
{
    public Inventory inventario;
    public Item acidobrab;
    public AudioSource acidoconcluido;

    // Start is called before the first frame update
    void Start()
    {
        if(inventario.itemList.Contains(acidobrab))
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inventario.itemList.Contains(acidobrab))
        {
            acidoconcluido.Play();
            Destroy(this);

        }
        
    }
}
