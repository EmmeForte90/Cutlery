using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class DuelManager : MonoBehaviour
{
    //public LevelChanger LVCH;
    public GameObject ThisBattle; 
    public int WhatMusicAB;
       
    [Header("Arena")]
    public Vector3 savedPosition;
    public int EnemyinArena;
    private bool win = true;
    public bool WinEnd = false;
    public bool Ending = false;
    public int DieCont = 0;
    public GameObject GameOverBox;
    public AttStats Stats;
    //public Item[] Rewards;
    private int result;
    private int Money;
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;

    [Header("Fork")]
    public Scrollbar FhealthBar;
    public Image FRageBar;
    public GameObject MaxRageF;
    public float FcurrentMP;
    public Scrollbar FMPBar;
    //public float FcostMP = 20;
    public float F_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    public GameObject[] Enemies; 
    public GameObject[] ActiveObj; 
    [SerializeField] CharacterFollow ch_FAc;
    [Header("Knife")]
    //public float KcurrentHealth;
    public Scrollbar KhealthBar;
    public Image KRageBar;
    public GameObject MaxRageK;
    //public float KcurrentMP;
    public Scrollbar KMPBar;
    //public float KcostMP = 15;
    public float K_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_KAc;
    [Header("Spoon")]
    //public float ScurrentHealth;
    public Scrollbar ShealthBar;
    public Image SRageBar;
    public GameObject MaxRageS;
    //public float ScurrentMP;
    public Scrollbar SMPBar;
    //public float ScostMP = 10;
    public float S_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_SAc;
    [Header("Status")]
    public float damagePerSecond = 0.1f;
    public float duration = 5.0f;
    private float elapsedTime = 0.0f;
    private bool isDamaging = false;
    /*[Header("ChangeScene")]
    public SceneEvent sceneEvent;
    public LevelChanger L_C;*/

    [Header("Pause")]
    //public bool stopInput = false;
    //[SerializeField]  GameObject Pause;
    //[SerializeField]  GameObject Item;
    //[SerializeField]  GameObject Skill;
    [SerializeField]  GameObject Win;
    private int ID_Enm;
    public bool inputCTR = false;
    //[Header("AnimationUI")]
    //public Animator animator;
    public int CharacterID;
    [Header("TimelineAfterBattle")]
    public GameObject pointView; 
    private CinemachineVirtualCamera virtualCamera; //riferimento alla virtual camera di Cinemachine
    public bool F_isRight = false;    
    public bool S_isRight = false;
    public bool K_isRight = false;
    public bool isTimeline = false;
    public GameObject ActorSpoon;
    public GameObject ActorKnife;
    public GameObject ActorFork;

    public static DuelManager instance;
public void Awake()
    {
        if (instance == null){instance = this;}
        savedPosition = GameManager.instance.savedPosition;
        //
        if(GameManager.instance.F_Unlock){DieCont++;}       
        if(GameManager.instance.S_Unlock){DieCont++;}      
        if(GameManager.instance.K_Unlock){DieCont++;}
        //
        //Animator animator = GetComponent<Animator>();
        if(GameManager.instance.F_Unlock){
        PlayerStats.instance.F_curHP = PlayerStats.instance.F_HP;
        PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        //
        if(GameManager.instance.K_Unlock){
        PlayerStats.instance.K_curHP = PlayerStats.instance.K_HP;
        PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        //
        if(GameManager.instance.S_Unlock){
        PlayerStats.instance.S_curHP = PlayerStats.instance.S_HP;
        PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}
        CharacterID = 1; 
        if(GameManager.instance.S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(GameManager.instance.F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(GameManager.instance.K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        //
        if(GameManager.instance.F_Unlock){FAct = GameObject.FindWithTag("F_Player");}
        if(GameManager.instance.S_Unlock){SAct = GameObject.FindWithTag("S_Player");}
        if(GameManager.instance.K_Unlock){KAct = GameObject.FindWithTag("K_Player");}
        //
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curRage = 0;}       
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curRage = 0;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curRage = 0;}
        /*if(isRight){
        if(GameManager.instance.F_Unlock){FAct.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.S_Unlock){KAct.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.S_Unlock){SAct.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.S_Unlock){ch_SAc.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.F_Unlock){ch_FAc.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.K_Unlock){ch_KAc.transform.localScale = new Vector3(1, 1,1);}
        }
        else if(!isRight){
        if(GameManager.instance.F_Unlock){FAct.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.S_Unlock){KAct.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.S_Unlock){SAct.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.S_Unlock){ch_SAc.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.F_Unlock){ch_FAc.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.K_Unlock){ch_KAc.transform.localScale = new Vector3(-1, 1,1);}
        }*/
         ID_Enm = GameManager.instance.IdENM;
        StartCoroutine(StartAI());    
    }
public void Update()
    {
        if(GameManager.instance.F_Unlock){
        FhealthBar.size = PlayerStats.instance.F_curHP / PlayerStats.instance.F_HP;
        FhealthBar.size = Mathf.Clamp(FhealthBar.size, 0.01f, 1);        
        //
        FMPBar.size = PlayerStats.instance.F_curMP / PlayerStats.instance.F_MP;
        FMPBar.size = Mathf.Clamp(FMPBar.size, 0.01f, 1);
        //
        FRageBar.fillAmount = PlayerStats.instance.F_curRage / PlayerStats.instance.F_Rage;
        FRageBar.fillAmount = Mathf.Clamp(FRageBar.fillAmount, 0.01f, 1);}
        ////////////////////////////////////////////////////////
        if(GameManager.instance.K_Unlock){
        KhealthBar.size = PlayerStats.instance.K_curHP / PlayerStats.instance.K_HP;
        KhealthBar.size = Mathf.Clamp(KhealthBar.size, 0.01f, 1);
        //
        KMPBar.size = PlayerStats.instance.K_curMP / PlayerStats.instance.K_MP;
        KMPBar.size = Mathf.Clamp(KMPBar.size, 0.01f, 1);
        //
        KRageBar.fillAmount = PlayerStats.instance.K_curRage / PlayerStats.instance.K_Rage;
        KRageBar.fillAmount = Mathf.Clamp(KRageBar.fillAmount, 0.01f, 1);}
        //////////////////////////////////////////////////////////
        if(GameManager.instance.S_Unlock){
        ShealthBar.size = PlayerStats.instance.S_curHP / PlayerStats.instance.S_HP;
        ShealthBar.size = Mathf.Clamp(ShealthBar.size, 0.01f, 1);
        //
        SMPBar.size = PlayerStats.instance.S_curMP / PlayerStats.instance.S_MP;
        SMPBar.size = Mathf.Clamp(SMPBar.size, 0.01f, 1);
        //
        SRageBar.fillAmount = PlayerStats.instance.S_curRage / PlayerStats.instance.S_Rage;
        SRageBar.fillAmount = Mathf.Clamp(SRageBar.fillAmount, 0.01f, 1);}
        //           
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curMP += F_SpeedRestore * Time.deltaTime;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curMP += K_SpeedRestore * Time.deltaTime;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curMP += S_SpeedRestore * Time.deltaTime;}
        //
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curMP >= PlayerStats.instance.F_MP)
        {PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curMP >= PlayerStats.instance.K_MP)
        {PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curMP >= PlayerStats.instance.S_MP)
        {PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}
        //
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curMP <= 0)
        {PlayerStats.instance.F_curMP = 1;}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curMP <= 0)
        {PlayerStats.instance.S_curMP = 1;}
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curMP <= 0)
        {PlayerStats.instance.K_curMP = 1;}
        //
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curRage >= PlayerStats.instance.K_Rage)
        {MaxRageK.SetActive(true);} 
        else if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curRage < PlayerStats.instance.K_Rage)
        {MaxRageK.SetActive(false);}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curRage >= PlayerStats.instance.S_Rage)
        {MaxRageS.SetActive(true);} 
        else if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curRage < PlayerStats.instance.S_Rage)
        {MaxRageS.SetActive(false);}
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curRage >= PlayerStats.instance.F_Rage)
        {MaxRageF.SetActive(true);} 
        else if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curRage < PlayerStats.instance.F_Rage)
        {MaxRageF.SetActive(false);}
        //
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curHP <= 0)
        {GameManager.instance.PoseDeathS(); DieCont--;}
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curHP <= 0)
        {GameManager.instance.PoseDeathK(); DieCont--;}
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curHP <= 0)
        {GameManager.instance.PoseDeathF(); DieCont--;}
        //
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_paralysisResistance <= 0)
        {GameManager.instance.StunF();}
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_paralysisResistance <= 0)
        {GameManager.instance.StunK();}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_paralysisResistance <= 0)
        {GameManager.instance.StunS();}
        //
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_poisonResistance <= 0)
        {GameManager.instance.PoisonF();
        isDamaging = true;
        elapsedTime = 0.0f;
        if (isDamaging)
        {
            elapsedTime += Time.deltaTime;
            PlayerStats.instance.F_curHP -= damagePerSecond;
            if (elapsedTime >= duration)
            {
                // Il periodo di danno è terminato
                isDamaging = false;
            }
        }}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_poisonResistance <= 0)
        {GameManager.instance.PoisonS();
        isDamaging = true;
        elapsedTime = 0.0f;
        if (isDamaging)
        {
            elapsedTime += Time.deltaTime;
            PlayerStats.instance.S_curHP -= damagePerSecond;
            if (elapsedTime >= duration)
            {
                // Il periodo di danno è terminato
                isDamaging = false;
            }
        }
        }
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_poisonResistance <= 0)
        {GameManager.instance.PoisonK();isDamaging = true;
        elapsedTime = 0.0f;
        if (isDamaging)
        {
            elapsedTime += Time.deltaTime;
            PlayerStats.instance.K_curHP -= damagePerSecond;
            if (elapsedTime >= duration)
            {
                // Il periodo di danno è terminato
                isDamaging = false;
            }
        }}
        if(EnemyinArena <= 0){StartCoroutine(EndBattle());}
        //
        if(WinEnd){if(Input.GetMouseButtonDown(0)){StartCoroutine(RetunBattle());}}
        if(DieCont <= 0){StartCoroutine(GameOver());}   
        if(Ending){if(Input.GetMouseButtonDown(0)){StartCoroutine(ReturnMainMenu());}} 

    }
    IEnumerator GameOver()
    {
        inputCTR = true;
        AudioManager.instance.CrossFadeOUTAudio(1);
       yield return new WaitForSeconds(5f);
        AudioManager.instance.CrossFadeINAudio(2);
       GameOverBox.SetActive(true);
       Ending = true;
    }

    IEnumerator ReturnMainMenu()
    {   
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(2f);
    GameManager.instance.StartGame = true;
    SceneManager.LoadScene (sceneName:"MainMenu");
    GameManager.instance.DestroyManager();
    }
    

    // Metodo per iniziare il danno nel tempo
    public void StartDamaging()
    {
        isDamaging = true;
        elapsedTime = 0.0f;
        InvokeRepeating("ApplyDamage", 0.0f, 1.0f);
    }

    // Metodo per interrompere il danno nel tempo
    public void StopDamaging()
    {
        isDamaging = false;
        CancelInvoke("ApplyDamage");
    }
