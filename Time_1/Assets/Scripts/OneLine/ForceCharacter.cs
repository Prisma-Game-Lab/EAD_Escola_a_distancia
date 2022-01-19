using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCharacter : MonoBehaviour
{
    public Student student;

    private void Awake() {
        VariableManager.instance.activeCharacter = student;
    }
}
