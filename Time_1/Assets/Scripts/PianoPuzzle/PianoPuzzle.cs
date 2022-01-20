using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PianoPuzzle : MonoBehaviour
{
    public List<int> correctSequence;
    private List<int> currentSequence;
    public List<PianoKey> keys;
    public GameObject blocker;

    private void OnEnable()
    {
        StopAllCoroutines();
        currentSequence = new List<int>();
        StartPuzzle();
    }
    private void OnDisable() {
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
            yield return new WaitForSeconds(0.3f);
            keys[correctSequence[i]].OnPointerDown();
            yield return new WaitForSeconds(0.3f);
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
            Debug.Log("Correct sequence");
            currentSequence.Clear();
        }
    }
}
