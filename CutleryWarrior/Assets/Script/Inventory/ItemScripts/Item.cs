using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : ScriptableObject
{
    public string itemName;
    public string NameSkin;
    public string itemDes;
    public int ID;
    [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-EquipFork 4-EquipKnife 5-EquipSpoon")]
    public int KindItem;
    public int price;
    public bool Stackable;
    public Sprite itemIcon;
    [Tooltip("Che tipo di Equipaggiamento? 0-Armor 1-Weapon ")]
    public int TypesE;
    public void Use(int whatDo)
    {if(whatDo == 0){Inventory.instance.RemoveItem(this, 1);}
        else if(whatDo == 1)
        {GameManager.instance.money += price;
        Inventory.instance.RemoveItem(this, 1);
        Debug.Log("Hai Venduto!");}}//Vai allo script Consumable per verificarne la function
    public virtual void Equip()
    {}//Vai allo script Weapon per verificarne la function
    public virtual void Sell()
    {}//Vai allo script Consumable per verificarne la function
}