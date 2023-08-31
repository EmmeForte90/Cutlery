using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickUpItem : MonoBehaviour
{
    #region Header
    public Item specificItem;
    public GameObject Icon;
    public GameObject VFXTake;
    public int specificQuant;
    [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-Weapom 4-Armor")]
    private int KindItem;
    public bool IsQuest = false;
    public Quests Quest;
    #endregion
    public void Awake(){KindItem = specificItem.KindItem;}
    public void Update()
    {
        if(IsQuest){
        if(QuestsManager.instance.QuestSegnal[Quest.id]){Icon.SetActive(true);} 
        else if(!QuestsManager.instance.QuestSegnal[Quest.id]){Icon.SetActive(false);}
        }
    }
    public void OnTriggerEnter(Collider collision)
    {if (collision.gameObject.CompareTag("F_Player") || collision.gameObject.CompareTag("S_Player") || collision.gameObject.CompareTag("K_Player"))
    {
        Instantiate(VFXTake, transform.position, transform.rotation);
        AudioManager.instance.PlayUFX(5);
        AddSpecificItem();
        Inventory.instance.Reward(specificItem, specificQuant);
        if(IsQuest){Quest.isComplete = true; Quest.isActive = false;}
    }}
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