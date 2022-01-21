using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public DialogueBoxObject dialogueBoxObject;

    [HideInInspector]
    public bool isInDialogue = false;

    private Queue<DialogueBox> queue;
    // quando essa variável possui de fato uma coroutine,
    // quer dizer que a caixa ainda está no processo de ser exibida,
    // para, por exemplo, apertar o botão apenas acelere o texto e não
    // pular pra proxima fala antes da hora
    private Coroutine displayBoxCoroutine;
    private DialogueBox currentBox;
    public static DialogueManager instance = null;

    private GameObject dialogueBox;
    private TextMeshProUGUI dialogueText;
    private TextMeshProUGUI speakerNameText;
    private void Awake() {
        if(dialogueBoxObject == null)
        {
            dialogueBoxObject = GameObject.FindObjectOfType<DialogueBoxObject>(true);
        }
        dialogueBox = dialogueBoxObject.gameObject;
        Assert.IsNotNull(dialogueBox);
        dialogueText = dialogueBoxObject.dialogueText;
        Assert.IsNotNull(dialogueText);
        speakerNameText = dialogueBoxObject.speakerNameText;
        Assert.IsNotNull(speakerNameText);
        Assert.IsNull(instance);
        instance=this;
    }
    private void Update() {
        if (isInDialogue && Input.GetButtonUp("AdvanceDialogue"))
        {
            DisplayNextBox();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue " + dialogue.name);
        PlayerMovement.instance.LockMovement();
        Interactable.LockInteraction();
        isInDialogue = true;
        queue = new Queue<DialogueBox>();
        foreach (var dBox in dialogue.dialogueBoxes)
        {
            queue.Enqueue(dBox);
        }
        dialogueBox.SetActive(true);
        DisplayNextBox();
    }

    private string GetSpeakerName(string speaker)
    {
        if (speaker == "")
        {
            return Students.GetName(VariableManager.instance.activeCharacter);
        }
        return speaker;

    }

    public void DisplayNextBox()
    {
        Assert.IsTrue(isInDialogue);


        // if displaying a dialogue box currently, just skips the animation
        if (displayBoxCoroutine != null)
        {
            StopCoroutine(displayBoxCoroutine);
            displayBoxCoroutine = null;
            DisplayBoxInstantly(currentBox);
            return;
        }
        else
        {
            if (queue.Count <= 0)
            {
                StartCoroutine(EndDialogue());
            }
            else
            {
                currentBox = queue.Dequeue();
                speakerNameText.text = GetSpeakerName(currentBox.speaker);
                dialogueBoxObject.setPortrait(GetSpeakerName(currentBox.speaker));
                displayBoxCoroutine = StartCoroutine(DisplayBox(currentBox));
            }
        }
    }

    private IEnumerator DisplayBox(DialogueBox box)
    {
        dialogueText.text = "";
        string currentText = "";
        string finalText = box.text;

        for (int i = 0; i < finalText.Length; i++)
        {
            currentText = finalText.Substring(0, i);
            currentText += "<color=#00000000>" + finalText.Substring(i) + "</color>";
            yield return new WaitForSeconds(0.1f);
            dialogueText.text = currentText;
        }
        dialogueText.text = finalText;
        // helps avoiding accidently skipping dialogue
        yield return new WaitForSeconds(0.5f);
        displayBoxCoroutine = null;
    }
    private void DisplayBoxInstantly(DialogueBox box)
    {
        dialogueText.text = box.text;
    }

    public IEnumerator EndDialogue()
    {
        dialogueBox.SetActive(false);
        isInDialogue = false;
        yield return new WaitForSeconds(0.5f);
        PlayerMovement.instance.UnlockMovement();
        Interactable.UnlockInteraction();
    }
}
