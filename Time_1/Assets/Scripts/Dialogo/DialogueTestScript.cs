using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTestScript : MonoBehaviour
{
    public Dialogue dialogo;
    public void Click()
    {
        var dManager = DialogueManager.instance;
        if(!dManager.isInDialogue)
        {
            dManager.StartDialogue(dialogo);
        }
    }
}
