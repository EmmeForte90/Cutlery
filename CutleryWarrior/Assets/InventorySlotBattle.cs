using System.Collections;
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
    public Button button;

    private bool Using = true;

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
            button.onClick.AddListener(UseItem);
        }
        else{itemImage.enabled = false;quantity.enabled = false;}
    }
    public void OnPointerEnter(PointerEventData eventData){GetComponentInParent<ItemInfoUpdate>().UpdateInfoPanel(item);}
    public void OnPointerExit(PointerEventData eventData){GetComponentInParent<ItemInfoUpdate>().ClosePanel();}

    private void Update() 
    {
         if(!Using){StartCoroutine(RestoreItem());}
    }
    public void UseItem()
    {
        if (item != null)
        {
            InvB = GameObject.FindWithTag("Manager").GetComponent<InventoryB>();
            if(Using){InvB.RemoveItem(item, 1);  Using = false;}//Lo rimuove dall'inventario
            rotationSwitcher = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();
            switch(rotationSwitcher.rotationSwitcher.CharacterID)
        {
            case 1:
            UseItemCharacter = GameManager.instance.F_Hero.GetComponent<ChargeSkill>();
            UseItemCharacter.ItemData(item);//Richiama lo script chargeskill per preparare l'oggetto da lanciare
            break;
            case 2:
            UseItemCharacter = GameManager.instance.K_Hero.GetComponent<ChargeSkill>();
            UseItemCharacter.ItemData(item);
            break;
            case 3:
            UseItemCharacter = GameManager.instance.S_Hero.GetComponent<ChargeSkill>();
            UseItemCharacter.ItemData(item);
            break;
        }
        }
    }
        IEnumerator RestoreItem()
    {    
        yield return new WaitForSeconds(0.001f);
        Using = true; 
    }
    public void RemoveItem(){Inventory.instance.RemoveItem(Inventory.instance.itemList[Inventory.instance.itemList.IndexOf(item)], 1);}
}
