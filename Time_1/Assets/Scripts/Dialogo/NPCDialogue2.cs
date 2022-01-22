using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class NPCDialogue2 : MonoBehaviour
{
    [SerializeField]
    string selfName;
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

    private void ShuffleList<T>(List<T> l)
    {
        for (int i = 0; i < l.Count; i++)
        {
            var temp = l[i];
            int randomIndex = Random.Range(i, l.Count);
            l[i] = l[randomIndex];
            l[randomIndex] = temp;
        }
    }

    public void TriggerDialogue()
    {
        var vInstance = VariableManager.instance;

        var dInstance = DialogueManager.instance;
        string metString = "met" + selfName;
        if (!vInstance.HasCompletedPuzzle(metString))
        {
            dInstance.StartDialogue(initialDialogue);
            vInstance.CompletePuzzle(metString);
            return;
        }
        else
        {
            ShuffleList(itemDialogueOptions);
            foreach (var item in itemDialogueOptions.FindAll((dialogueOption) =>
            {

                foreach (var e in dialogueOption.blockingEvents)
                {
                    if (vInstance.HasCompletedPuzzle(e))
                    {
                        return false;
                    }
                }
                return true;
            }))
            {
                if (vInstance.HasItem(item.item))
                {
                    dInstance.StartDialogue(item.dialogue);
                    return;
                }
            }
            foreach (var puzzle in puzzleDialogueOptions.FindAll((dialogueOption) =>
            {

                foreach (var e in dialogueOption.blockingEvents)
                {
                    if (vInstance.HasCompletedPuzzle(e))
                    {
                        return false;
                    }
                }
                return true;
            }))
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
