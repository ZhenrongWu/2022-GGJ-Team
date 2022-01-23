using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class show_player_health2 : MonoBehaviour
{
    [Header("Heart")]
    [SerializeField]
    private List<SpriteRenderer> _sprites = new List<SpriteRenderer>();

    public static bool isDamage;
    [SerializeField]
    public int life=3 ;
    private int cur_life;
    public static bool AnyOneDie2;
    private void Start()
    { 
        cur_life =life;
    }
    

    private void Update()
    {
        beDamaged();
        if (life != cur_life)
        {
            if (cur_life==1)
            {
                AnyOneDie2 = true;
            }
            showlife();
            cur_life = life;
        }
        
    }
    private void showlife()
    {
        _sprites[life].enabled = false;
    }

    private void beDamaged()
    {
        if (isDamage)
        {
            life--;
        }

        isDamage = false;
    }
}
