using UnityEngine;

public class ScriptTestBattle : MonoBehaviour
{
    //private PlayerStats PlayerStats.instance;
    public DuelManager DM;
    private CharacterMove F_Script;
    private CharacterFollow ch_FAc;
    private CharacterMove K_Script;
    private CharacterFollow ch_KAc;
    private CharacterMove S_Script;
    private CharacterFollow ch_SAc;
    private SwitchCharacter Switch;
    public ForkSemple[] EnmF;
    public KnifeSample[] EnmK;
    public SpoonSemple[] EnmS;

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
        //PlayerStats.instance = GameObject.Find("PlayerStats.instance").GetComponent<PlayerStats>();
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
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curHP =  PlayerStats.instance.F_HP;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curHP =  PlayerStats.instance.K_HP;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curHP =  PlayerStats.instance.S_HP;}   
    }

    //Funziona
    public void DeathPL()
    {
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curHP =  0;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curHP =  0;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curHP =  0;}
    }
    public void DeathEN()
    {
        
    }
    public void Stun()
    {
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_paralysisResistance = 0;}
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_paralysisResistance = 0;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_paralysisResistance = 0;}
    }
    public void Poison()
    {
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_poisonResistance = 0;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_poisonResistance = 0;}
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_poisonResistance = 0;}
    }
    public void Recover()
    {
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curHP =  PlayerStats.instance.F_HP;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curHP =  PlayerStats.instance.K_HP;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curHP =  PlayerStats.instance.S_HP;}
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curMP =  PlayerStats.instance.F_MP;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curMP =  PlayerStats.instance.K_MP;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curMP =  PlayerStats.instance.S_MP;}   
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_paralysisResistance = PlayerStats.instance.K_paralysisResistanceCont;}
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_paralysisResistance = PlayerStats.instance.F_paralysisResistanceCont;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_paralysisResistance = PlayerStats.instance.S_paralysisResistanceCont;}
        //
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_poisonResistance = PlayerStats.instance.K_poisonResistanceCont;}
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_poisonResistance = PlayerStats.instance.F_poisonResistanceCont;}
        if(GameManager.instance.S_Unlock){ PlayerStats.instance.S_poisonResistance = PlayerStats.instance.S_poisonResistanceCont;}
        if(GameManager.instance.F_Unlock){GameManager.instance.RestoreF();}
        if(GameManager.instance.K_Unlock){GameManager.instance.RestoreK(); }
        if(GameManager.instance.S_Unlock){GameManager.instance.RestoreS();}
    }
    public void RageMax()
    {
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curRage =  100;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curRage =  100;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curRage =  100;}
    }

    public void Win()
    {
        EnmF[0].currentHealth =  0;
        EnmS[0].currentHealth =  0;
        EnmK[0].currentHealth =  0;

        EnmF[0].Die();        
        EnmS[0].Die();
        EnmK[0].Die();
    }
    public void RageLess()
    {
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curRage =  0;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curRage =  0;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curRage =  0;}
    }
}