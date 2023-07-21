using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <=0)
        {
            Destroy(gameObject);
        }
    }


    public void Damage()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        Turret classAInstance = new Turret();

        int damage = classAInstance.turretAtk;
        enemyHP -= damage;

    }

   
}
