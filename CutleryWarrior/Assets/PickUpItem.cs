using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
       
    // In case of random, this list becomes active in the Editor
    //public List<Item> itemsToGive = new List<Item>();

    // In case of specific, this two parameters become active in the Editor
    public Item specificItem;
    //public bool Weapon, Item, Armor, Key, Quest;
    public int specificQuant;
    
    [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-Weapom 4-Armor")]
    private int KindItem;

    private void Awake() 
    {KindItem = specificItem.KindItem;}

       private void OnTriggerEnter(Collider collision)
{
    // Controlliamo se il player ha toccato il collider
    if (collision.gameObject.CompareTag("Player"))
    {
        AddSpecificItem();
    }
}


void AddSpecificItem()
    {
        switch(KindItem)
        {
            case 0:
            Inventory.instance.AddItem(specificItem, specificQuant);            
            break;
            case 1:
            QuestsManager.instance.AddItem(specificItem, specificQuant);            
            break;
            case 2:
            KeyManager.instance.AddItem(specificItem, specificQuant);            
            break;
            case 3:
            EquipM_F.instance.AddItem(specificItem, specificQuant);            
            break;
            case 4:
            EquipM_K.instance.AddItem(specificItem, specificQuant);            
            break;
            case 5:
            EquipM_S.instance.AddItem(specificItem, specificQuant);            
            break;
        }
        Destroy(gameObject);
    }
}
