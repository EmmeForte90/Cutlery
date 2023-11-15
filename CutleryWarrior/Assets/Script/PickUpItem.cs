using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickUpItem : MonoBehaviour
{
    #region Header
    public Item specificItem;
    public bool StartGame = false;
    public int Id;
    [Header("Solo se è in item da Quest")]
    public GameObject Icon;
    public GameObject VFXTake;
    public int specificQuant;
    [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-Weapom 4-Armor")]
    private int KindItem;
    private bool takeitem = true;
    public bool IsQuest = false;
    public Quests Quest;
    [Header("Skill List")]
    public bool IsSkill = false;
    [Tooltip("Che tipo di skill? 0-Fork 1-Knife 2-Spoon")]
    [Range(0, 2)]
    public int KindSkill;
    [Tooltip("Attiva la skill su numerazione")]
    [Range(0, 9)]
    public int IdSkill;

    #endregion
    public void Awake(){KindItem = specificItem.KindItem; Id = specificItem.ID;}
    public void Take(){Destroy(gameObject);}
    public void Update()
    {
        if(IsQuest){
        if(QuestsManager.instance.QuestSegnal[Quest.id]){Icon.SetActive(true);} 
        else if(!QuestsManager.instance.QuestSegnal[Quest.id]){Icon.SetActive(false);}
        }else if(IsSkill)
        {
            
            switch(KindSkill)
            {
                case 0:
                PlayerStats.instance.FSkillATT(IdSkill);
                break;
                case 1:
                PlayerStats.instance.KSkillATT(IdSkill);
                break;
                case 2:
                PlayerStats.instance.SSkillATT(IdSkill);
                break;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {Touch();}
    else if (other.CompareTag("K_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {Touch();}
    else if (other.CompareTag("S_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {Touch();}
    }
    public void Touch()
    {
        if(takeitem)
        {
        Instantiate(VFXTake, transform.position, transform.rotation);
        AudioManager.instance.PlayUFX(5);
        AddSpecificItem();
        if(!StartGame){Inventory.instance.Reward(specificItem, specificQuant);}
        if(IsQuest){Quest.isComplete = true; Quest.isActive = false;}
        Inventory.instance.itemsArea(Id);
        takeitem = false;
        }
    }
    void AddSpecificItem()
    {
        switch(KindItem)
        {
            case 0:
            Inventory.instance.AddItem(specificItem, specificQuant);  
            InventoryB.instance.AddItem(specificItem, specificQuant);
            break;
            case 1:
            QuestsManager.instance.AddItem(specificItem, specificQuant);            
            break;
            case 2:
            KeyManager.instance.AddItem(specificItem, specificQuant);            
            break;
            case 3:
            EquipM_F.instance.AddItem(specificItem, specificQuant);            
            break;
            case 4:
            EquipM_K.instance.AddItem(specificItem, specificQuant);            
            break;
            case 5:
            EquipM_S.instance.AddItem(specificItem, specificQuant);            
            break;
        }
        Destroy(gameObject);
    }
}