using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (PlayerPrefs.GetInt("key", 0) == 1)
            StartCoroutine(MoveTo(transform.position, new Vector3(11.7f,1.49f,8.61f), 1));
    }




    private IEnumerator MoveTo(Vector3 startPos, Vector3 targetPos, float time)
    {
        float t=0;
        do
        {
            yield return new WaitForFixedUpdate();
            t+=Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, targetPos, t/time);
        }while(t<time);
    }
}
