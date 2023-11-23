using UnityEngine;

public class StatusRestore : MonoBehaviour
{
    public bool isVaccino, isCoffe, isAglio, isMalox, isRistoro = false;
    public bool one = true;
    public float lifeTime = 1f;

    public void OnTriggerEnter(Collider other)
    {
        if(one)
        {
        if(other.CompareTag("F_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        if(isVaccino){PlayerStats.instance.F_poisonResistance = PlayerStats.instance.F_poisonResistanceCont;}
        else if(isCoffe){PlayerStats.instance.F_paralysisResistance = PlayerStats.instance.F_paralysisResistanceCont;}
        else if(isAglio){PlayerStats.instance.F_poisonResistance = PlayerStats.instance.F_poisonResistanceCont;}
        else if(isMalox){PlayerStats.instance.F_poisonResistance = PlayerStats.instance.F_poisonResistanceCont;}
        else if(isRistoro){PlayerStats.instance.F_curHP = PlayerStats.instance.F_HP; GameManager.instance.RestoreDeathF();}
        one = false;
        }
        if(other.CompareTag("K_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        if(isVaccino){PlayerStats.instance.K_poisonResistance = PlayerStats.instance.K_poisonResistanceCont;}
        else if(isCoffe){PlayerStats.instance.K_paralysisResistance = PlayerStats.instance.K_paralysisResistanceCont;}
        else if(isAglio){PlayerStats.instance.K_poisonResistance = PlayerStats.instance.K_poisonResistanceCont;}
        else if(isMalox){PlayerStats.instance.K_poisonResistance = PlayerStats.instance.K_poisonResistanceCont;}
        else if(isRistoro){PlayerStats.instance.K_curHP = PlayerStats.instance.K_HP; GameManager.instance.RestoreDeathhK();}
        one = false;        
        }
        if(other.CompareTag("S_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        if(isVaccino){PlayerStats.instance.S_poisonResistance = PlayerStats.instance.S_poisonResistanceCont;}
        else if(isCoffe){PlayerStats.instance.S_paralysisResistance = PlayerStats.instance.S_paralysisResistanceCont;}
        else if(isAglio){PlayerStats.instance.S_poisonResistance = PlayerStats.instance.S_poisonResistanceCont;}
        else if(isMalox){PlayerStats.instance.S_poisonResistance = PlayerStats.instance.S_poisonResistanceCont;}
        else if(isRistoro){PlayerStats.instance.S_curHP = PlayerStats.instance.S_HP; GameManager.instance.RestoreDeathS();}
        one = false;
        }
        }
        Destroy(gameObject, lifeTime);
    }
}
