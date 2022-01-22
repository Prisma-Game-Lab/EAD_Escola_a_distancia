using UnityEngine;
using UnityEditor;
using System.Collections;
// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

#if (UNITY_EDITOR)
public class ReplaceGameObjects : ScriptableWizard
{
    public bool copyValues = true;
    public GameObject prefab;
    public GameObject[] objects;


    [MenuItem("Custom/Replace GameObjects")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
    }

    void OnWizardCreate()
    {

        foreach (GameObject go in objects)
        {
            Transform t = go.transform;
            GameObject newObject;
            newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            newObject.transform.position = t.position;
            newObject.transform.rotation = t.rotation;
            newObject.transform.parent = t.parent;

            DestroyImmediate(go);

        }

    }
}
#endif

