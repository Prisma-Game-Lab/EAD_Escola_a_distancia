using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneJump : MonoBehaviour
{
    public FadeOut fadeOut;

    void Start()
    {
        fadeOut.StartCoroutine(fadeOut.FadeInCoroutine());
    }

    public void SwitchScene(int index)
    {
        StartCoroutine(ChangeScene(index));
    }

    public IEnumerator ChangeScene(int index)
    {
        fadeOut.gameObject.SetActive(true);
        yield return fadeOut.StartCoroutine(fadeOut.FadeOutCoroutine());
        SceneManager.LoadScene(index);
    }
}
