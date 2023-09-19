using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColl : MonoBehaviour
{
    public int damage;
    //public bool isDamageSecond;
    //private int WhatSkill;
    public Skill itemInfo;
    public float lifeTime;
    public static DamageColl instance;

     public void Start()
    {
        if (instance == null){instance = this;}
        damage = itemInfo.damage;
        //WhatSkill = itemInfo.WhoSkill;
        //isDamageSecond = itemInfo.isDamageSecond;
        Destroy(gameObject, lifeTime);
    }
    
}
