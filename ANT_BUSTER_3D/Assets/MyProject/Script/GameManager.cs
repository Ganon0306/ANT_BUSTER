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
    public static GameManager instance;
    private int coreHP = 30;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
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
}
