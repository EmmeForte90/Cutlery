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
    private string saveFilePath;
    public static SaveManager instance;
    //
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


    private void Start(){saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");}

    public void SaveGame()
    {
        // Create an instance of your game data object
        GameData gameData = new GameData();
        // Assign your game data values here...
        gameData.savedPosition = new SaveVector3(PlayerStats.instance.savedPosition);
        //Debug.Log("Save position: " + gameData.savedPosition.ToVector3());
        #region DatiDaSalvare
        //
        NameScene = PlayerStats.instance.NameScene;
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
        gameData.quest = PlayerStats.instance.quest;
        gameData.QuestActive = PlayerStats.instance.QuestActive;
        gameData.QuestComplete = PlayerStats.instance.QuestComplete;
        gameData.QuestSegnal = PlayerStats.instance.QuestSegnal;
        //
           //I_itemList = PlayerStats.instance.I_itemList;
        //
            I_quantityList = PlayerStats.instance.I_quantityList;
            IBattle_itemList = PlayerStats.instance.IBattle_itemList;
            IBattle_quantityList = PlayerStats.instance.IBattle_quantityList;
            F_itemList = PlayerStats.instance.F_itemList;
            F_quantityList = PlayerStats.instance.F_quantityList;
            S_itemList = PlayerStats.instance.S_itemList;
            S_quantityList = PlayerStats.instance.S_quantityList;
            K_itemList = PlayerStats.instance.K_itemList;
            K_quantityList = PlayerStats.instance.K_quantityList;
            Key_itemList = PlayerStats.instance.Key_itemList;
            Key_quantityList = PlayerStats.instance.Key_quantityList;
            Quest_itemList = PlayerStats.instance.Quest_itemList;
            Quest_quantityList = PlayerStats.instance.Quest_quantityList;
        #endregion
        // Chiamare il metodo per la serializzazione della lista di ScriptableObject
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
            PlayerStats.instance.savedPosition = loadedGameData.savedPosition.ToVector3();
            #region DatiDaCaricare
        //
        PlayerStats.instance.I_quantityList = loadedGameData.I_quantityList;
        PlayerStats.instance.IBattle_quantityList = loadedGameData.IBattle_quantityList;
        PlayerStats.instance.F_quantityList = loadedGameData.F_quantityList;
        PlayerStats.instance.S_quantityList = loadedGameData.S_quantityList;
        PlayerStats.instance.K_quantityList = loadedGameData.K_quantityList;
        PlayerStats.instance.Key_quantityList = loadedGameData.Key_quantityList;
        PlayerStats.instance.Quest_quantityList = loadedGameData.Quest_quantityList;
        //
        PlayerStats.instance.HaveData = loadedGameData.HaveData;
        PlayerStats.instance.CanLoading = loadedGameData.CanLoading;
        PlayerStats.instance.NameScene = loadedGameData.NameScene;
        PlayerStats.instance.F_Unlock = loadedGameData.F_Unlock; 
        PlayerStats.instance.S_Unlock = loadedGameData.S_Unlock; 
        PlayerStats.instance.K_Unlock = loadedGameData.K_Unlock;
        PlayerStats.instance.Money = loadedGameData.Money;
        PlayerStats.instance.WhatMusic = loadedGameData.WhatMusic;
        //
        PlayerStats.instance.F_LV = loadedGameData.F_LV;
        PlayerStats.instance.F_HP = loadedGameData.F_HP;
        PlayerStats.instance.F_curHP = loadedGameData.F_curHP;
        PlayerStats.instance.F_MP = loadedGameData.F_MP;
        PlayerStats.instance.F_curMP = loadedGameData.F_curMP;
        PlayerStats.instance.F_curRage = loadedGameData.F_curRage;
        PlayerStats.instance.F_Rage = loadedGameData.F_Rage;
        PlayerStats.instance.F_CostMP = loadedGameData.F_CostMP;
        PlayerStats.instance.F_Exp = loadedGameData.F_Exp;
        PlayerStats.instance.F_curExp = loadedGameData.F_curExp;
        PlayerStats.instance.F_attack = loadedGameData.F_attack;
        PlayerStats.instance.F_defense = loadedGameData.F_defense;
        PlayerStats.instance.F_poisonResistance = loadedGameData.F_poisonResistance;
        PlayerStats.instance.F_paralysisResistance = loadedGameData.F_paralysisResistance;
        PlayerStats.instance.F_sleepResistance = loadedGameData.F_sleepResistance;
        PlayerStats.instance.F_rustResistance = loadedGameData.F_rustResistance;
        //
        PlayerStats.instance.F_HPCont = loadedGameData.F_HPCont;
        PlayerStats.instance.F_curHPCont = loadedGameData.F_curHPCont;
        PlayerStats.instance.F_MPCont = loadedGameData.F_MPCont;
        PlayerStats.instance.F_curMPCont = loadedGameData.F_curMPCont;
        PlayerStats.instance.F_CostMPCont = loadedGameData.F_CostMPCont;
        PlayerStats.instance.F_ExpCont = loadedGameData.F_ExpCont;
        PlayerStats.instance.F_curExpCont = loadedGameData.F_curExpCont;
        PlayerStats.instance.F_attackCont = loadedGameData.F_attackCont;
        PlayerStats.instance.F_defenseCont = loadedGameData.F_defenseCont;
        PlayerStats.instance.F_poisonResistanceCont = loadedGameData.F_poisonResistanceCont;
        PlayerStats.instance.F_paralysisResistanceCont = loadedGameData.F_paralysisResistanceCont;
        PlayerStats.instance.F_sleepResistanceCont = loadedGameData.F_sleepResistanceCont;
        PlayerStats.instance.F_rustResistanceCont = loadedGameData.F_rustResistanceCont; 
        //
        PlayerStats.instance.S_LV = loadedGameData.S_LV;
        PlayerStats.instance.S_HP = loadedGameData.S_HP;
        PlayerStats.instance.S_curHP = loadedGameData.S_curHP;
        PlayerStats.instance.S_MP = loadedGameData.S_MP;
        PlayerStats.instance.S_curMP = loadedGameData.S_curMP;
        PlayerStats.instance.S_curRage = loadedGameData.S_curRage;
        PlayerStats.instance.S_Rage = loadedGameData.S_Rage;
        PlayerStats.instance.S_CostMP = loadedGameData.S_CostMP;
        PlayerStats.instance.S_Exp = loadedGameData.S_Exp;
        PlayerStats.instance.S_curExp = loadedGameData.S_curExp;
        PlayerStats.instance.S_attack = loadedGameData.S_attack;
        PlayerStats.instance.S_defense = loadedGameData.S_defense;
        PlayerStats.instance.S_poisonResistance = loadedGameData.S_poisonResistance;
        PlayerStats.instance.S_paralysisResistance = loadedGameData.S_paralysisResistance;
        PlayerStats.instance.S_sleepResistance = loadedGameData.S_sleepResistance;
        PlayerStats.instance.S_rustResistance = loadedGameData.S_rustResistance;
        //
        PlayerStats.instance.S_HPCont = loadedGameData.S_HPCont;
        PlayerStats.instance.S_curHPCont = loadedGameData.S_curHPCont;
        PlayerStats.instance.S_MPCont = loadedGameData.S_MPCont;
        PlayerStats.instance.S_curMPCont = loadedGameData.S_curMPCont;
        PlayerStats.instance.S_CostMPCont = loadedGameData.S_CostMPCont;
        PlayerStats.instance.S_ExpCont = loadedGameData.S_ExpCont;
        PlayerStats.instance.S_curExpCont = loadedGameData.S_curExpCont;
        PlayerStats.instance.S_attackCont = loadedGameData.S_attackCont;
        PlayerStats.instance.S_defenseCont = loadedGameData.S_defenseCont;
        PlayerStats.instance.S_poisonResistanceCont = loadedGameData.S_poisonResistanceCont;
        PlayerStats.instance.S_paralysisResistanceCont = loadedGameData.S_paralysisResistanceCont;
        PlayerStats.instance.S_sleepResistanceCont = loadedGameData.S_sleepResistanceCont;
        PlayerStats.instance.S_rustResistanceCont = loadedGameData.S_rustResistanceCont; 
        //
        PlayerStats.instance.K_LV = loadedGameData.K_LV;
        PlayerStats.instance.K_HP = loadedGameData.K_HP;
        PlayerStats.instance.K_curHP = loadedGameData.K_curHP;
        PlayerStats.instance.K_MP = loadedGameData.K_MP;
        PlayerStats.instance.K_curMP = loadedGameData.K_curMP;
        PlayerStats.instance.K_curRage = loadedGameData.K_curRage;
        PlayerStats.instance.K_Rage = loadedGameData.K_Rage;
        PlayerStats.instance.K_CostMP = loadedGameData.K_CostMP;
        PlayerStats.instance.K_Exp = loadedGameData.K_Exp;
        PlayerStats.instance.K_curExp = loadedGameData.K_curExp;
        PlayerStats.instance.K_attack = loadedGameData.K_attack;
        PlayerStats.instance.K_defense = loadedGameData.K_defense;
        PlayerStats.instance.K_poisonResistance = loadedGameData.K_poisonResistance;
        PlayerStats.instance.K_paralysisResistance = loadedGameData.K_paralysisResistance;
        PlayerStats.instance.K_sleepResistance = loadedGameData.K_sleepResistance;
        PlayerStats.instance.K_rustResistance = loadedGameData.K_rustResistance;
        //
        PlayerStats.instance.K_HPCont = loadedGameData.K_HPCont;
        PlayerStats.instance.K_curHPCont = loadedGameData.K_curHPCont;
        PlayerStats.instance.K_MPCont = loadedGameData.K_MPCont;
        PlayerStats.instance.K_curMPCont = loadedGameData.K_curMPCont;
        PlayerStats.instance.K_CostMPCont = loadedGameData.K_CostMPCont;
        PlayerStats.instance.K_ExpCont = loadedGameData.K_ExpCont;
        PlayerStats.instance.K_curExpCont = loadedGameData.K_curExpCont;
        PlayerStats.instance.K_attackCont = loadedGameData.K_attackCont;
        PlayerStats.instance.K_defenseCont = loadedGameData.K_defenseCont;
        PlayerStats.instance.K_poisonResistanceCont = loadedGameData.K_poisonResistanceCont;
        PlayerStats.instance.K_paralysisResistanceCont = loadedGameData.K_paralysisResistanceCont;
        PlayerStats.instance.K_sleepResistanceCont = loadedGameData.K_sleepResistanceCont;
        PlayerStats.instance.K_rustResistanceCont = loadedGameData.K_rustResistanceCont; 
        //
        PlayerStats.instance.Enemies = loadedGameData.Enemies;
        PlayerStats.instance.Treasure = loadedGameData.Treasure;
        //
        PlayerStats.instance.Skill_F  = loadedGameData.Skill_F;
        PlayerStats.instance.Skill_K  = loadedGameData.Skill_K;
        PlayerStats.instance.Skill_S  = loadedGameData.Skill_S;
        //
        PlayerStats.instance.EventsDesert = loadedGameData.EventsDesert; 
        PlayerStats.instance.SwitchDesert = loadedGameData.SwitchDesert; 
        //
        PlayerStats.instance.F_Unlock = loadedGameData.F_Unlock;
        PlayerStats.instance.K_Unlock = loadedGameData.K_Unlock;
        PlayerStats.instance.S_Unlock = loadedGameData.S_Unlock;
        //
        PlayerStats.instance.quest = loadedGameData.quest;
        PlayerStats.instance.QuestActive = loadedGameData.QuestActive;
        PlayerStats.instance.QuestComplete = loadedGameData.QuestComplete;
        PlayerStats.instance.QuestSegnal = loadedGameData.QuestSegnal;
        #endregion
            // Chiamare il metodo per la deserializzazione della lista di Item
            I_itemList = DeserializeItemList(saveFilePath);
            IBattle_itemList = DeserializeItemList(saveFilePath);
            F_itemList = DeserializeItemList(saveFilePath);
            S_itemList = DeserializeItemList(saveFilePath);
            K_itemList = DeserializeItemList(saveFilePath);
            Key_itemList = DeserializeItemList(saveFilePath);
            Quest_itemList = DeserializeItemList(saveFilePath);

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