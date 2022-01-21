using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime;
    [SerializeField]
    private float timeRemaining;
    private bool running = false;
    public VariableManager variableManager;
    public Image o2Fill;
    public FadeOut fadeOut;
    public SceneJump sceneJump;
    public Inventory personalInventory;
    public Item mask;
    private bool hasMask;
    public float maskTime;

    private void Start()
    {
        timeRemaining = totalTime;
        running = true;
        hasMask = false;    
    }

    void Update()
    {
        if (running)
        {
            if (timeRemaining > 0)
            {
                CheckMask();
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

    public void CheckMask()
    {
        Debug.Log("TESTOU");
        if (personalInventory.itemList.Contains(mask) && hasMask == false)
        {
            totalTime += maskTime;
            timeRemaining += maskTime;
            hasMask = true;
        }
        else if (!personalInventory.itemList.Contains(mask) && hasMask == true)
        {
            totalTime -= maskTime;
            timeRemaining -= maskTime;
            hasMask = false;
        }
        return;
    }
    
    void DisplayTime(float timeToDisplay)
    {
        o2Fill.fillAmount = 0.664f*(timeRemaining / totalTime);
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