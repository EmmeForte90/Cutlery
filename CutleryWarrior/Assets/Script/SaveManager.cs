using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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
    [SerializeField]    public List<Item> Kay_itemList;
    [SerializeField]    public List<int> Key_quantityList;
    [SerializeField]    public List<Item> Quest_itemList;
    [SerializeField]    public List<int> Quest_quantityList;
    public string F_NameWeapon;
    public string S_NameWeapon;
    public string K_NameWeapon;
    public string F_NameArmor;
    public string S_NameArmor;
    public string K_NameArmor;


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
    //public bool Saving = false;
    //public string NameScene;
    //public string saveFilePath;
    //public GameManager GM_Data;
    //public string F_NameWeapon;
    //public string S_NameWeapon;
    //public string K_NameWeapon;
    //public string F_NameArmor;
    //public string S_NameArmor;
    //public string K_NameArmor;

    public static SaveManager instance;
    //
    [SerializeField]    public PlayerStats PS;
    
    public void SaveGame()
    {
        ES3.Save("savedPosition", PS.savedPosition);
        ES3.Save("IdSpawn", PS.IdSpawn);
        //
        ES3.Save("NameScene", PS.NameScene);
        ES3.Save("HaveData", PS.HaveData);
        ES3.Save("CanLoading", PS.CanLoading);
        //
        PS.F_NameWeapon = GameManager.instance.Inv.F_NameWeapon;
        PS.S_NameWeapon = GameManager.instance.Inv.S_NameWeapon;
        PS.K_NameWeapon = GameManager.instance.Inv.K_NameWeapon;
        PS.F_NameArmor = GameManager.instance.Inv.F_NameArmor;
        PS.S_NameArmor = GameManager.instance.Inv.S_NameArmor;
        PS.K_NameArmor = GameManager.instance.Inv.K_NameArmor;
        //
        ES3.Save("F_NameWeapon", PS.F_NameWeapon);
        ES3.Save("S_NameWeapon", PS.S_NameWeapon);
        ES3.Save("K_NameWeapon", PS.K_NameWeapon);
        ES3.Save("F_NameArmor", PS.F_NameArmor);
        ES3.Save("S_NameArmor", PS.S_NameArmor);
        ES3.Save("K_NameArmor", PS.K_NameArmor);
        /*print("PS.F_NameWeapon" + PS.F_NameWeapon);
        print("PS.S_NameWeapon" + PS.S_NameWeapon);
        print("PS.K_NameWeapon" + PS.K_NameWeapon);
        print("PS.F_NameArmor" + PS.F_NameArmor);
        print("PS.K_NameArmor" + PS.K_NameWeapon);
        print("PS.S_NameArmor" + PS.S_NameArmor);*/
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
        ES3.Save("Timelines", PS.Timelines);
        ES3.Save("EventsDesert", PS.EventsDesert); 
        ES3.Save("SwitchDesert", PS.SwitchDesert);
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
        ES3.Save("Kay_itemList", PS.Kay_itemList);
        ES3.Save("Quest_itemList", PS.Quest_itemList);
        ES3.Save("F_itemList", PS.F_itemList);
        ES3.Save("S_itemList", PS.S_itemList);
        ES3.Save("K_itemList", PS.K_itemList);
        //
        ES3.Save("K_itemList", PS.K_itemList);
    }


    public void LoadGame()
    {
        PS.savedPosition = ES3.Load<Vector3>("savedPosition");
        PS.IdSpawn = ES3.Load<int>("IdSpawn");
        //////////////////////////////////////////////
        PS.I_itemList = null;
        PS.IBattle_itemList = null;
        PS.Kay_itemList = null;
        PS.Quest_itemList = null;
        PS.F_itemList = null;
        PS.S_itemList = null;
        PS.K_itemList = null;
        ////////////////////////////////////////////////
        PS.NameScene = ES3.Load<string>("NameScene");
        PS.HaveData = ES3.Load<bool>("HaveData");
        PS.CanLoading = ES3.Load<bool>("CanLoading");
        //
        PS.F_Unlock = ES3.Load<bool>("F_Unlock");
        PS.S_Unlock = ES3.Load<bool>("S_Unlock");
        PS.K_Unlock = ES3.Load<bool>("K_Unlock");
        GameManager.instance.F_Unlock = PS.F_Unlock;
        GameManager.instance.S_Unlock = PS.S_Unlock;
        GameManager.instance.K_Unlock = PS.K_Unlock;
        //
        PS.Money = ES3.Load<int>("Money");
        GameManager.instance.money = PS.Money;
        GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
        PS.WhatMusic = ES3.Load<int>("WhatMusic");
        /////////////////////////////////////////
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
        PS.F_rustResistanceCont = ES3.Load<float>("F_rustResistanceCont");
        /////////////////////////////////////////
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
        PS.K_rustResistanceCont = ES3.Load<float>("K_rustResistanceCont");
        /////////////////////////////////////////
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
        PS.S_rustResistanceCont = ES3.Load<float>("S_rustResistanceCont");
        //////////////////////////////////////////
        GameManager.instance.F_ExpTextM.text = GameManager.instance.F_Exp.ToString(); 
        GameManager.instance.S_ExpTextM.text = GameManager.instance.S_Exp.ToString();    
        GameManager.instance.K_ExpTextM.text = GameManager.instance.K_Exp.ToString(); 
        ///////////////////////////////////////
        PS.Enemies = ES3.Load<bool[]>("Enemies");
        PS.Treasure = ES3.Load<bool[]>("Treasure");
        PS.EventsDesert = ES3.Load<bool[]>("EventsDesert");
        PS.Timelines = ES3.Load<bool[]>("Timelines");
        PS.SwitchDesert = ES3.Load<bool[]>("SwitchDesert");
        //
        PS.Skill_F = ES3.Load<bool[]>("Skill_F");
        PS.Skill_K = ES3.Load<bool[]>("Skill_K");
        PS.Skill_S = ES3.Load<bool[]>("Skill_S");
        //
        PS.quest = ES3.Load<bool[]>("quest");
        PS.QuestActive = ES3.Load<bool[]>("QuestActive");
        PS.QuestComplete = ES3.Load<bool[]>("QuestComplete");
        PS.QuestSegnal = ES3.Load<bool[]>("QuestSegnal");
        /////////////////////////////////////////
        PS.I_itemList = ES3.Load<List<Item>>("I_itemList");
        PS.IBattle_itemList = ES3.Load<List<Item>>("IBattle_itemList");
        PS.Kay_itemList = ES3.Load<List<Item>>("Kay_itemList");
        PS.Quest_itemList = ES3.Load<List<Item>>("Quest_itemList");
        /////////////////////////////////////////
        PS.I_quantityList = null;
        PS.IBattle_quantityList = null;
        PS.Key_quantityList = null;
        PS.Quest_quantityList = null;
        if(GameManager.instance.F_Unlock){PS.F_quantityList = null;}
        if(GameManager.instance.S_Unlock){PS.S_quantityList = null;}
        if(GameManager.instance.K_Unlock){PS.K_quantityList = null;}
        //
        PS.I_quantityList = ES3.Load<List<int>>("I_quantityList");
        GameManager.instance.Inv.quantityList = PS.I_quantityList;
        GameManager.instance.Inv.UpdateInventoryUI();
        PS.IBattle_quantityList = ES3.Load<List<int>>("IBattle_quantityList");
        GameManager.instance.InvB.quantityList = PS.IBattle_quantityList;
        GameManager.instance.InvB.UpdateInventoryUI();
        PS.Key_quantityList = ES3.Load<List<int>>("Key_quantityList");
        GameManager.instance.KM.quantityList = PS.Key_quantityList;
        GameManager.instance.KM.UpdateInventoryUI();
        PS.Quest_quantityList = ES3.Load<List<int>>("Quest_quantityList");
        GameManager.instance.QuM.quantityList = PS.Quest_quantityList;
        GameManager.instance.QuM.UpdateInventoryUI();
        ///////////////////////////////////////////////
        if(GameManager.instance.S_Unlock){
        PS.S_itemList = ES3.Load<List<Item>>("S_itemList");
        PS.S_quantityList = ES3.Load<List<int>>("S_quantityList");
        GameManager.instance.M_S.quantityList = PS.S_quantityList;
        GameManager.instance.M_S.UpdateInventoryUI();
        
        PS.S_NameWeapon = ES3.Load<string>("S_NameWeapon");
        PS.S_NameArmor = ES3.Load<string>("S_NameArmor");
        //print("PS.S_NameWeapon" + PS.S_NameWeapon);
        //print("PS.S_NameArmor" + PS.S_NameArmor);
        
        GameManager.instance.Inv.Skin_S.Weapon = PS.S_NameWeapon;
        GameManager.instance.Inv.Puppets_S.Weapon = PS.S_NameWeapon;
        GameManager.instance.Inv.Skin_S.DressSkin = PS.S_NameArmor;
        GameManager.instance.Inv.Puppets_S.DressSkin = PS.S_NameArmor;
        GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Skin_S.Weapon);
	    GameManager.instance.Inv.Skin_S.UpdateCombinedSkin();
        GameManager.instance.Inv.Puppets_S.UpdateCharacterSkinUI(GameManager.instance.Inv.Skin_S.Weapon);
        GameManager.instance.Inv.Puppets_S.UpdateCombinedSkinUI();
        //__//
        GameManager.instance.Inv.Skin_S.UpdateCharacterSkin(GameManager.instance.Inv.Puppets_S.DressSkin);
	    GameManager.instance.Inv.Skin_S.UpdateCombinedSkin();
        //GameManager.instance.Inv.Puppets_S.UpdateCharacterSkinUI(GameManager.instance.Inv.Puppets_S.DressSkin);
        //GameManager.instance.Inv.Puppets_S.UpdateCombinedSkinUI();
        }
        /////////////////////////////////////////
        if(GameManager.instance.F_Unlock){
        PS.F_itemList = ES3.Load<List<Item>>("F_itemList");
        PS.F_quantityList = ES3.Load<List<int>>("F_quantityList");
        GameManager.instance.M_F.quantityList = PS.F_quantityList;
        GameManager.instance.M_F.UpdateInventoryUI();
        PS.F_NameWeapon = ES3.Load<string>("F_NameWeapon");
        PS.F_NameArmor = ES3.Load<string>("F_NameArmor");
        //print("PS.F_NameWeapon" + PS.F_NameWeapon);
        //print("PS.F_NameArmor" + PS.F_NameArmor);

        GameManager.instance.Inv.Skin_F.Weapon = PS.F_NameWeapon;
        GameManager.instance.Inv.Puppets_F.Weapon = PS.F_NameWeapon;
        GameManager.instance.Inv.Skin_F.DressSkin = PS.F_NameArmor;
        GameManager.instance.Inv.Puppets_F.DressSkin = PS.F_NameArmor;
        GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Skin_F.Weapon);
	    GameManager.instance.Inv.Skin_F.UpdateCombinedSkin();
        //GameManager.instance.Inv.Puppets_F.UpdateCharacterSkinUI(GameManager.instance.Inv.Skin_F.Weapon);
        //GameManager.instance.Inv.Puppets_F.UpdateCombinedSkinUI();
        //__//
        GameManager.instance.Inv.Skin_F.UpdateCharacterSkin(GameManager.instance.Inv.Puppets_F.DressSkin);
	    GameManager.instance.Inv.Skin_F.UpdateCombinedSkin();
        //GameManager.instance.Inv.Puppets_F.UpdateCharacterSkinUI(GameManager.instance.Inv.Puppets_F.DressSkin);
        //GameManager.instance.Inv.Puppets_F.UpdateCombinedSkinUI();
        }
        /////////////////////////////////////////
        if(GameManager.instance.K_Unlock){
        PS.K_itemList = ES3.Load<List<Item>>("K_itemList");
        PS.K_quantityList = ES3.Load<List<int>>("K_quantityList"); 
        GameManager.instance.M_K.quantityList = PS.K_quantityList;
        GameManager.instance.M_K.UpdateInventoryUI();
        PS.K_NameWeapon = ES3.Load<string>("K_NameWeapon");
        PS.K_NameArmor = ES3.Load<string>("K_NameArmor");
        //print("PS.k_NameArmor" + PS.K_NameWeapon);
        //print("PS.K_NameWeapon" + PS.K_NameWeapon);

        GameManager.instance.Inv.Skin_K.Weapon = PS.K_NameWeapon;
        GameManager.instance.Inv.Puppets_K.Weapon = PS.K_NameWeapon;
        GameManager.instance.Inv.Skin_K.DressSkin = PS.K_NameArmor;
        GameManager.instance.Inv.Puppets_K.DressSkin = PS.K_NameArmor;
        GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Skin_K.Weapon);
	    GameManager.instance.Inv.Skin_K.UpdateCombinedSkin();
        //GameManager.instance.Inv.Puppets_K.UpdateCharacterSkinUI(GameManager.instance.Inv.Skin_K.Weapon);
        //GameManager.instance.Inv.Puppets_K.UpdateCombinedSkinUI();
        //__//
        GameManager.instance.Inv.Skin_K.UpdateCharacterSkin(GameManager.instance.Inv.Puppets_K.DressSkin);
	    GameManager.instance.Inv.Skin_K.UpdateCombinedSkin();
       // GameManager.instance.Inv.Puppets_K.UpdateCharacterSkinUI(GameManager.instance.Inv.Puppets_K.DressSkin);
        //GameManager.instance.Inv.Puppets_K.UpdateCombinedSkinUI();
        }
        ///////////////////////////////
        print("Hai caricato");  
    }
}