using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showSkillCD : MonoBehaviour
{
    public static bool skillBeenUsed;
    private bool curSkillBeenUsed;
    [SerializeField]
    private float cdtime = 5.0f;

    private float countDown;

    [SerializeField]
    private Text cdText;

     void Start()
     {
         cdText.GetComponent<Text>();
         countDown = cdtime;
     }

    void Update()
    {

        if (skillBeenUsed)
        {
            countDown -= Time.deltaTime; 
            cdText.text = ((int)countDown).ToString();
            if (countDown <= 0.1f)
            {
                countDown = cdtime;
                skillBeenUsed = false;
                cdText.text = "0";
            }
        }


    }
}
