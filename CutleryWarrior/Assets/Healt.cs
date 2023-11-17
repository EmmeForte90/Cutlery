using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    #region Header
    public float restore = 10;
    public bool isSkill = true;
    public bool one = true;
    public Skill itemInfo;
    public float lifeTime = 2f;
    public static Healt instance;
    #endregion
    void Start()
    {
        if (instance == null){instance = this;}
        if (isSkill){restore = itemInfo.damage;}
        Destroy(gameObject, lifeTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(one)
        {
        if(other.CompareTag("F_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        PlayerStats.instance.F_curHP += restore;
        one = false;
        }
        if(other.CompareTag("K_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        PlayerStats.instance.K_curHP += restore;
        one = false;        
        }
        if(other.CompareTag("S_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        PlayerStats.instance.S_curHP += restore;
        Destroy(gameObject, lifeTime);
        one = false;
        }
        }
    }
}
