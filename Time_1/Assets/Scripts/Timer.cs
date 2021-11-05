using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime;
    private float timeRemaining;
    private bool running = false;
    public VariableManager variableManager;
    public Image o2Fill;
    public FadeOut fadeOut;
    public SceneJump sceneJump;
    public Inventory personalInventory;

    private void Start()
    {
        timeRemaining = totalTime;
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

                string kill = string.Format("{0} Morreu", variableManager.activeCharacter);
                Debug.Log(kill);
                Kill(variableManager.activeCharacter);

                var lostItems = new List<Item>();
                for (int i = 0; i < personalInventory.itemList.Count; i++)
                {
                    var item = personalInventory.PopItemAt(i);
                    if(item != null)
                    {
                        lostItems.Add(item);
                    }
                }
                var rs = new RescueStruct();
                rs.lostItems = lostItems;
                rs.student = variableManager.activeCharacter;
                variableManager.rescuables.Add(rs);

                // espaco para uma kill message
                
                //load hub
                sceneJump.StartCoroutine(sceneJump.ChangeScene(1));
            }
        }
    }


    
    void DisplayTime(float timeToDisplay)
    {
        o2Fill.fillAmount = timeRemaining / totalTime;
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