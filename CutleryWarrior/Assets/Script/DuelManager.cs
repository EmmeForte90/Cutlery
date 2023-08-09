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

[Header("Stats")]

[Header("Fork")]

    public float FmaxHealth = 100f;
    public float FcurrentHealth;
    public Scrollbar FhealthBar;
    public float FmaxMP = 100f;
    public float FcurrentMP;
    public Scrollbar FMPBar;
    public float FcostMP = 20;
    public float F_SpeedRestore = 5f; // il massimo valore di essenza disponibile


    [Header("Knife")]

    public float KmaxHealth = 100f;
    public float KcurrentHealth;
    public Scrollbar KhealthBar;
    public float KmaxMP = 100f;
    public float KcurrentMP;
    public Scrollbar KMPBar;
    public float KcostMP = 15;
    public float K_SpeedRestore = 5f; // il massimo valore di essenza disponibile


    [Header("Spoon")]

    public float SmaxHealth = 100f;
    public float ScurrentHealth;
    public Scrollbar ShealthBar;
    public float SmaxMP = 100f;
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
        FcurrentHealth = FmaxHealth;
        FcurrentMP = FmaxMP;
        //
        KcurrentHealth = KmaxHealth;
        KcurrentMP = KmaxMP;
        //
        ScurrentHealth = SmaxHealth;
        ScurrentMP = SmaxMP;
        CharacterID = 1;
        //sceneEvent = GetComponent<SceneEvent>();
        // Aggiungiamo un listener all'evento di cambio scena
        //sceneEvent.onSceneChange.AddListener(ChangeScene);
    }
public void Update()
    {
        FhealthBar.size = FcurrentHealth / FmaxHealth;
        FhealthBar.size = Mathf.Clamp(FhealthBar.size, 0.01f, 1);
        //
        FMPBar.size = FcurrentMP / FmaxMP;
        FMPBar.size = Mathf.Clamp(FMPBar.size, 0.01f, 1);
        //
        KhealthBar.size = KcurrentHealth / KmaxHealth;
        KhealthBar.size = Mathf.Clamp(KhealthBar.size, 0.01f, 1);
        //
        KMPBar.size = KcurrentMP / KmaxMP;
        KMPBar.size = Mathf.Clamp(KMPBar.size, 0.01f, 1);
        //
        ShealthBar.size = ScurrentHealth / SmaxHealth;
        ShealthBar.size = Mathf.Clamp(ShealthBar.size, 0.01f, 1);
        //
        SMPBar.size = ScurrentMP / SmaxMP;
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

        if(FcurrentMP >= FmaxMP)
        {
            FcurrentMP = FmaxMP;
            //Restore = false;
        }
        if(KcurrentMP >= KmaxMP)
        {
            KcurrentMP = KmaxMP;
            //Restore = false;
        }
        if(ScurrentMP >= SmaxMP)
        {
            ScurrentMP = SmaxMP;
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