using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DuelManager : MonoBehaviour
{
    public LevelChanger LVCH;
    [Header("Arena")]
    public int EnemyinArena;
    private bool win = true;
    public bool WinEnd = false;
    public AttStats Stats;
    public Item[] Rewards;
    private int specificQuant = 1;
    private int result;
    private int Money;
    private int ItemN;
    [Header("Fork")]
    public Scrollbar FhealthBar;
    public Image FRageBar;
    public GameObject MaxRageF;
    public float FcurrentMP;
    public Scrollbar FMPBar;
    public float FcostMP = 20;
    public float F_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_FAc;
    [Header("Knife")]
    public float KcurrentHealth;
    public Scrollbar KhealthBar;
    public Image KRageBar;
    public GameObject MaxRageK;
    public float KcurrentMP;
    public Scrollbar KMPBar;
    public float KcostMP = 15;
    public float K_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_KAc;
    [Header("Spoon")]
    public float ScurrentHealth;
    public Scrollbar ShealthBar;
    public Image SRageBar;
    public GameObject MaxRageS;

    public float ScurrentMP;
    public Scrollbar SMPBar;
    public float ScostMP = 10;
    public float S_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_SAc;
    [Header("Status")]
    public float damagePerSecond = 0.1f;
    public float duration = 5.0f;
    private float elapsedTime = 0.0f;
    private bool isDamaging = false;
    [Header("ChangeScene")]
    public SceneEvent sceneEvent;
    public LevelChanger L_C;

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
        PlayerStats.instance.F_curRage = 0;        
        PlayerStats.instance.S_curRage = 0;
        PlayerStats.instance.K_curRage = 0;
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
        FRageBar.fillAmount = PlayerStats.instance.F_curRage / PlayerStats.instance.F_Rage;
        FRageBar.fillAmount = Mathf.Clamp(FRageBar.fillAmount, 0.01f, 1);
        ////////////////////////////////////////////////////////
        KhealthBar.size = PlayerStats.instance.K_curHP / PlayerStats.instance.K_HP;
        KhealthBar.size = Mathf.Clamp(KhealthBar.size, 0.01f, 1);
        //
        KMPBar.size = PlayerStats.instance.K_curMP / PlayerStats.instance.K_MP;
        KMPBar.size = Mathf.Clamp(KMPBar.size, 0.01f, 1);
        //
        KRageBar.fillAmount = PlayerStats.instance.K_curRage / PlayerStats.instance.K_Rage;
        KRageBar.fillAmount = Mathf.Clamp(KRageBar.fillAmount, 0.01f, 1);
        //////////////////////////////////////////////////////////
        ShealthBar.size = PlayerStats.instance.S_curHP / PlayerStats.instance.S_HP;
        ShealthBar.size = Mathf.Clamp(ShealthBar.size, 0.01f, 1);
        //
        SMPBar.size = PlayerStats.instance.S_curMP / PlayerStats.instance.S_MP;
        SMPBar.size = Mathf.Clamp(SMPBar.size, 0.01f, 1);
        //
        SRageBar.fillAmount = PlayerStats.instance.S_curRage / PlayerStats.instance.S_Rage;
        SRageBar.fillAmount = Mathf.Clamp(SRageBar.fillAmount, 0.01f, 1);
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
        if(PlayerStats.instance.K_curRage >= PlayerStats.instance.K_Rage)
        {MaxRageK.SetActive(true);} 
        else if(PlayerStats.instance.K_curRage < PlayerStats.instance.K_Rage)
        {MaxRageK.SetActive(false);}
        if(PlayerStats.instance.S_curRage >= PlayerStats.instance.S_Rage)
        {MaxRageS.SetActive(true);} 
        else if(PlayerStats.instance.S_curRage < PlayerStats.instance.S_Rage)
        {MaxRageS.SetActive(false);}
        if(PlayerStats.instance.F_curRage >= PlayerStats.instance.F_Rage)
        {MaxRageF.SetActive(true);} 
        else if(PlayerStats.instance.F_curRage < PlayerStats.instance.F_Rage)
        {MaxRageF.SetActive(false);}
        //
        if(PlayerStats.instance.S_curHP <= 0)
        {GameManager.instance.PoseDeathS();}
        if(PlayerStats.instance.K_curHP <= 0)
        {GameManager.instance.PoseDeathK();}
        if(PlayerStats.instance.F_curHP <= 0)
        {GameManager.instance.PoseDeathF();}
        //
        if(PlayerStats.instance.F_paralysisResistance <= 0)
        {GameManager.instance.StunF();}
        if(PlayerStats.instance.K_paralysisResistance <= 0)
        {GameManager.instance.StunK();}
        if(PlayerStats.instance.S_paralysisResistance <= 0)
        {GameManager.instance.StunS();}
        //
        if(PlayerStats.instance.F_poisonResistance <= 0)
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
        if(PlayerStats.instance.S_poisonResistance <= 0)
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
        if(PlayerStats.instance.K_poisonResistance <= 0)
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
        if(EnemyinArena <= 0)
        {StartCoroutine(EndBattle());}
        if(WinEnd){if (Input.GetMouseButtonDown(0)){L_C.Escape();}}
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
        LVCH.sceneName = GameManager.instance.sceneName;
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