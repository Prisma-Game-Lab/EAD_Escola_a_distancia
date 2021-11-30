using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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
    Student self;
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

    private void Awake()
    {
        Assert.IsNotNull(initialDialogue, "Initial dialogue is null");
        Assert.IsNotNull(itemDialogueOptions, "Item dialogue options is null");
        Assert.IsNotNull(puzzleDialogueOptions, "Puzzle dialogue options is null");
        Assert.IsNotNull(genericDialogueOptions, "Generic dialogue options is null");
        Assert.IsTrue(genericDialogueOptions.Count > 0, "Generic dialogue options is empty");
    }

    public void TriggerDialogue()
    {
        var vInstance = VariableManager.instance;
        if(targetStudent != vInstance.activeCharacter)
        {
            return;
        }
        var dInstance = DialogueManager.instance;
        string metString = Students.GetName(targetStudent) + "met" + Students.GetName(self);
        if (!vInstance.HasCompletedPuzzle(metString))
        {
            dInstance.StartDialogue(initialDialogue);
            vInstance.CompletePuzzle(metString);
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

