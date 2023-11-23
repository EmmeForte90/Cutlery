using System.Collections.Generic;
using UnityEngine;

public class ItemBattle : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    public List<int> quantityList = new List<int>();
    private readonly List<InventorySlot> slotListItem = new();
    public GameObject inventoryItem;
    public void Update()
    {
        itemList = Inventory.instance.itemList;
        quantityList = Inventory.instance.quantityList;
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
                else{slot.UpdateSlot(null, 0);}
            }
            else{slot.UpdateSlot(null, 0);}
        }
    }
}