IEnumerator StartAI()
    {
        yield return new WaitForSeconds(3f);
        if(GameManager.instance.K_Unlock){ch_KAc.order = 1;}
        if(GameManager.instance.S_Unlock){ch_SAc.order = 2;}
        if(GameManager.instance.F_Unlock){ch_FAc.order = 1;}
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
        if(GameManager.instance.F_Unlock){Stats.F_GainExperience(result);}
        if(GameManager.instance.S_Unlock){Stats.S_GainExperience(result);}
        if(GameManager.instance.K_Unlock){Stats.K_GainExperience(result);}
        GameManager.instance.AddTomoney(Money);
        PlayerStats.instance.EnemyDefeatArea(GameManager.instance.IdENM);
        //LVCH.sceneName = GameManager.instance.sceneName;
        //Reward();
        win = false;}
        WinEnd = true;
    }
    private void ToggleTimeScale()
    {
        if (Time.timeScale == 1){Time.timeScale = 0.01f;}
        else{Time.timeScale = 1;}
    }
     IEnumerator RetunBattle()
    {   
    GameManager.instance.StartGame = false;
    CharacterMove.instance.inputCTR = true;
    CharacterMove.instance.Idle();
    GameManager.instance.FadeIn();
    AudioManager.instance.CrossFadeOUTAudio(1);
    yield return new WaitForSeconds(2f);
    foreach (GameObject arenaObject in ActiveObj){arenaObject.SetActive(true);}
    //SwitchCharacter.instance.ActiveCH();
    if(GameManager.instance.K_Unlock){ch_KAc.IDAction = 0;}
    if(GameManager.instance.S_Unlock){ch_SAc.IDAction = 0;}
    if(GameManager.instance.F_Unlock){ch_FAc.IDAction = 0;}
    GameManager.instance.Exploration();
    GameManager.instance.Change();
    GameManager.instance.RecalculateCharacter();
    if(isTimeline){ResetCamera();}
    else if(!isTimeline){SpawnB();}
    GameManager.instance.FadeOut();
    }

    public  void ResetCamera()
    {
    virtualCamera = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    virtualCamera.Follow =  pointView.transform;
    if(GameManager.instance.F_Unlock)
    {FAct.transform.position = ActorFork.transform.position;
    if(F_isRight){FAct.transform.localScale = new Vector3(1, 1,1);}
    else if(!F_isRight){FAct.transform.localScale = new Vector3(-1, 1,1);}
    }
    if(GameManager.instance.S_Unlock)
    {SAct.transform.position = ActorSpoon.transform.position;
    if(S_isRight){SAct.transform.localScale = new Vector3(1, 1,1);}
    else if(!S_isRight){SAct.transform.localScale = new Vector3(-1, 1,1);}
    }
    if(GameManager.instance.K_Unlock)
    {KAct.transform.position = ActorKnife.transform.position;
    if(K_isRight){KAct.transform.localScale = new Vector3(1, 1,1);}
    else if(!K_isRight){KAct.transform.localScale = new Vector3(-1, 1,1);}
    ThisBattle.SetActive(false);
    }
    GameManager.instance.ChCanM();
    Destroy(this);
    }
    public void SpawnB()
    {
    GameManager.instance.battle = false;
    if(GameManager.instance.F_Unlock){FAct.transform.position = savedPosition;}
    if(GameManager.instance.K_Unlock){KAct.transform.position = savedPosition;}
    if(GameManager.instance.S_Unlock){SAct.transform.position = savedPosition;}
    foreach (GameObject arenaObject in Enemies){arenaObject.SetActive(false);}
    GameManager.instance.StopWin();
    GameManager.instance.ChCanM();
    GameManager.instance.ActiveMinimap();
    AudioManager.instance.CrossFadeINAudio(WhatMusicAB);
    ThisBattle.SetActive(false);
    }
    //public void EnemiesActive(int ID){Enemies[ID].SetActive(false);}
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