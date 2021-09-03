using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJump : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            Scene scene = SceneManager.GetActiveScene();
            Debug.Log("Active Scene is '" + scene.buildIndex + "'.");

            switch(scene.buildIndex)
            {
                case 1:
                    SceneManager.LoadScene(0);  
                    break;
                case 0:
                    SceneManager.LoadScene(1);
                    break;
            }
        }
    }
}
