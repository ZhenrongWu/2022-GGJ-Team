using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class show_player_health : MonoBehaviour
{
    [Header("Heart")]
    [SerializeField]
    private List<SpriteRenderer> _sprites = new List<SpriteRenderer>();
    [Header("TestButton")]

    public static  int life = 3;
    private int cur_life;
    public static bool AnyOneDie;
    
    private void Start()
    {
        cur_life = life;

    }
    

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            life--;
        }
        
        if (life != cur_life)
        {
            if (cur_life==0)
            {
                AnyOneDie = true;
            }
            showlife(life);
            cur_life = life;
        }
        
    }
    private void showlife(int life)
    {
        _sprites[life].enabled = false;
    }
}
