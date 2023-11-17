using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class InventorySlotBattle : MonoBehaviour
{
    #region Header
    Item item;
    private SwitchCharacter rotationSwitcher;
    private ChargeSkill UseItemCharacter;
    private Weapon weapon;
    private string NameSkin;
    public Image itemImage;
    public TextMeshProUGUI quantity;
    private Inventory Inv;
    private InventoryB InvB;

    #endregion
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
    public void UseItem()
    {
        if (item != null)
        {
            rotationSwitcher = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();
            switch(rotationSwitcher.rotationSwitcher.CharacterID)
        {
            case 1:
            UseItemCharacter = GameObject.Find("F_Player").GetComponent<ChargeSkill>();
            UseItemCharacter.ItemData(item);//Richiama lo script chargeskill per preparare l'oggetto da lanciare
            Inv = GameObject.FindWithTag("Manager").GetComponent<Inventory>();
            InvB = GameObject.FindWithTag("Manager").GetComponent<InventoryB>();
            Inv.RemoveItem(item, 1); InvB.RemoveItem(item, 1);//Lo rimuove dall'inventario
            break;
            case 2:
            UseItemCharacter = GameObject.Find("K_Player").GetComponent<ChargeSkill>();
            InvB = GameObject.FindWithTag("Manager").GetComponent<InventoryB>();
            Inv.RemoveItem(item, 1); InvB.RemoveItem(item, 1);
            UseItemCharacter.ItemData(item);
            break;
            case 3:
            UseItemCharacter = GameObject.Find("S_Player").GetComponent<ChargeSkill>();
            InvB = GameObject.FindWithTag("Manager").GetComponent<InventoryB>();
            Inv.RemoveItem(item, 1); InvB.RemoveItem(item, 1);
            UseItemCharacter.ItemData(item);
            break;
        }
        }
    
    }
    
    public void RemoveItem(){Inventory.instance.RemoveItem(Inventory.instance.itemList[Inventory.instance.itemList.IndexOf(item)], 1);}
}
