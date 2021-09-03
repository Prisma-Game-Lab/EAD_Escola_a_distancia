using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public GridBehaviour gridGenerator;
    public LayerMask groundLayer;
    [HideInInspector]
    public List<GameObject> path;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit,Mathf.Infinity,groundLayer))
            {
                GridStat hitTile = hit.transform.gameObject.GetComponent<GridStat>();
                if(hitTile != null)
                {
                    // TODO: tirar esse 0.5f hard codado
                    var currentTileGO = Physics.OverlapSphere(transform.position,0.5f,groundLayer)[0];
                    Assert.IsNotNull(currentTileGO,"Player not on a tile");

                    GridStat currentTile = currentTileGO.GetComponent<GridStat>();
                    Assert.IsNotNull(currentTile,"Player not on a tile, maybe change my groundLayer property");

                    // Isso pode parar o player entre tiles. Pode ser um problema no futuro
                    StopAllCoroutines();

                    gridGenerator.endX=hitTile.x;
                    gridGenerator.endY=hitTile.y;

                    gridGenerator.startX=currentTile.x;
                    gridGenerator.startY=currentTile.y;

                    path = gridGenerator.GetPath();
                    StartCoroutine(MoveThroughPath(path));
                }
            }

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

