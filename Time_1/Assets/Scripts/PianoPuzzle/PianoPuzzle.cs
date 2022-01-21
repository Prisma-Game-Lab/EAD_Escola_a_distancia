using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;

public class PianoPuzzle : MonoBehaviour
{
    public List<int> correctSequence;
    public List<float> intervals;
    private List<int> currentSequence;
    public List<PianoKey> keys;
    public GameObject blocker;
    public UnityEvent onCorrectSequence;

    private void OnEnable()
    {
        StopAllCoroutines();
        currentSequence = new List<int>();
        PlayerMovement.instance.LockMovement();
        StartPuzzle();
    }
    private void OnDisable()
    {
        PlayerMovement.instance.UnlockMovement();
        StopAllCoroutines();
    }

    public void StartPuzzle()
    {
        currentSequence.Clear();
        blocker.SetActive(true);
        StartCoroutine(StartPuzzleCoroutine());
    }

    private IEnumerator StartPuzzleCoroutine()
    {
        for (int i = 0; i < correctSequence.Count; i++)
        {
            yield return new WaitForSeconds(intervals[i]);
            keys[correctSequence[i]].OnPointerDown();
            yield return new WaitForSeconds(0.45f);
            keys[correctSequence[i]].OnPointerUp();
        }
        blocker.SetActive(false);
    }

    public void OnKeyPressed(int keyIndex)
    {
        currentSequence.Add(keyIndex);
        for (int i = 0; i < currentSequence.Count; i++)
        {
            if (currentSequence[i] != correctSequence[i])
            {
                StartPuzzle();
                return;
            }
        }
        if (currentSequence.Count == correctSequence.Count)
        {
            StartCoroutine(CompletePuzzle());
        }
    }

    private IEnumerator CompletePuzzle()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Correct sequence");
        currentSequence.Clear();
        onCorrectSequence.Invoke();
        VariableManager.instance.CompletePuzzle("piano");
        gameObject.SetActive(false);
    }
}
