using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemDescription : MonoBehaviour
{
    public TextMeshProUGUI objName;
    public TextMeshProUGUI description;

    private void LateUpdate() {
        Vector3 mouse = Input.mousePosition;
        if (mouse.x > Screen.width/2)
        {
            if (mouse.y > Screen.height/2)
            {
                //Debug.Log(2);
                transform.position = new Vector3 (mouse.x - Screen.width/6, mouse.y - Screen.height/6, 0);
            }
            else
            {
                //Debug.Log(4);
                transform.position = new Vector3 (mouse.x - Screen.width/6, mouse.y + Screen.height/6, 0);
            }
        }
        else
        {
            if (mouse.y > Screen.height/2)
            {
                //Debug.Log(1);
                transform.position = new Vector3 (mouse.x + Screen.width/6, mouse.y - Screen.height/6, 0);
            }
            else
            {
                //Debug.Log(3);
                transform.position = new Vector3 (mouse.x + Screen.width/6, mouse.y + Screen.height/6, 0);
            }
        }
        
    }
}
