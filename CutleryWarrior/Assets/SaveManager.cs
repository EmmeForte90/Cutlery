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

    public bool[] quest;
    public bool[] QuestActive;
    public bool[] QuestComplete;
    public bool[] QuestSegnal;
    public bool[] items;
    [SerializeField]    public List<SerializedItem> I_itemList;
    [SerializeField]    public List<int> I_quantityList;
    [SerializeField]    public List<SerializedItem> IBattle_itemList;
    [SerializeField]    public List<int> IBattle_quantityList;
    [SerializeField]    public List<SerializedItem> F_itemList;
    [SerializeField]    public List<int> F_quantityList;
    [SerializeField]    public List<SerializedItem> S_itemList;
    [SerializeField]    public List<int> S_quantityList;
    [SerializeField]    public List<SerializedItem> K_itemList;
    [SerializeField]    public List<int> K_quantityList;
    [SerializeField]    public List<SerializedItem> Key_itemList;
    [SerializeField]    public List<int> Key_quantityList;
    [SerializeField]    public List<SerializedItem> Quest_itemList;
   [SerializeField]    public List<int> Quest_quantityList;

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public static GameData FromJson(string json)
    {
        return JsonUtility.FromJson<GameData>(json);
    }
    
}

[System.Serializable]
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
    public bool Saving = false;
    public string NameScene;
    public string saveFilePath;
    public static SaveManager instance;
    //
    [SerializeField]    public PlayerStats PS;
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
    [SerializeField]    public List<Item> Key_itemList;
    [SerializeField]    public List<int> Key_quantityList;
    [SerializeField]    public List<Item> Quest_itemList;
   [SerializeField]    public List<int> Quest_quantityList;


    public void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
    }

    public void SaveGame()
    {
        // Create an instance of your game data object
        GameData gameData = new GameData();
        // Assign your game data values here...
        gameData.savedPosition = new SaveVector3(PS.savedPosition);
        //Debug.Log("Save position: " + gameData.savedPosition.ToVector3());
        
        #region DatiDaSalvare
        
        NameScene = PS.NameScene;
        gameData.HaveData = PS.HaveData;
        gameData.CanLoading = PS.CanLoading;
        gameData.NameScene = PS.NameScene;
        gameData.F_Unlock = PS.F_Unlock; 
        gameData.S_Unlock = PS.S_Unlock; 
        gameData.K_Unlock = PS.K_Unlock;
        gameData.Money = PS.Money;
        gameData.WhatMusic = PS.WhatMusic;
        //
        gameData.F_LV = PS.F_LV;
        gameData.F_HP = PS.F_HP;
        gameData.F_curHP = PS.F_curHP;
        gameData.F_MP = PS.F_MP;
        gameData.F_curMP = PS.F_curMP;
        gameData.F_curRage = PS.F_curRage;
        gameData.F_Rage = PS.F_Rage;
        gameData.F_CostMP = PS.F_CostMP;
        gameData.F_Exp = PS.F_Exp;
        gameData.F_curExp = PS.F_curExp;
        gameData.F_attack = PS.F_attack;
        gameData.F_defense = PS.F_defense;
        gameData.F_poisonResistance = PS.F_poisonResistance;
        gameData.F_paralysisResistance = PS.F_paralysisResistance;
        gameData.F_sleepResistance = PS.F_sleepResistance;
        gameData.F_rustResistance = PS.F_rustResistance;
        //
        gameData.F_HPCont = PS.F_HPCont;
        gameData.F_curHPCont = PS.F_curHPCont;
        gameData.F_MPCont = PS.F_MPCont;
        gameData.F_curMPCont = PS.F_curMPCont;
        gameData.F_CostMPCont = PS.F_CostMPCont;
        gameData.F_ExpCont = PS.F_ExpCont;
        gameData.F_curExpCont = PS.F_curExpCont;
        gameData.F_attackCont = PS.F_attackCont;
        gameData.F_defenseCont = PS.F_defenseCont;
        gameData.F_poisonResistanceCont = PS.F_poisonResistanceCont;
        gameData.F_paralysisResistanceCont = PS.F_paralysisResistanceCont;
        gameData.F_sleepResistanceCont = PS.F_sleepResistanceCont;
        gameData.F_rustResistanceCont = PS.F_rustResistanceCont; 
        //
        gameData.S_LV = PS.S_LV;
        gameData.S_HP = PS.S_HP;
        gameData.S_curHP = PS.S_curHP;
        gameData.S_MP = PS.S_MP;
        gameData.S_curMP = PS.S_curMP;
        gameData.S_curRage = PS.S_curRage;
        gameData.S_Rage = PS.S_Rage;
        gameData.S_CostMP = PS.S_CostMP;
        gameData.S_Exp = PS.S_Exp;
        gameData.S_curExp = PS.S_curExp;
        gameData.S_attack = PS.S_attack;
        gameData.S_defense = PS.S_defense;
        gameData.S_poisonResistance = PS.S_poisonResistance;
        gameData.S_paralysisResistance = PS.S_paralysisResistance;
        gameData.S_sleepResistance = PS.S_sleepResistance;
        gameData.S_rustResistance = PS.S_rustResistance;
        //
        gameData.S_HPCont = PS.S_HPCont;
        gameData.S_curHPCont = PS.S_curHPCont;
        gameData.S_MPCont = PS.S_MPCont;
        gameData.S_curMPCont = PS.S_curMPCont;
        gameData.S_CostMPCont = PS.S_CostMPCont;
        gameData.S_ExpCont = PS.S_ExpCont;
        gameData.S_curExpCont = PS.S_curExpCont;
        gameData.S_attackCont = PS.S_attackCont;
        gameData.S_defenseCont = PS.S_defenseCont;
        gameData.S_poisonResistanceCont = PS.S_poisonResistanceCont;
        gameData.S_paralysisResistanceCont = PS.S_paralysisResistanceCont;
        gameData.S_sleepResistanceCont = PS.S_sleepResistanceCont;
        gameData.S_rustResistanceCont = PS.S_rustResistanceCont; 
        //
        gameData.K_LV = PS.K_LV;
        gameData.K_HP = PS.K_HP;
        gameData.K_curHP = PS.K_curHP;
        gameData.K_MP = PS.K_MP;
        gameData.K_curMP = PS.K_curMP;
        gameData.K_curRage = PS.K_curRage;
        gameData.K_Rage = PS.K_Rage;
        gameData.K_CostMP = PS.K_CostMP;
        gameData.K_Exp = PS.K_Exp;
        gameData.K_curExp = PS.K_curExp;
        gameData.K_attack = PS.K_attack;
        gameData.K_defense = PS.K_defense;
        gameData.K_poisonResistance = PS.K_poisonResistance;
        gameData.K_paralysisResistance = PS.K_paralysisResistance;
        gameData.K_sleepResistance = PS.K_sleepResistance;
        gameData.K_rustResistance = PS.K_rustResistance;
        //
        gameData.K_HPCont = PS.K_HPCont;
        gameData.K_curHPCont = PS.K_curHPCont;
        gameData.K_MPCont = PS.K_MPCont;
        gameData.K_curMPCont = PS.K_curMPCont;
        gameData.K_CostMPCont = PS.K_CostMPCont;
        gameData.K_ExpCont = PS.K_ExpCont;
        gameData.K_curExpCont = PS.K_curExpCont;
        gameData.K_attackCont = PS.K_attackCont;
        gameData.K_defenseCont = PS.K_defenseCont;
        gameData.K_poisonResistanceCont = PS.K_poisonResistanceCont;
        gameData.K_paralysisResistanceCont = PS.K_paralysisResistanceCont;
        gameData.K_sleepResistanceCont = PS.K_sleepResistanceCont;
        gameData.K_rustResistanceCont = PS.K_rustResistanceCont; 
        //
        gameData.Enemies = PS.Enemies;
        gameData.Treasure = PS.Treasure;
        //
        gameData.Skill_F  = PS.Skill_F;
        gameData.Skill_K  = PS.Skill_K;
        gameData.Skill_S  = PS.Skill_S;
        //
        gameData.EventsDesert = PS.EventsDesert; 
        gameData.SwitchDesert = PS.SwitchDesert; 
        //
        gameData.F_Unlock = PS.F_Unlock;
        gameData.K_Unlock = PS.K_Unlock;
        gameData.S_Unlock = PS.S_Unlock;
        //
        gameData.quest = PS.quest;
        gameData.QuestActive = PS.QuestActive;
        gameData.QuestComplete = PS.QuestComplete;
        gameData.QuestSegnal = PS.QuestSegnal;
        //
        gameData.I_quantityList = PS.I_quantityList;
        gameData.IBattle_quantityList = PS.IBattle_quantityList;
        gameData.Key_quantityList = PS.Key_quantityList;
        gameData.Quest_quantityList = PS.Quest_quantityList;
        gameData.F_quantityList = PS.F_quantityList;
        gameData.S_quantityList = PS.S_quantityList;
        gameData.K_quantityList = PS.K_quantityList;
        //Per aggiornare il save manager dell'inspector
        I_quantityList = PS.I_quantityList;
        IBattle_quantityList = PS.IBattle_quantityList;
        Key_quantityList = PS.Key_quantityList;
        Quest_quantityList = PS.Quest_quantityList;
        F_quantityList = PS.F_quantityList;
        S_quantityList = PS.S_quantityList;
        K_quantityList = PS.K_quantityList;
        //
        I_itemList = PS.I_itemList;
        IBattle_itemList = PS.IBattle_itemList;
        Key_quantityList = PS.Key_quantityList;
        Quest_itemList = PS.Quest_itemList;
        F_itemList = PS.F_itemList;
        S_itemList = PS.S_itemList;
        K_itemList = PS.K_itemList;
        #endregion
        // Chiamare il metodo per la serializzazione della lista di ScriptableObject
           
        //
        SerializeItemList(I_itemList, saveFilePath);
        SerializeItemList(IBattle_itemList, saveFilePath);
        SerializeItemList(F_itemList, saveFilePath);
        SerializeItemList(S_itemList, saveFilePath);
        SerializeItemList(K_itemList, saveFilePath);
        SerializeItemList(Key_itemList, saveFilePath);
        SerializeItemList(Quest_itemList, saveFilePath);

        // Convert the game data to JSON
        string jsonData = gameData.ToJson();

        // Save the JSON data to a file
        File.WriteAllText(saveFilePath, jsonData);
    }
    public void SerializeItemList(List<Item> itemList, string filePath)
{
    // Creare una lista di oggetti serializzati
    List<string> serializedObjects = new List<string>();

    // Ciclare attraverso la lista di Item e serializzare ciascuno
    foreach (Item item in itemList)
    {
        string json = JsonUtility.ToJson(item);
        serializedObjects.Add(json);
    }

    // Converti la lista in un array
    string[] serializedArray = serializedObjects.ToArray();

    // Serializza l'array in formato JSON
    string finalJson = JsonUtility.ToJson(serializedArray, true);

    // Salva il JSON su file o fai qualsiasi altra cosa tu voglia
    File.WriteAllText(filePath, finalJson);
}

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            // Read the JSON from the file
            string jsonData = File.ReadAllText(saveFilePath);

            // Deserialize the JSON into a GameData object
            GameData loadedGameData = GameData.FromJson(jsonData);

            // Restore your game data values here...
            //Debug.Log("Loaded position: " + loadedGameData.savedPosition.ToVector3());
            PS.savedPosition = loadedGameData.savedPosition.ToVector3();
            #region DatiDaCaricare
        //
        PS.HaveData = loadedGameData.HaveData;
        PS.CanLoading = loadedGameData.CanLoading;
        PS.NameScene = loadedGameData.NameScene;
        PS.F_Unlock = loadedGameData.F_Unlock; 
        PS.S_Unlock = loadedGameData.S_Unlock; 
        PS.K_Unlock = loadedGameData.K_Unlock;
        PS.Money = loadedGameData.Money;
        PS.WhatMusic = loadedGameData.WhatMusic;
        //
        PS.F_LV = loadedGameData.F_LV;
        PS.F_HP = loadedGameData.F_HP;
        PS.F_curHP = loadedGameData.F_curHP;
        PS.F_MP = loadedGameData.F_MP;
        PS.F_curMP = loadedGameData.F_curMP;
        PS.F_curRage = loadedGameData.F_curRage;
        PS.F_Rage = loadedGameData.F_Rage;
        PS.F_CostMP = loadedGameData.F_CostMP;
        PS.F_Exp = loadedGameData.F_Exp;
        PS.F_curExp = loadedGameData.F_curExp;
        PS.F_attack = loadedGameData.F_attack;
        PS.F_defense = loadedGameData.F_defense;
        PS.F_poisonResistance = loadedGameData.F_poisonResistance;
        PS.F_paralysisResistance = loadedGameData.F_paralysisResistance;
        PS.F_sleepResistance = loadedGameData.F_sleepResistance;
        PS.F_rustResistance = loadedGameData.F_rustResistance;
        //
        PS.F_HPCont = loadedGameData.F_HPCont;
        PS.F_curHPCont = loadedGameData.F_curHPCont;
        PS.F_MPCont = loadedGameData.F_MPCont;
        PS.F_curMPCont = loadedGameData.F_curMPCont;
        PS.F_CostMPCont = loadedGameData.F_CostMPCont;
        PS.F_ExpCont = loadedGameData.F_ExpCont;
        PS.F_curExpCont = loadedGameData.F_curExpCont;
        PS.F_attackCont = loadedGameData.F_attackCont;
        PS.F_defenseCont = loadedGameData.F_defenseCont;
        PS.F_poisonResistanceCont = loadedGameData.F_poisonResistanceCont;
        PS.F_paralysisResistanceCont = loadedGameData.F_paralysisResistanceCont;
        PS.F_sleepResistanceCont = loadedGameData.F_sleepResistanceCont;
        PS.F_rustResistanceCont = loadedGameData.F_rustResistanceCont; 
        //
        PS.S_LV = loadedGameData.S_LV;
        PS.S_HP = loadedGameData.S_HP;
        PS.S_curHP = loadedGameData.S_curHP;
        PS.S_MP = loadedGameData.S_MP;
        PS.S_curMP = loadedGameData.S_curMP;
        PS.S_curRage = loadedGameData.S_curRage;
        PS.S_Rage = loadedGameData.S_Rage;
        PS.S_CostMP = loadedGameData.S_CostMP;
        PS.S_Exp = loadedGameData.S_Exp;
        PS.S_curExp = loadedGameData.S_curExp;
        PS.S_attack = loadedGameData.S_attack;
        PS.S_defense = loadedGameData.S_defense;
        PS.S_poisonResistance = loadedGameData.S_poisonResistance;
        PS.S_paralysisResistance = loadedGameData.S_paralysisResistance;
        PS.S_sleepResistance = loadedGameData.S_sleepResistance;
        PS.S_rustResistance = loadedGameData.S_rustResistance;
        //
        PS.S_HPCont = loadedGameData.S_HPCont;
        PS.S_curHPCont = loadedGameData.S_curHPCont;
        PS.S_MPCont = loadedGameData.S_MPCont;
        PS.S_curMPCont = loadedGameData.S_curMPCont;
        PS.S_CostMPCont = loadedGameData.S_CostMPCont;
        PS.S_ExpCont = loadedGameData.S_ExpCont;
        PS.S_curExpCont = loadedGameData.S_curExpCont;
        PS.S_attackCont = loadedGameData.S_attackCont;
        PS.S_defenseCont = loadedGameData.S_defenseCont;
        PS.S_poisonResistanceCont = loadedGameData.S_poisonResistanceCont;
        PS.S_paralysisResistanceCont = loadedGameData.S_paralysisResistanceCont;
        PS.S_sleepResistanceCont = loadedGameData.S_sleepResistanceCont;
        PS.S_rustResistanceCont = loadedGameData.S_rustResistanceCont; 
        //
        PS.K_LV = loadedGameData.K_LV;
        PS.K_HP = loadedGameData.K_HP;
        PS.K_curHP = loadedGameData.K_curHP;
        PS.K_MP = loadedGameData.K_MP;
        PS.K_curMP = loadedGameData.K_curMP;
        PS.K_curRage = loadedGameData.K_curRage;
        PS.K_Rage = loadedGameData.K_Rage;
        PS.K_CostMP = loadedGameData.K_CostMP;
        PS.K_Exp = loadedGameData.K_Exp;
        PS.K_curExp = loadedGameData.K_curExp;
        PS.K_attack = loadedGameData.K_attack;
        PS.K_defense = loadedGameData.K_defense;
        PS.K_poisonResistance = loadedGameData.K_poisonResistance;
        PS.K_paralysisResistance = loadedGameData.K_paralysisResistance;
        PS.K_sleepResistance = loadedGameData.K_sleepResistance;
        PS.K_rustResistance = loadedGameData.K_rustResistance;
        //
        PS.K_HPCont = loadedGameData.K_HPCont;
        PS.K_curHPCont = loadedGameData.K_curHPCont;
        PS.K_MPCont = loadedGameData.K_MPCont;
        PS.K_curMPCont = loadedGameData.K_curMPCont;
        PS.K_CostMPCont = loadedGameData.K_CostMPCont;
        PS.K_ExpCont = loadedGameData.K_ExpCont;
        PS.K_curExpCont = loadedGameData.K_curExpCont;
        PS.K_attackCont = loadedGameData.K_attackCont;
        PS.K_defenseCont = loadedGameData.K_defenseCont;
        PS.K_poisonResistanceCont = loadedGameData.K_poisonResistanceCont;
        PS.K_paralysisResistanceCont = loadedGameData.K_paralysisResistanceCont;
        PS.K_sleepResistanceCont = loadedGameData.K_sleepResistanceCont;
        PS.K_rustResistanceCont = loadedGameData.K_rustResistanceCont; 
        //
        PS.Enemies = loadedGameData.Enemies;
        PS.Treasure = loadedGameData.Treasure;
        //
        PS.Skill_F  = loadedGameData.Skill_F;
        PS.Skill_K  = loadedGameData.Skill_K;
        PS.Skill_S  = loadedGameData.Skill_S;
        //
        PS.EventsDesert = loadedGameData.EventsDesert; 
        PS.SwitchDesert = loadedGameData.SwitchDesert; 
        //
        PS.F_Unlock = loadedGameData.F_Unlock;
        PS.K_Unlock = loadedGameData.K_Unlock;
        PS.S_Unlock = loadedGameData.S_Unlock;
        //
        PS.quest = loadedGameData.quest;
        PS.QuestActive = loadedGameData.QuestActive;
        PS.QuestComplete = loadedGameData.QuestComplete;
        PS.QuestSegnal = loadedGameData.QuestSegnal;
        #endregion
            // Chiamare il metodo per la deserializzazione della lista di Item
            //
            PS.I_quantityList = loadedGameData.I_quantityList;
            PS.IBattle_quantityList = loadedGameData.IBattle_quantityList;
            PS.F_quantityList = loadedGameData.F_quantityList;
            PS.S_quantityList = loadedGameData.S_quantityList;
            PS.K_quantityList = loadedGameData.K_quantityList;
            PS.Key_quantityList = loadedGameData.Key_quantityList;
            PS.Quest_quantityList = loadedGameData.Quest_quantityList;
            //
            /*I_itemList = DeserializeItemList(saveFilePath);
            IBattle_itemList = DeserializeItemList(saveFilePath);
            F_itemList = DeserializeItemList(saveFilePath);
            S_itemList = DeserializeItemList(saveFilePath);
            K_itemList = DeserializeItemList(saveFilePath);
            Key_itemList = DeserializeItemList(saveFilePath);
            Quest_itemList = DeserializeItemList(saveFilePath);*/

        }
        else
        {
            Debug.Log("Save file not found. Creating a new one.");
        }
    }

        public List<Item> DeserializeItemList(string filePath)
{
    // Carica il JSON della lista di Item da file o da qualsiasi altra fonte
    string json = File.ReadAllText(filePath);

    // Deserializza l'array
    string[] serializedArray = JsonUtility.FromJson<string[]>(json);

    // Creare una nuova lista di Item
    List<Item> itemList = new List<Item>();

    // Ciclare attraverso l'array serializzato e deserializzare ciascun oggetto
    foreach (string serializedObject in serializedArray)
    {
        Item item = JsonUtility.FromJson<Item>(serializedObject);
        itemList.Add(item);
    }

    return itemList;
}
}