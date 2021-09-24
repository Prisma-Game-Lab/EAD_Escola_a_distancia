using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Create a new Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueBox> dialogueBoxes;
}
