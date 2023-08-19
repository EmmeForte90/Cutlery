using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class QuestsManager : MonoBehaviour
{
    #region Header
    public List<Item> itemList = new List<Item>();
    public List<int> quantityList = new List<int>();
    public GameObject inventoryQuestsItem;
    List<InventorySlot> slotListItem = new List<InventorySlot>();
    #endregion

    #region Singleton
    public static QuestsManager instance;
    public void Awake(){instance = this;}
    #endregion
    public void Start()
    {
    foreach (InventorySlot child in inventoryQuestsItem.GetComponentsInChildren<InventorySlot>()){slotListItem.Add(child);}
    }
    
    #region QuestItemInventory
    public void AddItem(Item itemAdded, int quantityAdded)
    {  
        if (itemAdded.Stackable)
        {
            if (itemList.Contains(itemAdded))
            {quantityList[itemList.IndexOf(itemAdded)] = quantityList[itemList.IndexOf(itemAdded)] + quantityAdded;}
            else
            {
                if (itemList.Count < slotListItem.Count)
                {itemList.Add(itemAdded); quantityList.Add(quantityAdded);}
                else{}
            }
        }
        else
        {
            for (int i = 0; i < quantityAdded; i++)
            {
                if (itemList.Count < slotListItem.Count){itemList.Add(itemAdded); quantityList.Add(1);}
                else {}
            }
        }
        UpdateInventoryUI();
    }

    public void RemoveItem(Item itemRemoved, int quantityRemoved)
    {
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
        UpdateInventoryUI();
    }
    public void UpdateInventoryUI()
    {
    int ind = 0;
      foreach(InventorySlot slot in slotListItem)
        {
            if (itemList.Count != 0)
            {
                if (ind < itemList.Count)
                {
                    slot.UpdateSlot(itemList[ind], quantityList[ind]);
                    ind = ind + 1;
                }
                else
                {slot.UpdateSlot(null, 0);}
            }
            else
            {slot.UpdateSlot(null, 0);}
        }
    }
#endregion
}