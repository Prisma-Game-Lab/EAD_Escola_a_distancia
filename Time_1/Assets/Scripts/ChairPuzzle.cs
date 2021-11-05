using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPuzzle : MonoBehaviour
{
    public List<GameObject> cadeiras;
    public List<GameObject> linhas;
    public List<int> finalAngles;

    public Material materialErrado;
    public Material materialCerto;

    public float chairSpeed;
    public GameObject door;
    public float doorSpeed;

    public GridGen gridGen;
    public GameObject cupula;
    

    public void GiraCadeira(int index)
    {
        StartCoroutine(FullRotate(index));
        StartCoroutine(FullRotate((index+1)%4));
        if (index == 0)
            StartCoroutine(FullRotate(3));
        else
            StartCoroutine(FullRotate(index-1));
      
    }

    public IEnumerator FullRotate(int index)
    {
        for (int i=0; i< 90; i++)
        {
        cadeiras[index].transform.Rotate(new Vector3 (0,1,0));
        yield return new WaitForSeconds(1f/chairSpeed);
        }
        
        TestaAngulos();
    }

    public void TestaAngulos()
    {
        bool win = true;
        for (int i = 0; i< 4; i++)
        {
            
            if ((int) cadeiras[i].transform.eulerAngles[1] == finalAngles[i])
            {

                linhas[i].GetComponent<MeshRenderer>().material = materialCerto;
            }
            else
            {
                linhas[i].GetComponent<MeshRenderer>().material = materialErrado;
                win = false;
            }
        }
        if (win)
        {
            linhas[4].GetComponent<MeshRenderer>().material = materialCerto;
            StartCoroutine(MoveDoor());
            cupula.SetActive(false);
        }
    }

    private IEnumerator MoveDoor()
    {
        Vector3 startPos = door.transform.position;
        Vector3 targetPos = new Vector3 (startPos.x, startPos.y,startPos.z + 15);
        float distance = Vector3.Distance(startPos, targetPos);
        float time = distance / doorSpeed;
        float t = 0;
        
        do
        {
            yield return new WaitForFixedUpdate();
            t += Time.deltaTime;
            door.transform.position = Vector3.Lerp(startPos, targetPos, t / time);
        } while (t < time);
        gridGen.CreateGrid();
    }

}
