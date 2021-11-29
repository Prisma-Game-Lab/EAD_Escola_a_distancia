using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    private UnityEvent onAccept;

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
            Correta();
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

    private void Correta()
    {
        passcodeText.text = "Correto";

        onAccept.Invoke();

        this.gameObject.SetActive(false);
    }

    private void OnEnable() {
        Interactable.LockInteraction();
        PlayerMovement.instance.LockMovement();
    }

    private void OnDisable() {
        Interactable.UnlockInteraction();
        PlayerMovement.instance.UnlockMovement();
    }

}
