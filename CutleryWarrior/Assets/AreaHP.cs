using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHP : MonoBehaviour
{
    #region Header
    public float restore = 1;
    public bool isSkill = true;
    public bool one = true;
    public Skill itemInfo;
    public float lifeTime = 10f;
    public static AreaHP instance;
    #endregion
    void Start()
    {
        if (instance == null){instance = this;}
        if (isSkill){restore = itemInfo.damage;}
        Destroy(gameObject, lifeTime);
    }

    public void OnTriggerStay(Collider other)
    {
       
        if(other.CompareTag("F_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        PlayerStats.instance.F_curHP += restore;
        }
        if(other.CompareTag("K_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        PlayerStats.instance.K_curHP += restore;
        }
        if(other.CompareTag("S_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        PlayerStats.instance.S_curHP += restore;
        Destroy(gameObject, lifeTime);
        }
        }
}