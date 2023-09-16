using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCharacter : MonoBehaviour
{
    public GameObject ThisObj;   
    public Item Weapon;
    public Item Armor;
    public int specificQuant;

    public bool Fork;
    public bool Spoon;
    public bool Knife;
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {
    if(Spoon){GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    EquipM_S.instance.AddItem(Weapon, specificQuant);
    EquipM_S.instance.AddItem(Armor, specificQuant);} 
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    EquipM_K.instance.AddItem(Weapon, specificQuant);
    EquipM_K.instance.AddItem(Armor, specificQuant);}
    else if(Fork){GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    EquipM_F.instance.AddItem(Weapon, specificQuant);
    EquipM_F.instance.AddItem(Armor, specificQuant);}
    }
    else if (other.CompareTag("K_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {
    if(Spoon){GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    EquipM_S.instance.AddItem(Weapon, specificQuant);
    EquipM_S.instance.AddItem(Armor, specificQuant);} 
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    EquipM_K.instance.AddItem(Weapon, specificQuant);
    EquipM_K.instance.AddItem(Armor, specificQuant);}
    else if(Fork){GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    EquipM_F.instance.AddItem(Weapon, specificQuant);
    EquipM_F.instance.AddItem(Armor, specificQuant);}
    }
    else if (other.CompareTag("S_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {
    if(Spoon){GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    EquipM_S.instance.AddItem(Weapon, specificQuant);
    EquipM_S.instance.AddItem(Armor, specificQuant);} 
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    EquipM_K.instance.AddItem(Weapon, specificQuant);
    EquipM_K.instance.AddItem(Armor, specificQuant);}
    else if(Fork){GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    EquipM_F.instance.AddItem(Weapon, specificQuant);
    EquipM_F.instance.AddItem(Armor, specificQuant);}
    }
    SwitchCharacter.instance.TakeCharacters();
    //print("SwitchCharacter.instance.TakeCharacters");
    Destroy(ThisObj);} 
}