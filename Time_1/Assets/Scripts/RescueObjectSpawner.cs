using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RescueObjectSpawner : MonoBehaviour
{
    public RescueObject rescueObjectPrefab;
    public static int currentRescuableIndex = -1;
    public static RescueObjectSpawner first = null;
    void Awake()
    {
        if(first == null)
        {
            first = this;
            currentRescuableIndex = -1;
        }
        currentRescuableIndex += 1;
        if(currentRescuableIndex < VariableManager.instance.rescuables.Count)
        {
            SpawnRescuable(VariableManager.instance.rescuables[currentRescuableIndex]);
        }
    }

    void SpawnRescuable(RescueStruct r)
    {
        var obj = Instantiate(rescueObjectPrefab,transform);
        obj.student = r.student;
        obj.itemList = r.lostItems;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position,Vector3.one * 5);
    }

}
