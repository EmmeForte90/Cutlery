using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EquipSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    //The item on the slot, if it's null the slot is considered empty
    Item item;
    [Header("Menu Equip")]
    //public GameObject buttonObject;
   //public Transform ItemContent_E;
 // Riferimenti ai componenti delle immagini di preview e delle descrizioni
    //public Image previewImages_A;
    //public Image previewImages_W;

    //public TextMeshProUGUI descriptions_E;
    //public TextMeshProUGUI Num_E;
    //public TextMeshProUGUI NameItems_E;
    //Weapon weapon;
    //private string NameSkin;

    // Each slots shows the icon and quantity of that item, the following are the references to those on the UI
    public Image itemImage;
    public TextMeshProUGUI quantity;
    //public TextMeshProUGUI Description;

    // The remove Button is where the player clicks to remove the item in this slot
    //public Button removeButton;


    // The following function is called everytime an item is added or removed from the inventory
    public void UpdateSlot(Item itemInSlot, int quantityInSlot)
    {
        item = itemInSlot;
       // Button buttonComponent = buttonObject.AddComponent<Button>();
        // Aggiungiamo un listener per gestire l'evento del clic sul pulsante
        
        //if (buttonComponent != null)
        //{buttonComponent.onClick.AddListener(OnButtonClick);}
        // If the item is null or the quantity 0 the slot is considered empty
        if (itemInSlot != null && quantityInSlot !=0)
        {
            // Slot has item: Enable the icon and Remove Button

            //removeButton.enabled = true;
            itemImage.enabled = true; 
            itemImage.sprite = itemInSlot.itemIcon;
            //Description.text = Des.ToString();
            //If the quantity on the slot is equal to one there is no necessity of enabling the quantity UI text
            if (quantityInSlot > 1)
            {
               
                quantity.enabled = true;
                quantity.text = quantityInSlot.ToString();
            }
            else
            {
                quantity.enabled = false;
                
            }

        }
        else
        {
            // Slot Empy: Disable the Icon, quantity and Remove Button
            
            //removeButton.enabled = false;
            itemImage.enabled = false;
            quantity.enabled = false;
        }

    }

    // Called if the player mouses over this slot
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Tells the UI that shows the information of an item to appear and show it
        GetComponentInParent<ItemInfoUpdate>().UpdateInfoPanel(item);
    }

    // Called if the player take the mouse out of the slot borders
    public void OnPointerExit(PointerEventData eventData)
    {
        // Calls the function that sets the panel inactive
        GetComponentInParent<ItemInfoUpdate>().ClosePanel();
    }
     public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down!");
    }
    public void UseItem()
    {
        //Checks if there is an item in the slot
        if (item != null)
        {
            // Use the item by calling the function of that specific item
             
            item.Equip();
            //AssignDress(weapon);
            //AssignWeapon(weapon);
        }

    }

    

    // Called when the player presses the Remove Button corresponding to this slot
    public void RemoveItem()
    {
        // Removes item from the Inventory Script and consequently updates the UI(This occurs inside of RemoveItem())
        // Currently removing one piece on stackable objects
        Inventory.instance.RemoveItem(Inventory.instance.itemList[Inventory.instance.itemList.IndexOf(item)], 1);
    }
}
