using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogueBox", menuName = "Dialogue/Create a new Dialogue Box")]
public class DialogueBox : ScriptableObject
{
   public string speaker;
   [TextArea]
   public string text;
}
