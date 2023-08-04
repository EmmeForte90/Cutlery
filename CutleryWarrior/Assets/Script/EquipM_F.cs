using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EquipM_F : MonoBehaviour
{
    // The items on the inventory
    public List<Item> itemList = new List<Item>();

    // The correponding quantities of each item
    public List<int> quantityList = new List<int>();


    // The inventoryPanel is the parent object of each slot
    public GameObject inventoryQuestsItem;

    // The slotListItem is the list of slots on the inventory, you can turn this List public and place the slots manually inside of it
    // Currently it's making the list based on the inventoryPanel children objects on GatherSlots() in line 86
  List<EquipSlot> slotListItem = new List<EquipSlot>();

    #region Singleton

    public static EquipM_F instance;

    public void Awake()
    {
        instance = this;
    }

    #endregion


    public void Start()
    {
        // Add the slots of the Inventory Panel to the list

        foreach (EquipSlot child in inventoryQuestsItem.GetComponentsInChildren<EquipSlot>())
        {slotListItem.Add(child);}
    }
    // AddItem() can be called in other scripts with the following line:
    //Inventory.instance.Add(ItemYouWantToGiveHere , quantityOfThatItem);
    // Currently it's being called by the AddItemToInventory Script on the Add Items Buttons 
    #region QuestItemInventory
    public void AddItem(Item itemAdded, int quantityAdded)
{
    // Se l'oggetto è impilabile (stackable), controlla se è già presente nell'inventario e aggiorna solo la quantità
    if (itemAdded.Stackable)
    {
        if (itemList.Contains(itemAdded))
        {
            int index = itemList.IndexOf(itemAdded);
            quantityList[index] += quantityAdded;
        }
        else
        {
            // Se l'oggetto non è già presente nell'inventario, aggiungilo solo se ci sono spazi disponibili
            if (itemList.Count < slotListItem.Count)
            {
                itemList.Add(itemAdded);
                quantityList.Add(quantityAdded);
            }
            else
            {
                // L'inventario è pieno, non puoi aggiungere l'oggetto
                Debug.LogWarning("L'inventario è pieno, non puoi aggiungere l'oggetto.");
            }
        }
    }
    else
    {
        // Se l'oggetto non è impilabile, aggiungi tanti oggetti quanti è specificato dalla quantità
        for (int i = 0; i < quantityAdded; i++)
        {
            // Verifica se ci sono spazi disponibili nell'inventario
            if (itemList.Count < slotListItem.Count)
            {
                itemList.Add(itemAdded);
                quantityList.Add(1);
            }
            else
            {
                // L'inventario è pieno, non puoi aggiungere altri oggetti
                Debug.LogWarning("L'inventario è pieno, non puoi aggiungere altri oggetti.");
                break; // Esci dal ciclo for per evitare di aggiungere altri oggetti
            }
        }
    }

    // Aggiorna l'interfaccia grafica dell'inventario ogni volta che un oggetto viene aggiunto
    UpdateInventoryUI();
}


    // As the previous function, this can be called from another script
    // Currently called by the Remove Button in each InventorySlot Prefab
    public void RemoveItem(Item itemRemoved, int quantityRemoved)
    {
        // If the item is stackable it removes the quantity and if it's 0 or less it removes the item completely from the itemList
        if (itemRemoved.Stackable)
        {
            if (itemList.Contains(itemRemoved))
            {
                quantityList[itemList.IndexOf(itemRemoved)] = quantityList[itemList.IndexOf(itemRemoved)] - quantityRemoved;

                if (quantityList[itemList.IndexOf(itemRemoved)]<= 0)
                {
                    quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                    itemList.RemoveAt(itemList.IndexOf(itemRemoved));
                }
            }
            
        }
        else
        {

            
            for (int i = 0; i < quantityRemoved; i++)
            {
                quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                itemList.RemoveAt(itemList.IndexOf(itemRemoved));
              
            }
        }
        // Update Inventory everytime an item is removed
        UpdateInventoryUI();
    }

    // Ogni volta che un oggetto viene aggiunto o rimosso dall'inventario, viene eseguita la funzione UpdateInventoryUI
public void UpdateInventoryUI()
{
    // Questo int serve per contare quanti slot sono pieni
    int ind = 0;

    // Per ogni slot nella lista, viene assegnato un oggetto dalla itemList e la corrispondente quantità
    foreach (EquipSlot slot in slotListItem)
    {
        if (itemList.Count != 0)
        {
            // Se ind è minore della quantità di oggetti nella itemList, l'elemento è considerato uno slot pieno
            if (ind < itemList.Count)
            {
                // Chiama la funzione UpdateSlot() sul rispettivo slot e assegna l'oggetto e la quantità in base al loro indice univoco nella itemList
                slot.UpdateSlot(itemList[ind], quantityList[ind]);
                ind++;
            }
            else
            {
                // Aggiorna lo slot vuoto
                slot.UpdateSlot(null, 0);
            }
        }
        else
        {
            // Aggiorna lo slot vuoto
            slot.UpdateSlot(null, 0);
        }
    }
}

#endregion

}


