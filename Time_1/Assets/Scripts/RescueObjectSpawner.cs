using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RescueObjectSpawner : MonoBehaviour
{
    [HideInInspector]
    public RescueObjectSpawner instance;
    public RescueObject rescueObjectPrefab;
    void Awake()
    {
        Assert.IsNull(instance, "duplicate instance of RescueObjectSpawner");
        instance = this;
        foreach (RescueStruct r in VariableManager.instance.rescuables)
        {
            SpawnRescuable(r);
        }
    }

    void SpawnRescuable(RescueStruct r)
    {
        var obj = Instantiate(rescueObjectPrefab,transform);
        obj.student = r.student;
        obj.itemList = r.lostItems;
    }

}
