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
    public SimpleEnemy[] Enm;

    public float DamageTest;
    public void Awake()
    {
        //if (instance == null){instance = this;} 
        if(GameManager.instance.S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(GameManager.instance.F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(GameManager.instance.K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        //
        if(GameManager.instance.S_Unlock){S_Script = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.F_Unlock){F_Script = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.K_Unlock){K_Script = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        //
        Stats = GameObject.Find("Stats").GetComponent<PlayerStats>();
        Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();

    }
    //Funziona
    public void Damage()
    {
        switch(Switch.rotationSwitcher.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock){F_Script.TakeDamage(DamageTest);}
            if(GameManager.instance.S_Unlock){ch_SAc.TakeDamage(DamageTest);}
            if(GameManager.instance.K_Unlock){ch_KAc.TakeDamage(DamageTest);}
            break;
            case 2:
            if(GameManager.instance.K_Unlock){K_Script.TakeDamage(DamageTest);} 
            if(GameManager.instance.S_Unlock){ch_SAc.TakeDamage(DamageTest);}
            if(GameManager.instance.F_Unlock){ch_FAc.TakeDamage(DamageTest);}
            break;
            case 3:
            if(GameManager.instance.S_Unlock){S_Script.TakeDamage(DamageTest);}
            if(GameManager.instance.K_Unlock){ch_KAc.TakeDamage(DamageTest);}
            if(GameManager.instance.F_Unlock){ch_FAc.TakeDamage(DamageTest);}
            break;
        }   
    }
    //Funziona
    public void Restore()
    {
        if(GameManager.instance.F_Unlock){Stats.F_curHP =  Stats.F_HP;}
        if(GameManager.instance.S_Unlock){Stats.S_curHP =  Stats.K_HP;}
        if(GameManager.instance.K_Unlock){Stats.K_curHP =  Stats.S_HP;}   
    }

    //Funziona
    public void DeathPL()
    {
        if(GameManager.instance.F_Unlock){Stats.F_curHP =  0;}
        if(GameManager.instance.S_Unlock){Stats.S_curHP =  0;}
        if(GameManager.instance.K_Unlock){Stats.K_curHP =  0;}
    }
    public void DeathEN()
    {
        
    }
    public void Stun()
    {
        if(GameManager.instance.K_Unlock){Stats.K_paralysisResistance = 0;}
        if(GameManager.instance.F_Unlock){Stats.F_paralysisResistance = 0;}
        if(GameManager.instance.S_Unlock){Stats.S_paralysisResistance = 0;}
    }
    public void Poison()
    {
        if(GameManager.instance.K_Unlock){Stats.K_poisonResistance = 0;}
        if(GameManager.instance.S_Unlock){Stats.S_poisonResistance = 0;}
        if(GameManager.instance.F_Unlock){Stats.F_poisonResistance = 0;}
    }
    public void Recover()
    {
        if(GameManager.instance.F_Unlock){Stats.F_curHP =  Stats.F_HP;}
        if(GameManager.instance.S_Unlock){Stats.S_curHP =  Stats.K_HP;}
        if(GameManager.instance.K_Unlock){Stats.K_curHP =  Stats.S_HP;}
        if(GameManager.instance.F_Unlock){Stats.F_curMP =  Stats.F_MP;}
        if(GameManager.instance.S_Unlock){Stats.S_curMP =  Stats.K_MP;}
        if(GameManager.instance.K_Unlock){Stats.K_curMP =  Stats.S_MP;}   
        if(GameManager.instance.K_Unlock){Stats.K_paralysisResistance = Stats.K_paralysisResistanceCont;}
        if(GameManager.instance.F_Unlock){Stats.F_paralysisResistance = Stats.F_paralysisResistanceCont;}
        if(GameManager.instance.S_Unlock){Stats.S_paralysisResistance = Stats.S_paralysisResistanceCont;}
        //
        if(GameManager.instance.K_Unlock){Stats.K_poisonResistance = Stats.K_poisonResistanceCont;}
        if(GameManager.instance.F_Unlock){Stats.F_poisonResistance = Stats.F_poisonResistanceCont;}
        if(GameManager.instance.S_Unlock){ Stats.S_poisonResistance = Stats.S_poisonResistanceCont;}
        if(GameManager.instance.F_Unlock){GameManager.instance.RestoreF();}
        if(GameManager.instance.K_Unlock){GameManager.instance.RestoreK(); }
        if(GameManager.instance.S_Unlock){GameManager.instance.RestoreS();}
    }
    public void RageMax()
    {
        if(GameManager.instance.F_Unlock){Stats.F_curRage =  100;}
        if(GameManager.instance.S_Unlock){Stats.S_curRage =  100;}
        if(GameManager.instance.K_Unlock){Stats.K_curRage =  100;}
    }

    public void Win()
    {
        Enm[0].currentHealth =  0;
        Enm[1].currentHealth =  0;
        Enm[2].currentHealth =  0;
        Enm[0].Die();
        Enm[1].Die();
        Enm[2].Die();
    }
    public void RageLess()
    {
        if(GameManager.instance.F_Unlock){Stats.F_curRage =  0;}
        if(GameManager.instance.S_Unlock){Stats.S_curRage =  0;}
        if(GameManager.instance.K_Unlock){Stats.K_curRage =  0;}
    }
}