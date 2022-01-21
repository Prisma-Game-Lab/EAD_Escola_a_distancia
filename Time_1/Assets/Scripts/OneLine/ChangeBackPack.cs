using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackPack : MonoBehaviour
{
    [SerializeField]
    private Sprite clara;
    [SerializeField]
    private Sprite claraOutline;

    [SerializeField]
    private Sprite ericson;
    [SerializeField]
    private Sprite ericsonOutline;

    [SerializeField]
    private Sprite maria;
    [SerializeField]
    private Sprite mariaOutline;

    [SerializeField]
    private Image buttonImage;
    [SerializeField]
    private Image buttonOutline;

    private void Update() {
        switch (VariableManager.instance.activeCharacter) {
            case Student.clara:
                buttonImage.sprite = clara;
                buttonOutline.sprite = claraOutline;
                break;
            case Student.ericson:
                buttonImage.sprite = ericson;
                buttonOutline.sprite = ericsonOutline;
                break;
            case Student.maria:
                buttonImage.sprite = maria;
                buttonOutline.sprite = mariaOutline;
                break;
        }
    }

}
