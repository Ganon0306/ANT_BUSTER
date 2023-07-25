using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner1 : MonoBehaviour
{

    public GameObject enemyPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public Transform enemyPool = default;
    // private Transform target = default;
   // private float spawnRate = default;
    private float timeAfterSpawn = default;


    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        //if (spawnRate <= timeAfterSpawn)
        if (timeAfterSpawn >= 3)
        {
            timeAfterSpawn = 0;
            // transform.LookAt(target);

            GameObject enemy = Instantiate(enemyPrefab,
                transform.position, transform.rotation, enemyPool);

           // spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }


    }
}
