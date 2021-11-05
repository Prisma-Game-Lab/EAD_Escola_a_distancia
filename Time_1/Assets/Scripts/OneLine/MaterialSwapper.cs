using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    public void SwapMaterial(Material material)
    {
        this.GetComponent<MeshRenderer>().material = material;
    }
}
