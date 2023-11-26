using System;
using System.IO;
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
    public GameManager GM_Data;

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


    /*public void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
    }*/

    public void SaveGame()
    {
        //List<string> serializedStrings = new List<string>();
        // Create an instance of your game data object
        //GameData gameData = new GameData();
        // Assign your game data values here...
        //gameData.savedPosition = new SaveVector3(PS.savedPosition);
        //Debug.Log("Save position: " + gameData.savedPosition.ToVector3());
        
        #region DatiDaSalvare
        
        /*NameScene = PS.NameScene;
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
        
        // Chiamare il metodo per la serializzazione della lista di ScriptableObject
           
        //
        SerializeItemList(I_itemList, saveFilePath);
        SerializeItemList(IBattle_itemList, saveFilePath);
        SerializeItemList(F_itemList, saveFilePath);
        SerializeItemList(S_itemList, saveFilePath);
        SerializeItemList(K_itemList, saveFilePath);
        SerializeItemList(Key_itemList, saveFilePath);
        SerializeItemList(Quest_itemList, saveFilePath);*/
        #endregion

        ES3.Save("savedPosition", PS.savedPosition);
        //
        ES3.Save("NameScene", PS.NameScene);
        ES3.Save("HaveData", PS.HaveData);
        ES3.Save("CanLoading", PS.CanLoading);
        //
        ES3.Save("F_Unlock", PS.F_Unlock);
        ES3.Save("S_Unlock", PS.S_Unlock);
        ES3.Save("K_Unlock", PS.K_Unlock);
        //
        ES3.Save("Money", PS.Money);
        ES3.Save("WhatMusic", PS.WhatMusic);
        //
        ES3.Save("F_LV", PS.F_LV);
        ES3.Save("F_HP", PS.F_HP);
        ES3.Save("F_curHP", PS.F_curHP);
        ES3.Save("F_MP", PS.F_MP);
        ES3.Save("F_curMP", PS.F_curMP);
        ES3.Save("F_CostMP", PS.F_CostMP);
        ES3.Save("F_curRage", PS.F_curRage);
        ES3.Save("F_Rage", PS.F_Rage);
        ES3.Save("F_Exp", PS.F_Exp);
        ES3.Save("F_curExp", PS.F_curExp);
        ES3.Save("F_attack", PS.F_attack);
        ES3.Save("F_defense", PS.F_defense);
        ES3.Save("F_poisonResistance", PS.F_poisonResistance);
        ES3.Save("F_paralysisResistance", PS.F_paralysisResistance);
        ES3.Save("F_sleepResistance", PS.F_sleepResistance);
        ES3.Save("F_rustResistance", PS.F_rustResistance);
        ES3.Save("F_HPCont", PS.F_HPCont);
        ES3.Save("F_curHPCont", PS.F_curHPCont);
        ES3.Save("F_MPCont", PS.F_MPCont);
        ES3.Save("F_curMPCont", PS.F_curMPCont);
        ES3.Save("F_CostMPCont", PS.F_CostMPCont);
        ES3.Save("F_ExpCont", PS.F_ExpCont);
        ES3.Save("F_curExpCont", PS.F_curExpCont);
        ES3.Save("F_attackCont", PS.F_attackCont);
        ES3.Save("F_defenseCont", PS.F_defenseCont);
        ES3.Save("F_poisonResistanceCont", PS.F_poisonResistanceCont);
        ES3.Save("F_paralysisResistanceCont", PS.F_paralysisResistanceCont);
        ES3.Save("F_sleepResistanceCont", PS.F_sleepResistanceCont);
        ES3.Save("F_rustResistanceCont", PS.F_rustResistanceCont);
        //
        ES3.Save("K_LV", PS.K_LV);
        ES3.Save("K_HP", PS.K_HP);
        ES3.Save("K_curHP", PS.K_curHP);
        ES3.Save("K_MP", PS.K_MP);
        ES3.Save("K_curMP", PS.K_curMP);
        ES3.Save("K_CostMP", PS.K_CostMP);
        ES3.Save("K_curRage", PS.K_curRage);
        ES3.Save("K_Rage", PS.K_Rage);
        ES3.Save("K_Exp", PS.K_Exp);
        ES3.Save("K_curExp", PS.K_curExp);
        ES3.Save("K_attack", PS.K_attack);
        ES3.Save("K_defense", PS.K_defense);
        ES3.Save("K_poisonResistance", PS.K_poisonResistance);
        ES3.Save("K_paralysisResistance", PS.K_paralysisResistance);
        ES3.Save("K_sleepResistance", PS.K_sleepResistance);
        ES3.Save("K_rustResistance", PS.K_rustResistance);
        ES3.Save("K_HPCont", PS.K_HPCont);
        ES3.Save("K_curHPCont", PS.K_curHPCont);
        ES3.Save("K_MPCont", PS.K_MPCont);
        ES3.Save("K_curMPCont", PS.K_curMPCont);
        ES3.Save("K_CostMPCont", PS.K_CostMPCont);
        ES3.Save("K_ExpCont", PS.K_ExpCont);
        ES3.Save("K_curExpCont", PS.K_curExpCont);
        ES3.Save("K_attackCont", PS.K_attackCont);
        ES3.Save("K_defenseCont", PS.K_defenseCont);
        ES3.Save("K_poisonResistanceCont", PS.K_poisonResistanceCont);
        ES3.Save("K_paralysisResistanceCont", PS.K_paralysisResistanceCont);
        ES3.Save("K_sleepResistanceCont", PS.K_sleepResistanceCont);
        ES3.Save("K_rustResistanceCont", PS.K_rustResistanceCont);
        //
        ES3.Save("S_LV", PS.S_LV);
        ES3.Save("S_HP", PS.S_HP);
        ES3.Save("S_curHP", PS.S_curHP);
        ES3.Save("S_MP", PS.S_MP);
        ES3.Save("S_curMP", PS.S_curMP);
        ES3.Save("S_CostMP", PS.S_CostMP);
        ES3.Save("S_curRage", PS.S_curRage);
        ES3.Save("S_Rage", PS.S_Rage);
        ES3.Save("S_Exp", PS.S_Exp);
        ES3.Save("S_curExp", PS.S_curExp);
        ES3.Save("S_attack", PS.S_attack);
        ES3.Save("S_defense", PS.S_defense);
        ES3.Save("S_poisonResistance", PS.S_poisonResistance);
        ES3.Save("S_paralysisResistance", PS.S_paralysisResistance);
        ES3.Save("S_sleepResistance", PS.S_sleepResistance);
        ES3.Save("S_rustResistance", PS.S_rustResistance);
        ES3.Save("S_HPCont", PS.S_HPCont);
        ES3.Save("S_curHPCont", PS.S_curHPCont);
        ES3.Save("S_MPCont", PS.S_MPCont);
        ES3.Save("S_curMPCont", PS.S_curMPCont);
        ES3.Save("S_CostMPCont", PS.S_CostMPCont);
        ES3.Save("S_ExpCont", PS.S_ExpCont);
        ES3.Save("S_curExpCont", PS.S_curExpCont);
        ES3.Save("S_attackCont", PS.S_attackCont);
        ES3.Save("S_defenseCont", PS.S_defenseCont);
        ES3.Save("S_poisonResistanceCont", PS.S_poisonResistanceCont);
        ES3.Save("S_paralysisResistanceCont", PS.S_paralysisResistanceCont);
        ES3.Save("S_sleepResistanceCont", PS.S_sleepResistanceCont);
        ES3.Save("S_rustResistanceCont", PS.S_rustResistanceCont);
        //
        ES3.Save("Enemies", PS.Enemies);
        ES3.Save("Treasure", PS.Treasure);
        //
        ES3.Save("Skill_F", PS.Skill_F);
        ES3.Save("Skill_K", PS.Skill_K);
        ES3.Save("Skill_S", PS.Skill_S);
        //
        ES3.Save("quest", PS.quest);
        ES3.Save("QuestActive", PS.QuestActive);
        ES3.Save("QuestComplete", PS.QuestComplete);
        ES3.Save("QuestSegnal", PS.QuestSegnal);
        //
        ES3.Save("I_quantityList", PS.I_quantityList);
        ES3.Save("IBattle_quantityList", PS.IBattle_quantityList);
        ES3.Save("Key_quantityList", PS.Key_quantityList);
        ES3.Save("Quest_quantityList", PS.Quest_quantityList);
        ES3.Save("F_quantityList", PS.F_quantityList);
        ES3.Save("S_quantityList", PS.S_quantityList);
        ES3.Save("K_quantityList", PS.K_quantityList);
        //
        ES3.Save("I_itemList", PS.I_itemList);
        ES3.Save("IBattle_itemList", PS.IBattle_itemList);
        ES3.Save("Key_quantityList", PS.Key_quantityList);
        ES3.Save("Quest_itemList", PS.Quest_itemList);
        ES3.Save("F_itemList", PS.F_itemList);
        ES3.Save("S_itemList", PS.S_itemList);
        ES3.Save("K_itemList", PS.K_itemList);
        //
        //GM_Data = GameManager.instance.GM_Data;
        //ES3.Save("GM_Data", GM_Data);

    }

        // Convert the game data to JSON
        // Supponendo che gameData sia un oggetto che desideri serializzare
        /*string gameDataJson = JsonUtility.ToJson(gameData);

        foreach (var scriptableObject in I_itemList)
        {
            serializedStrings.Add(scriptableObject.IdItem);
        }

        // Serializza la lista di stringhe
        string serializedStringsJson = JsonUtility.ToJson(serializedStrings);

        // Puoi combinare le due stringhe JSON come desideri, ad esempio concatenandole
        string jsonData = gameDataJson + serializedStringsJson;


        // Save the JSON data to a file
        File.WriteAllText(saveFilePath, jsonData);*/

    /*public void SerializeItemList(List<Item> itemList, string filePath)
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
}*/

    public void LoadGame()
    {
        PS.savedPosition = ES3.Load<Vector3>("savedPosition");
        //
        PS.NameScene = ES3.Load<string>("NameScene");
        PS.HaveData = ES3.Load<bool>("HaveData");
        PS.CanLoading = ES3.Load<bool>("CanLoading");
        //
        PS.F_Unlock = ES3.Load<bool>("F_Unlock");
        PS.S_Unlock = ES3.Load<bool>("S_Unlock");
        PS.K_Unlock = ES3.Load<bool>("K_Unlock");
        //
        PS.Money = ES3.Load<int>("Money");
        PS.WhatMusic = ES3.Load<int>("WhatMusic");
        //
        PS.F_LV = ES3.Load<int>("F_LV");
        PS.F_HP = ES3.Load<float>("F_HP");
        PS.F_curHP = ES3.Load<float>("F_curHP");
        PS.F_MP = ES3.Load<float>("F_MP");
        PS.F_curMP = ES3.Load<float>("F_curMP");
        PS.F_CostMP = ES3.Load<float>("F_CostMP");
        PS.F_curRage = ES3.Load<float>("F_curRage");
        PS.F_Rage = ES3.Load<float>("F_Rage");
        PS.F_Exp = ES3.Load<float>("F_Exp");
        PS.F_curExp = ES3.Load<float>("F_curExp");
        PS.F_attack = ES3.Load<float>("F_attack");
        PS.F_defense = ES3.Load<float>("F_defense");
        PS.F_poisonResistance = ES3.Load<float>("F_poisonResistance");
        PS.F_paralysisResistance = ES3.Load<float>("F_paralysisResistance");
        PS.F_sleepResistance = ES3.Load<float>("F_sleepResistance");
        PS.F_rustResistance = ES3.Load<float>("F_rustResistance");
        PS.F_HPCont = ES3.Load<float>("F_HPCont");
        PS.F_curHPCont = ES3.Load<float>("F_curHPCont");
        PS.F_MPCont = ES3.Load<float>("F_MPCont");
        PS.F_curMPCont = ES3.Load<float>("F_curMPCont");
        PS.F_CostMPCont = ES3.Load<float>("F_CostMPCont");
        PS.F_ExpCont = ES3.Load<float>("F_ExpCont");
        PS.F_curExpCont = ES3.Load<float>("F_curExpCont");
        PS.F_attackCont = ES3.Load<float>("F_attackCont");
        PS.F_defenseCont = ES3.Load<float>("F_defenseCont");
        PS.F_poisonResistanceCont = ES3.Load<float>("F_poisonResistanceCont");
        PS.F_paralysisResistanceCont = ES3.Load<float>("F_paralysisResistanceCont");
        PS.F_sleepResistanceCont = ES3.Load<float>("F_sleepResistanceCont");
//        PS.F_rustResistanceCont = ES3.Load<int>("F_rustResistanceCont");
        //
        PS.K_LV = ES3.Load<int>("K_LV");
        PS.K_HP = ES3.Load<float>("K_HP");
        PS.K_curHP = ES3.Load<float>("K_curHP");
        PS.K_MP = ES3.Load<float>("K_MP");
        PS.K_curMP = ES3.Load<float>("K_curMP");
        PS.K_CostMP = ES3.Load<float>("K_CostMP");
        PS.K_curRage = ES3.Load<float>("K_curRage");
        PS.K_Rage = ES3.Load<float>("K_Rage");
        PS.K_Exp = ES3.Load<float>("K_Exp");
        PS.K_curExp = ES3.Load<float>("K_curExp");
        PS.K_attack = ES3.Load<float>("K_attack");
        PS.K_defense = ES3.Load<float>("K_defense");
        PS.K_poisonResistance = ES3.Load<float>("K_poisonResistance");
        PS.K_paralysisResistance = ES3.Load<float>("K_paralysisResistance");
        PS.K_sleepResistance = ES3.Load<float>("K_sleepResistance");
        PS.K_rustResistance = ES3.Load<float>("K_rustResistance");
        PS.K_HPCont = ES3.Load<float>("K_HPCont");
        PS.K_curHPCont = ES3.Load<float>("K_curHPCont");
        PS.K_MPCont = ES3.Load<float>("K_MPCont");
        PS.K_curMPCont = ES3.Load<float>("K_curMPCont");
        PS.K_CostMPCont = ES3.Load<float>("K_CostMPCont");
        PS.K_ExpCont = ES3.Load<float>("K_ExpCont");
        PS.K_curExpCont = ES3.Load<float>("K_curExpCont");
        PS.K_attackCont = ES3.Load<float>("K_attackCont");
        PS.K_defenseCont = ES3.Load<float>("K_defenseCont");
        PS.K_poisonResistanceCont = ES3.Load<float>("K_poisonResistanceCont");
        PS.K_paralysisResistanceCont = ES3.Load<float>("K_paralysisResistanceCont");
        PS.K_sleepResistanceCont = ES3.Load<float>("K_sleepResistanceCont");
   //     PS.K_rustResistanceCont = ES3.Load<int>("K_rustResistanceCont");
        //
        PS.S_LV = ES3.Load<int>("S_LV");
        PS.S_HP = ES3.Load<float>("S_HP");
        PS.S_curHP = ES3.Load<float>("S_curHP");
        PS.S_MP = ES3.Load<float>("S_MP");
        PS.S_curMP = ES3.Load<float>("S_curMP");
        PS.S_CostMP = ES3.Load<float>("S_CostMP");
        PS.S_curRage = ES3.Load<float>("S_curRage");
        PS.S_Rage = ES3.Load<float>("S_Rage");
        PS.S_Exp = ES3.Load<float>("S_Exp");
        PS.S_curExp = ES3.Load<float>("S_curExp");
        PS.S_attack = ES3.Load<float>("S_attack");
        PS.S_defense = ES3.Load<float>("S_defense");
        PS.S_poisonResistance = ES3.Load<float>("S_poisonResistance");
        PS.S_paralysisResistance = ES3.Load<float>("S_paralysisResistance");
        PS.S_sleepResistance = ES3.Load<float>("S_sleepResistance");
        PS.S_rustResistance = ES3.Load<float>("S_rustResistance");
        PS.S_HPCont = ES3.Load<float>("S_HPCont");
        PS.S_curHPCont = ES3.Load<float>("S_curHPCont");
        PS.S_MPCont = ES3.Load<float>("S_MPCont");
        PS.S_curMPCont = ES3.Load<float>("S_curMPCont");
        PS.S_CostMPCont = ES3.Load<float>("S_CostMPCont");
        PS.S_ExpCont = ES3.Load<float>("S_ExpCont");
        PS.S_curExpCont = ES3.Load<float>("S_curExpCont");
        PS.S_attackCont = ES3.Load<float>("S_attackCont");
        PS.S_defenseCont = ES3.Load<float>("S_defenseCont");
        PS.S_poisonResistanceCont = ES3.Load<float>("S_poisonResistanceCont");
        PS.S_paralysisResistanceCont = ES3.Load<float>("S_paralysisResistanceCont");
        PS.S_sleepResistanceCont = ES3.Load<float>("S_sleepResistanceCont");
   //     PS.S_rustResistanceCont = ES3.Load<int>("S_rustResistanceCont");
        //
        PS.Enemies = ES3.Load<bool[]>("Enemies");
        PS.Treasure = ES3.Load<bool[]>("Treasure");
        //
        PS.Skill_F = ES3.Load<bool[]>("Skill_F");
        PS.Skill_K = ES3.Load<bool[]>("Skill_K");
        PS.Skill_S = ES3.Load<bool[]>("Skill_S");
        //
        PS.quest = ES3.Load<bool[]>("quest");
        PS.QuestActive = ES3.Load<bool[]>("QuestActive");
        PS.QuestComplete = ES3.Load<bool[]>("QuestComplete");
        PS.QuestSegnal = ES3.Load<bool[]>("QuestSegnal");
        //
        PS.I_quantityList = ES3.Load<List<int>>("I_quantityList");
        PS.IBattle_quantityList = ES3.Load<List<int>>("IBattle_quantityList");
        PS.Key_quantityList = ES3.Load<List<int>>("Key_quantityList");
        PS.Quest_quantityList = ES3.Load<List<int>>("Quest_quantityList");
        PS.F_quantityList = ES3.Load<List<int>>("F_quantityList");
        PS.S_quantityList = ES3.Load<List<int>>("S_quantityList");
        PS.K_quantityList = ES3.Load<List<int>>("K_quantityList");
        //
        PS.I_itemList = ES3.Load<List<Item>>("I_itemList");
        PS.IBattle_itemList = ES3.Load<List<Item>>("IBattle_itemList");
        //PS.Key_itemList = ES3.Load<List<Item>>("Key_itemList");
        PS.Quest_itemList = ES3.Load<List<Item>>("Quest_itemList");
        PS.F_itemList = ES3.Load<List<Item>>("F_itemList");
        PS.S_itemList = ES3.Load<List<Item>>("S_itemList");
        PS.K_itemList = ES3.Load<List<Item>>("K_itemList");
        print("Hai caricato");
        
    }
    }

            //GameManager.instance.GM_Data = ES3.Load("GM_Data");

           /* List<string> serializedStrings = JsonUtility.FromJson<List<string>>(jsonData);
            I_itemList.Clear();

            foreach (var serializedString in serializedStrings)
            {
                Item scriptableObject = ScriptableObject.CreateInstance<Item>();
                scriptableObject.IdItem = serializedString;
                I_itemList.Add(scriptableObject);
            }
            }
            else
            {
                Debug.Log("Save file not found. Creating a new one.");
            }*/
    

/*        public List<Item> DeserializeItemList(string filePath)
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
}*/
