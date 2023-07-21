using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody rigid = default;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyManager enemy = other.GetComponent<EnemyManager>();
            if (enemy != null)
            {
                enemy.Damage();
            }
            Destroy(gameObject);
        }
    }
}
