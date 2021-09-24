using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // objeto que contem o balão de fala
    public GameObject dialogueBox;
    // campo pras falas de fato
    public TextMeshProUGUI dialogueText;
    // campo pro nome do interlocutor
    public TextMeshProUGUI speakerNameText;

    public bool isInDialogue = false;

    private Queue<DialogueBox> queue;
    // quando essa variável possui de fato uma coroutine,
    // quer dizer que a caixa ainda está no processo de ser exibida,
    // para, por exemplo, apertar o botão apenas acelere o texto e não
    // pular pra proxima fala antes da hora
    private Coroutine displayBoxCoroutine;
    private DialogueBox currentBox;
    public static DialogueManager instance = null;

    private void Awake() {
        Assert.IsNotNull(dialogueBox);
        Assert.IsNotNull(dialogueText);
        Assert.IsNotNull(speakerNameText);
        Assert.IsNull(instance);
        instance=this;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        PlayerMovement.instance.LockMovement();
        isInDialogue = true;
        queue = new Queue<DialogueBox>();
        foreach (var dBox in dialogue.dialogueBoxes)
        {
            queue.Enqueue(dBox);
        }
        dialogueBox.SetActive(true);
        DisplayNextBox();
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
                EndDialogue();
            }
            else
            {
                currentBox = queue.Dequeue();
                speakerNameText.text = currentBox.speaker;
                displayBoxCoroutine = StartCoroutine(DisplayBox(currentBox));
            }
        }
    }

    private IEnumerator DisplayBox(DialogueBox box)
    {
        dialogueText.text = "";
        char[] charArray = box.text.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            dialogueText.text += charArray[i];
        }
        displayBoxCoroutine = null;
    }
    private void DisplayBoxInstantly(DialogueBox box)
    {
        dialogueText.text = box.text;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        isInDialogue = false;
        PlayerMovement.instance.UnlockMovement();
    }
}
