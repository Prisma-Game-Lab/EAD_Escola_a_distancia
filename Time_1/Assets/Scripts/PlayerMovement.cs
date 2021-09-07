using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public Pathfinding pathfinding;
    public GridGen gridGen;
    public LayerMask groundLayer;
    [HideInInspector]
    public List<Node> path;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit,Mathf.Infinity,groundLayer) && gridGen.NodeFromWorldPoint(hit.point).walkable)
            {              
                StopAllCoroutines();

                path = pathfinding.FindPath(transform.position, hit.point);
                StartCoroutine(MoveThroughPath(path));
            }

        }

    }

    private IEnumerator MoveThroughPath(List<Node> path)
    {
        foreach(Node targetTile in path)
        {
            float time = 1/speed;
            yield return StartCoroutine(MoveTo(transform.position, targetTile.worldPosition, time));//time seria settado em algum outro lugar
        }
    }

    private IEnumerator MoveTo(Vector3 startPos, Vector3 targetPos, float time)
    {
        float t=0;
        do
        {
            yield return new WaitForFixedUpdate();
            t+=Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, new Vector3(targetPos.x, 0.5f, targetPos.z), t/time);
        }while(t<time);
    }
}

