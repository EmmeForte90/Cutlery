using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    #region Header
    [Header("Stats")]
    public bool HaveData = false;
    public bool CanLoading = false;
    public int IdSpawn;
    public string NameScene;
    public Vector3 savedPosition;
    public bool F_Unlock = true; 
    public  bool S_Unlock = false; 
    public  bool K_Unlock = false;
    public int Money = 100;
    public int WhatMusic = 0;
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
    [SerializeField] public float F_attack = 10;
    [SerializeField] public float F_defense = 5;
    [SerializeField] public float F_poisonResistance = 0;
    [SerializeField] public float F_paralysisResistance = 0;
    [SerializeField] public float F_sleepResistance = 0;
    [SerializeField] public float F_rustResistance = 0;
    //
    [HideInInspector] public float F_HPCont;
    [HideInInspector] public float F_curHPCont;
    [HideInInspector] public float F_MPCont;
    [HideInInspector] public float F_curMPCont;
    [HideInInspector] public float F_CostMPCont;
    [HideInInspector] public float F_ExpCont;
    [HideInInspector] public float F_curExpCont;
    [HideInInspector] public float F_attackCont;
    [HideInInspector] public float F_defenseCont;
    [HideInInspector] public float F_poisonResistanceCont;
    [HideInInspector] public float F_paralysisResistanceCont;
    [HideInInspector] public float F_sleepResistanceCont;
    [HideInInspector] public float F_rustResistanceCont;
    //
    public Skill Skill_F_0;
    public Skill Skill_F_1;
    public Skill Skill_F_2;
    public Skill Skill_F_3;
    public Skill Skill_F_4;
    public Skill Skill_F_5;
    public Skill Skill_F_6;
    public Skill Skill_F_7;
    public Skill Skill_F_8;
    //    
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
    [SerializeField] public float S_attack = 10;
    [SerializeField] public float S_defense = 5;
    [SerializeField] public float S_poisonResistance = 0;
    [SerializeField] public float S_paralysisResistance = 0;
    [SerializeField] public float S_sleepResistance = 0;
    [SerializeField] public float S_rustResistance = 0; 
    //
    [HideInInspector] public float S_HPCont;
    [HideInInspector] public float S_curHPCont;
    [HideInInspector] public float S_MPCont;
    [HideInInspector] public float S_curMPCont;
    [HideInInspector] public float S_CostMPCont;
    [HideInInspector] public float S_ExpCont;
    [HideInInspector] public float S_curExpCont;
    [HideInInspector] public float S_attackCont;
    [HideInInspector] public float S_defenseCont;
    [HideInInspector] public float S_poisonResistanceCont;
    [HideInInspector] public float S_paralysisResistanceCont;
    [HideInInspector] public float S_sleepResistanceCont;
    [HideInInspector] public float S_rustResistanceCont;
    //
    public Skill Skill_S_0;
    public Skill Skill_S_1;
    public Skill Skill_S_2;
    public Skill Skill_S_3;
    public Skill Skill_S_4;
    public Skill Skill_S_5;
    public Skill Skill_S_6;
    public Skill Skill_S_7;
    public Skill Skill_S_8;
    //    
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
    [SerializeField] public float K_attack = 10;
    [SerializeField] public float K_defense = 5;
    [SerializeField] public float K_poisonResistance = 0;
    [SerializeField] public float K_paralysisResistance = 0;
    [SerializeField] public float K_sleepResistance = 0;
    [SerializeField] public float K_rustResistance = 0; 
    //
    [HideInInspector] public float K_HPCont;
    [HideInInspector] public float K_curHPCont;
    [HideInInspector] public float K_MPCont;
    [HideInInspector] public float K_curMPCont;
    [HideInInspector] public float K_CostMPCont;
    [HideInInspector] public float K_ExpCont;
    [HideInInspector] public float K_curExpCont;
    [HideInInspector] public float K_attackCont;
    [HideInInspector] public float K_defenseCont;
    [HideInInspector] public float K_poisonResistanceCont;
    [HideInInspector] public float K_paralysisResistanceCont;
    [HideInInspector] public float K_sleepResistanceCont;
    [HideInInspector] public float K_rustResistanceCont;
    //
    public Skill Skill_K_0;
    public Skill Skill_K_1;
    public Skill Skill_K_2;
    public Skill Skill_K_3;
    public Skill Skill_K_4;
    public Skill Skill_K_5;
    public Skill Skill_K_6;
    public Skill Skill_K_7;
    public Skill Skill_K_8;
    //    
    [HideInInspector] public string F_NameWeapon = "Weapon/Latta";
    [HideInInspector] public string S_NameWeapon = "Weapon/Latta";
    [HideInInspector] public string K_NameWeapon = "Weapon/Latta";
    [HideInInspector] public string F_NameArmor = "Dress/Dress";
    [HideInInspector] public string S_NameArmor = "Dress/Dress";
    [HideInInspector] public string K_NameArmor = "Dress/Dress";
    //
    [Header("Item List")]
    [SerializeField]    public List<Item> I_itemList;
    [SerializeField]    public List<int> I_quantityList;
    [SerializeField]    public List<Item> IBattle_itemList;
    [SerializeField]    public List<int> IBattle_quantityList;
    [SerializeField]    public List<Item> F_itemList;
    [SerializeField]    public List<int> F_quantityList;
    [SerializeField]    public List<Item> S_itemList;
    [SerializeField]    public List<int> S_quantityList;
    [SerializeField]    public List<Item> K_itemList;
    [SerializeField]    public List<int> K_quantityList;
    [SerializeField]    public List<Item> Kay_itemList;
    [SerializeField]    public List<int> Key_quantityList;
    [SerializeField]    public List<Item> Quest_itemList;
    [SerializeField]    public List<int> Quest_quantityList;
    //
    [Header("Enemies List")]
    public bool[] Enemies;
    [Header("Treasure List")]
    public bool[] Treasure;
    [Header("Skill List")]
    public bool[] Skill_F;
    public bool[] Skill_K; 
    public bool[] Skill_S;
    
    [Header("Events")]
    public bool[] EventsDesert;  
    public bool[] SwitchDesert;
    public bool[] Timelines;
    public bool[] MinieraSwitch;
    [Header("Switch")]
    public int SwitchMiniera = 0;
    [Header("Quests")]
    public List<Quests> questDatabase;
    public bool[] quest;
    public bool[] QuestActive;
    public bool[] QuestComplete;
    public bool[] QuestSegnal;

    [Header("Item List")]
    public bool[] items;

    [Header("Bool Boss")]
    public bool MinerBoss = false;


    public static PlayerStats instance;


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
    items = Inventory.instance.items;
    //
    questDatabase = QuestsManager.instance.questDatabase;
    quest = QuestsManager.instance.quest;
    QuestActive = QuestsManager.instance.QuestActive;
    QuestComplete = QuestsManager.instance.QuestComplete;
    QuestSegnal = QuestsManager.instance.QuestSegnal;
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
    Kay_itemList = KeyManager.instance.itemList;
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

    
    public void UpdateInventorySaving()
    {
    Money = GameManager.instance.money;
    F_Unlock = GameManager.instance.F_Unlock;
    K_Unlock = GameManager.instance.K_Unlock;
    S_Unlock = GameManager.instance.S_Unlock;
    //
    items = GameManager.instance.Inv.items;
    //
    questDatabase = GameManager.instance.QuM.questDatabase;
    quest = GameManager.instance.QuM.quest;
    QuestActive = GameManager.instance.QuM.QuestActive;
    QuestComplete = GameManager.instance.QuM.QuestComplete;
    QuestSegnal = GameManager.instance.QuM.QuestSegnal;
    //
    I_itemList = GameManager.instance.Inv.itemList;
    I_quantityList = GameManager.instance.Inv.quantityList;
    //
    IBattle_itemList = GameManager.instance.InvB.itemList;
    IBattle_quantityList = GameManager.instance.InvB.quantityList;
    //
    F_itemList = GameManager.instance.M_F.itemList;
    F_quantityList = GameManager.instance.M_F.quantityList;
    //
    K_itemList = GameManager.instance.M_K.itemList;
    K_quantityList = GameManager.instance.M_K.quantityList;
    //
    S_itemList = GameManager.instance.M_S.itemList;
    S_quantityList = GameManager.instance.M_S.quantityList;
    //
    Kay_itemList = GameManager.instance.KM.itemList;
    Key_quantityList = GameManager.instance.KM.quantityList;
    //
    Quest_itemList = GameManager.instance.QuM.itemList;
    Quest_quantityList = GameManager.instance.QuM.quantityList;
    }

    public void RestoreForNewGame()
    {
    Money = 100;
    F_Unlock = true;
    K_Unlock = false;
    S_Unlock = false;
    //
    I_itemList = null;
    I_quantityList = null;
    //
    F_itemList = null;
    F_quantityList = null;
    //
    K_itemList = null;
    K_quantityList = null;
    //
    S_itemList = null;
    S_quantityList = null;
    //
    Kay_itemList = null;
    Key_quantityList = null;
    //
    Quest_itemList = null;
    Quest_quantityList = null;
    //
    DisableSpecificArrayElements(Skill_F,1,2,3,4,5,6,7,8,9);
    DisableSpecificArrayElements(Skill_K,1,2,3,4,5,6,7,8,9);
    DisableSpecificArrayElements(Skill_S,1,2,3,4,5,6,7,8,9);
     //
    SetAllArrayElementsToFalse(Treasure);
    SetAllArrayElementsToFalse(Enemies);
    SetAllArrayElementsToFalse(EventsDesert);
    SetAllArrayElementsToFalse(SwitchDesert);
    SetAllArrayElementsToFalse(Timelines);
    SetAllArrayElementsToFalse(MinieraSwitch);
    SetAllArrayElementsToFalse(quest);
    SetAllArrayElementsToFalse(QuestActive);
    SetAllArrayElementsToFalse(QuestComplete);
    SetAllArrayElementsToFalse(QuestSegnal);
    SetAllArrayElementsToFalse(items);
    //
    SwitchMiniera = 0;
    }
    void SetAllArrayElementsToFalse(bool[] array){System.Array.Fill(array, false);}
    void DisableSpecificArrayElements(bool[] array, params int[] indices)
    {
        foreach (int index in indices)
        {
            if (index >= 0 && index < array.Length)
            {
                array[index] = false;
            }
            else
            {
                Debug.LogError("Index out of bounds: " + index);
            }
        }
    }


    public void FSkillATT(int Act)
    {Skill_F[Act] = true; GameManager.instance.Skill_FI[Act].SetActive(true); 
    GameManager.instance.Skill_FIB[Act].SetActive(true);}
    public void SSkillATT(int Act)
    {Skill_S[Act] = true; GameManager.instance.Skill_SI[Act].SetActive(true);
     GameManager.instance.Skill_SIB[Act].SetActive(true);}
    public void KSkillATT(int Act)
    {Skill_K[Act] = true; GameManager.instance.Skill_KI[Act].SetActive(true);
     GameManager.instance.Skill_KIB[Act].SetActive(true);}

    //public void EnemyDefeatArea(int Defeat){Enemies[Defeat] = true;}
    public void TreasureOpen(int Open)
    {
        Treasure[Open] = true;
    }

    public void EventDesertEnd(int id)
    {
        EventsDesert[id] = true;
    }

    public void EventSwitchEnd(int id)
    {
        SwitchDesert[id] = true;
    }

    public void TimelineEnd(int id)
    {
        Timelines[id] = true;
    }

    public void MinieraSwitchEnd(int id)
    {
        MinieraSwitch[id] = true;
    }


    #region Levelup
    public void F_LevelUp()
    {
        F_HP += 50;
        F_MP = +50;
        F_attack += 5;
        F_defense += 5;
        F_poisonResistance += 3;
        F_paralysisResistance += 2;
        F_sleepResistance += 3;
        F_rustResistance += 1;
        F_HPCont = F_HP;
        F_MPCont = F_MP;
        F_attackCont = F_attack;
        F_defenseCont = F_defense;
        F_poisonResistanceCont = F_poisonResistance;
        F_paralysisResistanceCont = F_paralysisResistance;
        F_sleepResistanceCont = F_sleepResistance;
        F_rustResistanceCont = F_rustResistance;
        F_LV++;
        F_Exp += 100; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
        F_curExp = 0;
        GameManager.instance.StatPlayer();
    }
    public void K_LevelUp()
    {
        K_HP += 100;
        K_MP = +30;
        K_attack += 10;
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
        K_Exp += 100; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
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
        S_Exp += 100; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
        S_curExp = 0;
        GameManager.instance.StatPlayer();
    }
