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
    [Header("EquipStart")]
    public bool isStartEquip = false;
    public Weapon Equip;
    [Range(0, 1)]
        [Tooltip("0, Dress - 1, Weapon")]

    public int TypesE;

    #endregion
    public void Awake(){KindItem = specificItem.KindItem; Id = specificItem.ID;}
    public void Take(){Destroy(gameObject);}
    public void Update()
    {
        if(IsQuest){
        if(GameManager.instance.activeMinimap){if(GameManager.instance.QuM.QuestSegnal[Quest.id]){Icon.SetActive(true);} 
        else if(!GameManager.instance.QuM.QuestSegnal[Quest.id]){Icon.SetActive(false);}}
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
    if (other.CompareTag("F_Player") && GameManager.instance.CharacterID == 1)
    {Touch();}
    else if (other.CompareTag("K_Player") && GameManager.instance.CharacterID == 2)
    {Touch();}
    else if (other.CompareTag("S_Player") && GameManager.instance.CharacterID ==  3)
    {Touch();}
    }
    public void Touch()
    {
        if(takeitem)
        {
        Instantiate(VFXTake, transform.position, transform.rotation);
        GameManager.instance.AM.PlayUFX(5);
        AddSpecificItem();
        if(!StartGame){GameManager.instance.Inv.Reward(specificItem, specificQuant);}
        if(IsQuest){Quest.isComplete = true; Quest.isActive = false;}
        //GameManager.instance.Inv.itemsArea(Id);
        if(isStartEquip)
        {if (TypesE == 1){GameManager.instance.Inv.AssignWeapon(Equip);}
        else if (TypesE == 0){GameManager.instance.Inv.AssignDress(Equip);} 
        if(GameManager.instance.F_Unlock){
        PlayerStats.instance.F_curHP = PlayerStats.instance.F_HP;
        PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        //
        if(GameManager.instance.K_Unlock){
        PlayerStats.instance.K_curHP = PlayerStats.instance.K_HP;
        PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        //
        if(GameManager.instance.S_Unlock){
        PlayerStats.instance.S_curHP = PlayerStats.instance.S_HP;
        PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}
        }
        takeitem = false;
        }
    }
    void AddSpecificItem()
    {
        switch(KindItem)
        {
            case 0:
            GameManager.instance.Inv.AddItem(specificItem, specificQuant);  
            GameManager.instance.InvB.AddItem(specificItem, specificQuant);
            break;
            case 1:
            GameManager.instance.QuM.AddItem(specificItem, specificQuant);            
            break;
            case 2:
            GameManager.instance.KM.AddItem(specificItem, specificQuant);            
            break;
            case 3:
            GameManager.instance.M_F.AddItem(specificItem, specificQuant);            
            break;
            case 4:
            GameManager.instance.M_K.AddItem(specificItem, specificQuant);            
            break;
            case 5:
            GameManager.instance.M_S.AddItem(specificItem, specificQuant);            
            break;
        }
        Destroy(gameObject);
    }
}