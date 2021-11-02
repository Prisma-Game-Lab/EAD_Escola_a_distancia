using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public struct RescueStruct
{
    public Student student;
    public List<Item> lostItems;
    public Vector3 position;
}

public class RescueObject : MonoBehaviour
{
    public Student student;
    public List<Item> itemList;
    [SerializeField]
    private Inventory globalInventory;
    public void Rescue()
    {
        Assert.IsNotNull(globalInventory, "RescueObject precisa de uma referência pro inventário global!");
        VariableManager.instance.SetStudentAlive(student, true);
        Assert.IsTrue(itemList.Count <= globalInventory.GetFreeSlots());
        for (int i = 0; i < itemList.Count; i++)
        {
            globalInventory.AddItem(itemList[i]);
        }
        var numberRemoved = VariableManager.instance.rescuables.RemoveAll((RescueStruct r)=>r.student == student);
        Assert.IsTrue(numberRemoved == 1);
    }
}