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
    private bool win = true;
    private bool WinEnd = false;
    public AttStats Stats;
    private int result;
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

    public SceneEvent sceneEvent;
    public LevelChanger L_C;
    public string sceneName;


    [Header("Pause")]
    public bool stopInput = false;
    [SerializeField]  GameObject Pause;
    [SerializeField]  GameObject Item;
    [SerializeField]  GameObject Skill;
    [SerializeField]  GameObject Win;

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
        PlayerStats.instance.F_curMP += F_SpeedRestore * Time.deltaTime;
        PlayerStats.instance.K_curMP += K_SpeedRestore * Time.deltaTime;
        PlayerStats.instance.S_curMP += S_SpeedRestore * Time.deltaTime;

        if(PlayerStats.instance.F_curMP >= PlayerStats.instance.F_MP)
        {PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        if(PlayerStats.instance.K_curMP >= PlayerStats.instance.K_MP)
        {PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        if(PlayerStats.instance.S_curMP >= PlayerStats.instance.S_MP)
        {PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}

        if(EnemyinArena <= 0)
        {StartCoroutine(EndBattle());}
        


    /*if(!inputCTR || win)
    {
       if (Input.GetButtonDown("Fire3") && !stopInput)
        {
            stopInput = true;
            CameraZoom.instance.ZoomIn();
            StartCoroutine(StartM());
        }
        else if(Input.GetButtonDown("Fire3") && stopInput)
        {
            stopInput = false;
            ToggleTimeScale();
            CameraZoom.instance.ZoomOut();
            Skill.gameObject.SetActive(false);
            Item.gameObject.SetActive(false);
            StartCoroutine(EndP());
        } 
    }*/
    if(WinEnd)
    {if (Input.GetMouseButtonDown(0)){L_C.Escape();}}
    }
IEnumerator StartM()
    {
        //InputBattle.instance.inputCTR = true;
        inputCTR = true;
        GameManager.instance.ChStop();
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
        GameManager.instance.ChCanM();
        inputCTR = false;
        //InputBattle.instance.inputCTR = false;
    }

IEnumerator EndBattle()
    {
        GameManager.instance.ChStop();
        AudioManager.instance.CrossFadeOUTAudio(1);
        yield return new WaitForSeconds(3f);
        GameManager.instance.battle = true;
        if(win)
        {Win.gameObject.SetActive(true);
        ExpChoise();
        AudioManager.instance.PlaySFX(7);
        GameManager.instance.NotChange(); 
        GameManager.instance.PoseWin();
        Stats.F_GainExperience(result);
        Stats.S_GainExperience(result);
        Stats.K_GainExperience(result);
        win = false;}
        WinEnd = true;
    }
    private void ToggleTimeScale()
    {
        if (Time.timeScale == 1)
        {Time.timeScale = 0.01f;}
        // Rallenta il gioco a metà velocità
        else{Time.timeScale = 1;}
        // Ripristina la velocità normale del gioco  
    }

    private void ExpChoise()
    {
       // Genera un numero casuale tra 1 e 2
        int randomNumber = Random.Range(100, 200);

        // Converte il numero in intero
        result = Mathf.RoundToInt(randomNumber);

         // Stampa il risultato nella console
        Debug.Log("Numero casuale: " + result);
    }

    
}