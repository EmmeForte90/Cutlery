using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EquipSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Item item;
    [Header("Menu Equip")]
    public Image itemImage;
    public TextMeshProUGUI quantity;

    public void UpdateSlot(Item itemInSlot, int quantityInSlot)
    {
        item = itemInSlot;
        if (itemInSlot != null && quantityInSlot !=0)
        {
            itemImage.enabled = true; 
            //itemImage.sprite = itemInSlot.itemIcon;
            if(itemInSlot.itemIcon != null){itemImage.sprite = itemInSlot.itemIcon;}
            else if (itemInSlot.itemIcon == null){itemImage.sprite = GameManager.instance.Inv.EquipsIcon[item.ID];}
            if (quantityInSlot > 1)
            {
                quantity.enabled = true;
                quantity.text = quantityInSlot.ToString();
            }
            else
            {quantity.enabled = false;}
        }
        else
        {
            itemImage.enabled = false;
            quantity.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData){GetComponentInParent<ItemInfoUpdate>().UpdateInfoPanel(item);}
    public void OnPointerExit(PointerEventData eventData){GetComponentInParent<ItemInfoUpdate>().ClosePanel();}
    public void UseItem(){if (item != null){item.Equip();}}
    public void RemoveItem()
    {GameManager.instance.Inv.RemoveItem(GameManager.instance.Inv.itemList[GameManager.instance.Inv.itemList.IndexOf(item)], 1);}
}