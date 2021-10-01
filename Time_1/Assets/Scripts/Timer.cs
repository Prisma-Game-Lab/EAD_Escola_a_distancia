using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    private bool running = false;
    public TextMeshProUGUI timeText;
    public VariableManager variableManager;
    public FadeOut fadeOut;

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
                timeRemaining = 0;
                running = false;
                // espaco para uma kill message
                StartCoroutine(respawn());
                //load hub
            }
        }
    }


    private IEnumerator respawn()
    {
        string kill = string.Format("{0} Morreu", variableManager.activeCharacter);
        Debug.Log(kill);
        Kill(variableManager.activeCharacter);

        yield return fadeOut.StartCoroutine(fadeOut.FadeOutCoroutine());

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);



    }

    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float min = Mathf.FloorToInt(timeToDisplay / 60); 
        float sec = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    void Kill(Student s)
    {
        switch (s)
        {
            case Student.ericson:
                variableManager.ericson = false;
                break;
            case Student.clara:
                variableManager.clara = false;
                break;
            case Student.maria:
                variableManager.maria = false;
                break;
        }
    }
}