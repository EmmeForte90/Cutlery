using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testin : MonoBehaviour
{
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;  
    public SaveManager Save;
    public void Start()
    {
        FAct = GameObject.FindWithTag("F_Player");
        Save = GameObject.FindWithTag("Save").GetComponent<SaveManager>();

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
        //PlayerStats.instance.KSkillATT(8);
        //
        PlayerStats.instance.SSkillATT(1);        
        PlayerStats.instance.SSkillATT(2);
        PlayerStats.instance.SSkillATT(3);
        PlayerStats.instance.SSkillATT(4);
        PlayerStats.instance.SSkillATT(5);
        PlayerStats.instance.SSkillATT(6);
        PlayerStats.instance.SSkillATT(7);
        //PlayerStats.instance.SSkillATT(8);
    }
    public void Addlevel()
    {
        if(PlayerStats.instance.F_Unlock){PlayerStats.instance.F_LevelUp();}
        if(PlayerStats.instance.K_Unlock){PlayerStats.instance.K_LevelUp();}
        if(PlayerStats.instance.S_Unlock){PlayerStats.instance.S_LevelUp();}
    }
    public void LoadGameF()
    {
        Save = GameObject.FindWithTag("Save").GetComponent<SaveManager>();
        Save.LoadGame();
        if(GameManager.instance.F_Unlock){FAct.transform.position = PlayerStats.instance.savedPosition;}
        if(GameManager.instance.K_Unlock){KAct.transform.position = PlayerStats.instance.savedPosition;}
        if(GameManager.instance.S_Unlock){SAct.transform.position = PlayerStats.instance.savedPosition;}
        PlayerStats.instance.IBattle_quantityList =   PlayerStats.instance.I_quantityList; 

    }

}
