using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeOut : MonoBehaviour
{
    public float transitionTime;

    public void StartFadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }
    public void StartFadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }
    public IEnumerator FadeOutCoroutine()
    {
        PlayerMovement.instance?.LockMovement();
        var img = GetComponent<Image>();
        Assert.IsNotNull(img);
        var color = img.color;
        for (float t = 0; t <= transitionTime; t += Time.deltaTime)
        {
            img.color = new Color(color.r, color.g, color.b, t / transitionTime);
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
        PlayerMovement.instance?.UnlockMovement();
    }
    public IEnumerator FadeInCoroutine()
    {
        if (PlayerMovement.instance != null)
        {
            PlayerMovement.instance.LockMovement();
        }

        var img = GetComponent<Image>();
        Assert.IsNotNull(img);
        var color = img.color;
        for (float t = transitionTime; t >= 0; t -= Time.deltaTime)
        {
            img.color = new Color(color.r, color.g, color.b, t / transitionTime);
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
        PlayerMovement.instance?.UnlockMovement();
    }
}
