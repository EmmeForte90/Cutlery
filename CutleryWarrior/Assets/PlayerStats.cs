using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("Stats")]

    [Header("Fork")]

    [SerializeField] public int F_LV = 1;

    [SerializeField] public float F_HP = 0;
    [SerializeField] public float F_curHP = 0;
    [SerializeField] public float F_MP = 0;
    [SerializeField] public float F_curMP = 0;
    [SerializeField] public float F_Exp = 0;
    [SerializeField] public float F_curExp = 0;
    [SerializeField] public int F_attack = 10;
    [SerializeField] public int F_defense = 5;
    [SerializeField] public int F_poisonResistance = 0;
    [SerializeField] public int F_paralysisResistance = 0;
    [SerializeField] public int F_sleepResistance = 0;
    [SerializeField] public int F_rustResistance = 0;

    [Header("Spoon")]

    [SerializeField] public int S_LV = 1;

    [SerializeField] public float S_HP = 0;
    [SerializeField] public float S_curHP = 0;
    [SerializeField] public float S_MP = 0;
    [SerializeField] public float S_curMP = 0;
    [SerializeField] public float S_Exp = 0;
    [SerializeField] public float S_curExp = 0;

    [SerializeField] public int S_attack = 10;
    [SerializeField] public int S_defense = 5;
    [SerializeField] public int S_poisonResistance = 0;
    [SerializeField] public int S_paralysisResistance = 0;
    [SerializeField] public int S_sleepResistance = 0;
    [SerializeField] public int S_rustResistance = 0; 
   


    [Header("Knife")]
    [SerializeField] public int K_LV = 1;

    [SerializeField] public float K_HP = 0;
    [SerializeField] public float K_curHP = 0;
    [SerializeField] public float K_MP = 0;
    [SerializeField] public float K_curMP = 0;
    [SerializeField] public float K_Exp = 0;
    [SerializeField] public float K_curExp = 0;

    [SerializeField] public int K_attack = 10;
    [SerializeField] public int K_defense = 5;
    [SerializeField] public int K_poisonResistance = 0;
    [SerializeField] public int K_paralysisResistance = 0;
    [SerializeField] public int K_sleepResistance = 0;
    [SerializeField] public int K_rustResistance = 0; 

    public static PlayerStats instance;
   
    public void Awake()
    {if (instance == null){instance = this;}}
    // Metodo chiamato quando il giocatore sale di livello

    public void TestExp()
    {
        F_GainExperience(50);
        K_GainExperience(50);
        S_GainExperience(50);
    }
    public void F_LevelUp()
    {
        // Aumento degli attributi
        F_HP += 50;
        F_MP = +50;
        F_attack += 10;
        F_defense += 5;
        F_poisonResistance += 2;
        F_paralysisResistance += 2;
        F_sleepResistance += 2;
        F_rustResistance += 2;

        // Aumento del livello
        F_LV++;

        // Aumento del numero massimo di esperienza
        F_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello

        // Reset dell'esperienza corrente
        F_curExp = 0;

        // Puoi anche inserire qui la logica per aggiornare la UI e mostrare le nuove statistiche al giocatore
        GameManager.instance.StatPlayer();
    }

    public void K_LevelUp()
    {
        // Aumento degli attributi
        K_HP += 100;
        K_MP = +30;
        K_attack += 20;
        K_defense += 5;
        K_poisonResistance += 1;
        K_paralysisResistance += 1;
        K_sleepResistance += 1;
        K_rustResistance += 1;

        // Aumento del livello
        K_LV++;

        // Aumento del numero massimo di esperienza
        K_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello

        // Reset dell'esperienza corrente
        K_curExp = 0;

        // Puoi anche inserire qui la logica per aggiornare la UI e mostrare le nuove statistiche al giocatore
        GameManager.instance.StatPlayer();
    }

    public void S_LevelUp()
    {
        // Aumento degli attributi
        S_HP += 50;
        S_MP = +40;
        S_attack += 5;
        S_defense += 10;
        S_poisonResistance += 3;
        S_paralysisResistance += 3;
        S_sleepResistance += 3;
        S_rustResistance += 3;

        // Aumento del livello
        S_LV++;

        // Aumento del numero massimo di esperienza
        S_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello

        // Reset dell'esperienza corrente
        S_curExp = 0;

        // Puoi anche inserire qui la logica per aggiornare la UI e mostrare le nuove statistiche al giocatore
        GameManager.instance.StatPlayer();
    }

    // Metodo chiamato quando il giocatore guadagna esperienza
    public void F_GainExperience(int amount)
    {
        F_curExp += amount;
        // Se il giocatore ha guadagnato abbastanza esperienza per salire di livello, chiama il metodo LevelUp()
        if (F_curExp >= F_Exp)
        {F_LevelUp();}
    }
    public void K_GainExperience(int amount)
    {
        K_curExp += amount;
        // Se il giocatore ha guadagnato abbastanza esperienza per salire di livello, chiama il metodo LevelUp()
        if (K_curExp >= K_Exp)
        {K_LevelUp();}
    }
    public void S_GainExperience(int amount)
    {
        S_curExp += amount;
        // Se il giocatore ha guadagnato abbastanza esperienza per salire di livello, chiama il metodo LevelUp()
        if (S_curExp >= S_Exp)
        {S_LevelUp();}
    }
}