using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public GameObject gridGenerator;
    public List<GameObject> path;


    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            path = gridGenerator.GetComponent<GridBehaviour>().path;
            StartCoroutine(MoveThroughPath(path));
        }

    }

    private IEnumerator MoveThroughPath(List<GameObject> path)
    {
        path.Reverse();
        foreach(GameObject targetTile in path)
        {
            float time = 1/speed;
            yield return StartCoroutine(MoveTo(transform.position, targetTile.transform.position, time));//time seria settado em algum outro lugar
        }
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

