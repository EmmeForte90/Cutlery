using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    // Aggiungi qui le variabili che desideri salvare
    public float playerScore;
    public float playerHealth;
    // E così via...
    [Header("Stats")]
    public bool HaveData = false;
    public bool CanLoading = false;
    public string NameScene;
    public SaveVector3 savedPosition;
    public bool F_Unlock = true; 
    public  bool S_Unlock = false; 
    public  bool K_Unlock = false;
    public int Money;
    public int WhatMusic = 0;
    public  bool StartData = false;
    //
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
    public bool[] Enemies;
    public bool[] Treasure;
    public bool[] Skill_F;
    public bool[] Skill_K; 
    public bool[] Skill_S;

    public bool[] EventsDesert;  
    public bool[] SwitchDesert;

    //public List<Quests> questDatabase;
    public bool[] quest;
    public bool[] QuestActive;
    public bool[] QuestComplete;
    public bool[] QuestSegnal;

    /*
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
    [Header("Item List")]
    public bool[] items;*/
}

[Serializable]
public class SaveVector3
{
    public float x;
    public float y;
    public float z;

    public SaveVector3(Vector3 vector3)
    {
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}


public class SaveManager : MonoBehaviour
{
    private string saveFilePath;
    public static SaveManager instance;

    private void Start()
    {
        if (instance == null){instance = this;} 
        // Imposta il percorso del file di salvataggio
        saveFilePath = Application.persistentDataPath + "/save.txt";

    }

