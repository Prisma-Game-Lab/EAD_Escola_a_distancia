using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Manager", menuName = "Variable Manager")]
public class VariableManager : ScriptableObject
{
    public bool ericson;
    public bool clara;
    public bool maria;
    public Student activeCharacter;

    public bool IsStudentAlive(Student s)
    {
        switch(s)
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

}