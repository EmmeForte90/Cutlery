using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColl : MonoBehaviour
{
    [HideInInspector] public float damage;
    public Skill itemInfo;
    public float lifeTime;
    public static DamageColl instance;

     public void Start()
    {
        if (instance == null){instance = this;}
        damage = itemInfo.damage;
        Destroy(gameObject, lifeTime);
    }
    
}
