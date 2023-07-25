using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    Turret_Rotater rotater = new Turret_Rotater();

    public GameObject bulletPrefab = default;
    public Transform bulletPool = default;

    private Transform target = default;
    private float spawnRate = 1f;      //공속
    private float timeAfterSpawn = default;
    public int turretAtk = 1;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyObjects.Length > 0)
        {
            // 모든 적들 중 가장 가까운 적 찾기
            float closestDistance = Mathf.Infinity;
            GameObject closestEnemy = null;

            foreach (GameObject enemyObject in enemyObjects)
            {
                float aaa = Vector3.Distance(transform.position, enemyObject.transform.position);
                if (aaa < closestDistance)
                {
                    closestDistance = aaa;
                    closestEnemy = enemyObject;
                }
            }
            if (closestEnemy != null) 
            {
                target = closestEnemy.transform;
            }
        }
        else
        {
            target = null;
        }

        if (target != null)
        {
            timeAfterSpawn += Time.deltaTime;
            float aaa = Vector3.Distance(transform.position, target.position);

            if (aaa < 7)
            {
                if (timeAfterSpawn >= spawnRate)
                {
                    timeAfterSpawn = 0;
                    transform.LookAt(target);
                    Vector3 bulletSpawnPosition = transform.position + Vector3.up * 0.8f;
                    GameObject bullet = Instantiate(bulletPrefab,
                        bulletSpawnPosition, transform.rotation, bulletPool);
                }
            }
            else
            {
                rotater.Run(transform);
            }
        }
        else
        {
            rotater.Run(transform);
        }
      
    }
}
