using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    [SerializeField]
    private int time;
    private int x;
    private int y;
    private int z;

    public void MoveStraight()
    {
        StartCoroutine(GoTo());
    }
    public IEnumerator GoTo()
    {
        Vector3 startPos = this.transform.position;
        Vector3 targetPos = new Vector3 (startPos.x + x, startPos.y + y, startPos.z + z);
        float t = 0;

        do
        {
            yield return new WaitForFixedUpdate();
            t += Time.deltaTime;
            this.transform.position = Vector3.Lerp(startPos, targetPos, t / time);
        } while (t < time);
    }

    public void SetX(int offset)
    {
        x = offset;
    }
    
    public void SetY(int offset)
    {
        y = offset;
    }

    public void SetZ(int offset)
    {
        z = offset;
    }

    public void SetTime(int tempo)
    {
        time = tempo;
    }
}
