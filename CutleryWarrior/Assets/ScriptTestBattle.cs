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
    //Funziona
    public void Damage()
    {
        switch(Switch.rotationSwitcher.CharacterID)
        {
            case 1:
            F_Script.TakeDamage(DamageTest); ch_SAc.TakeDamage(DamageTest); ch_KAc.TakeDamage(DamageTest);
            break;
            case 2:
            K_Script.TakeDamage(DamageTest); ch_SAc.TakeDamage(DamageTest); ch_FAc.TakeDamage(DamageTest);
            break;
            case 3:
            S_Script.TakeDamage(DamageTest); ch_KAc.TakeDamage(DamageTest); ch_FAc.TakeDamage(DamageTest);
            break;
        }   
    }
    //Funziona
    public void Restore()
    {
        Stats.F_curHP =  Stats.F_HP;
        Stats.S_curHP =  Stats.K_HP;
        Stats.K_curHP =  Stats.S_HP;   
    }

    //Funziona
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
        Stats.K_paralysisResistance = Stats.K_paralysisResistanceCont;
        Stats.F_paralysisResistance = Stats.F_paralysisResistanceCont;
        Stats.S_paralysisResistance = Stats.S_paralysisResistanceCont;
        //
        Stats.K_poisonResistance = Stats.K_poisonResistanceCont;
        Stats.F_poisonResistance = Stats.F_poisonResistanceCont;
        Stats.S_poisonResistance = Stats.S_poisonResistanceCont;
        GameManager.instance.RestoreF();
        GameManager.instance.RestoreK(); 
        GameManager.instance.RestoreS();
    }
    public void RageMax()
    {
        Stats.F_curRage =  100;
        Stats.S_curRage =  100;
        Stats.K_curRage =  100;
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
        Stats.F_curRage =  0;
        Stats.S_curRage =  0;
        Stats.K_curRage =  0;
    }

}