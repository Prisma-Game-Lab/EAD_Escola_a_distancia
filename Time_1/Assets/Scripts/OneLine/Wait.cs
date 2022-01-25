using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{

    public void DesligaComDelay()
    {
        StartCoroutine(Desligar());
    }

    private IEnumerator Desligar()
    {
        yield return new WaitForSeconds(.01f);
        this.gameObject.SetActive(false);
    }
}
