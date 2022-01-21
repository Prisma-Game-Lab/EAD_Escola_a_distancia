using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemDescription : MonoBehaviour
{
    public TextMeshProUGUI objName;
    public TextMeshProUGUI description;

    private void LateUpdate() {
        transform.position = Input.mousePosition;
    }
}
