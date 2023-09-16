using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCharacter : MonoBehaviour
{
    public GameObject ThisObj;
    public bool Spoon;
    public bool Knife;
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {if(Spoon){GameManager.instance.SpoonUnlock();} else if(Knife){GameManager.instance.KnifeUnlock();}}
    else if (other.CompareTag("K_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {if(Spoon){GameManager.instance.SpoonUnlock();} else if(Knife){GameManager.instance.KnifeUnlock();}}
    else if (other.CompareTag("S_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {if(Spoon){GameManager.instance.SpoonUnlock();} else if(Knife){GameManager.instance.KnifeUnlock();}}
    SwitchCharacter.instance.TakeCharacters();
    print("SwitchCharacter.instance.TakeCharacters");
    Destroy(ThisObj);} 
}