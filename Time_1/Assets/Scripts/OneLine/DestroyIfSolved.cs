using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfSolved : MonoBehaviour
{
    [SerializeField]
    private string puzzleName;

    private void Awake() {
        if(VariableManager.instance.completedPuzzles.Contains(puzzleName))
        {
            Destroy(this.gameObject);
        }
    }
}
