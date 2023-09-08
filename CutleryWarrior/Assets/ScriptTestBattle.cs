using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTestBattle : MonoBehaviour
{
    private PlayerStats Stats;
    public DuelManager DM;
    private CharacterMove F_Script;
    private CharacterFollow ch_FAc;
    private CharacterMove K_Script;
    private CharacterFollow ch_KAc;
    private CharacterMove S_Script;
    private CharacterFollow ch_SAc;
    private SwitchCharacter Switch;
    public float DamageTest;
    public void Awake()
    {
        //if (instance == null){instance = this;} 
        ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();
        ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();
        ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();
        //
        S_Script = GameObject.Find("S_Player").GetComponent<CharacterMove>();
        F_Script = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        K_Script = GameObject.Find("K_Player").GetComponent<CharacterMove>();
        //
        Stats = GameObject.Find("Stats").GetComponent<PlayerStats>();
        Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();

    }
    public void Damage()
    {
        Stats.F_curHP -=  DamageTest;
        Stats.S_curHP -=  DamageTest;
        Stats.K_curHP -=  DamageTest;
        S_Script.TakeDamage();
        F_Script.TakeDamage();
        K_Script.TakeDamage();
        ch_SAc.TakeDamage();
        ch_KAc.TakeDamage();
        ch_FAc.TakeDamage();
    }

    public void Restore()
    {
        Stats.F_curHP =  Stats.F_HP;
        Stats.S_curHP =  Stats.K_HP;
        Stats.K_curHP =  Stats.S_HP;
        
    }

    public void DeathPL()
    {
        Stats.F_curHP =  0;
        Stats.S_curHP =  0;
        Stats.K_curHP =  0;
    }
    public void DeathEN()
    {
        
    }
    public void Stun()
    {
        Stats.K_paralysisResistance = 0;
        Stats.F_paralysisResistance = 0;
        Stats.S_paralysisResistance = 0;
    }
    public void Poison()
    {
        Stats.K_poisonResistance = 0;
        Stats.S_poisonResistance = 0;
        Stats.F_poisonResistance = 0;
    }
    public void Recover()
    {
        Stats.F_curHP =  Stats.F_HP;
        Stats.S_curHP =  Stats.K_HP;
        Stats.K_curHP =  Stats.S_HP;
        Stats.K_paralysisResistance = 1;
        Stats.F_paralysisResistance = 1;
        Stats.S_paralysisResistance = 1;
        //
        Stats.K_poisonResistance = 1;
        Stats.F_poisonResistance = 1;
        Stats.S_poisonResistance = 1;
        GameManager.instance.StopWin();
    }
    public void RageMax()
    {
        Stats.F_curRage =  100;
        Stats.S_curRage =  100;
        Stats.K_curRage =  100;
    }
    public void RageLess()
    {
        Stats.F_curRage =  0;
        Stats.S_curRage =  0;
        Stats.K_curRage =  0;
    }

}