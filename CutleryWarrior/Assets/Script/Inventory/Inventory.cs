using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// IN THIS SCRIPT: Inventory Main Script that handles items and respective quantities aqquired
// WARNING: This script uses UNITY Editor to simplify the process of setting it up
// USE THIS SCRIPT by attaching it to any GameObject(Ex. PlayerPrefab, EmptyObject)
public class Inventory : MonoBehaviour
{
 
    // The items on the inventory
    public List<Item> itemList = new List<Item>();

    // The correponding quantities of each item
    public List<int> quantityList = new List<int>();
    public Image previewImages_AF;
    public Image previewImages_WF;
    public ChangeHeroSkin Skin_F;
    public PuppetSkin Puppets_F;

    public Image previewImages_AK;
    public Image previewImages_WK;
    public ChangeHeroSkin Skin_K;
    public PuppetSkin Puppets_K;

    public Image previewImages_AS;
    public Image previewImages_WS;
    public ChangeHeroSkin Skin_S;
    public PuppetSkin Puppets_S;
        
    public UIRotationSwitcher rotationSwitcher;

    // The inventoryPanel is the parent object of each slot
    public GameObject inventoryItem;
    public GameObject inventoryItemBattle;
    public GameObject inventoryQuestsItem;
    public GameObject inventoryKey;
    public GameObject inventoryEquip_F;
    public GameObject inventorySkill_F;
    public GameObject inventoryEquip_K;
    public GameObject inventorySkill_K;
    public GameObject inventoryEquip_S;
    public GameObject inventorySkill_S;

    // The slotListItem is the list of slots on the inventory, you can turn this List public and place the slots manually inside of it
    // Currently it's making the list based on the inventoryPanel children objects on GatherSlots() in line 86
    private readonly List<InventorySlot> slotListItem = new();

    #region Singleton

    public static Inventory instance;

    public void Awake()
    {
        instance = this;
    }

    #endregion

public void AssignDress(Weapon Item)
{
    switch (rotationSwitcher.CharacterID)
    {
    case 1:
            Skin_F.DressSkin = Item.NameSkin;
            AudioManager.instance.PlayUFX(6);  
            previewImages_WF.sprite = Item.itemIcon;
            Skin_F.UpdateCharacterSkin();
	    	Skin_F.UpdateCombinedSkin();
            //
            PlayerStats.instance.F_HP = 0;
            PlayerStats.instance.F_MP = 0;
            PlayerStats.instance.F_defense = 0;
            PlayerStats.instance.F_poisonResistance = 0;
            PlayerStats.instance.F_paralysisResistance = 0;
            PlayerStats.instance.F_sleepResistance = 0;
            PlayerStats.instance.F_rustResistance = 0;
            PlayerStats.instance.F_HP += Item.HP + PlayerStats.instance.F_HPCont;
            PlayerStats.instance.F_MP += Item.MP + PlayerStats.instance.F_MP;
            PlayerStats.instance.F_defense += Item.DefenceDress + PlayerStats.instance.F_defense;
            PlayerStats.instance.F_poisonResistance += Item.Res_Poison + PlayerStats.instance.F_poisonResistance;
            PlayerStats.instance.F_paralysisResistance += Item.Res_Stun + PlayerStats.instance.F_paralysisResistance;
            PlayerStats.instance.F_sleepResistance += Item.Res_Sleep + PlayerStats.instance.F_sleepResistance;
            PlayerStats.instance.F_rustResistance += Item.Res_Rust + PlayerStats.instance.F_rustResistance;
            Puppets_F.DressSkin = Item.NameSkin;
            Puppets_F.UpdateCharacterSkinUI(Item.NameSkin);
            Puppets_F.UpdateCombinedSkinUI(); 
    break;
    case 2:
            Skin_K.DressSkin = Item.NameSkin;
            AudioManager.instance.PlayUFX(6);  
            previewImages_WK.sprite = Item.itemIcon;
            Skin_K.UpdateCharacterSkin();
	    	Skin_K.UpdateCombinedSkin();
            //
            PlayerStats.instance.K_HP = 0;
            PlayerStats.instance.K_MP = 0;
            PlayerStats.instance.K_defense = 0;
            PlayerStats.instance.K_poisonResistance = 0;
            PlayerStats.instance.K_paralysisResistance = 0;
            PlayerStats.instance.K_sleepResistance = 0;
            PlayerStats.instance.K_rustResistance = 0;
            PlayerStats.instance.K_HP += Item.HP += PlayerStats.instance.K_HPCont;
            PlayerStats.instance.K_MP += Item.MP += PlayerStats.instance.K_MP;
            PlayerStats.instance.K_defense += Item.DefenceDress + PlayerStats.instance.K_defense;
            PlayerStats.instance.K_poisonResistance += Item.Res_Poison + PlayerStats.instance.K_poisonResistance;
            PlayerStats.instance.K_paralysisResistance += Item.Res_Stun + PlayerStats.instance.K_paralysisResistance;
            PlayerStats.instance.K_sleepResistance += Item.Res_Sleep + PlayerStats.instance.K_sleepResistance;
            PlayerStats.instance.K_rustResistance += Item.Res_Rust + PlayerStats.instance.K_rustResistance;
            Puppets_K.DressSkin = Item.NameSkin;
            Puppets_K.UpdateCharacterSkinUI(Item.NameSkin);
            Puppets_K.UpdateCombinedSkinUI(); 
    break;
    case 3:
            Skin_S.DressSkin = Item.NameSkin;
            AudioManager.instance.PlayUFX(6);  
            previewImages_WS.sprite = Item.itemIcon;
            Skin_S.UpdateCharacterSkin();
	    	Skin_S.UpdateCombinedSkin();
            //
            PlayerStats.instance.S_HP = 0;
            PlayerStats.instance.S_MP = 0;
            PlayerStats.instance.S_defense = 0;
            PlayerStats.instance.S_poisonResistance = 0;
            PlayerStats.instance.S_paralysisResistance = 0;
            PlayerStats.instance.S_sleepResistance = 0;
            PlayerStats.instance.S_rustResistance = 0;
            PlayerStats.instance.S_HP += Item.HP + PlayerStats.instance.S_HPCont;
            PlayerStats.instance.S_MP += Item.MP + PlayerStats.instance.S_MP;
            PlayerStats.instance.S_defense += Item.DefenceDress + PlayerStats.instance.S_defense;
            PlayerStats.instance.S_poisonResistance += Item.Res_Poison + PlayerStats.instance.S_poisonResistance;
            PlayerStats.instance.S_paralysisResistance += Item.Res_Stun + PlayerStats.instance.S_paralysisResistance;
            PlayerStats.instance.S_sleepResistance += Item.Res_Sleep + PlayerStats.instance.S_sleepResistance;
            PlayerStats.instance.S_rustResistance += Item.Res_Rust + PlayerStats.instance.S_rustResistance;
            Puppets_S.DressSkin = Item.NameSkin;
            Puppets_S.UpdateCharacterSkinUI(Item.NameSkin);
            Puppets_S.UpdateCombinedSkinUI(); 
    break;  
    }          
}

public void AssignWeapon(Weapon Item)
{
    switch (rotationSwitcher.CharacterID)
    {
    case 1:
            Skin_F.Weapon = Item.NameSkin;            
            AudioManager.instance.PlayUFX(6);  
            previewImages_AF.sprite = Item.itemIcon;
            Skin_F.UpdateCharacterSkin();
		    Skin_F.UpdateCombinedSkin();
            PlayerStats.instance.F_attack = 0; 
            PlayerStats.instance.F_attack += Item.weaponDamage;
            Puppets_F.Weapon = Item.NameSkin;
            Puppets_F.UpdateCharacterSkinUI(Item.NameSkin);
            Puppets_F.UpdateCombinedSkinUI();  
    break;
    case 2:
            Skin_K.Weapon = Item.NameSkin;
            AudioManager.instance.PlayUFX(6);  
            previewImages_AK.sprite = Item.itemIcon;
            Skin_K.UpdateCharacterSkin();
		    Skin_K.UpdateCombinedSkin(); 
            PlayerStats.instance.K_attack = 0;
            PlayerStats.instance.K_attack += Item.weaponDamage;
            Puppets_K.Weapon = Item.NameSkin;
            Puppets_K.UpdateCharacterSkinUI(Item.NameSkin);
            Puppets_K.UpdateCombinedSkinUI();   
    break;
    case 3:
            Skin_S.Weapon = Item.NameSkin;
            AudioManager.instance.PlayUFX(6);  
            previewImages_AS.sprite = Item.itemIcon;
            Skin_S.UpdateCharacterSkin();
		    Skin_S.UpdateCombinedSkin(); 
            PlayerStats.instance.S_attack = 0; 
            PlayerStats.instance.S_attack += Item.weaponDamage;
            Puppets_S.Weapon = Item.NameSkin;
            Puppets_S.UpdateCharacterSkinUI(Item.NameSkin);
            Puppets_S.UpdateCombinedSkinUI();   
    break;
            
}}




