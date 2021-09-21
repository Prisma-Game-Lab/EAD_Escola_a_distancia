using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool running = false;
    public Text timeText;
    public VariableManager variableManager;

    private void Start()
    {
        running = true;
    }

    void Update()
    {
        if (running)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                string kill = string.Format("{0} Morreu", variableManager.activeCharacter);
                Debug.Log(kill);
                Kill(variableManager.activeCharacter);
                timeRemaining = 0;
                running = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float min = Mathf.FloorToInt(timeToDisplay / 60); 
        float sec = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    void Kill(string s)
    {
        switch (s)
        {
            case "ericson":
                variableManager.ericson = false;
                break;
            case "clara":
                variableManager.clara = false;
                break;
            case "maria":
                variableManager.maria = false;
                break;
        }
    }
}