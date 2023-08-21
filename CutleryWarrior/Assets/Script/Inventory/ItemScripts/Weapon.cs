
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")]
public class Weapon : Item
{
    #region Header
    public weaponType type;
    [Header("Se è un arma")]
    public int weaponDamage;
    public int MpCost;
    [Header("Se è un'armatura")]
    public int DefenceDress;
    public float HP;
    public float MP;
    public int Res_Poison;
    public int Res_Stun;
    public int Res_Sleep;
    public int Res_Rust;
    #endregion
    public override void Equip()
    {
        base.Equip();
        if (TypesE == 1)
        {Inventory.instance.AssignWeapon(this);}
        else if (TypesE == 0){Inventory.instance.AssignDress(this);} //Debug.Log("Hai cliccato il pulsante!");
    }
    public enum weaponType { Sword, Fork, Spoon}
}