    public void Start()
    {
        // Add the slots of the Inventory Panel to the list

        foreach (InventorySlot child in inventoryItem.GetComponentsInChildren<InventorySlot>())
        {slotListItem.Add(child);}
        foreach (InventorySlot child in inventoryItemBattle.GetComponentsInChildren<InventorySlot>())
        {slotListItem.Add(child);}
    }
    // AddItem() can be called in other scripts with the following line:
    //Inventory.instance.Add(ItemYouWantToGiveHere , quantityOfThatItem);
    // Currently it's being called by the AddItemToInventory Script on the Add Items Buttons 
    #region ItemInventory
    public void AddItem(Item itemAdded, int quantityAdded)
    {
        //If the Item is Stackable it checks if there is already that item in the inventory and only adds the quantity
  
        if (itemAdded.Stackable)
        {
            if (itemList.Contains(itemAdded))
            {
                quantityList[itemList.IndexOf(itemAdded)] = quantityList[itemList.IndexOf(itemAdded)] + quantityAdded;
            }
            else
            {

                if (itemList.Count < slotListItem.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(quantityAdded);
                }
                else { }
               
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
                else {  }
               
            }
            
        }
        
        // Update Inventory everytime an item is added
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
        // This int is to count how many slots are full
        int ind = 0;

        // For each slot in the list it's attributed an Item from the itemList and the corresponding quantity
      foreach(InventorySlot slot in slotListItem)
        {

            if (itemList.Count != 0)
            {
                // If the ind is greater than the item quantity, the rest is considered empty slot

                if (ind < itemList.Count)
                {
                    // Calls the UpdateSlot() function on the respective slot and attributes the item and quantity of their unique index in the itemList
                    slot.UpdateSlot(itemList[ind], quantityList[ind]);
                    ind = ind + 1;
                }
                else
                {
                    //Update Empty Slot
                    slot.UpdateSlot(null, 0);
                }
            }
            else
            {
                //Update Empty Slot
                slot.UpdateSlot(null, 0);
            }

        }
    }
#endregion
 
}
