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
    public LevelChanger LVCH;
    [Header("Arena")]
    public int EnemyinArena;
    private bool win = true;
    private bool WinEnd = false;
    public AttStats Stats;
    public Item[] Rewards;
    private int specificQuant = 1;
    private int result;
    private int Money;
    private int ItemN;
    [Header("Fork")]
    public Scrollbar FhealthBar;
    public float FcurrentMP;
    public Scrollbar FMPBar;
    public float FcostMP = 20;
    public float F_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_FAc;
    [Header("Knife")]
    public float KcurrentHealth;
    public Scrollbar KhealthBar;
    public float KcurrentMP;
    public Scrollbar KMPBar;
    public float KcostMP = 15;
    public float K_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_KAc;
    [Header("Spoon")]
    public float ScurrentHealth;
    public Scrollbar ShealthBar;
    public float ScurrentMP;
    public Scrollbar SMPBar;
    public float ScostMP = 10;
    public float S_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_SAc;
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
        ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();
        ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();
        ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();
        StartCoroutine(StartAI());    
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
        //
        if(PlayerStats.instance.F_curMP >= PlayerStats.instance.F_MP)
        {PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        if(PlayerStats.instance.K_curMP >= PlayerStats.instance.K_MP)
        {PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        if(PlayerStats.instance.S_curMP >= PlayerStats.instance.S_MP)
        {PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}
        //
        if(EnemyinArena <= 0)
        {StartCoroutine(EndBattle());}
        if(WinEnd){if (Input.GetMouseButtonDown(0)){L_C.Escape();}}
    }
IEnumerator StartAI()
    {
        yield return new WaitForSeconds(3f);
        ch_KAc.order = 1;ch_SAc.order = 2;ch_FAc.order = 1;
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
        RandomReward();
        AudioManager.instance.PlaySFX(7);
        GameManager.instance.NotChange(); 
        GameManager.instance.PoseWin();
        Stats.F_GainExperience(result);
        Stats.S_GainExperience(result);
        Stats.K_GainExperience(result);
        GameManager.instance.AddTomoney(Money);
        PlayerStats.instance.EnemyDefeatArea(GameManager.instance.IdENM);
        LVCH.sceneName = sceneName;
        //Reward();
        win = false;}
        WinEnd = true;
    }
    private void ToggleTimeScale()
    {
        if (Time.timeScale == 1){Time.timeScale = 0.01f;}
        else{Time.timeScale = 1;}
    }
    private void RandomReward()
    {
        int randomNumber = Random.Range(10, 20);
        int randomNumberM = Random.Range(10, 50);
       // int randomNumberItem = Random.Range(1, 100);
        result = Mathf.RoundToInt(randomNumber);
        Money = Mathf.RoundToInt(randomNumberM);
        //ItemN = Mathf.RoundToInt(randomNumberItem);
       // Debug.Log("Numero casuale: " + result);
        Debug.Log("Numero casuale: " + Money);
        //Debug.Log("Numero casuale: " + ItemN);
    }
    /*private void Reward()
    {
        if(ItemN <= 20)//20% Di possibilità
        {Inventory.instance.AddItem(Rewards[1], specificQuant);}
        else if(ItemN <= 50)//50% Di possibilità
        {Inventory.instance.AddItem(Rewards[2], specificQuant);  
        InventoryB.instance.AddItem(Rewards[2], specificQuant);}
         else if(ItemN <= 80)//80% Di possibilità
        {Inventory.instance.AddItem(Rewards[3], specificQuant);  
        InventoryB.instance.AddItem(Rewards[3], specificQuant);}
    }*/
}