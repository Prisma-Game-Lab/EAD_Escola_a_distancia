using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Student
{
    ericson, clara, maria
}
public class Students
{
    public static string GetName(Student s)
    {
        switch (s)
        {
            case Student.ericson:
                return "Ericson";
            case Student.clara:
                return "Clara";
            case Student.maria:
                return "Maria";
            default:
                return "";
        }
    }
}

public class ModelSwapper : MonoBehaviour
{
    public GameObject ericson;
    public GameObject clara;
    public GameObject maria;

    public PlayerModels playerModels;

    public Student currentStudent;
    private VariableManager variableManager;
    public FadeOut fadeOut;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        if(playerModels == null)
        {
            playerModels = GameObject.FindObjectOfType<PlayerModels>();
        }
        playerMovement = PlayerMovement.instance;
        variableManager = VariableManager.instance;
        Student s = variableManager.activeCharacter;
        Student student = Student.ericson;

        if (variableManager.IsStudentAlive(s))
        {
            switch (s)
            {
                case Student.ericson:
                    student = Student.ericson;
                    break;
                case Student.clara:
                    student = Student.clara;
                    break;
                case Student.maria:
                    student = Student.maria;
                    break;
            }
        }
        else
        {
            if (variableManager.ericson)
            {
                variableManager.activeCharacter = Student.ericson;
                student = Student.ericson;
            }
            else if (variableManager.clara)
            {
                variableManager.activeCharacter = Student.clara;
                student = Student.clara;
            }
            else if (variableManager.maria)
            {
                variableManager.activeCharacter = Student.maria;
                student = Student.maria;
            }
        }

        currentStudent = student;
        UpdateModels();
    }

    private void UpdateModels()
    {
        if (variableManager.ericson)
            ericson.SetActive(true);
        else
            ericson.SetActive(false);

        if (variableManager.clara)
            clara.SetActive(true);
        else
            clara.SetActive(false);

        if (variableManager.maria)
            maria.SetActive(true);
        else
            maria.SetActive(false);

        playerModels.clara.SetActive(false);
        playerModels.ericson.SetActive(false);
        playerModels.maria.SetActive(false);

        switch (currentStudent)
        {
            case Student.ericson:
                ericson.SetActive(false);
                playerModels.ericson.SetActive(true);
                break;
            case Student.clara:
                clara.SetActive(false);
                playerModels.clara.SetActive(true);
                break;
            case Student.maria:
                maria.SetActive(false);
                playerModels.maria.SetActive(true);
                break;
        }
    }

    public void SwapTo(Student s)
    {
        StopAllCoroutines();
        StartCoroutine(SwapModels(s));
    }

    private IEnumerator WaitDialogueThenSwapModel(string studentName)
    {
        yield return new WaitUntil(()=>DialogueManager.instance.isInDialogue);
        yield return new WaitWhile(()=>DialogueManager.instance.isInDialogue);
        SwapTo(studentName);
    }
    public void WaitDialogueThenSwapTo(string studentName)
    {
        StopAllCoroutines();
        StartCoroutine(WaitDialogueThenSwapModel(studentName));
    }

    public void SwapTo(string s)
    {
        Student student = Student.ericson;
        switch (s)
        {
            case "ericson":
                student = Student.ericson;
                break;
            case "clara":
                student = Student.clara;
                break;
            case "maria":
                student = Student.maria;
                break;
        }

        StopAllCoroutines();
        StartCoroutine(SwapModels(student));
    }

    private IEnumerator SwapModels(Student s)
    {
        fadeOut.gameObject.SetActive(true);
        yield return fadeOut.StartCoroutine(fadeOut.FadeOutCoroutine());
        currentStudent = s;
        variableManager.activeCharacter = s;
        UpdateModels();
        //playerMovement.ResetPosition();
        fadeOut.gameObject.SetActive(true);
        yield return fadeOut.StartCoroutine(fadeOut.FadeInCoroutine());
    }

}
