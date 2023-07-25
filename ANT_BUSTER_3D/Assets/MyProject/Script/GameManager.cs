using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;

    public TMP_Text CoreHP; 
    public TMP_Text Money;
    public static GameManager instance;
    private int coreHP = 30;
    private int money = 500;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;

        //Debug.LogFormat("{0}", coreHP);
        if (coreHP <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void CoreHpUi(int newDamage)
    {
        if (isGameOver == false)
        {
            coreHP -= newDamage;
            CoreHP.text = string.Format("CORE : {0}", coreHP);
            Debug.Log(coreHP);
        }
    }
    public void AddMoney(int newMoney)
    {

        if (isGameOver == false)
        {
            money += newMoney;
            Money.text = string.Format("MONEY : {0}", money);
            Debug.Log(money);
        }
    }
}
