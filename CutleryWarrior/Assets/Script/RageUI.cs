using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageUI : MonoBehaviour
{
    public GameObject F_Button;    
    public GameObject K_Button;
    public GameObject S_Button;
    public SwitchCharacter SwitcherUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (SwitcherUI.rotationSwitcher.CharacterID)
        {
            case 1:
            if(PlayerStats.instance.F_curRage >= PlayerStats.instance.F_Rage)
            {F_Button.SetActive(true);} 
            else if(PlayerStats.instance.F_curRage < PlayerStats.instance.F_Rage)
            {F_Button.SetActive(false);}  
            break;
            case 2:
            if(PlayerStats.instance.K_curRage >= PlayerStats.instance.K_Rage)
            {K_Button.SetActive(true);} 
            else if(PlayerStats.instance.K_curRage < PlayerStats.instance.K_Rage)
            {K_Button.SetActive(false);}
            break; 
            case 3:
            if(PlayerStats.instance.S_curRage >= PlayerStats.instance.S_Rage)
            {S_Button.SetActive(true);} 
            else if(PlayerStats.instance.S_curRage < PlayerStats.instance.S_Rage)
            {S_Button.SetActive(false);}
            break;
        }
    }
}