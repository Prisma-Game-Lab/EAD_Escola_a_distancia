using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTestScript : MonoBehaviour
{
    public Dialogue dialogo;
    public void Click()
    {
        var dManager = DialogueManager.instance;
        if(dManager.isInDialogue)
        {
            dManager.DisplayNextBox();
        }
        else
        {
            dManager.StartDialogue(dialogo);
        }
    }
}
