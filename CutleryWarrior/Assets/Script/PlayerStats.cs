using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.SqlTypes;

[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    #region Header
    [Header("Stats")]
    public bool HaveData = false;
    public bool CanLoading = false;
    public string NameScene;
    public Vector3 savedPosition;
    public bool F_Unlock = true; 
    public  bool S_Unlock = false; 
    public  bool K_Unlock = false;
    public int Money;
    public  bool StartData = false;

    [Header("Fork")]
    [SerializeField] public int F_LV = 1;
    [SerializeField] public float F_HP = 0;
    [SerializeField] public float F_curHP = 0;
    [SerializeField] public float F_MP = 0;
    [SerializeField] public float F_curMP = 0;
    [SerializeField] public float F_curRage = 0;
    [SerializeField] public float F_Rage = 100;
    [SerializeField] public float F_CostMP = 0;
    [SerializeField] public float F_Exp = 0;
    [SerializeField] public float F_curExp = 0;
    [SerializeField] public int F_attack = 10;
    [SerializeField] public int F_defense = 5;
    [SerializeField] public int F_poisonResistance = 0;
    [SerializeField] public int F_paralysisResistance = 0;
    [SerializeField] public int F_sleepResistance = 0;
    [SerializeField] public int F_rustResistance = 0;
    //
    [HideInInspector] public float F_HPCont;
    [HideInInspector] public float F_curHPCont;
    [HideInInspector] public float F_MPCont;
    [HideInInspector] public float F_curMPCont;
    [HideInInspector] public float F_CostMPCont;
    [HideInInspector] public float F_ExpCont;
    [HideInInspector] public float F_curExpCont;
    [HideInInspector] public int F_attackCont;
    [HideInInspector] public int F_defenseCont;
    [HideInInspector] public int F_poisonResistanceCont;
    [HideInInspector] public int F_paralysisResistanceCont;
    [HideInInspector] public int F_sleepResistanceCont;
    [HideInInspector] public int F_rustResistanceCont;
    [Header("Spoon")]
    [SerializeField] public int S_LV = 1;
    [SerializeField] public float S_HP = 0;
    [SerializeField] public float S_curHP = 0;
    [SerializeField] public float S_MP = 0;
    [SerializeField] public float S_curMP = 0;
    [SerializeField] public float S_curRage = 0;
    [SerializeField] public float S_Rage = 100;
    [SerializeField] public float S_CostMP = 0;
    [SerializeField] public float S_Exp = 0;
    [SerializeField] public float S_curExp = 0;
    [SerializeField] public int S_attack = 10;
    [SerializeField] public int S_defense = 5;
    [SerializeField] public int S_poisonResistance = 0;
    [SerializeField] public int S_paralysisResistance = 0;
    [SerializeField] public int S_sleepResistance = 0;
    [SerializeField] public int S_rustResistance = 0; 
    //
    [HideInInspector] public float S_HPCont;
    [HideInInspector] public float S_curHPCont;
    [HideInInspector] public float S_MPCont;
    [HideInInspector] public float S_curMPCont;
    [HideInInspector] public float S_CostMPCont;
    [HideInInspector] public float S_ExpCont;
    [HideInInspector] public float S_curExpCont;
    [HideInInspector] public int S_attackCont;
    [HideInInspector] public int S_defenseCont;
    [HideInInspector] public int S_poisonResistanceCont;
    [HideInInspector] public int S_paralysisResistanceCont;
    [HideInInspector] public int S_sleepResistanceCont;
    [HideInInspector] public int S_rustResistanceCont;
    [Header("Knife")]
    [SerializeField] public int K_LV = 1;
    [SerializeField] public float K_HP = 0;
    [SerializeField] public float K_curHP = 0;
    [SerializeField] public float K_MP = 0;
    [SerializeField] public float K_curMP = 0;
    [SerializeField] public float K_CostMP = 0;
    [SerializeField] public float K_curRage = 0;
    [SerializeField] public float K_Rage = 100;
    [SerializeField] public float K_Exp = 0;
    [SerializeField] public float K_curExp = 0;
    [SerializeField] public int K_attack = 10;
    [SerializeField] public int K_defense = 5;
    [SerializeField] public int K_poisonResistance = 0;
    [SerializeField] public int K_paralysisResistance = 0;
    [SerializeField] public int K_sleepResistance = 0;
    [SerializeField] public int K_rustResistance = 0; 
    //
    [HideInInspector] public float K_HPCont;
    [HideInInspector] public float K_curHPCont;
    [HideInInspector] public float K_MPCont;
    [HideInInspector] public float K_curMPCont;
    [HideInInspector] public float K_CostMPCont;
    [HideInInspector] public float K_ExpCont;
    [HideInInspector] public float K_curExpCont;
    [HideInInspector] public int K_attackCont;
    [HideInInspector] public int K_defenseCont;
    [HideInInspector] public int K_poisonResistanceCont;
    [HideInInspector] public int K_paralysisResistanceCont;
    [HideInInspector] public int K_sleepResistanceCont;
    [HideInInspector] public int K_rustResistanceCont;
    //
    [Header("Enemies List")]
    public bool[] Enemies;
    [Header("Treasure List")]
    public bool[] Treasure;
    public static PlayerStats instance;
    [Header("Skill List")]
    public bool[] Skill_F;
    public bool[] Skill_K; 
    public bool[] Skill_S;
    
    [Header("Item List")]
    public List<Item> I_itemList = new List<Item>();
    public List<int> I_quantityList = new List<int>();
    public List<Item> IBattle_itemList = new List<Item>();
    public List<int> IBattle_quantityList = new List<int>();
    public List<Item> F_itemList = new List<Item>();
    public List<int> F_quantityList = new List<int>();
    public List<Item> S_itemList = new List<Item>();
    public List<int> S_quantityList = new List<int>();
    public List<Item> K_itemList = new List<Item>();
    public List<int> K_quantityList = new List<int>();
    public List<Item> Key_itemList = new List<Item>();
    public List<int> Key_quantityList = new List<int>();
    public List<Item> Quest_itemList = new List<Item>();
    public List<int> Quest_quantityList = new List<int>();
    
    [Header("Events")]
    public bool[] EventsDesert;    

    public static bool DataManager; 

    #endregion
    public void Awake(){
    if (instance == null){instance = this;} 
    if (DataManager){Destroy(gameObject);}
    else {DataManager = true; DontDestroyOnLoad(gameObject);} 
    }
    public void Update()
    {
    if(StartData){
    Money = GameManager.instance.money;
    F_Unlock = GameManager.instance.F_Unlock;
    K_Unlock = GameManager.instance.K_Unlock;
    S_Unlock = GameManager.instance.S_Unlock;
    //
    I_itemList = Inventory.instance.itemList;
    I_quantityList = Inventory.instance.quantityList;
    //
    IBattle_itemList = InventoryB.instance.itemList;
    IBattle_quantityList = InventoryB.instance.quantityList;
    //
    F_itemList = EquipM_F.instance.itemList;
    F_quantityList = EquipM_F.instance.quantityList;
    //
    K_itemList = EquipM_K.instance.itemList;
    K_quantityList = EquipM_K.instance.quantityList;
    //
    S_itemList = EquipM_S.instance.itemList;
    S_quantityList = EquipM_S.instance.quantityList;
    //
    Key_itemList = KeyManager.instance.itemList;
    Key_quantityList = KeyManager.instance.quantityList;
    //
    Quest_itemList = QuestsManager.instance.itemList;
    Quest_quantityList = QuestsManager.instance.quantityList;
    //
    if(GameManager.instance.F_Unlock){
    F_HPCont = F_HP;
    F_curHP = F_HP;
    F_MPCont = F_MP;
    F_curMP = F_MP;
    F_attackCont = F_attack;
    F_defenseCont = F_defense;
    F_poisonResistanceCont = F_poisonResistance;
    F_paralysisResistanceCont = F_paralysisResistance;
    F_sleepResistanceCont = F_sleepResistance;
    F_rustResistanceCont = F_rustResistance;}
    //
    if(GameManager.instance.K_Unlock){
    K_HPCont = K_HP;
    K_curHP = K_HP;
    K_MPCont = K_MP;
    K_curMP = K_MP;
    K_attackCont = K_attack;
    K_defenseCont = K_defense;
    K_poisonResistanceCont = K_poisonResistance;
    K_paralysisResistanceCont = K_paralysisResistance;
    K_sleepResistanceCont = K_sleepResistance;
    K_rustResistanceCont = K_rustResistance;}
    //
    if(GameManager.instance.S_Unlock){
    S_HPCont = S_HP;
    S_curHP = S_HP;
    S_MPCont = S_MP;
    S_curMP = S_MP;
    S_attackCont = S_attack;
    S_defenseCont = S_defense;
    S_poisonResistanceCont = S_poisonResistance;
    S_paralysisResistanceCont = S_paralysisResistance;
    S_sleepResistanceCont = S_sleepResistance;
    S_rustResistanceCont = S_rustResistance;}   
    }
    StartData = false;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ResetStatF()
    {
    if(GameManager.instance.F_Unlock){
    F_HPCont = F_HP;
    F_curHP = F_HP;
    F_MPCont = F_MP;
    F_curMP = F_MP;
    F_attackCont = F_attack;
    F_defenseCont = F_defense;
    F_poisonResistanceCont = F_poisonResistance;
    F_paralysisResistanceCont = F_paralysisResistance;
    F_sleepResistanceCont = F_sleepResistance;
    F_rustResistanceCont = F_rustResistance;}
    }
    public void ResetStatS()
    {
    if(GameManager.instance.S_Unlock){
    S_HPCont = S_HP;
    S_curHP = S_HP;
    S_MPCont = S_MP;
    S_curMP = S_MP;
    S_attackCont = S_attack;
    S_defenseCont = S_defense;
    S_poisonResistanceCont = S_poisonResistance;
    S_paralysisResistanceCont = S_paralysisResistance;
    S_sleepResistanceCont = S_sleepResistance;
    S_rustResistanceCont = S_rustResistance;}   
    }
    public void ResetStatK()
    {
    if(GameManager.instance.K_Unlock){
    K_HPCont = K_HP;
    K_curHP = K_HP;
    K_MPCont = K_MP;
    K_curMP = K_MP;
    K_attackCont = K_attack;
    K_defenseCont = K_defense;
    K_poisonResistanceCont = K_poisonResistance;
    K_paralysisResistanceCont = K_paralysisResistance;
    K_sleepResistanceCont = K_sleepResistance;
    K_rustResistanceCont = K_rustResistance;}  
    }

     public void EventDesertEnd(int id){EventsDesert[id] = true;}
    
    public void UpdateInventorySaving()
    {
    I_itemList = Inventory.instance.itemList;
    I_quantityList = Inventory.instance.quantityList;
    //
    F_itemList = EquipM_F.instance.itemList;
    F_quantityList = EquipM_F.instance.quantityList;
    //
    K_itemList = EquipM_K.instance.itemList;
    K_quantityList = EquipM_K.instance.quantityList;
    //
    S_itemList = EquipM_S.instance.itemList;
    S_quantityList = EquipM_S.instance.quantityList;
    //
    Key_itemList = KeyManager.instance.itemList;
    Key_quantityList = KeyManager.instance.quantityList;
    //
    Quest_itemList = QuestsManager.instance.itemList;
    Quest_quantityList = QuestsManager.instance.quantityList;
    }

    public void DeactivateWarning()
    {
        // Cerca tutti i GameObjects con il tag "Enemy"
        GameObject[] WarningEvent = GameObject.FindGameObjectsWithTag("Event");
    
    foreach (GameObject Character in WarningEvent)
        {
            // Ottiene il componente QuestCharacters
            CameraWarning Event = Character.GetComponent<CameraWarning>();

            // Verifica se il componente esiste
            if (Event != null)
            {
                // Verifica se l'id della quest corrisponde all'id di un gameobject in OrdaliaActive
                int Id = Event.IdEvent;
                for (int i = 0; i <  EventsDesert.Length; i++)
                {
                    if ( EventsDesert[i] && i == Id)
                    {
                        // Imposta ordaliT.FirstD a false
                        Event.Take();
                        break;
                    }
                }
            }
        }
    }




    public void DeactivateENM()
    {
        // Cerca tutti i GameObjects con il tag "Enemy"
        GameObject[] ENMIT = GameObject.FindGameObjectsWithTag("Enemy");
    
    foreach (GameObject Character in ENMIT)
        {
            // Ottiene il componente QuestCharacters
            TouchPlayer Enm = Character.GetComponent<TouchPlayer>();

            // Verifica se il componente esiste
            if (Enm != null)
            {
                // Verifica se l'id della quest corrisponde all'id di un gameobject in OrdaliaActive
                int Id = Enm.IdENM;
                for (int i = 0; i <  Enemies.Length; i++)
                {
                    if ( Enemies[i] && i == Id)
                    {
                        // Imposta ordaliT.FirstD a false
                        Enm.Take();
                        break;
                    }
                }
            }
        }
    }
    public void DeactivateCHEST()
    {
        // Cerca tutti i GameObjects con il tag "Enemy"
        GameObject[] Chest = GameObject.FindGameObjectsWithTag("Chest");
    
    foreach (GameObject Character in Chest)
        {
            // Ottiene il componente QuestCharacters
            Treasure tre = Character.GetComponent<Treasure>();

            // Verifica se il componente esiste
            if (tre != null)
            {
                // Verifica se l'id della quest corrisponde all'id di un gameobject in OrdaliaActive
                int Id = tre.IdChest;
                for (int i = 0; i <  Enemies.Length; i++)
                {
                    if ( Treasure[i] && i == Id)
                    {
                        // Imposta ordaliT.FirstD a false
                        tre.Take();
                        break;
                    }
                }
            }
        }
    }


    public void FSkillATT(int Act){Skill_F[Act] = true; GameManager.instance.Skill_FI[Act].SetActive(true); GameManager.instance.Skill_FIB[Act].SetActive(true);}
    public void SSkillATT(int Act){Skill_S[Act] = true; GameManager.instance.Skill_SI[Act].SetActive(true); GameManager.instance.Skill_SIB[Act].SetActive(true);}
    public void KSkillATT(int Act){Skill_K[Act] = true; GameManager.instance.Skill_KI[Act].SetActive(true); GameManager.instance.Skill_KIB[Act].SetActive(true);}

    public void EnemyDefeatArea(int Defeat){Enemies[Defeat] = true;}
    public void TreasureOpen(int Open){Treasure[Open] = true;}

    #region Levelup
    public void F_LevelUp()
    {
        F_HP += 50;
        F_MP = +50;
        F_attack += 10;
        F_defense += 5;
        F_poisonResistance += 2;
        F_paralysisResistance += 2;
        F_sleepResistance += 2;
        F_rustResistance += 2;
        F_HPCont = F_HP;
        F_MPCont = F_MP;
        F_attackCont = F_attack;
        F_defenseCont = F_defense;
        F_poisonResistanceCont = F_poisonResistance;
        F_paralysisResistanceCont = F_paralysisResistance;
        F_sleepResistanceCont = F_sleepResistance;
        F_rustResistanceCont = F_rustResistance;
        F_LV++;
        F_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
        F_curExp = 0;
        GameManager.instance.StatPlayer();
    }
    public void K_LevelUp()
    {
        K_HP += 100;
        K_MP = +30;
        K_attack += 20;
        K_defense += 5;
        K_poisonResistance += 1;
        K_paralysisResistance += 1;
        K_sleepResistance += 1;
        K_rustResistance += 1;
        K_HPCont = K_HP;
        K_MPCont = K_MP;
        K_attackCont = K_attack;
        K_defenseCont = K_defense;
        K_poisonResistanceCont = K_poisonResistance;
        K_paralysisResistanceCont = K_paralysisResistance;
        K_sleepResistanceCont = K_sleepResistance;
        K_rustResistanceCont = K_rustResistance;
        K_LV++;
        K_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
        K_curExp = 0;
        GameManager.instance.StatPlayer();
    }
    public void S_LevelUp()
    {
        S_HP += 50;
        S_MP = +40;
        S_attack += 5;
        S_defense += 10;
        S_poisonResistance += 3;
        S_paralysisResistance += 3;
        S_sleepResistance += 3;
        S_rustResistance += 3;
        S_HPCont = S_HP;
        S_MPCont = S_MP;
        S_attackCont = S_attack;
        S_defenseCont = S_defense;
        S_poisonResistanceCont = S_poisonResistance;
        S_paralysisResistanceCont = S_paralysisResistance;
        S_sleepResistanceCont = S_sleepResistance;
        S_rustResistanceCont = S_rustResistance;
        S_LV++;
        S_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
        S_curExp = 0;
        GameManager.instance.StatPlayer();
    }
#endregion
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private string percorsoSalvataggio;

    private void Awake()
    {
    
        percorsoSalvataggio = Path.Combine(Application.persistentDataPath, "datigioco.json");

    }
    // Salvataggio
    public void SalvaDati(PlayerStats dati)
    {
        string datiJson = JsonUtility.ToJson(dati);
        File.WriteAllText(percorsoSalvataggio, datiJson);
    }

    // Caricamento
    public PlayerStats CaricaDati()
    {
        if (File.Exists(percorsoSalvataggio))
        {
            string datiJson = File.ReadAllText(percorsoSalvataggio);
            return JsonUtility.FromJson<PlayerStats>(datiJson);
        }
        else
        {
            return new PlayerStats(); // Ritorna nuovi dati se il file non esiste
        }
    }

}