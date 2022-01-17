using UnityEngine;
using TMPro;

public class DialogueBoxObject : MonoBehaviour {
    public GameObject background;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerNameText;
    public GameObject ericPortrait;
    public GameObject mariaPortrait;
    public GameObject claraPortrait;

    public void setPortrait(string name)
    {
        ericPortrait.SetActive(false);
        mariaPortrait.SetActive(false);
        claraPortrait.SetActive(false);
        if(name.ToUpper() == "ERICSON")
        {
            ericPortrait.SetActive(true);
        }
        if(name.ToUpper() == "MARIA")
        {
            mariaPortrait.SetActive(true);
        }
        if(name.ToUpper() == "CLARA")
        {
            claraPortrait.SetActive(true);
        }
    }
}