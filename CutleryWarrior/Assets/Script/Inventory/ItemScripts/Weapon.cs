
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")]
public class Weapon : Item
{
    public weaponType type;
    public int weaponDamage;
    //public string NameSkin;
    public override void Equip()
    {
        base.Equip();


        //Equip Action
        //The Equip Action is avaible in the "Inventory & Equip System - Drag & Drop", an extension of this package that can be purchased from the Unity asset Store in the following link:
        // https://assetstore.unity.com/packages/slug/209478

        //Use the following line if you want to destroy this type of item after use
        //Inventory.instance.RemoveItem(this, 1);
         if (TypesE == 1)
        {Inventory.instance.AssignWeapon(this);}
        else if (TypesE == 0)
        {Inventory.instance.AssignDress(this);} 
        //Debug.Log("Hai cliccato il pulsante!");

    }

    public enum weaponType { Sword, Fork, Spoon}
}
