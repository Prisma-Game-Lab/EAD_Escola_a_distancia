using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class InfPuzzle : MonoBehaviour
{
    public string password;
    public string playerText;
    public TextMeshProUGUI blinkText;
    public TextMeshProUGUI mText;
    public GameObject blinkObject;


    void Start()
    {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
        blinkText = blinkObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(Blink());
    }

    private void OnEnable()
    {
        StartCoroutine(Blink());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (playerText.Length != 0)
                {
                    playerText = playerText.Substring(0, playerText.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                CheckPassword();
            }
            else
            {
                playerText += c;
            }
        }
        mText.text = playerText;
    }

    private IEnumerator Blink()
    {
        while(true)
        {
            yield return new WaitForSeconds(.5f);
            blinkText.text = ">";
            yield return new WaitForSeconds(.5f);
            blinkText.text = "";
        }
    }

    public UnityEvent onWin;


    void CheckPassword()
    {
        if (playerText.ToLower() == password)
        {
            onWin.Invoke();
        }
        else
        {
            playerText = "";
        }
    }
}
