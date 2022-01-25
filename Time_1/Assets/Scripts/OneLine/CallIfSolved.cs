using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallIfSolved : MonoBehaviour
{
    [SerializeField]
    private string puzzleName;
    public UnityEvent action;

    private void Awake() {
        if(VariableManager.instance.HasCompletedPuzzle(puzzleName))
        {
            action.Invoke();
        }
    }
}
