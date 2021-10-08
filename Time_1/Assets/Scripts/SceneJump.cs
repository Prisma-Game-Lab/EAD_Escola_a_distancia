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

    public IEnumerator ChangeScene(int index)
    {
        yield return fadeOut.StartCoroutine(fadeOut.FadeOutCoroutine());
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(index);
        
    }
}
