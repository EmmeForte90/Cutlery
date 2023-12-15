using System.Collections;
using UnityEngine;

public class UnlockCharacter : MonoBehaviour
{
    public GameObject This;
    public bool isDestroy = false;
    public Item Weapon;
    public Item Armor;
    public Weapon Weapon_B;
    public Weapon Armor_B;
    public int specificQuant;
    public bool with_contact = false;
    [Header("Characters")]
    public bool Fork;
    public bool Spoon;
    public bool Knife;

    [Header("WhatPlace")]
    public bool isMiner = false;
    public DeactivateEvent DeactivateEvent_Var;


    public void Unlock( )
    {
    if (SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {
    if(Spoon){GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    EquipM_S.instance.AddItem(Weapon, specificQuant);
    EquipM_S.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);}
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    EquipM_K.instance.AddItem(Weapon, specificQuant);
    EquipM_K.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);}
    else if(Fork){GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    EquipM_F.instance.AddItem(Weapon, specificQuant);
    EquipM_F.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);}
    }
    else if (SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {
    if(Spoon){GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    EquipM_S.instance.AddItem(Weapon, specificQuant);
    EquipM_S.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);} 
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    EquipM_K.instance.AddItem(Weapon, specificQuant);
    EquipM_K.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);}
    else if(Fork){GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    EquipM_F.instance.AddItem(Weapon, specificQuant);
    EquipM_F.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);}
    }
    else if (SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {
    if(Spoon){GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    EquipM_S.instance.AddItem(Weapon, specificQuant);
    EquipM_S.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);} 
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    EquipM_K.instance.AddItem(Weapon, specificQuant);
    EquipM_K.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);}
    else if(Fork){GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    EquipM_F.instance.AddItem(Weapon, specificQuant);
    EquipM_F.instance.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);}
    }
    SwitchCharacter.instance.TakeCharacters();
    //print("SwitchCharacter.instance.TakeCharacters");
    //Destroy(ThisObj);
    } 
    //////////////////////////////////////////////////////////////////////////////////////
    public void Unlock_F( )
    {StartCoroutine(UnlockToFork());}

    IEnumerator UnlockToFork()
    {yield return new WaitForSeconds(2f);
    GameManager.instance.NotParty = false;
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
    if(isDestroy){Destroy(This);}
    }

    //////////////////////////////////////////////////////////////////////////////////////
    public void Unlock_K( )
    {StartCoroutine(UnlockToKnife());}
    IEnumerator UnlockToKnife()
    {yield return new WaitForSeconds(2f);
    GameManager.instance.NotParty = false;
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
    if(isDestroy){Destroy(This);}
    }

    //////////////////////////////////////////////////////////////////////////////////////
    public void Unlock_S( )
    {StartCoroutine(UnlockToSpoon());}

    IEnumerator UnlockToSpoon()
    {yield return new WaitForSeconds(2f);
    GameManager.instance.NotParty = false;
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
    if(isDestroy){Destroy(This);}
    }

    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && with_contact && Fork){StartCoroutine(UnlockToFork());}
    if (other.CompareTag("F_Player") && with_contact && Knife){StartCoroutine(UnlockToKnife());}
    if (other.CompareTag("F_Player") && with_contact && Spoon){StartCoroutine(UnlockToSpoon());}
    SwitchCharacter.instance.TakeCharacters();
    if(isMiner){DeactivateEvent_Var.ConfirmDeactivation();}
    }
}
