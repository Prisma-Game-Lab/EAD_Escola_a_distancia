using UnityEngine;
using TMPro;

public class DialogueBoxObject : MonoBehaviour {
    public GameObject background;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerNameText;
    public GameObject ericPortrait;
    public GameObject mariaPortrait;
    public GameObject claraPortrait;
    public GameObject gambaPortait;
    public GameObject porteiroPortrait;
    public GameObject diretorPortrait;

    public void setPortrait(string name)
    {
        ericPortrait.SetActive(false);
        mariaPortrait.SetActive(false);
        claraPortrait.SetActive(false);
        gambaPortait.SetActive(false);
        porteiroPortrait.SetActive(false);
        diretorPortrait.SetActive(false);

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
        if(name.ToUpper() == "GAMBÁ")
        {
            gambaPortait.SetActive(true);
        }
        if(name.ToUpper() == "PORTEIRO")
        {
            porteiroPortrait.SetActive(true);
        }
        if(name.ToUpper() == "DIRETOR")
        {
            diretorPortrait.SetActive(true);
        }
    }
}