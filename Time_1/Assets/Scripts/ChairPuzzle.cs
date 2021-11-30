using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class ChairPuzzle : MonoBehaviour
{
    private const string puzzleName = "cadeiras";
    public List<GameObject> cadeiras;
    public List<GameObject> linhas;
    public List<int> finalAngles;

    public Material materialErrado;
    public Material materialCerto;

    public float chairSpeed;

    [SerializeField]
    private UnityEvent onSolve;


    public void GiraCadeira(int index)
    {
        StartCoroutine(FullRotate(index));
        StartCoroutine(FullRotate((index + 1) % 4));
        if (index == 0)
            StartCoroutine(FullRotate(3));
        else
            StartCoroutine(FullRotate(index - 1));

    }

    private void Start() {
        if(VariableManager.instance.HasCompletedPuzzle(puzzleName))
        {
            for (int i = 0; i < 4; i++)
            {
                var t = cadeiras[i].transform;
                t.rotation = Quaternion.Euler(0,finalAngles[i],0);
            }
            TestaAngulos();
        }
    }

    public IEnumerator FullRotate(int index)
    {
        for (int i = 0; i < 90; i++)
        {
            cadeiras[index].transform.Rotate(new Vector3(0, 1, 0));
            yield return new WaitForSeconds(1f / chairSpeed);
        }

        TestaAngulos();
    }

    public void TestaAngulos()
    {
        bool win = true;
        for (int i = 0; i < 4; i++)
        {

            if ((int)cadeiras[i].transform.eulerAngles[1] == finalAngles[i])
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
            VariableManager.instance.CompletePuzzle(puzzleName);
            onSolve.Invoke();
        }
    }
}
