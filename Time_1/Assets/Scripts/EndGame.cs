using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject porta;
    [SerializeField]
    private GameObject estante;

    [SerializeField]
    private Inventory priv, global;
    [SerializeField]
    private Item key1, key2;

    void Awake()
    {
        if (
            (priv.itemList.Contains(key1) ||
            global.itemList.Contains(key1))
                &&
            (priv.itemList.Contains(key2) ||
            global.itemList.Contains(key2)))
        {
            VariableManager.instance.CompletePuzzle("keys");
        }
        if (VariableManager.instance.HasCompletedPuzzle("informatica"))
        {
            LoadPorta();
        }
    }

    void LoadPorta()
    {
        porta.SetActive(true);
        estante.transform.Rotate(0, 90, 0);
        estante.transform.position += new Vector3(0, 0, 1.5f);
    }
}
