using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    #region Header
    public List<Item> itemList = new List<Item>();
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
    public GameObject inventoryItem;
    public GameObject inventoryQuestsItem;
    public GameObject inventoryKey;
    public GameObject inventoryEquip_F;
    public GameObject inventorySkill_F;
    public GameObject inventoryEquip_K;
    public GameObject inventorySkill_K;
    public GameObject inventoryEquip_S;
    public GameObject inventorySkill_S;
    private readonly List<InventorySlot> slotListItem = new();
    public GameObject RewardScreen;
    public Image previewReward;
    public TextMeshProUGUI QunatityR;
    public TextMeshProUGUI NameReward;
     [Header("Item List")]
    public bool[] items;
    #endregion
    #region Singleton
    public static Inventory instance;
    public void Awake(){instance = this; DontDestroyOnLoad(gameObject);}
    #endregion
       public void DeactivateItem()
    {
        // Cerca tutti i GameObjects con il tag "Enemy"
        GameObject[] ItemIT = GameObject.FindGameObjectsWithTag("Items");
    
    foreach (GameObject Character in ItemIT)
        {
            // Ottiene il componente QuestCharacters
            PickUpItem Takeitem = Character.GetComponent<PickUpItem>();

            // Verifica se il componente esiste
            if (Takeitem != null)
            {
                // Verifica se l'id della quest corrisponde all'id di un gameobject in OrdaliaActive
                int Id = Takeitem.Id;
                for (int i = 0; i <  items.Length; i++)
                {
                    if ( items[i] && i == Id)
                    {
                        Takeitem.Take();
                        break;
                    }
                }
            }
        }
    }
    public void itemsArea(int Take){items[Take] = true;}
    #region Equip
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
            PlayerStats.instance.F_MP += Item.MP + PlayerStats.instance.F_MPCont;
            PlayerStats.instance.F_defense += Item.DefenceDress + PlayerStats.instance.F_defenseCont;
            PlayerStats.instance.F_poisonResistance += Item.Res_Poison + PlayerStats.instance.F_poisonResistanceCont;
            PlayerStats.instance.F_paralysisResistance += Item.Res_Stun + PlayerStats.instance.F_paralysisResistanceCont;
            PlayerStats.instance.F_sleepResistance += Item.Res_Sleep + PlayerStats.instance.F_sleepResistanceCont;
            PlayerStats.instance.F_rustResistance += Item.Res_Rust + PlayerStats.instance.F_rustResistanceCont;
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
            PlayerStats.instance.K_MP += Item.MP += PlayerStats.instance.K_MPCont;
            PlayerStats.instance.K_defense += Item.DefenceDress + PlayerStats.instance.K_defenseCont;
            PlayerStats.instance.K_poisonResistance += Item.Res_Poison + PlayerStats.instance.K_poisonResistanceCont;
            PlayerStats.instance.K_paralysisResistance += Item.Res_Stun + PlayerStats.instance.K_paralysisResistanceCont;
            PlayerStats.instance.K_sleepResistance += Item.Res_Sleep + PlayerStats.instance.K_sleepResistanceCont;
            PlayerStats.instance.K_rustResistance += Item.Res_Rust + PlayerStats.instance.K_rustResistanceCont;
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
            PlayerStats.instance.S_MP += Item.MP + PlayerStats.instance.S_MPCont;
            PlayerStats.instance.S_defense += Item.DefenceDress + PlayerStats.instance.S_defenseCont;
            PlayerStats.instance.S_poisonResistance += Item.Res_Poison + PlayerStats.instance.S_poisonResistanceCont;
            PlayerStats.instance.S_paralysisResistance += Item.Res_Stun + PlayerStats.instance.S_paralysisResistanceCont;
            PlayerStats.instance.S_sleepResistance += Item.Res_Sleep + PlayerStats.instance.S_sleepResistanceCont;
            PlayerStats.instance.S_rustResistance += Item.Res_Rust + PlayerStats.instance.S_rustResistanceCont;
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
#endregion
    public void Start()
    {foreach (InventorySlot child in inventoryItem.GetComponentsInChildren<InventorySlot>()){slotListItem.Add(child);}} 
    #region ItemInventory
    public void AddItem(Item itemAdded, int quantityAdded)
    {
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
                }else{}  
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
                }else{}
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
                else{slot.UpdateSlot(null, 0);}
            }
            else{slot.UpdateSlot(null, 0);}
        }
    }
#endregion
    public void Reward(Item itemAdded, int quantityAdded)
    {
        StartCoroutine(RewardC());
        previewReward.sprite = itemAdded.itemIcon;
        QunatityR.text = quantityAdded.ToString();    
        NameReward.text =  itemAdded.itemName.ToString();
    }
    IEnumerator RewardC()
    {            
        RewardScreen.SetActive(true);
        yield return new WaitForSeconds(5); 
        RewardScreen.SetActive(false);
    }
}