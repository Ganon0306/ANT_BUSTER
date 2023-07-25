using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public Vector3[] wayPoint;
    public float speed = 3f;
    private int wayPointIndex = 0;
    public int enemyHP;
    private int turretAtk;
    EnemyManager enemyManager = new EnemyManager();
    Turret_Bullet bullet = new Turret_Bullet();


    private void Start()
    {
        enemyHP = 8 + (enemyManager.killCount)/5 ;
        wayPoint = new Vector3[]
        {
            new Vector3(-11.5f, transform.position.y, 7.5f),
            new Vector3(-9.5f, transform.position.y, 7.5f),
            new Vector3(-9.5f, transform.position.y, 11.5f),
            new Vector3(-1.5f, transform.position.y, 11.5f),
            new Vector3(-1.5f, transform.position.y, 8f),
            new Vector3(-3.5f, transform.position.y, 8f),
            new Vector3(-3.5f, transform.position.y, 5.5f),
            new Vector3(-7.5f, transform.position.y, 5.5f),
            new Vector3(-7.5f, transform.position.y, 0.25f),
            new Vector3(-12f, transform.position.y, 0.25f),
            new Vector3(-12f, transform.position.y, -3.5f),
            new Vector3(-5f, transform.position.y, -3.5f),
            new Vector3(-5f, transform.position.y, 0f),
            new Vector3(0f, transform.position.y, 0f)
        };
    }

    void Update()
    {
        turretAtk = Turret_Bullet.atk;

        if (enemyHP <= 0)
        {
            enemyManager.killCount += 1;
            Destroy(gameObject);

            GameManager.instance.AddMoney(enemyHP * 5);
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
                lookAtPosition.y = transform.position.y; // y ���� ������ �ʵ��� ����
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
            Destroy(collision.gameObject);
            Debug.LogFormat("{0}", enemyHP);
            enemyHP -= turretAtk;
        }

    }

}
