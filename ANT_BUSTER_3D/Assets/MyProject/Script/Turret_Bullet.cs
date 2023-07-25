using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rigid = default;
    public static int atk;
    Turret turret = new Turret();

    public int a;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }

    private void Update()
    {
        atk = turret.turretAtk;
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag.Equals("Enemy"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
