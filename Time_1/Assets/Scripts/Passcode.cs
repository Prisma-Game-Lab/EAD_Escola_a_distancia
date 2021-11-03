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
            inputText = "Correto";
            AtualizaDisplay();
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


}
