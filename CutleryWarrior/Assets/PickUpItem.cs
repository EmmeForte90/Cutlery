using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
       
    // In case of random, this list becomes active in the Editor
    //public List<Item> itemsToGive = new List<Item>();

    // In case of specific, this two parameters become active in the Editor
    public Item specificItem;
    public int specificQuant;
       
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
        Inventory.instance.AddItem(specificItem, specificQuant);
        Destroy(gameObject);
    }
}
