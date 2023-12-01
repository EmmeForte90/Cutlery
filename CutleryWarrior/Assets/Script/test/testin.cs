using UnityEngine;

public class testin : MonoBehaviour
{
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;  
    public SaveManager Save;
    private CharacterMove F_Script;
    private CharacterFollow ch_FAc;
    private CharacterMove K_Script;
    private CharacterFollow ch_KAc;
    private CharacterMove S_Script;
    private CharacterFollow ch_SAc;
    public void Start()
    {
        FAct = GameManager.instance.F_Hero;
        Save = GameObject.FindWithTag("Save").GetComponent<SaveManager>();
      
        if(GameManager.instance.S_Unlock){ch_SAc = GameManager.instance.S_Hero.GetComponent<CharacterFollow>();}
        if(GameManager.instance.F_Unlock){ch_FAc = GameManager.instance.F_Hero.GetComponent<CharacterFollow>();}
        if(GameManager.instance.K_Unlock){ch_KAc = GameManager.instance.K_Hero.GetComponent<CharacterFollow>();}
        //
        if(GameManager.instance.S_Unlock){S_Script = GameManager.instance.S_Hero.GetComponent<CharacterMove>();}
        if(GameManager.instance.F_Unlock){F_Script = GameManager.instance.F_Hero.GetComponent<CharacterMove>();}
        if(GameManager.instance.K_Unlock){K_Script = GameManager.instance.K_Hero.GetComponent<CharacterMove>();}
        AudioManager.instance.PlayUFX(8);
    

    }
        public void addskill()
    {
        PlayerStats.instance.FSkillATT(1);        
        PlayerStats.instance.FSkillATT(2);
        PlayerStats.instance.FSkillATT(3);
        PlayerStats.instance.FSkillATT(4);
        PlayerStats.instance.FSkillATT(5);
        PlayerStats.instance.FSkillATT(6);
        PlayerStats.instance.FSkillATT(7);
        PlayerStats.instance.FSkillATT(8);
        //
        PlayerStats.instance.KSkillATT(1);        
        PlayerStats.instance.KSkillATT(2);
        PlayerStats.instance.KSkillATT(3);
        PlayerStats.instance.KSkillATT(4);
        PlayerStats.instance.KSkillATT(5);
        PlayerStats.instance.KSkillATT(6);
        PlayerStats.instance.KSkillATT(7);
        //
        PlayerStats.instance.SSkillATT(1);        
        PlayerStats.instance.SSkillATT(2);
        PlayerStats.instance.SSkillATT(3);
        PlayerStats.instance.SSkillATT(4);
        PlayerStats.instance.SSkillATT(5);
        PlayerStats.instance.SSkillATT(6);
        PlayerStats.instance.SSkillATT(7);
    }
    public void Addlevel()
    {
        if(PlayerStats.instance.F_Unlock){PlayerStats.instance.F_LevelUp();}
        if(PlayerStats.instance.K_Unlock){PlayerStats.instance.K_LevelUp();}
        if(PlayerStats.instance.S_Unlock){PlayerStats.instance.S_LevelUp();}
    }
    public void Knockback()
    {
        if(PlayerStats.instance.F_Unlock){F_Script.Knockback();}
        if(PlayerStats.instance.K_Unlock){K_Script.Knockback();}
        if(PlayerStats.instance.S_Unlock){S_Script.Knockback();}
    }

    public void StopMusic()
    {
        AudioManager.instance.CrossFadeOUTAudio(4);
    }
    public void LoadGameF()
    {
        Save = GameObject.FindWithTag("Save").GetComponent<SaveManager>();
        Save.LoadGame();
        if(GameManager.instance.F_Unlock){FAct.transform.position = PlayerStats.instance.savedPosition;}
        if(GameManager.instance.K_Unlock){KAct.transform.position = PlayerStats.instance.savedPosition;}
        if(GameManager.instance.S_Unlock){SAct.transform.position = PlayerStats.instance.savedPosition;}
        //PlayerStats.instance.IBattle_quantityList =   PlayerStats.instance.I_quantityList; 
    }
}