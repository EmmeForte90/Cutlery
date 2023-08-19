using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// IN THIS SCRIPT: Inventory Slot Handler that shows the player one item and it's quantity based on the Inventory Script
public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Item item;
    //[Header("Menu Equip")]
    //public Image previewImages_A;
    //public Image previewImages_W;
    Weapon weapon;
    private string NameSkin;
    public Image itemImage;
    public TextMeshProUGUI quantity;
    public void UpdateSlot(Item itemInSlot, int quantityInSlot)
    {
        item = itemInSlot;
        if (itemInSlot != null && quantityInSlot !=0)
        {
            itemImage.enabled = true; 
            itemImage.sprite = itemInSlot.itemIcon;
            if (quantityInSlot > 1)
            {quantity.enabled = true;quantity.text = quantityInSlot.ToString();}
            else{quantity.enabled = false;}
        }
        else{itemImage.enabled = false;quantity.enabled = false;}
    }
    public void OnPointerEnter(PointerEventData eventData){GetComponentInParent<ItemInfoUpdate>().UpdateInfoPanel(item);}
    public void OnPointerExit(PointerEventData eventData){GetComponentInParent<ItemInfoUpdate>().ClosePanel();}
    public void UseItem(){if (item != null){item.Use(0);}}
    //public void SellItem(){if (item != null){item.Sell();}}
    public void RemoveItem(){Inventory.instance.RemoveItem(Inventory.instance.itemList[Inventory.instance.itemList.IndexOf(item)], 1);}
}