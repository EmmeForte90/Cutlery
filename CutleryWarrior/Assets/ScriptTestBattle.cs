using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTestBattle : MonoBehaviour
{
    public PlayerStats Stats;
    public DuelManager DM;
    public CharacterMove F_Script;
    public CharacterFollow ch_FAc;
    public CharacterMove K_Script;
    public CharacterFollow ch_KAc;
    public CharacterMove S_Script;
    public CharacterFollow ch_SAc;
    public SwitchCharacter Switch;
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
        
    }
    public void Poison()
    {
       
    }
    public void Recover()
    {
        Stats.F_curHP =  Stats.F_HP;
        Stats.S_curHP =  Stats.K_HP;
        Stats.K_curHP =  Stats.S_HP;
    }
    public void Rage()
    {
        
    }

}