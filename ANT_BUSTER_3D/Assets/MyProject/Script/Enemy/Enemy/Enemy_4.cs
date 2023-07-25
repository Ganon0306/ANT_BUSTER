using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    public Vector3[] wayPoint;
    public float speed = 3f;
    private int wayPointIndex = 0;
    private int enemyHP;
    private int turretAtk;
    private void Start()
    {

        wayPoint = new Vector3[]
        {
            new Vector3(11.5f, transform.position.y, -7.5f),
            new Vector3(9f, transform.position.y, -7.5f),
            new Vector3(9f, transform.position.y, -11.4f),
            new Vector3(7f, transform.position.y, -11.4f),
            new Vector3(7f, transform.position.y, -7.5f),
            new Vector3(5f, transform.position.y, -7.5f),
            new Vector3(5f, transform.position.y, -11.5f),
            new Vector3(3f, transform.position.y, -11.5f),
            new Vector3(3f, transform.position.y, -1.5f),
            new Vector3(0f, transform.position.y, -1.5f)

        };
    }

    void Update()
    {
        EnemyManager enemyManager = new EnemyManager();
        enemyHP = 4 + (enemyManager.killCount) / 5;
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }

        if (wayPoint.Length == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, wayPoint[wayPointIndex], speed * Time.deltaTime);

        if (transform.position == wayPoint[wayPointIndex])
        {
            wayPointIndex = (wayPointIndex + 1) % wayPoint.Length;
            if (wayPointIndex < wayPoint.Length)
            {
                Vector3 lookAtPosition = wayPoint[wayPointIndex];
                lookAtPosition.y = transform.position.y; // y 축은 변하지 않도록 설정
                transform.LookAt(lookAtPosition);
            }
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Core"))
        {
            Destroy(gameObject);
            GameManager.instance.CoreHpUi(1);
        }
        if (collision.tag.Equals("Bullet"))
        {
            enemyHP -= turretAtk;
        }
    }

}