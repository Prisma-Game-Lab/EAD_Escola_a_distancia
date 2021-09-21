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

    private void Awake()
    {
        string s = variableManager.activeCharacter;
        Student student = Student.ericson;

        if (s == "ericson" && variableManager.ericson)
        {
            variableManager.activeCharacter = "ericson";
            student = Student.ericson;
        }
        else if (s == "clara" && variableManager.clara)
        {
            variableManager.activeCharacter = "clara";
            student = Student.clara;
        }
        else if (s == "maria" && variableManager.maria)
        {
            variableManager.activeCharacter = "maria";
            student = Student.maria;
        }
        else if (variableManager.ericson)
        {
            variableManager.activeCharacter = "ericson";
            student = Student.ericson;
        }
        else if (variableManager.clara)
        {
            variableManager.activeCharacter = "clara";
            student = Student.clara;
        }
        else if (variableManager.maria)
        {
            variableManager.activeCharacter = "maria";
            student = Student.maria;
        }

        currentStudent = student;
        UpdateModels();
        UpdateButtons();
    }

    private void UpdateModels()
    {
        if (variableManager.ericson)
            ericson.SetActive(true);
        if (variableManager.clara)
            clara.SetActive(true);
        if (variableManager.maria)
            maria.SetActive(true);

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
        yield return fadeOut.StartCoroutine(fadeOut.FadeOutCoroutine());
        currentStudent = s;
        variableManager.activeCharacter = s.ToString();
        UpdateModels();
        yield return fadeOut.StartCoroutine(fadeOut.FadeInCoroutine());
        UpdateButtons();
    }

    public void UpdateButtons()
    {
        if (variableManager.activeCharacter != "ericson" && variableManager.ericson)
            buttonEricson.interactable = true;
        else
            buttonEricson.interactable = false;

        if (variableManager.activeCharacter != "clara" && variableManager.clara)
            buttonClara.interactable = true;
        else
            buttonClara.interactable = false;

        if (variableManager.activeCharacter != "maria" && variableManager.maria)
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
