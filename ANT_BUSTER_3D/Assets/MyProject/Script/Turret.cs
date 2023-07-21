using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    Turret_Rotater rotater = new Turret_Rotater();

    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public Transform bulletPool = default;
    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;

    public int turretAtk = 1;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<EnemyManager>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < 10)
        {
            if (spawnRate <= timeAfterSpawn)
            {
                timeAfterSpawn = 0;
                transform.LookAt(target);

                GameObject bullet = Instantiate(bulletPrefab,
                    transform.position, transform.rotation, bulletPool);

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
        else
        {
            rotater.Run(transform);
        }
    }
}
