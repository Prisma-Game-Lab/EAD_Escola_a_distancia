using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject porta;
    [SerializeField]
    private GameObject estante;

    void Awake()
    {
        if(VariableManager.instance.HasCompletedPuzzle("informatica"))
        {
            LoadPorta();
        }
    }

    void LoadPorta()
    {
        porta.SetActive(true);
        estante.transform.Rotate(0,90,0);
        estante.transform.position += new Vector3(0,0,1.5f);
    }
}
