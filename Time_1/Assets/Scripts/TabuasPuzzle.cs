using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabuasPuzzle : MonoBehaviour
{
    public int madeiras;

    public UnityEvent OnComplete;

    public void Soma()
    {
        madeiras += 1;
    }

    void Update()
    {
        if (madeiras == 3)
        {
            OnComplete.Invoke();
        }
    }
}
