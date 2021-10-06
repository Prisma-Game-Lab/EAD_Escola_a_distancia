using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public int locks = 0;
    public Pathfinding pathfinding;
    public GridGen gridGen;
    public LayerMask groundLayer;
    [HideInInspector]
    public List<Node> path;

    public static PlayerMovement instance = null;

    public void LockMovement()
    {
        Assert.IsTrue(locks >= 0);
        locks += 1;
        Stop();
    }
    public void UnlockMovement()
    {
        Assert.IsTrue(locks >= 1);
        locks -= 1;
    }

    private void Awake()
    {
        Assert.IsNull(instance);
        instance = this;
        locks = 0;
    }
    void Update()
    {
        if (locks > 0) return;

        if (Input.GetButtonUp("Walk"))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer) && gridGen.NodeFromWorldPoint(hit.point).walkable)
            {
                StopAllCoroutines();

                path = pathfinding.FindPath(transform.position, hit.point);
                StartCoroutine(MoveThroughPath(path));
            }

        }

    }

    public void Stop()
    {
        StopAllCoroutines();
    }


    private IEnumerator MoveThroughPath(List<Node> path)
    {
        foreach (Node targetTile in path)
        {
            float distance = Vector3.Distance(transform.position, targetTile.worldPosition);
            float time = distance / speed;
            yield return StartCoroutine(MoveTo(transform.position, targetTile.worldPosition, time));//time seria settado em algum outro lugar
        }
    }

    private IEnumerator MoveTo(Vector3 startPos, Vector3 targetPos, float time)
    {
        float t = 0;
        do
        {
            yield return new WaitForFixedUpdate();
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, new Vector3(targetPos.x, 0, targetPos.z), t / time);
        } while (t < time);
    }
}

