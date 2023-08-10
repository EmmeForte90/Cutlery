using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class DuelManager : MonoBehaviour
{

    [Header("Arena")]
    public int EnemyinArena;

    [Header("Fork")]

    public Scrollbar FhealthBar;
    public float FcurrentMP;
    public Scrollbar FMPBar;
    public float FcostMP = 20;
    public float F_SpeedRestore = 5f; // il massimo valore di essenza disponibile


    [Header("Knife")]

    public float KcurrentHealth;
    public Scrollbar KhealthBar;
    public float KcurrentMP;
    public Scrollbar KMPBar;
    public float KcostMP = 15;
    public float K_SpeedRestore = 5f; // il massimo valore di essenza disponibile


    [Header("Spoon")]

    public float ScurrentHealth;
    public Scrollbar ShealthBar;
    public float ScurrentMP;
    public Scrollbar SMPBar;
    public float ScostMP = 10;

    public float S_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    
    [Header("ChangeScene")]

    private SceneEvent sceneEvent;
    public string sceneName;


[Header("Pause")]
    public bool stopInput = false;
    [SerializeField]  GameObject Pause;
    [SerializeField]  GameObject Item;
    [SerializeField]  GameObject Skill;
    public bool inputCTR = false;


[Header("AnimationUI")]
public Animator animator;

public int CharacterID;


public static DuelManager instance;
public void Awake()
    {
         if (instance == null){instance = this;}
        Animator animator = GetComponent<Animator>();
        PlayerStats.instance.F_curHP = PlayerStats.instance.F_HP;
        PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;
        //
        PlayerStats.instance.K_curHP = PlayerStats.instance.K_HP;
        PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;
        //
        PlayerStats.instance.S_curHP = PlayerStats.instance.S_HP;
        PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;
        CharacterID = 1;
        //sceneEvent = GetComponent<SceneEvent>();
        // Aggiungiamo un listener all'evento di cambio scena
        //sceneEvent.onSceneChange.AddListener(ChangeScene);
    }
public void Update()
    {
        FhealthBar.size = PlayerStats.instance.F_curHP / PlayerStats.instance.F_HP;
        FhealthBar.size = Mathf.Clamp(FhealthBar.size, 0.01f, 1);
        //
        FMPBar.size = PlayerStats.instance.F_curMP / PlayerStats.instance.F_MP;
        FMPBar.size = Mathf.Clamp(FMPBar.size, 0.01f, 1);
        //
        KhealthBar.size = PlayerStats.instance.K_curHP / PlayerStats.instance.K_HP;
        KhealthBar.size = Mathf.Clamp(KhealthBar.size, 0.01f, 1);
        //
        KMPBar.size = PlayerStats.instance.K_curMP / PlayerStats.instance.K_MP;
        KMPBar.size = Mathf.Clamp(KMPBar.size, 0.01f, 1);
        //
        ShealthBar.size = PlayerStats.instance.S_curHP / PlayerStats.instance.S_MP;
        ShealthBar.size = Mathf.Clamp(ShealthBar.size, 0.01f, 1);
        //
        SMPBar.size = PlayerStats.instance.S_curMP / PlayerStats.instance.S_MP;
        SMPBar.size = Mathf.Clamp(SMPBar.size, 0.01f, 1);
        //
        //Il nemico attacca il player, creare un fattore randomico così che il nemico scelga il personaggio d'attaccare
        if(CharacterID == 1)
        {SimpleEnemy.instance.TakePlayer();}
        if(CharacterID == 2)
        {SimpleEnemy.instance.TakePlayer();}
        if(CharacterID == 3)
        {SimpleEnemy.instance.TakePlayer();}
        //
        
        FcurrentMP += F_SpeedRestore * Time.deltaTime;
        KcurrentMP += K_SpeedRestore * Time.deltaTime;
        ScurrentMP += S_SpeedRestore * Time.deltaTime;

        if(FcurrentMP >= PlayerStats.instance.F_MP)
        {
            FcurrentMP = PlayerStats.instance.F_MP;
            //Restore = false;
        }
        if(KcurrentMP >= PlayerStats.instance.K_MP)
        {
            KcurrentMP = PlayerStats.instance.K_MP;
            //Restore = false;
        }
        if(ScurrentMP >= PlayerStats.instance.S_MP)
        {
            ScurrentMP = PlayerStats.instance.S_MP;
            //Restore = false;
        }
        


    if(!inputCTR)
    {
       if (Input.GetButtonDown("Pause") && !stopInput)
        {
            stopInput = true;
            StartCoroutine(StartM());
        }
        else if(Input.GetButtonDown("Pause") && stopInput)
        {
            stopInput = false;
            ToggleTimeScale();
            Skill.gameObject.SetActive(false);
            Item.gameObject.SetActive(false);
            StartCoroutine(EndP());
        } 
    }
    }
IEnumerator StartM()
    {
        InputBattle.instance.inputCTR = true;
        Pause.gameObject.SetActive(true);
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(1f);
        ToggleTimeScale();
    }
IEnumerator EndP()
    {
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(1f);
        Pause.gameObject.SetActive(false);
        InputBattle.instance.inputCTR = false;
    }
private void ToggleTimeScale()
    {
        if (Time.timeScale == 1)
        {Time.timeScale = 0.01f;}
        // Rallenta il gioco a metà velocità
        else{Time.timeScale = 1;}
        // Ripristina la velocità normale del gioco  
    }
}