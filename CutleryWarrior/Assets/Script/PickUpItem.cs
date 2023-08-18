using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
       
    // In case of random, this list becomes active in the Editor
    //public List<Item> itemsToGive = new List<Item>();

    // In case of specific, this two parameters become active in the Editor
    public Item specificItem;
    public GameObject VFXTake;
    public int specificQuant;
    
    [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-Weapom 4-Armor")]
    private int KindItem;

    public void Awake() 
    {KindItem = specificItem.KindItem;}

       public void OnTriggerEnter(Collider collision)
{
    // Controlliamo se il player ha toccato il collider
    if (collision.gameObject.CompareTag("F_Player") || collision.gameObject.CompareTag("S_Player") || collision.gameObject.CompareTag("K_Player"))
    {
        Instantiate(VFXTake, transform.position, transform.rotation);
        AudioManager.instance.PlayUFX(5);
        AddSpecificItem();
    }
}



void AddSpecificItem()
    {
        switch(KindItem)
        {
            case 0:
            Inventory.instance.AddItem(specificItem, specificQuant);  
            InventoryB.instance.AddItem(specificItem, specificQuant);
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
