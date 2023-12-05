using System.Collections;
using UnityEngine;

public class CristalBoss : MonoBehaviour
{
    [Header("Actions")]
    public GameObject Cristal;
    public GameObject VFXCristal;
    public int CurrentCrystal = 0;
    bool DieB = false;
    public BossMiniera BM;
    private void OnEnable()
    {CurrentCrystal = BM.MaxCrystal;VFX();}
    //private void OnDisable(){VFX();}
    void Update(){BM.CurrentCrystal = CurrentCrystal; 
    if(CurrentCrystal <= 0){VFX();Cristal.SetActive(false);}}
    public void VFX(){Instantiate(VFXCristal, Cristal.transform.position, VFXCristal.transform.rotation);}
    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("F_Coll"))
        {if(!DieB){CurrentCrystal -= 1;VFX();}} 
        else if (collision.gameObject.CompareTag("F_Stump"))
        {if(!DieB){CurrentCrystal -= 1;VFX();}} 
        else if (collision.gameObject.CompareTag("K_Coll"))
        {if(!DieB){CurrentCrystal -= 1;VFX();}}
        else if (collision.gameObject.CompareTag("K_Stump"))
        {if(!DieB){CurrentCrystal -= 1;VFX();}}
        else if (collision.gameObject.CompareTag("S_Coll"))
        {if(!DieB){CurrentCrystal -= 1;VFX();}}
         else if (collision.gameObject.CompareTag("S_Stump"))
        {if(!DieB){CurrentCrystal -= 1;VFX();}}
        else if (collision.gameObject.CompareTag("Spell"))
        {if(!DieB){CurrentCrystal -= 1;VFX();}} 
        else if (collision.gameObject.CompareTag("Bomb"))
        {if(!DieB){CurrentCrystal -= 1;VFX();}}
    }
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Rage"))
        {if(!DieB)
        {CurrentCrystal -= 1;}} 
        } 
    }