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
    public Skill F_Skill_0;
    public Skill F_Skill_1;
    public Skill F_Skill_2;
    public Skill F_Skill_3;
    public Skill F_Skill_4;
    public Skill F_Skill_5;
    public Skill F_Skill_6;
    public Skill F_Skill_7;
    public Skill F_Skill_8;
    //public Skill F_Skill_9;
    //public Skill F_Skill_10;
    
    private TimerSkill F_Time_Skill_0;
    private TimerSkill F_Time_Skill_1;
    private TimerSkill F_Time_Skill_2;
    private TimerSkill F_Time_Skill_3;
    private TimerSkill F_Time_Skill_4;
    private TimerSkill F_Time_Skill_5;
    private TimerSkill F_Time_Skill_6;
    private TimerSkill F_Time_Skill_7;
    private TimerSkill F_Time_Skill_8;
    //private TimerSkill F_Time_Skill_9;
    //private TimerSkill F_Time_Skill_10;


    public KnifeSample[] EnmK;

    public Skill K_Skill_0;
    public Skill K_Skill_1;
    public Skill K_Skill_2;
    public Skill K_Skill_3;
    public Skill K_Skill_4;
    public Skill K_Skill_5;
    public Skill K_Skill_6;
    public Skill K_Skill_7;
    public Skill K_Skill_8;
    //public Skill K_Skill_9;
    //public Skill K_Skill_10;
    private TimerSkill K_Time_Skill_0;
    private TimerSkill K_Time_Skill_1;
    private TimerSkill K_Time_Skill_2;
    private TimerSkill K_Time_Skill_3;
    private TimerSkill K_Time_Skill_4;
    private TimerSkill K_Time_Skill_5;
    private TimerSkill K_Time_Skill_6;
    private TimerSkill K_Time_Skill_7;
    private TimerSkill K_Time_Skill_8;
    //private TimerSkill K_Time_Skill_9;
    //private TimerSkill K_Time_Skill_10;
    public SpoonSemple[] EnmS;
    public Skill S_Skill_0;
    public Skill S_Skill_1;
    public Skill S_Skill_2;
    public Skill S_Skill_3;
    public Skill S_Skill_4;
    public Skill S_Skill_5;
    public Skill S_Skill_6;
    public Skill S_Skill_7;
    public Skill S_Skill_8;
    //public Skill S_Skill_9;
    //public Skill S_Skill_10;

    private TimerSkill S_Time_Skill_0;
    private TimerSkill S_Time_Skill_1;
    private TimerSkill S_Time_Skill_2;
    private TimerSkill S_Time_Skill_3;
    private TimerSkill S_Time_Skill_4;
    private TimerSkill S_Time_Skill_5;
    private TimerSkill S_Time_Skill_6;
    private TimerSkill S_Time_Skill_7;
    private TimerSkill S_Time_Skill_8;
    //private TimerSkill S_Time_Skill_9;
    //private TimerSkill S_Time_Skill_10;

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
        if(GameManager.instance.F_Unlock)
        {
            F_Time_Skill_0 = GameObject.Find("BigSpell_T").GetComponent<TimerSkill>();
            F_Time_Skill_1 = GameObject.Find("BigFork_T").GetComponent<TimerSkill>();
            F_Time_Skill_2 = GameObject.Find("Flame_T").GetComponent<TimerSkill>();
            F_Time_Skill_3 = GameObject.Find("Impulsium_T").GetComponent<TimerSkill>();
            F_Time_Skill_4 = GameObject.Find("Smug_T").GetComponent<TimerSkill>();
            F_Time_Skill_5 = GameObject.Find("Bombing_T").GetComponent<TimerSkill>();
            F_Time_Skill_6 = GameObject.Find("Fenix_T").GetComponent<TimerSkill>();
            F_Time_Skill_7 = GameObject.Find("DragonFlame_T").GetComponent<TimerSkill>();
            F_Time_Skill_8 = GameObject.Find("Hole_T").GetComponent<TimerSkill>();
            //F_Time_Skill_9 = GameObject.Find("BigSpell_T").GetComponent<TimerSkill>();
            //F_Time_Skill_10 = GameObject.Find("BigSpell_T").GetComponent<TimerSkill>();
        }
        if(GameManager.instance.S_Unlock)
        {
            S_Time_Skill_0 = GameObject.Find("Benediction_T").GetComponent<TimerSkill>();
            S_Time_Skill_1 = GameObject.Find("Cura_T").GetComponent<TimerSkill>();
            S_Time_Skill_2 = GameObject.Find("ShockWave_T").GetComponent<TimerSkill>();
            S_Time_Skill_3 = GameObject.Find("Linfa_T").GetComponent<TimerSkill>();
            S_Time_Skill_4 = GameObject.Find("Regene_T").GetComponent<TimerSkill>();
            S_Time_Skill_5 = GameObject.Find("HitStun_T").GetComponent<TimerSkill>();
            S_Time_Skill_6 = GameObject.Find("Revive_T").GetComponent<TimerSkill>();
            S_Time_Skill_7 = GameObject.Find("Reflect_T").GetComponent<TimerSkill>();
            S_Time_Skill_8 = GameObject.Find("Panacea_T").GetComponent<TimerSkill>();
            //F_Time_Skill_9 = GameObject.Find("BigSpell_T").GetComponent<TimerSkill>();
            //F_Time_Skill_10 = GameObject.Find("BigSpell_T").GetComponent<TimerSkill>();
        }
        if(GameManager.instance.K_Unlock)
        {
            K_Time_Skill_0 = GameObject.Find("BigSlash_T").GetComponent<TimerSkill>();
            K_Time_Skill_1 = GameObject.Find("Fury_T").GetComponent<TimerSkill>();
            K_Time_Skill_2 = GameObject.Find("DanceSword_T").GetComponent<TimerSkill>();
            K_Time_Skill_3 = GameObject.Find("SlashBombing_T").GetComponent<TimerSkill>();
            K_Time_Skill_4 = GameObject.Find("RainSword_T").GetComponent<TimerSkill>();
            K_Time_Skill_5 = GameObject.Find("SawTrain_T").GetComponent<TimerSkill>();
            K_Time_Skill_6 = GameObject.Find("Stalactities_T").GetComponent<TimerSkill>();
            K_Time_Skill_7 = GameObject.Find("Whirlwinds_T").GetComponent<TimerSkill>();
            //S_Time_Skill_8 = GameObject.Find("Hole_T").GetComponent<TimerSkill>();
            //F_Time_Skill_9 = GameObject.Find("BigSpell_T").GetComponent<TimerSkill>();
            //F_Time_Skill_10 = GameObject.Find("BigSpell_T").GetComponent<TimerSkill>();
        }
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
        if(GameManager.instance.F_Unlock)
        {
            PlayerStats.instance.F_curHP =  PlayerStats.instance.F_HP;
            F_Skill_0.Utilizzi = F_Skill_0.UtilizziMAX;
            F_Skill_1.Utilizzi = F_Skill_1.UtilizziMAX;
            F_Skill_2.Utilizzi = F_Skill_2.UtilizziMAX;
            F_Skill_3.Utilizzi = F_Skill_3.UtilizziMAX;
            F_Skill_4.Utilizzi = F_Skill_4.UtilizziMAX;
            F_Skill_5.Utilizzi = F_Skill_5.UtilizziMAX;
            F_Skill_6.Utilizzi = F_Skill_6.UtilizziMAX;
            F_Skill_7.Utilizzi = F_Skill_7.UtilizziMAX;
            F_Skill_8.Utilizzi = F_Skill_8.UtilizziMAX;
            //F_Skill_9.Utilizzi = F_Skill_9.UtilizziMAX;
            //F_Skill_10.Utilizzi = F_Skill_10.UtilizziMAX;
            //
            F_Time_Skill_0.curTime = F_Time_Skill_0.TimeMin;
            F_Time_Skill_1.curTime = F_Time_Skill_1.TimeMin;
            F_Time_Skill_2.curTime = F_Time_Skill_2.TimeMin;
            F_Time_Skill_3.curTime = F_Time_Skill_3.TimeMin;
            F_Time_Skill_4.curTime = F_Time_Skill_4.TimeMin;
            F_Time_Skill_5.curTime = F_Time_Skill_5.TimeMin;
            F_Time_Skill_6.curTime = F_Time_Skill_6.TimeMin;
            F_Time_Skill_7.curTime = F_Time_Skill_7.TimeMin;
            F_Time_Skill_8.curTime = F_Time_Skill_8.TimeMin;
            //F_Time_Skill_9.curTime = F_Skill_9.TimeMin;
            //F_Time_Skill_10.curTime = F_Skill_10.TimeMin;
        }
        //
        if(GameManager.instance.S_Unlock)
        {
            PlayerStats.instance.S_curHP =  PlayerStats.instance.S_HP;
            S_Skill_0.Utilizzi = S_Skill_0.UtilizziMAX;
            S_Skill_1.Utilizzi = S_Skill_1.UtilizziMAX;
            S_Skill_2.Utilizzi = S_Skill_2.UtilizziMAX;
            S_Skill_3.Utilizzi = S_Skill_3.UtilizziMAX;
            S_Skill_4.Utilizzi = S_Skill_4.UtilizziMAX;
            S_Skill_5.Utilizzi = S_Skill_5.UtilizziMAX;
            S_Skill_6.Utilizzi = S_Skill_6.UtilizziMAX;
            S_Skill_7.Utilizzi = S_Skill_7.UtilizziMAX;
            S_Skill_8.Utilizzi = S_Skill_8.UtilizziMAX;
            //S_Skill_9.Utilizzi = S_Skill_9.UtilizziMAX;
            //S_Skill_10.Utilizzi = S_Skill_10.UtilizziMAX;
            //
            S_Time_Skill_0.curTime = S_Time_Skill_0.TimeMin;
            S_Time_Skill_1.curTime = S_Time_Skill_1.TimeMin;
            S_Time_Skill_2.curTime = S_Time_Skill_2.TimeMin;
            S_Time_Skill_3.curTime = S_Time_Skill_3.TimeMin;
            S_Time_Skill_4.curTime = S_Time_Skill_4.TimeMin;
            S_Time_Skill_5.curTime = S_Time_Skill_5.TimeMin;
            S_Time_Skill_6.curTime = S_Time_Skill_6.TimeMin;
            S_Time_Skill_7.curTime = S_Time_Skill_7.TimeMin;
            S_Time_Skill_8.curTime = S_Time_Skill_8.TimeMin;
            //S_Time_Skill_9.curTime = S_Skill_9.TimeMin;
            //S_Time_Skill_10.curTime = S_Skill_10.TimeMin;
        }
        //
        if(GameManager.instance.K_Unlock)
        {
            PlayerStats.instance.K_curHP =  PlayerStats.instance.K_HP;
            K_Skill_0.Utilizzi = K_Skill_0.UtilizziMAX;
            K_Skill_1.Utilizzi = K_Skill_1.UtilizziMAX;
            K_Skill_2.Utilizzi = K_Skill_2.UtilizziMAX;
            K_Skill_3.Utilizzi = K_Skill_3.UtilizziMAX;
            K_Skill_4.Utilizzi = K_Skill_4.UtilizziMAX;
            K_Skill_5.Utilizzi = K_Skill_5.UtilizziMAX;
            K_Skill_6.Utilizzi = K_Skill_6.UtilizziMAX;
            K_Skill_7.Utilizzi = K_Skill_7.UtilizziMAX;
            K_Skill_8.Utilizzi = K_Skill_8.UtilizziMAX;
            //K_Skill_9.Utilizzi = K_Skill_9.UtilizziMAX;
            //K_Skill_10.Utilizzi = K_Skill_10.UtilizziMAX;
            //
            K_Time_Skill_0.curTime = K_Time_Skill_0.TimeMin;
            K_Time_Skill_1.curTime = K_Time_Skill_1.TimeMin;
            K_Time_Skill_2.curTime = K_Time_Skill_2.TimeMin;
            K_Time_Skill_3.curTime = K_Time_Skill_3.TimeMin;
            K_Time_Skill_4.curTime = K_Time_Skill_4.TimeMin;
            K_Time_Skill_5.curTime = K_Time_Skill_5.TimeMin;
            K_Time_Skill_6.curTime = K_Time_Skill_6.TimeMin;
            K_Time_Skill_7.curTime = K_Time_Skill_7.TimeMin;
            K_Time_Skill_8.curTime = K_Time_Skill_8.TimeMin;
            //K_Time_Skill_9.curTime = K_Skill_9.TimeMin;
            //K_Time_Skill_10.curTime = K_Skill_10.TimeMin;
        }

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