using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDialogueOption
{
    public Item item;
    public Dialogue dialogue;
}
[System.Serializable]
public class PuzzleDialogueOption
{
    public string puzzle;
    public Dialogue dialogue;
}
public class NPCDialogue : MonoBehaviour
{
    [SerializeField]
    Student targetStudent;
    [SerializeField]
    Dialogue initialDialogue;
    [SerializeField]
    List<ItemDialogueOption> itemDialogueOptions;
    [SerializeField]

    List<PuzzleDialogueOption> puzzleDialogueOptions;
    [SerializeField]
    List<Dialogue> genericDialogueOptions;

    public void TriggerDialogue()
    {
        var vInstance = VariableManager.instance;
        var dInstance = DialogueManager.instance;
        string metString = Students.GetName(vInstance.activeCharacter) + "met" + Students.GetName(targetStudent);
        if (vInstance.HasCompletedPuzzle(metString))
        {
            dInstance.StartDialogue(initialDialogue);
            return;
        }
        else
        {
            foreach (var item in itemDialogueOptions)
            {
                if (vInstance.HasItem(item.item))
                {
                    dInstance.StartDialogue(item.dialogue);
                    return;
                }
            }
            foreach (var puzzle in puzzleDialogueOptions)
            {
                if (vInstance.HasCompletedPuzzle(puzzle.puzzle))
                {
                    dInstance.StartDialogue(puzzle.dialogue);
                    return;
                }
            }
            // none of the conditions are met, play a random dialogue
            dInstance.StartDialogue(
                genericDialogueOptions[Random.Range(0, genericDialogueOptions.Count)]);
            return;
        }
    }
}

