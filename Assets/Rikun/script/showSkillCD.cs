using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showSkillCD : MonoBehaviour
{
    private bool skillBeenUsed=false;
    [SerializeField]
    private float cdtime = 5.0f;

    private float countDown;

    private Text cdText;

     void Start()
     {
         countDown = cdtime;
     }

    void Update()
    {
        if (skillBeenUsed)
        {
            countDown -= Time.deltaTime;
        }

        if (countDown >= 0)
        {
            skillBeenUsed = false;
            countDown = cdtime;
        }
    }
}
