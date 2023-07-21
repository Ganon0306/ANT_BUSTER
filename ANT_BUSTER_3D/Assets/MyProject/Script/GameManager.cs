using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public TMP_Text damageText;
    public static GameManager instance;
    public int coreHP = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coreHP <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void CoreHpUi(int newDamage)
    {
        coreHP -= newDamage;
        damageText.text = string.Format("CORE : {0}", coreHP);
        Debug.Log(coreHP);
    }
}
