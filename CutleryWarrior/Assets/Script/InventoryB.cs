using System.Collections.Generic;
using UnityEngine;

public class InventoryB : MonoBehaviour
{
   // The items on the inventory
    public List<Item> itemList = new List<Item>();

    // The correponding quantities of each item
    public List<int> quantityList = new List<int>();    
    public GameObject inventoryItem;
    // The slotListItem is the list of slots on the inventory, you can turn this List public and place the slots manually inside of it
    // Currently it's making the list based on the inventoryPanel children objects on GatherSlots() in line 86
    private readonly List<InventorySlotBattle> slotListItem = new();

    #region Singleton

    public static InventoryB instance;

    public void Awake()
    {instance = this;}

    #endregion

    public void Start()
    {
        foreach (InventorySlotBattle child in inventoryItem.GetComponentsInChildren<InventorySlotBattle>())
        {slotListItem.Add(child);}
    }
    // AddItem() can be called in other scripts with the following line:
    //Inventory.instance.Add(ItemYouWantToGiveHere , quantityOfThatItem);
    // Currently it's being called by the AddItemToInventory Script on the Add Items Buttons 
    #region ItemInventory
  public void AddItem(Item itemAdded, int quantityAdded)
{
    int index = itemList.IndexOf(itemAdded);

    if (itemAdded.Stackable)
    {
        if (index != -1 && index < quantityList.Count)
        {
            quantityList[index] += quantityAdded;
        }
        else
        {
            if (itemList.Count < slotListItem.Count)
            {
                itemList.Add(itemAdded);
                quantityList.Add(quantityAdded);
            }
            else
            {
                // Gestisci il caso in cui la lista è piena
            }
        }
    }
    else
    {
        for (int i = 0; i < quantityAdded; i++)
        {
            if (itemList.Count < slotListItem.Count)
            {
                itemList.Add(itemAdded);
                quantityList.Add(1);
            }
            else
            {
                // Gestisci il caso in cui la lista è piena
            }
        }
    }

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

    // Everytime an item is Added or Removed from the Inventory, the UpdateInventoryUI runs
  public void UpdateInventoryUI()
{
    int slotIndex = 0;

    for (int i = 0; i < itemList.Count && slotIndex < slotListItem.Count; i++)
    {
        slotListItem[slotIndex].UpdateSlot(itemList[i], quantityList[i]);
        slotIndex++;
    }

    // Se ci sono slotListItem rimanenti senza corrispondenza in itemList, aggiornali a null
    for (; slotIndex < slotListItem.Count; slotIndex++)
    {
        slotListItem[slotIndex].UpdateSlot(null, 0);
    }
}


#endregion
}