#endregion
#region ResetStatForNewGame
public void ResetStatNewGame()
{
    //SaveManager.instance.ResetValueStat();
    HaveData = false;
    CanLoading = false;
    NameScene = null;
    savedPosition = new Vector3(0,0,0);
    F_Unlock = true; 
    S_Unlock = false; 
    K_Unlock = false;
    Money = 100;
    WhatMusic = 0;
    StartData = false;
    //
    F_LV = 1;
    F_HP = 100;
    F_curHP = 0;
    F_MP = 100;
    F_curMP = 0;
    F_curRage = 0;
    F_Rage = 100;
    F_CostMP = 0;
    F_Exp = 0;
    F_curExp = 0;
    F_attack = 10;
    F_defense = 5;
    F_poisonResistance = 0;
    F_paralysisResistance = 0;
    F_sleepResistance = 0;
    F_rustResistance = 0;
    //
    S_LV = 1;
    S_HP = 100;
    S_curHP = 0;
    S_MP = 100;
    S_curMP = 0;
    S_curRage = 0;
    S_Rage = 100;
    S_CostMP = 0;
    S_Exp = 0;
    S_curExp = 0;
    S_attack = 10;
    S_defense = 5;
    S_poisonResistance = 0;
    S_paralysisResistance = 0;
    S_sleepResistance = 0;
    S_rustResistance = 0; 
    //
    K_LV = 1;
    K_HP = 100;
    K_curHP = 0;
    K_MP = 100;
    K_curMP = 0;
    K_CostMP = 0;
    K_curRage = 0;
    K_Rage = 100;
    K_Exp = 0;
    K_curExp = 0;
    K_attack = 10;
    K_defense = 5;
    K_poisonResistance = 0;
    K_paralysisResistance = 0;
    K_sleepResistance = 0;
    K_rustResistance = 0; 
    //
    Enemies = new bool[10]; 
    SetAllElementsFalse(Enemies);
    //
    Treasure = new bool[10]; 
    SetAllElementsFalse(Treasure);
    //
    Skill_F = new bool[10]; 
    SetAllElementsFalse(Skill_F);
    Skill_K = new bool[10]; 
    SetAllElementsFalse(Skill_K);
    Skill_S = new bool[10]; 
    SetAllElementsFalse(Skill_S);
    //
    I_itemList = null;
    I_quantityList = null;
    IBattle_itemList = null;
    IBattle_quantityList = null;
    F_itemList = null;
    F_quantityList = null;
    S_itemList = null;
    S_quantityList = null;
    K_itemList = null;
    K_quantityList = null;
    Kay_itemList = null;
    Key_quantityList = null;
    Quest_itemList = null;
    Quest_quantityList = null;
    //
    EventsDesert = new bool[10]; 
    SetAllElementsFalse(EventsDesert);
    SwitchDesert = new bool[10]; 
    SetAllElementsFalse(SwitchDesert);
    //
    questDatabase = null;
    quest = new bool[10]; 
    SetAllElementsFalse(quest);
    QuestActive = new bool[10]; 
    SetAllElementsFalse(QuestActive);
    QuestComplete = new bool[10]; 
    SetAllElementsFalse(QuestComplete);
    QuestSegnal = new bool[10]; 
    SetAllElementsFalse(QuestSegnal);
    //
    items = new bool[10]; 
    SetAllElementsFalse(items);
}
void SetAllElementsFalse(bool[] array){for (int i = 0; i < array.Length; i++){array[i] = false;}}

#endregion
}