    public void SaveGame()
    {
        // Crea un'istanza del tuo oggetto di dati di gioco
        GameData gameData = new GameData();
        //gameData.playerScore = PlayerStats.instance.F_HP; // Sostituisci con il valore reale
        //gameData.playerHealth = PlayerStats.instance.F_MP; // Sostituisci con il valore reale
           gameData.HaveData = PlayerStats.instance.HaveData;
        gameData.CanLoading = PlayerStats.instance.CanLoading;
        gameData.NameScene = PlayerStats.instance.NameScene;
        gameData.F_Unlock = PlayerStats.instance.F_Unlock; 
        gameData.S_Unlock = PlayerStats.instance.S_Unlock; 
        gameData.K_Unlock = PlayerStats.instance.K_Unlock;
        gameData.Money = PlayerStats.instance.Money;
        gameData.WhatMusic = PlayerStats.instance.WhatMusic;
        //
        gameData.F_LV = PlayerStats.instance.F_LV;
        gameData.F_HP = PlayerStats.instance.F_HP;
        gameData.F_curHP = PlayerStats.instance.F_curHP;
        gameData.F_MP = PlayerStats.instance.F_MP;
        gameData.F_curMP = PlayerStats.instance.F_curMP;
        gameData.F_curRage = PlayerStats.instance.F_curRage;
        gameData.F_Rage = PlayerStats.instance.F_Rage;
        gameData.F_CostMP = PlayerStats.instance.F_CostMP;
        gameData.F_Exp = PlayerStats.instance.F_Exp;
        gameData.F_curExp = PlayerStats.instance.F_curExp;
        gameData.F_attack = PlayerStats.instance.F_attack;
        gameData.F_defense = PlayerStats.instance.F_defense;
        gameData.F_poisonResistance = PlayerStats.instance.F_poisonResistance;
        gameData.F_paralysisResistance = PlayerStats.instance.F_paralysisResistance;
        gameData.F_sleepResistance = PlayerStats.instance.F_sleepResistance;
        gameData.F_rustResistance = PlayerStats.instance.F_rustResistance;
        //
        gameData.F_HPCont = PlayerStats.instance.F_HPCont;
        gameData.F_curHPCont = PlayerStats.instance.F_curHPCont;
        gameData.F_MPCont = PlayerStats.instance.F_MPCont;
        gameData.F_curMPCont = PlayerStats.instance.F_curMPCont;
        gameData.F_CostMPCont = PlayerStats.instance.F_CostMPCont;
        gameData.F_ExpCont = PlayerStats.instance.F_ExpCont;
        gameData.F_curExpCont = PlayerStats.instance.F_curExpCont;
        gameData.F_attackCont = PlayerStats.instance.F_attackCont;
        gameData.F_defenseCont = PlayerStats.instance.F_defenseCont;
        gameData.F_poisonResistanceCont = PlayerStats.instance.F_poisonResistanceCont;
        gameData.F_paralysisResistanceCont = PlayerStats.instance.F_paralysisResistanceCont;
        gameData.F_sleepResistanceCont = PlayerStats.instance.F_sleepResistanceCont;
        gameData.F_rustResistanceCont = PlayerStats.instance.F_rustResistanceCont; 
        //
        gameData.S_LV = PlayerStats.instance.S_LV;
        gameData.S_HP = PlayerStats.instance.S_HP;
        gameData.S_curHP = PlayerStats.instance.S_curHP;
        gameData.S_MP = PlayerStats.instance.S_MP;
        gameData.S_curMP = PlayerStats.instance.S_curMP;
        gameData.S_curRage = PlayerStats.instance.S_curRage;
        gameData.S_Rage = PlayerStats.instance.S_Rage;
        gameData.S_CostMP = PlayerStats.instance.S_CostMP;
        gameData.S_Exp = PlayerStats.instance.S_Exp;
        gameData.S_curExp = PlayerStats.instance.S_curExp;
        gameData.S_attack = PlayerStats.instance.S_attack;
        gameData.S_defense = PlayerStats.instance.S_defense;
        gameData.S_poisonResistance = PlayerStats.instance.S_poisonResistance;
        gameData.S_paralysisResistance = PlayerStats.instance.S_paralysisResistance;
        gameData.S_sleepResistance = PlayerStats.instance.S_sleepResistance;
        gameData.S_rustResistance = PlayerStats.instance.S_rustResistance;
        //
        gameData.S_HPCont = PlayerStats.instance.S_HPCont;
        gameData.S_curHPCont = PlayerStats.instance.S_curHPCont;
        gameData.S_MPCont = PlayerStats.instance.S_MPCont;
        gameData.S_curMPCont = PlayerStats.instance.S_curMPCont;
        gameData.S_CostMPCont = PlayerStats.instance.S_CostMPCont;
        gameData.S_ExpCont = PlayerStats.instance.S_ExpCont;
        gameData.S_curExpCont = PlayerStats.instance.S_curExpCont;
        gameData.S_attackCont = PlayerStats.instance.S_attackCont;
        gameData.S_defenseCont = PlayerStats.instance.S_defenseCont;
        gameData.S_poisonResistanceCont = PlayerStats.instance.S_poisonResistanceCont;
        gameData.S_paralysisResistanceCont = PlayerStats.instance.S_paralysisResistanceCont;
        gameData.S_sleepResistanceCont = PlayerStats.instance.S_sleepResistanceCont;
        gameData.S_rustResistanceCont = PlayerStats.instance.S_rustResistanceCont; 
        //
        gameData.K_LV = PlayerStats.instance.K_LV;
        gameData.K_HP = PlayerStats.instance.K_HP;
        gameData.K_curHP = PlayerStats.instance.K_curHP;
        gameData.K_MP = PlayerStats.instance.K_MP;
        gameData.K_curMP = PlayerStats.instance.K_curMP;
        gameData.K_curRage = PlayerStats.instance.K_curRage;
        gameData.K_Rage = PlayerStats.instance.K_Rage;
        gameData.K_CostMP = PlayerStats.instance.K_CostMP;
        gameData.K_Exp = PlayerStats.instance.K_Exp;
        gameData.K_curExp = PlayerStats.instance.K_curExp;
        gameData.K_attack = PlayerStats.instance.K_attack;
        gameData.K_defense = PlayerStats.instance.K_defense;
        gameData.K_poisonResistance = PlayerStats.instance.K_poisonResistance;
        gameData.K_paralysisResistance = PlayerStats.instance.K_paralysisResistance;
        gameData.K_sleepResistance = PlayerStats.instance.K_sleepResistance;
        gameData.K_rustResistance = PlayerStats.instance.K_rustResistance;
        //
        gameData.K_HPCont = PlayerStats.instance.K_HPCont;
        gameData.K_curHPCont = PlayerStats.instance.K_curHPCont;
        gameData.K_MPCont = PlayerStats.instance.K_MPCont;
        gameData.K_curMPCont = PlayerStats.instance.K_curMPCont;
        gameData.K_CostMPCont = PlayerStats.instance.K_CostMPCont;
        gameData.K_ExpCont = PlayerStats.instance.K_ExpCont;
        gameData.K_curExpCont = PlayerStats.instance.K_curExpCont;
        gameData.K_attackCont = PlayerStats.instance.K_attackCont;
        gameData.K_defenseCont = PlayerStats.instance.K_defenseCont;
        gameData.K_poisonResistanceCont = PlayerStats.instance.K_poisonResistanceCont;
        gameData.K_paralysisResistanceCont = PlayerStats.instance.K_paralysisResistanceCont;
        gameData.K_sleepResistanceCont = PlayerStats.instance.K_sleepResistanceCont;
        gameData.K_rustResistanceCont = PlayerStats.instance.K_rustResistanceCont; 
        //
        gameData.Enemies = PlayerStats.instance.Enemies;
        gameData.Treasure = PlayerStats.instance.Treasure;
        //
        gameData.Skill_F  = PlayerStats.instance.Skill_F;
        gameData.Skill_K  = PlayerStats.instance.Skill_K;
        gameData.Skill_S  = PlayerStats.instance.Skill_S;
        //
        gameData.EventsDesert = PlayerStats.instance.EventsDesert; 
        gameData.SwitchDesert = PlayerStats.instance.SwitchDesert; 
        //
        gameData.F_Unlock = PlayerStats.instance.F_Unlock;
        gameData.K_Unlock = PlayerStats.instance.K_Unlock;
        gameData.S_Unlock = PlayerStats.instance.S_Unlock;
        //
        //gameData.questDatabase = PlayerStats.instance.questDatabase;
        gameData.quest = PlayerStats.instance.quest;
        gameData.QuestActive = PlayerStats.instance.QuestActive;
        gameData.QuestComplete = PlayerStats.instance.QuestComplete;
        gameData.QuestSegnal = PlayerStats.instance.QuestSegnal;

        //gameData.savedPosition = new SaveVector3(PlayerStats.instance.savedPosition);
        

        // Serializza l'oggetto di dati di gioco in binario
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Create(saveFilePath);
        formatter.Serialize(fileStream, gameData);
        fileStream.Close();

        Debug.Log("Gioco salvato con successo!");
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            // Deserializza l'oggetto di dati di gioco da binario
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.Open(saveFilePath, FileMode.Open);
            GameData gameData = (GameData)formatter.Deserialize(fileStream);
            fileStream.Close();
            //PlayerStats.instance.savedPosition = gameData.savedPosition.ToVector3();
            //PlayerStats.instance.HaveData = gameData.HaveData;
        PlayerStats.instance.HaveData = gameData.HaveData;
        PlayerStats.instance.CanLoading = gameData.CanLoading;
        PlayerStats.instance.NameScene = gameData.NameScene;
        PlayerStats.instance.F_Unlock = gameData.F_Unlock; 
        PlayerStats.instance.S_Unlock = gameData.S_Unlock; 
        PlayerStats.instance.K_Unlock = gameData.K_Unlock;
        PlayerStats.instance.Money = gameData.Money;
        PlayerStats.instance.WhatMusic = gameData.WhatMusic;
        //
        PlayerStats.instance.F_LV = gameData.F_LV;
        PlayerStats.instance.F_HP = gameData.F_HP;
        PlayerStats.instance.F_curHP = gameData.F_curHP;
        PlayerStats.instance.F_MP = gameData.F_MP;
        PlayerStats.instance.F_curMP = gameData.F_curMP;
        PlayerStats.instance.F_curRage = gameData.F_curRage;
        PlayerStats.instance.F_Rage = gameData.F_Rage;
        PlayerStats.instance.F_CostMP = gameData.F_CostMP;
        PlayerStats.instance.F_Exp = gameData.F_Exp;
        PlayerStats.instance.F_curExp = gameData.F_curExp;
        PlayerStats.instance.F_attack = gameData.F_attack;
        PlayerStats.instance.F_defense = gameData.F_defense;
        PlayerStats.instance.F_poisonResistance = gameData.F_poisonResistance;
        PlayerStats.instance.F_paralysisResistance = gameData.F_paralysisResistance;
        PlayerStats.instance.F_sleepResistance = gameData.F_sleepResistance;
        PlayerStats.instance.F_rustResistance = gameData.F_rustResistance;
        //
        PlayerStats.instance.F_HPCont = gameData.F_HPCont;
        PlayerStats.instance.F_curHPCont = gameData.F_curHPCont;
        PlayerStats.instance.F_MPCont = gameData.F_MPCont;
        PlayerStats.instance.F_curMPCont = gameData.F_curMPCont;
        PlayerStats.instance.F_CostMPCont = gameData.F_CostMPCont;
        PlayerStats.instance.F_ExpCont = gameData.F_ExpCont;
        PlayerStats.instance.F_curExpCont = gameData.F_curExpCont;
        PlayerStats.instance.F_attackCont = gameData.F_attackCont;
        PlayerStats.instance.F_defenseCont = gameData.F_defenseCont;
        PlayerStats.instance.F_poisonResistanceCont = gameData.F_poisonResistanceCont;
        PlayerStats.instance.F_paralysisResistanceCont = gameData.F_paralysisResistanceCont;
        PlayerStats.instance.F_sleepResistanceCont = gameData.F_sleepResistanceCont;
        PlayerStats.instance.F_rustResistanceCont = gameData.F_rustResistanceCont; 
        //
        PlayerStats.instance.S_LV = gameData.S_LV;
        PlayerStats.instance.S_HP = gameData.S_HP;
        PlayerStats.instance.S_curHP = gameData.S_curHP;
        PlayerStats.instance.S_MP = gameData.S_MP;
        PlayerStats.instance.S_curMP = gameData.S_curMP;
        PlayerStats.instance.S_curRage = gameData.S_curRage;
        PlayerStats.instance.S_Rage = gameData.S_Rage;
        PlayerStats.instance.S_CostMP = gameData.S_CostMP;
        PlayerStats.instance.S_Exp = gameData.S_Exp;
        PlayerStats.instance.S_curExp = gameData.S_curExp;
        PlayerStats.instance.S_attack = gameData.S_attack;
        PlayerStats.instance.S_defense = gameData.S_defense;
        PlayerStats.instance.S_poisonResistance = gameData.S_poisonResistance;
        PlayerStats.instance.S_paralysisResistance = gameData.S_paralysisResistance;
        PlayerStats.instance.S_sleepResistance = gameData.S_sleepResistance;
        PlayerStats.instance.S_rustResistance = gameData.S_rustResistance;
        //
        PlayerStats.instance.S_HPCont = gameData.S_HPCont;
        PlayerStats.instance.S_curHPCont = gameData.S_curHPCont;
        PlayerStats.instance.S_MPCont = gameData.S_MPCont;
        PlayerStats.instance.S_curMPCont = gameData.S_curMPCont;
        PlayerStats.instance.S_CostMPCont = gameData.S_CostMPCont;
        PlayerStats.instance.S_ExpCont = gameData.S_ExpCont;
        PlayerStats.instance.S_curExpCont = gameData.S_curExpCont;
        PlayerStats.instance.S_attackCont = gameData.S_attackCont;
        PlayerStats.instance.S_defenseCont = gameData.S_defenseCont;
        PlayerStats.instance.S_poisonResistanceCont = gameData.S_poisonResistanceCont;
        PlayerStats.instance.S_paralysisResistanceCont = gameData.S_paralysisResistanceCont;
        PlayerStats.instance.S_sleepResistanceCont = gameData.S_sleepResistanceCont;
        PlayerStats.instance.S_rustResistanceCont = gameData.S_rustResistanceCont; 
        //
        PlayerStats.instance.K_LV = gameData.K_LV;
        PlayerStats.instance.K_HP = gameData.K_HP;
        PlayerStats.instance.K_curHP = gameData.K_curHP;
        PlayerStats.instance.K_MP = gameData.K_MP;
        PlayerStats.instance.K_curMP = gameData.K_curMP;
        PlayerStats.instance.K_curRage = gameData.K_curRage;
        PlayerStats.instance.K_Rage = gameData.K_Rage;
        PlayerStats.instance.K_CostMP = gameData.K_CostMP;
        PlayerStats.instance.K_Exp = gameData.K_Exp;
        PlayerStats.instance.K_curExp = gameData.K_curExp;
        PlayerStats.instance.K_attack = gameData.K_attack;
        PlayerStats.instance.K_defense = gameData.K_defense;
        PlayerStats.instance.K_poisonResistance = gameData.K_poisonResistance;
        PlayerStats.instance.K_paralysisResistance = gameData.K_paralysisResistance;
        PlayerStats.instance.K_sleepResistance = gameData.K_sleepResistance;
        PlayerStats.instance.K_rustResistance = gameData.K_rustResistance;
        //
        PlayerStats.instance.K_HPCont = gameData.K_HPCont;
        PlayerStats.instance.K_curHPCont = gameData.K_curHPCont;
        PlayerStats.instance.K_MPCont = gameData.K_MPCont;
        PlayerStats.instance.K_curMPCont = gameData.K_curMPCont;
        PlayerStats.instance.K_CostMPCont = gameData.K_CostMPCont;
        PlayerStats.instance.K_ExpCont = gameData.K_ExpCont;
        PlayerStats.instance.K_curExpCont = gameData.K_curExpCont;
        PlayerStats.instance.K_attackCont = gameData.K_attackCont;
        PlayerStats.instance.K_defenseCont = gameData.K_defenseCont;
        PlayerStats.instance.K_poisonResistanceCont = gameData.K_poisonResistanceCont;
        PlayerStats.instance.K_paralysisResistanceCont = gameData.K_paralysisResistanceCont;
        PlayerStats.instance.K_sleepResistanceCont = gameData.K_sleepResistanceCont;
        PlayerStats.instance.K_rustResistanceCont = gameData.K_rustResistanceCont; 
        //
        PlayerStats.instance.Enemies = gameData.Enemies;
        PlayerStats.instance.Treasure = gameData.Treasure;
        //
        PlayerStats.instance.Skill_F  = gameData.Skill_F;
        PlayerStats.instance.Skill_K  = gameData.Skill_K;
        PlayerStats.instance.Skill_S  = gameData.Skill_S;
        //
        PlayerStats.instance.EventsDesert = gameData.EventsDesert; 
        PlayerStats.instance.SwitchDesert = gameData.SwitchDesert; 
        //
        PlayerStats.instance.F_Unlock = gameData.F_Unlock;
        PlayerStats.instance.K_Unlock = gameData.K_Unlock;
        PlayerStats.instance.S_Unlock = gameData.S_Unlock;
        //
        //gameData.questDatabase = PlayerStats.instance.questDatabase;
        PlayerStats.instance.quest = gameData.quest;
        PlayerStats.instance.QuestActive = gameData.QuestActive;
        PlayerStats.instance.QuestComplete = gameData.QuestComplete;
        PlayerStats.instance.QuestSegnal = gameData.QuestSegnal;
        //
        //
        /*gameData.I_itemList = PlayerStats.instance.I_itemList;
        gameData.I_quantityList = PlayerStats.instance.I_quantityList;
        gameData.IBattle_itemList = PlayerStats.instance.IBattle_itemList;
        gameData.IBattle_quantityList = PlayerStats.instance.IBattle_quantityList;
        gameData.F_itemList = PlayerStats.instance.F_itemList;
        gameData.F_quantityList = PlayerStats.instance.F_quantityList;
        gameData.S_itemList = PlayerStats.instance.S_itemList;
        gameData.S_quantityList = PlayerStats.instance.S_quantityList;
        gameData.K_itemList = PlayerStats.instance.K_itemList;
        gameData.K_quantityList = PlayerStats.instance.K_quantityList;
        gameData.Key_itemList = PlayerStats.instance.Key_itemList;
        gameData.Key_quantityList = PlayerStats.instance.Key_quantityList;
        gameData.Key_itemList = PlayerStats.instance.Key_itemList;
        gameData.Quest_itemList = PlayerStats.instance.Quest_itemList;
        gameData.Quest_quantityList = PlayerStats.instance.Quest_quantityList;
        //
        gameData.items = PlayerStats.instance.items;*/
     

            // Usa i dati caricati per ripristinare lo stato del gioco
            Debug.Log("Caricato il gioco con successo. Score: " + gameData.playerScore + ", Health: " + gameData.playerHealth);
        }
        else
        {
            Debug.Log("Nessun file di salvataggio trovato.");
        }
    }
}