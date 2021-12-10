using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackPack : MonoBehaviour
{
    [SerializeField]
    private Sprite clara;
    [SerializeField]
    private Sprite ericson;
    [SerializeField]
    private Sprite maria;
    [SerializeField]
    private Image buttonImage;

    private void Update() {
        switch (VariableManager.instance.activeCharacter) {
            case Student.clara:
                buttonImage.sprite = clara;
                break;
            case Student.ericson:
                buttonImage.sprite = ericson;
                break;
            case Student.maria:
                buttonImage.sprite = maria;
                break;
        }
    }

}
