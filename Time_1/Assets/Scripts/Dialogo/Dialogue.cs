using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Create a new Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueBox> dialogueBoxes;
    public void Play()
    {
        var dManager = DialogueManager.instance;
        Assert.IsFalse(dManager.isInDialogue);
        dManager.StartDialogue(this);
    }
}
