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
    if (GameManager.instance.CharacterID == 1)
    {
    if(Spoon)
    {GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    GameManager.instance.M_S.AddItem(Weapon, specificQuant);
    GameManager.instance.M_S.AddItem(Armor, specificQuant);

    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.Weapon);
    GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.DressSkin);
	GameManager.instance.Inv.Skin_S.UpdateCombinedSkin();
    }
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    GameManager.instance.M_K.AddItem(Weapon, specificQuant);
    GameManager.instance.M_K.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.Weapon);
    GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.DressSkin);
	GameManager.instance.Inv.Skin_K.UpdateCombinedSkin();
    }
    else if(Fork)
    {GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    GameManager.instance.M_F.AddItem(Weapon, specificQuant);
    GameManager.instance.M_F.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.Weapon);
    GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.DressSkin);
	GameManager.instance.Inv.Skin_F.UpdateCombinedSkin();
    }
    }
    else if (GameManager.instance.CharacterID == 2)
    {
    if(Spoon)
    {GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    GameManager.instance.M_S.AddItem(Weapon, specificQuant);
    GameManager.instance.M_S.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.Weapon);
    GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.DressSkin);
	GameManager.instance.Inv.Skin_S.UpdateCombinedSkin();} 
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    GameManager.instance.M_K.AddItem(Weapon, specificQuant);
    GameManager.instance.M_K.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.Weapon);
    GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.DressSkin);
	GameManager.instance.Inv.Skin_K.UpdateCombinedSkin();
    }
    else if(Fork)
    {GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    GameManager.instance.M_F.AddItem(Weapon, specificQuant);
    GameManager.instance.M_F.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.Weapon);
    GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.DressSkin);
	GameManager.instance.Inv.Skin_F.UpdateCombinedSkin();
    }
    }
    else if (GameManager.instance.CharacterID == 3)
    {
    if(Spoon)
    {GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    GameManager.instance.M_S.AddItem(Weapon, specificQuant);
    GameManager.instance.M_S.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.Weapon);
    GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.DressSkin);
	GameManager.instance.Inv.Skin_S.UpdateCombinedSkin();} 
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    GameManager.instance.M_K.AddItem(Weapon, specificQuant);
    GameManager.instance.M_K.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.Weapon);
    GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.DressSkin);
	GameManager.instance.Inv.Skin_K.UpdateCombinedSkin();}
    else if(Fork)
    {GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    GameManager.instance.M_F.AddItem(Weapon, specificQuant);
    GameManager.instance.M_F.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.Weapon);
    GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.DressSkin);
	GameManager.instance.Inv.Skin_F.UpdateCombinedSkin();
    }
    }
    SwitchCharacter.instance.TakeCharacters();
    //print("SwitchCharacter.instance.TakeCharacters");
    //Destroy(ThisObj);
    } 
    //////////////////////////////////////////////////////////////////////////////////////
    public void Unlock_F( )
    {StartCoroutine(UnlockStats());}

    //////////////////////////////////////////////////////////////////////////////////////
    public void Unlock_K( )
    {StartCoroutine(UnlockStats());}
    
    //////////////////////////////////////////////////////////////////////////////////////
    public void Unlock_S( )
    {StartCoroutine(UnlockStats());}

    //////////////////////////////////////////////////////////////////////////////////////

    IEnumerator UnlockStats()
    {yield return new WaitForSeconds(2f);
    GameManager.instance.NotParty = false;
    if(Spoon)
    {GameManager.instance.SpoonUnlock(); 
    PlayerStats.instance.ResetStatS();
    GameManager.instance.M_S.AddItem(Weapon, specificQuant);
    GameManager.instance.M_S.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.Weapon);
    GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.DressSkin);
	GameManager.instance.Inv.Skin_S.UpdateCombinedSkin();
    } 
    else if(Knife)
    {GameManager.instance.KnifeUnlock();
    PlayerStats.instance.ResetStatK();
    GameManager.instance.M_K.AddItem(Weapon, specificQuant);
    GameManager.instance.M_K.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.Weapon);
    GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.DressSkin);
	GameManager.instance.Inv.Skin_K.UpdateCombinedSkin();
    }
    else if(Fork)
    {GameManager.instance.ForkUnlock();
    PlayerStats.instance.ResetStatF();
    GameManager.instance.M_F.AddItem(Weapon, specificQuant);
    GameManager.instance.M_F.AddItem(Armor, specificQuant);
    GameManager.instance.Inv.AssignWeapon(Weapon_B);
    GameManager.instance.Inv.AssignDress(Armor_B);
    GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.Weapon);
    GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.DressSkin);
	GameManager.instance.Inv.Skin_F.UpdateCombinedSkin();
    }
    
    if(isDestroy){Destroy(This);}
    }


    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && with_contact && Fork){StartCoroutine(UnlockStats());}
    if (other.CompareTag("F_Player") && with_contact && Knife){StartCoroutine(UnlockStats());}
    if (other.CompareTag("F_Player") && with_contact && Spoon){StartCoroutine(UnlockStats());}
    //SwitchCharacter.instance.TakeCharacters();
    if(isMiner){DeactivateEvent_Var.ConfirmDeactivation();}
    }
}
