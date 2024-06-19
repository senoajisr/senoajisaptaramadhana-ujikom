using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int delay = 10;
    public GameObject SpawnObject;
    
    void Start()
    {
        InvokeRepeating(nameof(Spawn), delay, 10);
    }
    
    void Spawn()
    {
        GameObject newSpawnObject = Instantiate(SpawnObject, transform);
    }
}
