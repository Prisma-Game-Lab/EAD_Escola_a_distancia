using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public VariableManager variableManager;
    public SceneJump sceneManager;
    public int cenaEric;
    public int cenaClara;
    public int cenaMaria;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Student s = variableManager.activeCharacter;
            switch (s)
            {
                case Student.ericson:
                    sceneManager.StartCoroutine(sceneManager.ChangeScene(cenaEric));
                    break;
                case Student.clara:
                    sceneManager.StartCoroutine(sceneManager.ChangeScene(cenaClara));
                    break;
                case Student.maria:
                    sceneManager.StartCoroutine(sceneManager.ChangeScene(cenaMaria));
                    break;
            }
        }
    }
}
