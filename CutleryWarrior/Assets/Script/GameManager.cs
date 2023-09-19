using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;
using UnityEngine.AI;
public class GameManager : MonoBehaviour
{
    #region Header  
    public bool StartGame = false;    
    public GameObject player;
    public GameObject Fork;
    public  bool F_Unlock = true; 
    public GameObject Spoon;
    public  bool S_Unlock = false; 
    public GameObject Knife;
    public  bool K_Unlock = false;
    public GameObject Minimap;
    public static bool GameManagerExist; 
    public Vector3 savedPosition;
    public string sceneName;
    public bool notChange = false;
    [Header("Pause")]
    public bool stopInput = false;
    public bool battle = false;
    public bool Day = true;
    public bool isRun = false;
    public bool Interact = false; 
    [SerializeField]  GameObject Pause;
    [SerializeField]  GameObject LittleM;
    [SerializeField]  GameObject TimerM;
    [SerializeField]  GameObject Ord;
    [SerializeField]  GameObject Itm;
    [SerializeField]  GameObject Esc;
    [Header("Fade")]
    [SerializeField] GameObject callFadeIn;
    [SerializeField] GameObject callFadeOut;
    [Header("Money")]
    [SerializeField] public int money = 0;
    [SerializeField] public TextMeshProUGUI moneyTextM;
    //[SerializeField] GameObject moneyObjectM;
    public int IDPorta;
    public int IdAreaAtt;
    public int IDCharacter;
    [Header("Stats")]
    public PlayerStats PStats;
    [SerializeField] public GameObject F_Hero;
    [SerializeField] public GameObject K_Hero;
    [SerializeField] public GameObject S_Hero;
    [SerializeField] public GameObject MP_F;
    [SerializeField] public GameObject MP_S;
    [SerializeField] public GameObject MP_K;
    [Header("Fork")]
    private  int F_LV;
    private float F_HP;
    private float F_MP;
    private float F_Exp;
    private float F_curExp;
    private int F_attack;
    private int F_defense;
    private int F_poisonResistance;
    private int F_paralysisResistance;
    private int F_sleepResistance;
    private int F_rustResistance;
    [Header("Fork")]
    [SerializeField] public TextMeshProUGUI F_ExpTextM;
    [SerializeField] public TextMeshProUGUI F_ExpText;
    [SerializeField] public TextMeshProUGUI F_LVTextM;
    [SerializeField] public TextMeshProUGUI F_hpTextM;
    [SerializeField] public TextMeshProUGUI F_mpTextM;
    [SerializeField] public TextMeshProUGUI F_Def;
    [SerializeField] public TextMeshProUGUI F_Atk;
    [SerializeField] public TextMeshProUGUI F_Pois;
    [SerializeField] public TextMeshProUGUI F_Rust;
    [SerializeField] public TextMeshProUGUI F_Sleep;
    [SerializeField] public TextMeshProUGUI F_Stun;
    [SerializeField] public Scrollbar F_Hp;
    [SerializeField] public Scrollbar F_Mp;
    [SerializeField] public Scrollbar F_ExpScrol;
    [SerializeField] CharacterMove ch_F;
    [SerializeField] CharacterFollow ch_FAc;
    [SerializeField] ManagerCharacter Manager_F;
    [Header("Spoon")]
    private  int S_LV;
    private float S_HP;
    private float S_MP;
    private float S_Exp;
    private float S_curExp;
    private int S_attack;
    private int S_defense;
    private int S_poisonResistance;
    private int S_paralysisResistance;
    private int S_sleepResistance;
    private int S_rustResistance;
    [Header("Spoon")]
    [SerializeField] public TextMeshProUGUI S_ExpTextM;
    [SerializeField] public TextMeshProUGUI S_ExpText;
    [SerializeField] public TextMeshProUGUI S_LVTextM;
    [SerializeField] public TextMeshProUGUI S_hpTextM;
    [SerializeField] public TextMeshProUGUI S_mpTextM;
    [SerializeField] public TextMeshProUGUI S_Def;
    [SerializeField] public TextMeshProUGUI S_Atk;
    [SerializeField] public TextMeshProUGUI S_Pois;
    [SerializeField] public TextMeshProUGUI S_Rust;
    [SerializeField] public TextMeshProUGUI S_Sleep;
    [SerializeField] public TextMeshProUGUI S_Stun;
    [SerializeField] public Scrollbar S_Hp;
    [SerializeField] public Scrollbar S_Mp;
    [SerializeField] public Scrollbar S_ExpScrol;
    [SerializeField] CharacterMove ch_S;
    [SerializeField] CharacterFollow ch_SAc;
    [SerializeField] ManagerCharacter Manager_S;
    [Header("Knife")]
    private  int K_LV;
    private float K_HP;
    private float K_MP;
    private float K_Exp;
    private float K_curExp;
    private int K_attack;
    private int K_defense;
    private int K_poisonResistance;
    private int K_paralysisResistance;
    private int K_sleepResistance;
    private int K_rustResistance;
    [Header("Knife")]
    [SerializeField] public TextMeshProUGUI K_ExpTextM;
    [SerializeField] public TextMeshProUGUI K_ExpText;
    [SerializeField] public TextMeshProUGUI K_LVTextM;
    [SerializeField] public TextMeshProUGUI K_hpTextM;
    [SerializeField] public TextMeshProUGUI K_mpTextM;
    [SerializeField] public TextMeshProUGUI K_Def;
    [SerializeField] public TextMeshProUGUI K_Atk;
    [SerializeField] public TextMeshProUGUI K_Pois;
    [SerializeField] public TextMeshProUGUI K_Rust;
    [SerializeField] public TextMeshProUGUI K_Sleep;
    [SerializeField] public TextMeshProUGUI K_Stun;
    [SerializeField] public Scrollbar K_Hp;
    [SerializeField] public Scrollbar K_Mp;
    [SerializeField] public Scrollbar K_ExpScrol;
    [SerializeField] CharacterMove ch_K;
    [SerializeField] CharacterFollow ch_KAc;
    [SerializeField] ManagerCharacter Manager_K;
    //[SerializeField] GameObject ExpObjectM;
    public UIRotationSwitcher rotationSwitcher;
    public SwitchCharacter SwitcherUI;
    public int IdENM;
    public bool NotTouchOption = false;
    public static GameManager instance;
    #endregion
    public void Awake()
    {
        if (instance == null){instance = this;}
        if (GameManagerExist){Destroy(gameObject);}
        else {GameManagerExist = true; DontDestroyOnLoad(gameObject);}
        TakeCharacter();
        /*if(StartGame)
        {AudioManager.instance.PlayMFX(0);}*/
        if(F_Unlock){
        PStats.F_curHP = PStats.F_HP;
        PStats.F_curMP = PStats.F_MP;}
        //
        if(K_Unlock){
        PStats.K_curHP = PStats.K_HP;
        PStats.K_curMP = PStats.K_MP;}
        //
        if(S_Unlock){
        PStats.S_curHP = PStats.S_HP;
        PStats.S_curMP = PStats.S_MP;}
    }
    public void TakeCharacter()
    {
        switch(rotationSwitcher.CharacterID)
        {
            case 1:
            player = GameObject.FindGameObjectWithTag("F_Player");
            break;
            case 2:
            player = GameObject.FindGameObjectWithTag("K_Player");
            break;
            case 3:
            player = GameObject.FindGameObjectWithTag("S_Player");
            break;
        }}
    public void Start(){Application.targetFrameRate = 60; Day = true;}
    public void Update()
    {
        IDCharacter = rotationSwitcher.CharacterID;
        StatPlayer();
        BarStat();
        TakeCharacter();
        moneyTextM.text = money.ToString(); 
        if(!NotTouchOption){
    if(!battle){
        Minimap.SetActive(true);
       if (Input.GetButtonDown("Pause") && !stopInput)
        {
            ChStop();
            switch (rotationSwitcher.CharacterID)
    {
    case 1:
    if(!notChange){
        if(F_Unlock){
        ch_F.Stop();
        ch_F.Idle();
        stopInput = true;
        ch_F.inputCTR = true;}
        Pause.gameObject.SetActive(true);}
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);     
    break;
    case 2:
    if(!notChange){
        if(K_Unlock){
        ch_K.Stop();
        ch_K.Idle();
        stopInput = true;
        ch_K.inputCTR = true;}
        Pause.gameObject.SetActive(true);}
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);  
    break;
    case 3:
        if(!notChange){
        if(S_Unlock){    
        ch_S.Stop();
        ch_S.Idle();
        stopInput = true;
        ch_S.inputCTR = true;}
        Pause.gameObject.SetActive(true);}
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);   
    break;
    }             
        }
        else if(Input.GetButtonDown("Pause") && stopInput)
        {
            ChCanM();
            stopInput = false;
            Pause.gameObject.SetActive(false);
            CharacterMove.instance.inputCTR = false;
            switch (rotationSwitcher.CharacterID)
            {
            case 1:
            if(F_Unlock){ch_F.inputCTR = false;}    
            break;
            case 2:
            if(K_Unlock){ch_K.inputCTR = false;}    
            break;
            case 3:
            if(S_Unlock){ch_S.inputCTR = false;}    
            break;
            }  
            CameraZoom.instance.ZoomOut();
            AudioManager.instance.PlayUFX(1);
        } 
    }
    else if(battle){
        Minimap.SetActive(false);
       if (Input.GetButtonDown("Pause") && !stopInput)
        {
            ChStop();
            Posebattle();
            notChange = true;
            DuelManager.instance.inputCTR = true;
            switch (rotationSwitcher.CharacterID)
        {
    case 1:
        if(F_Unlock){ch_F.Stop();
        stopInput = true;
        ch_F.inputCTR = true;}
        LittleM.gameObject.SetActive(true);
        LittleM.transform.position = MP_F.transform.position;
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);     
    break;
    case 2:
        if(K_Unlock){
        ch_K.Stop();
        stopInput = true;
        ch_K.inputCTR = true;}
        LittleM.gameObject.SetActive(true);
        LittleM.transform.position = MP_K.transform.position;
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);  
    break;
    case 3:
        if(S_Unlock){
        ch_S.Stop();
        stopInput = true;
        ch_S.inputCTR = true;}
        LittleM.gameObject.SetActive(true);
        LittleM.transform.position = MP_S.transform.position;
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);   
    break;
    }          
        }
        else if(Input.GetButtonDown("Pause") && stopInput)
        {
            ChCanM();
            notChange = false;
            stopInput = false;
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            CharacterMove.instance.inputCTR = false;
            switch (rotationSwitcher.CharacterID)
            {
            case 1:
                ch_F.inputCTR = false;    
            break;
            case 2:
                ch_K.inputCTR = false; 
            break;
            case 3:
                ch_S.inputCTR = false; 
            break;
            }  
            CameraZoom.instance.ZoomOut();
            DuelManager.instance.inputCTR = false;
            AudioManager.instance.PlayUFX(1);
        } 
    }}
    }
    public void CloseLittleM()
    {
            ChCanM();
            stopInput = false;
            notChange = false;
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            CharacterMove.instance.inputCTR = false;
            switch (rotationSwitcher.CharacterID)
            {
            case 1:
            if(F_Unlock){ch_F.inputCTR = false;}
            break;
            case 2:
            if(K_Unlock){ch_K.inputCTR = false;}
            break;
            case 3:
            if(S_Unlock){ch_S.inputCTR = false;}
            break;
            }  
            CameraZoom.instance.ZoomOut();
            DuelManager.instance.inputCTR = false;
            AudioManager.instance.PlayUFX(1);
    }

    public void CloseLittleMStop()
    {
            ChCanM();
            stopInput = false;
            notChange = false;
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            switch (rotationSwitcher.CharacterID)
            {
            case 1:
            if(F_Unlock){ch_F.inputCTR = false;}
            break;
            case 2:
            if(K_Unlock){ch_K.inputCTR = false;}
            break;
            case 3:
            if(S_Unlock){ch_S.inputCTR = false;}
            break;
            }  
    }
    public void StopBattle()
    {ChStop(); notChange = true; DuelManager.instance.inputCTR = true;}

     public void ResumeBattle()
    {ChCanM(); notChange = false; DuelManager.instance.inputCTR = false;}
     
        public void TimerMenu()
    {
            ChCanM();
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
           
            switch (rotationSwitcher.CharacterID)
            {
        case 1:
            TimerM.gameObject.SetActive(true);
            TimerM.transform.position = MP_F.transform.position;
            AudioManager.instance.PlayUFX(1);     
        break;
        case 2:
            TimerM.gameObject.SetActive(true);
            TimerM.transform.position = MP_K.transform.position;
            AudioManager.instance.PlayUFX(1);  
        break;
        case 3:
            TimerM.gameObject.SetActive(true);
            TimerM.transform.position = MP_S.transform.position;
            AudioManager.instance.PlayUFX(1);   
        break;
        }}

        public void CloseTimerMenu()
        {
            ChCanM();
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            TimerM.gameObject.SetActive(false);
            AudioManager.instance.PlayUFX(1);   
        }
    public void StatPlayer()
    {
    //Fork
    if(F_Unlock){
    F_LV = PStats.F_LV;
    F_HP = PStats.F_HP;
    F_MP = PStats.F_MP;
    F_Exp = PStats.F_Exp;
    F_curExp = PStats.F_curExp;
    F_attack = PStats.F_attack;
    F_defense = PStats.F_defense;
    F_poisonResistance = PStats.F_poisonResistance;
    F_paralysisResistance = PStats.F_paralysisResistance;
    F_sleepResistance = PStats.F_sleepResistance;
    F_rustResistance  = PStats.F_rustResistance;
    F_LVTextM.text = F_LV.ToString();
    F_ExpTextM.text = F_Exp.ToString();
    F_ExpText.text = F_curExp.ToString();
    F_Def.text = F_defense.ToString();
    F_Def.text = F_defense.ToString();
    F_Atk.text = F_attack.ToString();
    F_Pois.text = F_poisonResistance.ToString();
    F_Rust.text = F_rustResistance.ToString();
    F_Stun.text = F_paralysisResistance.ToString();
    F_Sleep.text = F_sleepResistance.ToString();
    F_mpTextM.text = F_MP.ToString();
    F_hpTextM.text = F_HP.ToString();
    
        F_Hp.size = PlayerStats.instance.F_curHP / PlayerStats.instance.F_HP;
        F_Hp.size = Mathf.Clamp(F_Hp.size, 1f, 1);
        //
        F_Mp.size = PlayerStats.instance.F_curMP / PlayerStats.instance.F_MP;
        F_Mp.size = Mathf.Clamp(F_Mp.size, 1f, 1);
        //
        //FRageBar.fillAmount = PlayerStats.instance.F_curRage / PlayerStats.instance.F_Rage;
        //FRageBar.fillAmount = Mathf.Clamp(FRageBar.fillAmount, 0.01f, 1);}
        
    }


    //Knife
    if(K_Unlock){
    K_LV = PStats.K_LV;
    K_HP = PStats.K_HP;
    K_MP = PStats.K_MP;
    K_Exp = PStats.K_Exp;
    K_curExp = PStats.K_curExp;
    K_attack = PStats.K_attack;
    K_defense = PStats.K_defense;
    K_poisonResistance = PStats.K_poisonResistance;
    K_paralysisResistance = PStats.K_paralysisResistance;
    K_sleepResistance = PStats.K_sleepResistance;
    K_rustResistance  = PStats.K_rustResistance;
    K_LVTextM.text = K_LV.ToString();
    K_ExpTextM.text = K_Exp.ToString();
    K_ExpText.text = K_curExp.ToString(); 
    K_Def.text = K_defense.ToString();
    K_Def.text = K_defense.ToString();
    K_Atk.text = K_attack.ToString();
    K_Pois.text = K_poisonResistance.ToString();
    K_Rust.text = K_rustResistance.ToString();
    K_Stun.text = K_paralysisResistance.ToString();
    K_Sleep.text = K_sleepResistance.ToString();
    K_mpTextM.text = K_MP.ToString();
    K_hpTextM.text = K_HP.ToString();
    
        K_Hp.size = PlayerStats.instance.K_curHP / PlayerStats.instance.K_HP;
        K_Hp.size = Mathf.Clamp(K_Hp.size, 1f, 1);
        //
        K_Mp.size = PlayerStats.instance.K_curMP / PlayerStats.instance.K_MP;
        K_Mp.size = Mathf.Clamp(K_Mp.size, 1f, 1);
        //
        //FRageBar.fillAmount = PlayerStats.instance.F_curRage / PlayerStats.instance.F_Rage;
        //FRageBar.fillAmount = Mathf.Clamp(FRageBar.fillAmount, 0.01f, 1);}
        
    }


    //Spoon
    if(S_Unlock){
    S_LV = PStats.S_LV;
    S_HP = PStats.S_HP;
    S_MP = PStats.S_MP;
    S_Exp = PStats.S_Exp;
    S_curExp = PStats.S_curExp;
    S_attack = PStats.S_attack;
    S_defense = PStats.S_defense;
    S_poisonResistance = PStats.S_poisonResistance;
    S_paralysisResistance = PStats.S_paralysisResistance;
    S_sleepResistance = PStats.S_sleepResistance;
    S_rustResistance  = PStats.S_rustResistance;
    S_LVTextM.text = S_LV.ToString();
    S_ExpTextM.text = S_Exp.ToString(); 
    S_ExpText.text = S_curExp.ToString(); 
    S_Def.text = S_defense.ToString();
    S_Def.text = S_defense.ToString();
    S_Atk.text = S_attack.ToString();
    S_Pois.text = S_poisonResistance.ToString();
    S_Rust.text = S_rustResistance.ToString();
    S_Stun.text = S_paralysisResistance.ToString();
    S_Sleep.text = S_sleepResistance.ToString();
    S_mpTextM.text = S_MP.ToString();
    S_hpTextM.text = S_HP.ToString();
    
        S_Hp.size = PlayerStats.instance.S_curHP / PlayerStats.instance.S_HP;
        S_Hp.size = Mathf.Clamp(S_Hp.size, 1f, 1);
        //
        S_Mp.size = PlayerStats.instance.K_curMP / PlayerStats.instance.S_MP;
        S_Mp.size = Mathf.Clamp(S_Mp.size, 1f, 1);
        //
        //FRageBar.fillAmount = PlayerStats.instance.F_curRage / PlayerStats.instance.F_Rage;
        //FRageBar.fillAmount = Mathf.Clamp(FRageBar.fillAmount, 0.01f, 1);}
        
    }
    }   
    public void BarStat()
    {   
        if(F_Unlock){
        F_Hp.size = PStats.F_curHP / PStats.F_HP;
        F_Hp.size = Mathf.Clamp(F_Hp.size, 0.01f, 1);
        F_ExpScrol.size = PStats.F_curExp / PStats.F_Exp;
        F_ExpScrol.size = Mathf.Clamp(F_ExpScrol.size, 0.01f, 1);
        F_Hp.size = PStats.F_curMP / PStats.F_MP;
        F_Hp.size = Mathf.Clamp(F_Hp.size, 0.01f, 1);}
        //
        if(K_Unlock){
        K_Hp.size = PStats.K_curHP / PStats.K_HP;
        K_Hp.size = Mathf.Clamp(K_Hp.size, 0.01f, 1);
        K_ExpScrol.size = PStats.K_curExp / PStats.K_Exp;
        K_ExpScrol.size = Mathf.Clamp(K_ExpScrol.size, 0.01f, 1);
        K_Mp.size = PStats.K_curMP / PStats.K_MP;
        K_Mp.size = Mathf.Clamp(K_Mp.size, 0.01f, 1);}
        //
        if(S_Unlock){
        S_Hp.size = PStats.S_curHP / PStats.S_MP;
        S_Hp.size = Mathf.Clamp(S_Hp.size, 0.01f, 1);
        S_ExpScrol.size = PStats.S_curExp / PStats.S_Exp;
        S_ExpScrol.size = Mathf.Clamp(S_ExpScrol.size, 0.01f, 1);
        S_Mp.size = PStats.S_curMP / PStats.S_MP;
        S_Mp.size = Mathf.Clamp(S_Mp.size, 0.01f, 1);}
    }
    public void Change(){notChange = false;} 
    public void NotChange(){notChange = true;} 
    public void TakeCamera()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_F.TakeCamera();}
        if(S_Unlock){ch_S.TakeCamera();}
        if(K_Unlock){ch_K.TakeCamera();}
    }   
    public void ChMov()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_F.Idle();}
        if(S_Unlock){ch_S.Idle();}
        if(K_Unlock){ch_K.Idle();}
    }
    public void ChStop()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_F.Idle();ch_F.Stop(); ch_F.inputCTR = true; ch_FAc.inputCTR = true; ch_F.isRun = false;}
        if(K_Unlock){ch_K.Idle();ch_K.Stop(); ch_K.inputCTR = true; ch_KAc.inputCTR = true; ch_K.isRun = false;}
        if(S_Unlock){ch_S.Idle();ch_S.Stop(); ch_S.inputCTR = true; ch_SAc.inputCTR = true; ch_S.isRun = false;}
    } 
    public void ChStopB()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_F.inputCTR = true; ch_FAc.inputCTR = true;}
        if(K_Unlock){ch_K.inputCTR = true; ch_KAc.inputCTR = true;}
        if(S_Unlock){ch_S.inputCTR = true; ch_SAc.inputCTR = true;} 
    }  
    public void ChInteract()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_F.Interact = true;} 
        if(K_Unlock){ch_K.Interact = true;} 
        if(S_Unlock){ch_S.Interact = true;}
        Interact = true;
    }  
    public void ChInteractStop()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_F.Interact = false;} 
        if(K_Unlock){ch_K.Interact = false;}
        if(S_Unlock){ch_S.Interact = false;}
        Interact = false;
    }  
    public void ChCanM()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_F.inputCTR = false; ch_FAc.inputCTR = false;}
        if(K_Unlock){ch_K.inputCTR = false; ch_KAc.inputCTR = false;}
        if(S_Unlock){ch_S.inputCTR = false; ch_SAc.inputCTR = false;}
    }
    public void Posebattle()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_F.Posebattle();ch_FAc.Posebattle();}
        if(instance.K_Unlock){ch_K.Posebattle();ch_KAc.Posebattle();}
        if(instance.S_Unlock){ch_S.Posebattle();ch_SAc.Posebattle();}
    }
    public void Charge()
    {
        if(F_Unlock){Manager_F = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();}
        if(S_Unlock){Manager_S = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();}
        if(K_Unlock){Manager_K = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();}
        if(F_Unlock){Manager_F.SwitchScriptsCharge();}
        if(S_Unlock){Manager_S.SwitchScriptsCharge();}
        if(K_Unlock){Manager_K.SwitchScriptsCharge();}
    }
    public void Die()
    {
        if(F_Unlock){Manager_F = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();}
        if(S_Unlock){Manager_S = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();}
        if(K_Unlock){Manager_K = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();}
        if(F_Unlock){Manager_F.SwitchScriptsDeath();}
        if(S_Unlock){Manager_S.SwitchScriptsDeath();}
        if(K_Unlock){Manager_K.SwitchScriptsDeath();}
    }
    public void Stun()
    {
        if(F_Unlock){Manager_F = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();}
        if(S_Unlock){Manager_S = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();}
        if(K_Unlock){Manager_K = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();}
        if(F_Unlock){Manager_F.SwitchScriptsStun();}
        if(S_Unlock){Manager_S.SwitchScriptsStun();}
        if(K_Unlock){Manager_K.SwitchScriptsStun();}
    }
    public void Poison()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_F.Poison();ch_FAc.Poison();}
        if(K_Unlock){ch_K.Poison();ch_KAc.Poison();}
        if(S_Unlock){ch_S.Poison();ch_SAc.Poison();}
    }
    public void PoseWin()
    {
       
        if(F_Unlock){Manager_F.SwitchScriptsWin();}
        if(S_Unlock){Manager_S.SwitchScriptsWin();}
        if(K_Unlock){Manager_K.SwitchScriptsWin();}
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Death
    public void PoseDeathF()
    {
        if(F_Unlock)
        {Manager_F = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();
        Manager_F.SwitchScriptsDeath();}
    }
    public void PoseDeathK()
    {
        if(K_Unlock){Manager_K = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();
        Manager_K.SwitchScriptsDeath();}
    }
    public void PoseDeathS()
    {
        if(S_Unlock){Manager_S = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();
        Manager_S.SwitchScriptsDeath();}
    }
    #endregion
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Stun
    public void StunF()
    {if(F_Unlock){Manager_F = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();Manager_F.SwitchScriptsStun();}}
    public void StunK()
    {if(K_Unlock){Manager_K = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();Manager_K.SwitchScriptsStun();}}
    public void StunS()
    {if(S_Unlock){Manager_S = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();Manager_S.SwitchScriptsStun();}}
    #endregion
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region PoisonState
    public void PoisonF()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){
        ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();
        ch_FAc.Poison();
        ch_F.Poison();}   
    }
    public void PoisonK()
    { 
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){
        ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();    
        ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();
        ch_KAc.Poison();
        ch_K.Poison();}  
    }
    public void PoisonS()
    {
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock)
        {ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();
        ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();
        ch_SAc.Poison();
        ch_S.Poison();} 
    }
    #endregion
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Restore
    public void RestoreF()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock)
        {PStats.F_paralysisResistance = PStats.F_paralysisResistanceCont;
        PStats.F_poisonResistance = PStats.F_poisonResistanceCont;
        ch_F.Idle();ch_F.ReCol();ch_FAc.Idle();ch_FAc.ReCol();}
    }
    public void RestoreK()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock)
        {PStats.K_paralysisResistance = PStats.K_paralysisResistanceCont;
        PStats.K_poisonResistance = PStats.K_poisonResistanceCont;   
        ch_K.Idle();ch_K.ReCol();ch_KAc.Idle();ch_KAc.ReCol();}
    }
    public void RestoreS()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock)
        {PStats.S_paralysisResistance = PStats.S_paralysisResistanceCont;
        PStats.S_poisonResistance = PStats.S_poisonResistanceCont;   
        ch_S.Idle();ch_S.ReCol();ch_SAc.Idle();ch_SAc.ReCol();}
    }
    #endregion   
