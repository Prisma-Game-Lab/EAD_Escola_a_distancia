using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Student
{
    ericson, clara, maria
}

public class ModelSwapper : MonoBehaviour
{
    public GameObject ericson;
    public GameObject clara;
    public GameObject maria;

    public GameObject playerEricson;
    public GameObject playerClara;
    public GameObject playerMaria;

    public Button buttonEricson;
    public Button buttonClara;
    public Button buttonMaria;

    public Student currentStudent;
    public VariableManager variableManager;
    public FadeOut fadeOut;

    public PlayerMovement playerMovement;

    private void Awake()
    {
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
        UpdateButtons();
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

        playerClara.SetActive(false);
        playerEricson.SetActive(false);
        playerMaria.SetActive(false);

        switch (currentStudent)
        {
            case Student.ericson:
                ericson.SetActive(false);
                playerEricson.SetActive(true);
                break;
            case Student.clara:
                clara.SetActive(false);
                playerClara.SetActive(true);
                break;
            case Student.maria:
                maria.SetActive(false);
                playerMaria.SetActive(true);
                break;
        }
    }

    public void SwapTo(Student s)
    {
        StopAllCoroutines();
        StartCoroutine(SwapModels(s));
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
        ButtonsOff();
        fadeOut.gameObject.SetActive(true);
        yield return fadeOut.StartCoroutine(fadeOut.FadeOutCoroutine());
        currentStudent = s;
        variableManager.activeCharacter = s;
        UpdateModels();
        playerMovement.ResetPosition();
        fadeOut.gameObject.SetActive(true);
        yield return fadeOut.StartCoroutine(fadeOut.FadeInCoroutine());
        UpdateButtons();
    }

    public void UpdateButtons()
    {
        if (variableManager.activeCharacter != Student.ericson && variableManager.ericson)
            buttonEricson.interactable = true;
        else
            buttonEricson.interactable = false;

        if (variableManager.activeCharacter != Student.clara && variableManager.clara)
            buttonClara.interactable = true;
        else
            buttonClara.interactable = false;

        if (variableManager.activeCharacter != Student.maria && variableManager.maria)
            buttonMaria.interactable = true;
        else
            buttonMaria.interactable = false;
    }

    public void ButtonsOff()
    {
        buttonEricson.interactable = false;
        buttonClara.interactable = false;
        buttonMaria.interactable = false;
    }

}
