using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Student currentStudent;

    public FadeOut fadeOut;

    private void Awake()
    {
        UpdateModels();
    }

    private void UpdateModels()
    {
        ericson.SetActive(true);
        clara.SetActive(true);
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

        StartCoroutine(SwapModels(student));
    }

    private IEnumerator SwapModels(Student s)
    {
        yield return fadeOut.StartCoroutine(fadeOut.FadeOutCoroutine());
        currentStudent = s;
        UpdateModels();
        yield return fadeOut.StartCoroutine(fadeOut.FadeInCoroutine());
    }

}