////////////////////////////////////////////////////////////////////////////////////////////////////////

    
    public void StopWin()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){Manager_F = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();}
        if(S_Unlock){Manager_S = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();}
        if(K_Unlock){Manager_K = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();}
        switch(rotationSwitcher.CharacterID)
        {
            case 1:
            if(F_Unlock){Manager_F.SwitchScriptsPlayer();}
            if(K_Unlock){Manager_K.SwitchScriptsActor();}
            if(S_Unlock){Manager_S.SwitchScriptsActor();}
            break;
            case 2:
            if(F_Unlock){Manager_F.SwitchScriptsActor();}
            if(K_Unlock){Manager_K.SwitchScriptsPlayer();}
            if(S_Unlock){Manager_S.SwitchScriptsActor();}
            break;
            case 3:
            if(F_Unlock){Manager_F.SwitchScriptsActor();}
            if(K_Unlock){Manager_K.SwitchScriptsActor();}
            if(S_Unlock){Manager_S.SwitchScriptsPlayer();} 
            break;
        }
       if(F_Unlock){ch_F.Idle();ch_F.Stop();ch_F.ReCol();ch_FAc.ReCol();ch_FAc.Idle();}
       if(S_Unlock){ch_S.Idle();ch_S.Stop();ch_S.ReCol();ch_SAc.ReCol();ch_SAc.Idle();}
       if(K_Unlock){ch_K.Idle();ch_K.Stop();ch_K.ReCol();ch_KAc.ReCol();ch_KAc.Idle();}

    }
    public void Allarm()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_F.Allarm();ch_F.Attention = true;ch_FAc.Allarm();ch_FAc.Attention = true;}
        if(K_Unlock){ch_K.Allarm();ch_K.warning = false;ch_K.Attention = true;ch_KAc.Allarm();ch_KAc.Attention = true;}
        if(S_Unlock){ch_S.Allarm();ch_S.warning = false;ch_S.Attention = true;ch_SAc.Allarm();ch_SAc.Attention = true;}
    }
    public void StopAllarm()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_FAc.StopAllarm();ch_F.StopAllarm();ch_F.Attention = false;ch_FAc.Attention = false;}
        if(K_Unlock){ch_KAc.StopAllarm();ch_K.StopAllarm();ch_K.Attention = false;ch_KAc.Attention = false;}
        if(S_Unlock){ch_SAc.StopAllarm();ch_S.StopAllarm();ch_S.Attention = false;ch_SAc.Attention = false;}
    }
    public void Esclamation()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}    
        if(F_Unlock){ch_F.Attention = true;} 
        if(S_Unlock){ch_S.Attention = true;} 
        if(K_Unlock){ch_K.Attention = true;} 
    }
    public void EsclamationStop()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_F.Attention = false;}         
        if(K_Unlock){ch_K.Attention = false;} 
        if(S_Unlock){ch_S.Attention = false;}
    }
    public void Exploration()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_F.IDAction = 0;ch_FAc.IDAction = 0;}
        if(S_Unlock){ch_S.IDAction = 0;ch_SAc.IDAction = 0;}
        if(K_Unlock){ch_K.IDAction = 0;ch_KAc.IDAction = 0;}
    }
    public void Battle()
    {
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(F_Unlock){ch_F.IDAction = 1;ch_FAc.IDAction = 1;}
        if(S_Unlock){ch_S.IDAction = 1;ch_SAc.IDAction = 1;}
        if(K_Unlock){ch_K.IDAction = 1;ch_KAc.IDAction = 1;}
    }
    public void TakeData()
    {   
        if(F_Unlock){Manager_F = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();}
        if(S_Unlock){Manager_S = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();}
        if(K_Unlock){Manager_K = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();}
        //
        if(F_Unlock){ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        //
        if(F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
    }
    public void AddTomoney(int pointsToAdd){money += pointsToAdd; moneyTextM.text = money.ToString();}
    public void ForkUnlock(){Fork.SetActive(true); F_Unlock = true; Manager_F.SwitchScriptsActor();}   
    public void SpoonUnlock(){Spoon.SetActive(true); S_Unlock = true; Manager_S.SwitchScriptsActor();}   
    public void KnifeUnlock(){Knife.SetActive(true); K_Unlock = true; Manager_K.SwitchScriptsActor();}   
    public void K_PlayerReachedLevelUp(){PStats.K_LevelUp();}
    public void S_PlayerReachedLevelUp(){PStats.S_LevelUp();}
    public void F_PlayerReachedLevelUp(){PStats.F_LevelUp();}
    public void AddToExp(int pointsToAdd)
    {
        F_Exp += pointsToAdd;
        S_Exp += pointsToAdd;
        K_Exp += pointsToAdd;
        F_ExpTextM.text = F_Exp.ToString(); 
        S_ExpTextM.text = S_Exp.ToString();    
        K_ExpTextM.text = K_Exp.ToString();    
    }
    
    #region Fade
    public void FadeIn(){StartCoroutine(StartFadeIn());}
    public void FadeOut(){StartCoroutine(StartFadeOut());}
    IEnumerator StartFadeIn()
    {
        callFadeOut.gameObject.SetActive(false);
        callFadeIn.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
    }
    IEnumerator StartFadeOut()
    {        
        callFadeIn.gameObject.SetActive(false);
        callFadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        callFadeOut.gameObject.SetActive(false);
    }
#endregion
}