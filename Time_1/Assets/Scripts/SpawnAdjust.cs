using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnAdjust : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    public Transform defaultSpawn;
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if(VariableManager.instance.lastPortal >= 0 && VariableManager.instance.lastPortal < spawnPoints.Length)
        {
            agent.Warp(spawnPoints[VariableManager.instance.lastPortal].position);
            transform.rotation = spawnPoints[VariableManager.instance.lastPortal].rotation;
        }
        else
        {
            agent.Warp(defaultSpawn.position);
            transform.rotation = defaultSpawn.rotation;
        }
    }
}
