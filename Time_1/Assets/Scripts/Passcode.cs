using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Passcode : MonoBehaviour
{
    public string passcode;
    public TextMeshProUGUI passcodeText;
    private string inputText = "";
    [SerializeField]
    private int maxSize;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private int time;
    public GridGen gridGen;
    

    void Start()
    {
        passcodeText.text = "";
    }

    public void AddNumber(string num)
    {
        if (inputText.Length < maxSize)
        {
            inputText += num;
            AtualizaDisplay();
        }
    }

    public void ClearInput()
    {
        inputText = "";
        AtualizaDisplay();
    }

    public void TryPasscode()
    {
       if (inputText == passcode)
        {
            inputText = "";
            StartCoroutine(Correta());
        }
        else
        {
            inputText = "";
            StartCoroutine(Incorreta());
        }
    }

    private void AtualizaDisplay()
    {
        passcodeText.text = inputText;
    }

    private IEnumerator Incorreta()
    {
        passcodeText.text = "INCORRETO";

        yield return new WaitForSeconds(0.5f);

        passcodeText.text = "";
    }

    private IEnumerator Correta()
    {
        passcodeText.text = "Correto";

        Vector3 startPos = door.transform.position;
        Vector3 targetPos = new Vector3 (startPos.x -12, startPos.y,startPos.z);
        float t = 0;
        
        do
        {
            yield return new WaitForFixedUpdate();
            t += Time.deltaTime;
            door.transform.position = Vector3.Lerp(startPos, targetPos, t / time);
        } while (t < time);
        gridGen.CreateGrid();
        
        this.gameObject.SetActive(false);
    }

}
