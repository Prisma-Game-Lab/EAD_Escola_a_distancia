using UnityEditor;
using UnityEngine;

public class ResetVariables : MonoBehaviour {
    [MenuItem("Custom/Reset Variables")]
    static void ResetVariableManager() => VariableManager.instance.ResetVariables();
}