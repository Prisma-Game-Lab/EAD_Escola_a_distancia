using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PianoKey : MonoBehaviour
{
    public Sprite pressedSprite;
    public Sprite defaultSprite;
    public AudioClip audioClip;

    private Image image;
    protected static AudioSource audioSource;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GameObject.FindObjectOfType<AudioSource>();
        }
        image = GetComponent<Image>();
        image.sprite = defaultSprite;
        image.alphaHitTestMinimumThreshold = 1f;

    }
    public void OnPointerDown()
    {
        if (audioClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning("AudioClip or AudioSource is null");
        }
        image.sprite = pressedSprite;
    }
    public void OnPointerUp()
    {
        image.sprite = defaultSprite;
    }

}
