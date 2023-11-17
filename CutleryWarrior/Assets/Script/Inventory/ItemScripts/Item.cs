using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Item : ScriptableObject
{
    #region Header
    [TextArea(3, 10)] public string itemName;
    public string NameSkin;
    [TextArea(3, 10)] public string itemDes;
    public int ID;
    [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-EquipFork 4-EquipKnife 5-EquipSpoon")]
    [Range(0, 5)]
    public int KindItem;
    
    [Tooltip("Consumabile? 0-Pozione 1-MediaPozione 2-AltaPozione 3-EquipFork 4-EquipKnife 5-EquipSpoon")]
    [Range(0, 10)]
    public int WhoConsumable;
    public int price;
    public bool Stackable;

    
    public Sprite itemIcon;
    [Tooltip("Che tipo di Equipaggiamento? 0-Armor 1-Weapon ")]
    [Range(0, 1)]
    public int TypesE;
    [HideInInspector]public int TimeItem = 0;
    [HideInInspector]public int MaxDurationItem = 0;

    private Inventory Inv;
    #endregion
    public void Use(int whatDo)
    {if(whatDo == 0)//Lo usa
    {Inv = GameObject.FindWithTag("Manager").GetComponent<Inventory>();
    Inv.RemoveItem(this, 1);}
    else if(whatDo == 1)//Lo vende
    {GameManager.instance.money += price;
    Inv = GameObject.FindWithTag("Manager").GetComponent<Inventory>();
    Inv.RemoveItem(this, 1);
     //Debug.Log("Hai Venduto!");
    }}
    public virtual void Equip()
    {}//Vai allo script Weapon per verificarne la function
    public virtual void Sell()
    {}//Vai allo script Consumable per verificarne la function
}