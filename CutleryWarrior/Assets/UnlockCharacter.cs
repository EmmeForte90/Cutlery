using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCharacter : MonoBehaviour
{
    public GameObject ThisObj;    
    public bool Fork;
    public bool Spoon;
    public bool Knife;
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {
    if(Spoon){GameManager.instance.SpoonUnlock(); PlayerStats.instance.ResetStatS();} 
    else if(Knife){GameManager.instance.KnifeUnlock();PlayerStats.instance.ResetStatK();}
    else if(Fork){GameManager.instance.ForkUnlock();PlayerStats.instance.ResetStatF();}
    }
    else if (other.CompareTag("K_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {
    if(Spoon){GameManager.instance.SpoonUnlock(); PlayerStats.instance.ResetStatS();} 
    else if(Knife){GameManager.instance.KnifeUnlock();PlayerStats.instance.ResetStatK();}
    else if(Fork){GameManager.instance.ForkUnlock();PlayerStats.instance.ResetStatF();}
    }
    else if (other.CompareTag("S_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {
    if(Spoon){GameManager.instance.SpoonUnlock();PlayerStats.instance.ResetStatS();} 
    else if(Knife){GameManager.instance.KnifeUnlock();PlayerStats.instance.ResetStatK();}
    else if(Fork){GameManager.instance.ForkUnlock();PlayerStats.instance.ResetStatF();}
    }
    SwitchCharacter.instance.TakeCharacters();
    //print("SwitchCharacter.instance.TakeCharacters");
    Destroy(ThisObj);} 
}