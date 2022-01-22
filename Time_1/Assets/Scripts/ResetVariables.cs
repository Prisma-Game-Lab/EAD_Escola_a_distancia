using UnityEditor;
using UnityEngine;

#if (UNITY_EDITOR)
public class ResetVariables : MonoBehaviour {
    [MenuItem("Custom/Reset Variables")]
    static void ResetVariableManager() => VariableManager.instance.ResetVariables();
}
#endif

