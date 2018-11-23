using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject LixoPrefab;
    public float SpawnTime = 7f;
    public Transform[] SpawnPoints;
 
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }

   public void Spawn()
    {
        int SpawnPointIndex = Random.Range(0, SpawnPoints.Length);

        Instantiate(LixoPrefab, SpawnPoints[SpawnPointIndex].position, SpawnPoints[SpawnPointIndex].rotation);
    }

}
