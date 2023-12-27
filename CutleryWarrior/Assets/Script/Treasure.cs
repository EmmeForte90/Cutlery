using UnityEngine;

public class Treasure : MonoBehaviour
{
    public GameObject Brain; 
    //public GameObject iconM; 
    public int IdChest;
    public Animator Anm;
    [Header("Item")]
    public Item specificItem;
    private int Id;
    [Header("Solo se è in item da Quest")]
    public GameObject Icon;
    public GameObject VFXTake;
    public GameObject VFXSegnalator;
    public int specificQuant;
    [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-Weapom 4-Armor")]
    private int KindItem;
    public bool IsQuest = false; 
    public bool canOpen = true;
    public Quests Quest;
    [Header("Skill List")]
    public bool IsSkill = false;
    [Tooltip("Che tipo di skill? 0-Fork 1-Knife 2-Spoon")]
    [Range(0, 2)]
    public int KindSkill;
    [Tooltip("Attiva la skill su numerazione")]
    [Range(0, 9)]
    public int IdSkill;
    public void Start()
    {
    KindItem = specificItem.KindItem; Id = specificItem.ID;
    if (ContainsIdEvent(PlayerStats.instance.Treasure, IdChest))
    {Destroy(gameObject);}
    }
    bool ContainsIdEvent(bool[] array, int idEvent)
    {
        // Controlla se l'indice idEvent è valido nell'array
        if (idEvent >= 0 && idEvent < array.Length)
        {
            // Restituisci true se l'elemento nell'array corrispondente all'idEvent è true
            return array[idEvent];
        }

        // Restituisci false se l'indice idEvent non è valido
        return false;
    }
    public void Update()
    {
        if(IsQuest){
        if(GameManager.instance.QuM.QuestSegnal[Quest.id]){Icon.SetActive(true);} 
        else if(!GameManager.instance.QuM.QuestSegnal[Quest.id]){Icon.SetActive(false);}
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
    public void OnTriggerStay(Collider other)
    {
    if (other.CompareTag("F_Player") && GameManager.instance.CharacterID == 1)
    {Touch();}
    else if (other.CompareTag("K_Player") && GameManager.instance.CharacterID == 2)
    {Touch();}
    else if (other.CompareTag("S_Player") && GameManager.instance.CharacterID == 3)
    {Touch();}
    }
    public void Touch()
    {
        if(canOpen){GameManager.instance.Esclamation();}
        else if(!canOpen){GameManager.instance.EsclamationStop();}
        if(Input.GetMouseButtonDown(0) && canOpen)
        {
        canOpen = false;
        Icon.SetActive(false);
        Anm.Play("Treasure_Anm");
        Instantiate(VFXTake, transform.position, transform.rotation);
        GameManager.instance.AM.PlaySFX(11);
        GameManager.instance.EsclamationStop();
        AddSpecificItem();
        //iconM.SetActive(false);
        VFXSegnalator.SetActive(false);
        GameManager.instance.Inv.Reward(specificItem, specificQuant);
        if(IsQuest){Quest.isComplete = true; Quest.isActive = false;}
        PlayerStats.instance.TreasureOpen(Id);
        }
    }
    public void OnTriggerExit(Collider other)
    {
    if (other.CompareTag("F_Player") && GameManager.instance.CharacterID == 1)
    {ExitTouch();}
    else if (other.CompareTag("K_Player") && GameManager.instance.CharacterID == 2)
    {ExitTouch();}
    else if (other.CompareTag("S_Player") && GameManager.instance.CharacterID == 3)
    {ExitTouch();}
    }
    public void ExitTouch(){GameManager.instance.EsclamationStop();}
     void AddSpecificItem()
    {
        switch(KindItem)
        {
            case 0:
            GameManager.instance.Inv.AddItem(specificItem, specificQuant);  
            //GameManager.instance.InvB.AddItem(specificItem, specificQuant);
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
    }
}