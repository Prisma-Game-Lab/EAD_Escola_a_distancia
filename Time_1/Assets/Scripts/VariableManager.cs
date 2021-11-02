using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Manager", menuName = "Variable Manager")]
public class VariableManager : ScriptableSingleton<VariableManager>
{
    public bool ericson;
    public bool clara;
    public bool maria;
    public Student activeCharacter;
    [SerializeField]
    public List<RescueStruct> rescuables = new List<RescueStruct>();

    public bool IsStudentAlive(Student s)
    {
        switch (s)
        {
            case Student.ericson:
                return ericson;
            case Student.maria:
                return maria;
            case Student.clara:
                return clara;
        }
        return false;
    }

    public void SetStudentAlive(Student s, bool alive)
    {
        switch (s)
        {
            case Student.ericson:
                ericson = alive;
                return;
            case Student.maria:
                maria = alive;
                return;
            case Student.clara:
                clara = alive;
                return;
        }
    }

}