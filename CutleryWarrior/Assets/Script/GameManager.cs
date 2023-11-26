using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    #region Header  
    public GameObject GM;
    public GameObject MouseCursorIcon;
    public bool StartGame = false;    
    public GameObject player;
    public GameObject Minimap;
    public static bool GameManagerExist; 
    public Inventory Inv;
    public Inventory QuM;
    public EquipM_F M_F;
    public EquipM_K M_K;
    public EquipM_S M_S;
    public int N_Target = 0;
    public Vector3 savedPosition;
    public Transform savedPositionEscape;
    public string sceneName;
    public bool notChange = false;
    [Range (1,3)]
    public int CharacterID;
    /// ////////////////////////////////////////////////////////
    [Header("Fork")]
    [SerializeField] public GameObject F_Hero;
    [SerializeField] public CharacterMove F_HeroP;
    [SerializeField] public CharacterFollow F_HeroAI;
    [SerializeField] public GameObject MP_F;
    [SerializeField] public GameObject Rust_F;
    public GameObject Fork;
    public GameObject F_SkillW;
    public GameObject[] OrderFork;
    public bool F_Unlock = true; 
    private  int F_LV;
    private float F_HP;
    private float F_MP;
    private float F_Exp;
    private float F_curExp;
    private float F_attack;
    private float F_defense;
    private float F_poisonResistance;
    private float F_paralysisResistance;
    private float F_sleepResistance;
    private float F_rustResistance;
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
    /// ////////////////////////////
    [Header("Spoon")]
    [SerializeField] public GameObject S_Hero;
    [SerializeField] public CharacterMove S_HeroP;
    [SerializeField] public CharacterFollow S_HeroAI;
    [SerializeField] public GameObject MP_S;
    [SerializeField] public GameObject Rust_S;
    public GameObject Spoon;
    public GameObject S_SkillW;
    public GameObject[] OrderSpoon;
    public  bool S_Unlock = false; 
    private  int S_LV;
    private float S_HP;
    private float S_MP;
    private float S_Exp;
    private float S_curExp;
    private float S_attack;
    private float S_defense;
    private float S_poisonResistance;
    private float S_paralysisResistance;
    private float S_sleepResistance;
    private float S_rustResistance;
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
    [SerializeField] public GameObject K_Hero;
    [SerializeField] public CharacterMove K_HeroP;
    [SerializeField] public CharacterFollow K_HeroAI;
    [SerializeField] public GameObject MP_K;
    [SerializeField] public GameObject Rust_K;
    public GameObject Knife;
    public GameObject K_SkillW;
    public GameObject[] OrderKnife;
    public  bool K_Unlock = false;
    private  int K_LV;
    private float K_HP;
    private float K_MP;
    private float K_Exp;
    private float K_curExp;
    private float K_attack;
    private float K_defense;
    private float K_poisonResistance;
    private float K_paralysisResistance;
    private float K_sleepResistance;
    private float K_rustResistance;
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
    /// ///////////////////////////////////////////////////
    public UIRotationSwitcher rotationSwitcher;
    public SwitchCharacter SwitcherUI;
    public GameObject[] Skill_FI;
    public GameObject[] Skill_FIB;
    public GameObject[] Skill_KI;
    public GameObject[] Skill_KIB;
    public GameObject[] Skill_SI;
    public GameObject[] Skill_SIB;
    public int IdENM;
    [Header("Pause")]
    public bool stopInput = false;
    public bool battle = false;
    public bool Day = true;
    public bool isRun = false;
    public bool Interact = false; 
    public bool NotParty = true; 
    public bool F_Die, K_Die, S_Die = false;
    public bool NotTouchOption = false;
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
    public int IDPorta;   
    public float Cooldown = 1.2f; // Tempo di cooldown tra le combo in second
    public CinemachineVirtualCamera vcam; // La telecamera virtuale Cinemachine
    public static GameManager instance;
    #endregion
    public void Awake()
    {
        if (instance == null){instance = this;}
        if (GameManagerExist){Destroy(gameObject);}
        else {GameManagerExist = true; DontDestroyOnLoad(gameObject);}
        TakeCharacter();
        foreach (GameObject arenaObjectN in OrderFork){arenaObjectN.SetActive(false);}
        foreach (GameObject arenaObjectN in OrderKnife){arenaObjectN.SetActive(false);}
        foreach (GameObject arenaObjectN in OrderSpoon){arenaObjectN.SetActive(false);}
        if(PlayerStats.instance == null)
        {print("Sta caricando i dati");}
        StartCoroutine(StartData());
    }
    IEnumerator StartData()
    {
        yield return new WaitForSeconds(0.1f);
        if(F_Unlock){
        PlayerStats.instance.F_curHP = PlayerStats.instance.F_HP;
        PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;
        foreach (GameObject arenaObjectN in OrderFork){arenaObjectN.SetActive(true);}}
        //
        if(K_Unlock){
        PlayerStats.instance.K_curHP = PlayerStats.instance.K_HP;
        PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;
        foreach (GameObject arenaObjectN in OrderKnife){arenaObjectN.SetActive(true);}}
        //
        if(S_Unlock){
        PlayerStats.instance.S_curHP = PlayerStats.instance.S_HP;
        PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;
        foreach (GameObject arenaObjectN in OrderSpoon){arenaObjectN.SetActive(true);}}
    }
    public void TakeCharacter()
    {
        switch(CharacterID)
        {
            case 1:
            player = F_Hero;
            CharacterID = 1;
            break;
            case 2:
            player = K_Hero;
            CharacterID = 2;
            break;
            case 3:
            player = S_Hero;
            CharacterID = 3;
            break;
        }}
        public void Order()
    {
        if(F_Unlock){foreach (GameObject arenaObjectN in OrderFork){arenaObjectN.SetActive(true);}}
        //
        if(K_Unlock){foreach (GameObject arenaObjectN in OrderKnife){arenaObjectN.SetActive(true);}}
        //
        if(S_Unlock){foreach (GameObject arenaObjectN in OrderSpoon){arenaObjectN.SetActive(true);}}
    }
    public void SkillINMenu()
    {
        if(F_Unlock){F_SkillW.SetActive(true);}
        else if(!F_Unlock){F_SkillW.SetActive(false);}
        //
        if(K_Unlock){K_SkillW.SetActive(true);}
        else if(!K_Unlock){K_SkillW.SetActive(false);}
        //
        if(S_Unlock){S_SkillW.SetActive(true);}
        else if(!S_Unlock){S_SkillW.SetActive(false);}
    }
    public void Start(){Application.targetFrameRate = 60; Day = true;}
    public void Update()
    {
        CharacterID = rotationSwitcher.CharacterID;
        StatPlayer();
        BarStat();
        TakeCharacter();
        SkillINMenu();
        Order();
        moneyTextM.text = money.ToString(); 
////////////////////////////////////////////////////////////////////////////
        if(!NotTouchOption){
    if(!battle){
        //Minimap.SetActive(true);
       if (Input.GetButtonDown("Pause") && !stopInput)
        {
            ChStop();
            switch (CharacterID)
    {
    case 1:
    if(!notChange){
        if(F_Unlock){
        ch_F.Stop();
        ch_F.Idle();
        stopInput = true;
        ch_F.inputCTR = true;}
        OpenBookF();
        Invoke("OpenMenu", Cooldown);
        }
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
        OpenBookK();
        Invoke("OpenMenu", Cooldown);
        }
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
        OpenBookS();
        Invoke("OpenMenu", Cooldown);
        }
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);   
    break;
    }             
    }
    else if(Input.GetButtonDown("Pause") && stopInput)
        {
            
            switch (CharacterID)
            {
            case 1:
            if(F_Unlock){ch_F.inputCTR = false; CloseBookF();}    
            break;
            case 2:
            if(K_Unlock){ch_K.inputCTR = false; CloseBookK();}    
            break;
            case 3:
            if(S_Unlock){ch_S.inputCTR = false; CloseBookS();}    
            break;
            }  
            MouseCursorIcon.SetActive(false);
            Pause.gameObject.SetActive(false);
            switch (CharacterID)
            {
            case 1:
            if(F_Unlock){CloseBookF();}    
            break;
            case 2:
            if(K_Unlock){CloseBookK();}    
            break;
            case 3:
            if(S_Unlock){CloseBookS();}    
            break;
            }  
            Invoke("CloseMenu", Cooldown);
            CameraZoom.instance.ZoomOut();
            AudioManager.instance.PlayUFX(1);
        } 
    }
////////////////////////////////////////////////////////////////////////////
    else if(battle){
        //Minimap.SetActive(false);
       if (Input.GetButtonDown("Pause") && !stopInput)
        {
            ChStop();
            Posebattle();
            MouseCursorIcon.SetActive(true);
            notChange = true;
            DuelManager.instance.inputCTR = true;
            switch (CharacterID)
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
            MouseCursorIcon.SetActive(false);
            notChange = false;
            stopInput = false;
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            CharacterMove.instance.inputCTR = false;
            switch (CharacterID)
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
        }}}
    }

    public void OpenMenu()
    {Pause.gameObject.SetActive(true); MouseCursorIcon.SetActive(true);}
    
    public void CloseMenu()
    {
        ChCanM();
        ChMov();
        stopInput = false;
        CharacterMove.instance.inputCTR = false;
    }
    
    public void CloseLittleM()
    {
            ChCanM();
            stopInput = false;
            notChange = false;
            MouseCursorIcon.SetActive(false);
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            CharacterMove.instance.inputCTR = false;
            switch (CharacterID)
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
    public void CloseLittleMWithoutInput()
    {
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            MouseCursorIcon.SetActive(false);
            CameraZoom.instance.ZoomOut();
    }

    public void CloseLittleMStop()
    {
            ChCanM();
            stopInput = false;
            notChange = false;
            MouseCursorIcon.SetActive(false);
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            switch (CharacterID)
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
    public void StopBattle(){ChStopWithoutANM(); notChange = true; DuelManager.instance.inputCTR = true;}
    public void Escapebattle(){DuelManager.instance.Escape(); MouseCursorIcon.SetActive(false);}
    public void ResumeBattle(){ChCanM(); notChange = false; DuelManager.instance.inputCTR = false;}
     
        public void TimerMenu()
    {
            ChCanM();
            Esc.gameObject.SetActive(false);
            Ord.gameObject.SetActive(false);
            Itm.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            LittleM.gameObject.SetActive(false);
            switch (CharacterID)
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
    public void DestroyManager(){GameManagerExist = false; Destroy(GM);}
    public void StatPlayer()
    {
    //Fork
    if(F_Unlock){
    F_LV = PlayerStats.instance.F_LV;
    F_HP = PlayerStats.instance.F_HP;
    F_MP = PlayerStats.instance.F_MP;
    F_Exp = PlayerStats.instance.F_Exp;
    F_curExp = PlayerStats.instance.F_curExp;
    F_attack = PlayerStats.instance.F_attack;
    F_defense = PlayerStats.instance.F_defense;
    F_poisonResistance = PlayerStats.instance.F_poisonResistance;
    F_paralysisResistance = PlayerStats.instance.F_paralysisResistance;
    F_sleepResistance = PlayerStats.instance.F_sleepResistance;
    F_rustResistance  = PlayerStats.instance.F_rustResistance;
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
    //
        F_Hp.size = PlayerStats.instance.F_curHP / PlayerStats.instance.F_HP;
        F_Hp.size = Mathf.Clamp(F_Hp.size, 1f, 1);
        //
        F_Mp.size = PlayerStats.instance.F_curMP / PlayerStats.instance.F_MP;
        F_Mp.size = Mathf.Clamp(F_Mp.size, 1f, 1);
    }

    //Knife
    if(K_Unlock){
    K_LV = PlayerStats.instance.K_LV;
    K_HP = PlayerStats.instance.K_HP;
    K_MP = PlayerStats.instance.K_MP;
    K_Exp = PlayerStats.instance.K_Exp;
    K_curExp = PlayerStats.instance.K_curExp;
    K_attack = PlayerStats.instance.K_attack;
    K_defense = PlayerStats.instance.K_defense;
    K_poisonResistance = PlayerStats.instance.K_poisonResistance;
    K_paralysisResistance = PlayerStats.instance.K_paralysisResistance;
    K_sleepResistance = PlayerStats.instance.K_sleepResistance;
    K_rustResistance  = PlayerStats.instance.K_rustResistance;
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
        //
        K_Hp.size = PlayerStats.instance.K_curHP / PlayerStats.instance.K_HP;
        K_Hp.size = Mathf.Clamp(K_Hp.size, 1f, 1);
        //
        K_Mp.size = PlayerStats.instance.K_curMP / PlayerStats.instance.K_MP;
        K_Mp.size = Mathf.Clamp(K_Mp.size, 1f, 1);
    }
    //Spoon
    if(S_Unlock){
    S_LV = PlayerStats.instance.S_LV;
    S_HP = PlayerStats.instance.S_HP;
    S_MP = PlayerStats.instance.S_MP;
    S_Exp = PlayerStats.instance.S_Exp;
    S_curExp = PlayerStats.instance.S_curExp;
    S_attack = PlayerStats.instance.S_attack;
    S_defense = PlayerStats.instance.S_defense;
    S_poisonResistance = PlayerStats.instance.S_poisonResistance;
    S_paralysisResistance = PlayerStats.instance.S_paralysisResistance;
    S_sleepResistance = PlayerStats.instance.S_sleepResistance;
    S_rustResistance  = PlayerStats.instance.S_rustResistance;
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
    }
    }   
    public void BarStat()
    {   
        if(F_Unlock){
        F_Hp.size = PlayerStats.instance.F_curHP / PlayerStats.instance.F_HP;
        F_Hp.size = Mathf.Clamp(F_Hp.size, 0.01f, 1);
        F_ExpScrol.size = PlayerStats.instance.F_curExp / PlayerStats.instance.F_Exp;
        F_ExpScrol.size = Mathf.Clamp(F_ExpScrol.size, 0.01f, 1);
        F_Hp.size = PlayerStats.instance.F_curMP / PlayerStats.instance.F_MP;
        F_Hp.size = Mathf.Clamp(F_Hp.size, 0.01f, 1);}
        //
        if(K_Unlock){
        K_Hp.size = PlayerStats.instance.K_curHP / PlayerStats.instance.K_HP;
        K_Hp.size = Mathf.Clamp(K_Hp.size, 0.01f, 1);
        K_ExpScrol.size = PlayerStats.instance.K_curExp / PlayerStats.instance.K_Exp;
        K_ExpScrol.size = Mathf.Clamp(K_ExpScrol.size, 0.01f, 1);
        K_Mp.size = PlayerStats.instance.K_curMP / PlayerStats.instance.K_MP;
        K_Mp.size = Mathf.Clamp(K_Mp.size, 0.01f, 1);}
        //
        if(S_Unlock){
        S_Hp.size = PlayerStats.instance.S_curHP / PlayerStats.instance.S_MP;
        S_Hp.size = Mathf.Clamp(S_Hp.size, 0.01f, 1);
        S_ExpScrol.size = PlayerStats.instance.S_curExp / PlayerStats.instance.S_Exp;
        S_ExpScrol.size = Mathf.Clamp(S_ExpScrol.size, 0.01f, 1);
        S_Mp.size = PlayerStats.instance.S_curMP / PlayerStats.instance.S_MP;
        S_Mp.size = Mathf.Clamp(S_Mp.size, 0.01f, 1);}
    }
    public void Change(){notChange = false;} 
    public void NotChange(){notChange = true;} 
    public void ActiveMinimap(){Minimap.SetActive(true);battle = false;}
    public void DectiveMinimap(){Minimap.SetActive(false);battle = true;}
    public void ReturnMainMenu()
        {   
        FadeIn();
        StartGame = true;
        StartCoroutine(enoughGame());
        }
    IEnumerator enoughGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene (sceneName:"MainMenu");
        DestroyManager();
    }
    public void RecognizeCharacters()
    {
        if(F_Unlock){ch_F = F_Hero.GetComponent<CharacterMove>();}
        if(S_Unlock){ch_S = S_Hero.GetComponent<CharacterMove>();}
        if(K_Unlock){ch_K = K_Hero.GetComponent<CharacterMove>();}
        if(F_Unlock){ch_FAc = F_Hero.GetComponent<CharacterFollow>();}
        if(K_Unlock){ch_KAc = K_Hero.GetComponent<CharacterFollow>();}
        if(S_Unlock){ch_SAc = S_Hero.GetComponent<CharacterFollow>();}
        if(F_Unlock){Manager_F = F_Hero.GetComponent<ManagerCharacter>();}
        if(S_Unlock){Manager_S = S_Hero.GetComponent<ManagerCharacter>();}
        if(K_Unlock){Manager_K = K_Hero.GetComponent<ManagerCharacter>();}
    }
    public void TakeCamera()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.TakeCamera();}
        if(S_Unlock){ch_S.TakeCamera();}
        if(K_Unlock){ch_K.TakeCamera();}
    }  
    public void Right()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.RightD();}
        if(S_Unlock){ch_S.RightD();}
        if(K_Unlock){ch_K.RightD();}
    } 
    public void Left()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.LeftD();}
        if(S_Unlock){ch_S.LeftD();}
        if(K_Unlock){ch_K.LeftD();}
    } 

    public void RecalculateCharacter()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_FAc.RetakeCh();}if(S_Unlock){ch_SAc.RetakeCh();}if(K_Unlock){ch_KAc.RetakeCh();}
    }
    public void ChMov()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.Idle();}
        if(S_Unlock){ch_S.Idle();}
        if(K_Unlock){ch_K.Idle();}
    }
    public void ChStopWithoutANM()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.Stop(); ch_F.inputCTR = true; ch_FAc.inputCTR = true; ch_F.isRun = false;}
        if(K_Unlock){ch_K.Stop(); ch_K.inputCTR = true; ch_KAc.inputCTR = true; ch_K.isRun = false;}
        if(S_Unlock){ch_S.Stop(); ch_S.inputCTR = true; ch_SAc.inputCTR = true; ch_S.isRun = false;}
    } 
    public void ChStop()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.Idle();ch_F.Stop(); ch_F.inputCTR = true; ch_FAc.inputCTR = true; ch_F.isRun = false;}
        if(K_Unlock){ch_K.Idle();ch_K.Stop(); ch_K.inputCTR = true; ch_KAc.inputCTR = true; ch_K.isRun = false;}
        if(S_Unlock){ch_S.Idle();ch_S.Stop(); ch_S.inputCTR = true; ch_SAc.inputCTR = true; ch_S.isRun = false;}
    } 
    
    public void ChInteract()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.Interact = true;} 
        if(K_Unlock){ch_K.Interact = true;} 
        if(S_Unlock){ch_S.Interact = true;}
        Interact = true;
    }  
    public void ChInteractStop()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.Interact = false;} 
        if(K_Unlock){ch_K.Interact = false;}
        if(S_Unlock){ch_S.Interact = false;}
        Interact = false;
    }  
    public void ChStopB()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.inputCTR = true; ch_FAc.inputCTR = true;}
        if(K_Unlock){ch_K.inputCTR = true; ch_KAc.inputCTR = true;}
        if(S_Unlock){ch_S.inputCTR = true; ch_SAc.inputCTR = true;} 
    }  
    public void ChCanM()
    {
        
        RecognizeCharacters();
        if(F_Unlock){ch_F.inputCTR = false; ch_FAc.inputCTR = false;}
        if(K_Unlock){ch_K.inputCTR = false; ch_KAc.inputCTR = false;}
        if(S_Unlock){ch_S.inputCTR = false; ch_SAc.inputCTR = false;}
    }
    public void Posebattle()
    {
        
        RecognizeCharacters();
        if(F_Unlock){ch_F.Posebattle();ch_FAc.Posebattle();}
        if(instance.K_Unlock){ch_K.Posebattle();ch_KAc.Posebattle();}
        if(instance.S_Unlock){ch_S.Posebattle();ch_SAc.Posebattle();}
    }

    public void OpenBookF(){RecognizeCharacters();if(F_Unlock){ch_F.OpenBook();}}
    public void OpenBookK(){RecognizeCharacters();if(K_Unlock){ch_K.OpenBook();}}
    public void OpenBookS(){RecognizeCharacters();if(S_Unlock){ch_S.OpenBook();}}
    public void CloseBookF()
    {RecognizeCharacters();if(F_Unlock){ch_F.CloseBook();}}
    public void CloseBookK()
    {RecognizeCharacters();if(K_Unlock){ch_K.CloseBook();}}
    public void CloseBookS()
    {RecognizeCharacters();if(S_Unlock){ch_S.CloseBook();}}

    public void Charge()
    {
        RecognizeCharacters();
        if(F_Unlock){Manager_F.SwitchScriptsCharge();}
        if(S_Unlock){Manager_S.SwitchScriptsCharge();}
        if(K_Unlock){Manager_K.SwitchScriptsCharge();}
    }
    public void Die()
    {
        RecognizeCharacters();
        if(F_Unlock){Manager_F.SwitchScriptsDeath();}
        if(S_Unlock){Manager_S.SwitchScriptsDeath();}
        if(K_Unlock){Manager_K.SwitchScriptsDeath();}
    }
    
    public void PoseWin()
    {
        if(F_Unlock){ch_FAc.order=7;ch_F.IDAction=5;}
        if(K_Unlock){ch_KAc.order=7;ch_K.IDAction=5;}
        if(S_Unlock){ch_SAc.order=7;ch_S.IDAction=5;}
    }
    public void StopWin()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.RestoreWin();ch_FAc.RestoreWin();ch_F.Stop();ch_F.ReCol();ch_FAc.ReCol();}
        if(K_Unlock){ch_K.RestoreWin();ch_KAc.RestoreWin();ch_K.Stop();ch_K.ReCol();ch_KAc.ReCol();}
        if(S_Unlock){ch_S.RestoreWin();ch_SAc.RestoreWin();ch_S.Stop();ch_S.ReCol();ch_SAc.ReCol();}
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Death
    public void PoseDeathF(){if(F_Unlock){RecognizeCharacters();ch_FAc.order=6;ch_F.IDAction=4;}}
    public void PoseDeathK(){if(K_Unlock){RecognizeCharacters();ch_KAc.order=6;ch_K.IDAction=4;}}
    public void PoseDeathS(){if(S_Unlock){RecognizeCharacters();ch_SAc.order=6;ch_S.IDAction=4;}}
    //----------------//
    public void RestoreDeathF(){if(F_Unlock){RecognizeCharacters();ch_FAc.RestoreDeath();ch_F.RestoreDeath();}}
    public void RestoreDeathhK(){if(K_Unlock){RecognizeCharacters();ch_KAc.RestoreDeath();ch_K.RestoreDeath();}}
    public void RestoreDeathS(){if(S_Unlock){RecognizeCharacters();ch_SAc.RestoreDeath();ch_S.RestoreDeath();}}
    #endregion
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Stun
    public void StunF()
    {if(F_Unlock){ RecognizeCharacters();ch_FAc.order=4;ch_F.IDAction=2;
    ch_F.VFXStun.SetActive(true);ch_FAc.VFXStun.SetActive(true);
    ch_F.VFXStun_I.SetActive(true);ch_FAc.VFXStun_I.SetActive(true);}}
    public void StunK()
    {if(K_Unlock){ RecognizeCharacters();ch_KAc.order=4;ch_K.IDAction=2;
    ch_K.VFXStun.SetActive(true);ch_KAc.VFXStun.SetActive(true);
    ch_K.VFXStun_I.SetActive(true);ch_KAc.VFXStun_I.SetActive(true);}}
    public void StunS()
    {if(S_Unlock){ RecognizeCharacters();ch_SAc.order=4;ch_S.IDAction=2;
    ch_S.VFXStun.SetActive(true);ch_SAc.VFXStun.SetActive(true);
    ch_S.VFXStun_I.SetActive(true);ch_SAc.VFXStun_I.SetActive(true);}}
    public void RestoreStunF()
    {
        RecognizeCharacters();
        if(F_Unlock)
        {PlayerStats.instance.F_paralysisResistance = PlayerStats.instance.F_paralysisResistanceCont;
        ch_F.VFXStun.SetActive(false);ch_FAc.VFXStun.SetActive(false);
        ch_F.VFXStun_I.SetActive(false);ch_FAc.VFXStun_I.SetActive(false);
        ch_F.Idle();ch_F.ReCol();ch_FAc.Idle();ch_FAc.ReCol();}
    }
    public void RestoreStunK()
    {
        RecognizeCharacters();
        if(K_Unlock)
        {PlayerStats.instance.K_paralysisResistance = PlayerStats.instance.K_paralysisResistanceCont;
        ch_K.VFXStun.SetActive(false);ch_KAc.VFXStun.SetActive(false);
        ch_K.VFXStun_I.SetActive(false);ch_KAc.VFXStun_I.SetActive(false);
        ch_K.Idle();ch_K.ReCol();ch_KAc.Idle();ch_KAc.ReCol();}
    }
    public void RestoreStunS()
    {
        RecognizeCharacters();
        if(S_Unlock)
        {PlayerStats.instance.S_paralysisResistance = PlayerStats.instance.S_paralysisResistanceCont;
        ch_S.VFXStun.SetActive(false);ch_SAc.VFXStun.SetActive(false);
        ch_S.VFXStun_I.SetActive(false);ch_SAc.VFXStun_I.SetActive(false);
        ch_S.Idle();ch_S.ReCol();ch_SAc.Idle();ch_SAc.ReCol();}
    }
    #endregion
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Sleep
    public void SleepF()
    {if(F_Unlock){RecognizeCharacters();ch_FAc.order=5;ch_F.IDAction=3;}}
    public void SleepK()
    {if(K_Unlock){ RecognizeCharacters();ch_KAc.order=5;ch_K.IDAction=3;}}
    public void SleepS()
    {if(S_Unlock){ RecognizeCharacters();ch_SAc.order=5;ch_S.IDAction=3;}}
    //
    public void RestoreSleepF()
    {
        RecognizeCharacters();
        if(F_Unlock)
        {PlayerStats.instance.F_sleepResistance = PlayerStats.instance.F_sleepResistanceCont;
        ch_F.Idle();ch_F.ReCol();ch_FAc.Idle();ch_FAc.ReCol();ch_F.SleepRestored(); ch_FAc.SleepRestored();}
    }
    public void RestoreSleepK()
    {
        RecognizeCharacters();
        if(K_Unlock)
        {PlayerStats.instance.K_sleepResistance = PlayerStats.instance.K_sleepResistanceCont;
        ch_K.Idle();ch_K.ReCol();ch_KAc.Idle();ch_KAc.ReCol();ch_K.SleepRestored(); ch_KAc.SleepRestored();}
    }
    public void RestoreSleepS()
    {
        RecognizeCharacters();
        if(S_Unlock)
        {PlayerStats.instance.S_sleepResistance = PlayerStats.instance.S_sleepResistanceCont;
        ch_S.Idle();ch_S.ReCol();ch_SAc.Idle();ch_SAc.ReCol();ch_S.SleepRestored(); ch_SAc.SleepRestored();}
    }
    #endregion
////////////////////////////////////////////////////////////////////////////////////////////////////////    
#region Rust/Silence
    public void RustF()
    {if(F_Unlock){ RecognizeCharacters();ch_FAc.Rust();ch_F.Rust();Rust_F.SetActive(true);}}
    public void RustK()
    {if(K_Unlock){ RecognizeCharacters();ch_KAc.Rust();ch_K.Rust();Rust_K.SetActive(true);}}
    public void RustS()
    {if(S_Unlock){ RecognizeCharacters();ch_SAc.Rust();ch_S.Rust();Rust_S.SetActive(true);}}
    //
    public void RestoreRustF()
    {if(F_Unlock){ PlayerStats.instance.F_rustResistance = PlayerStats.instance.F_rustResistanceCont;
    RecognizeCharacters();Rust_F.SetActive(false);ch_F.ReCol();ch_FAc.Idle();ch_FAc.ReCol();
    ch_F.VFXRust.SetActive(false);ch_FAc.VFXRust.SetActive(false);
    ch_F.VFXRust_I.SetActive(false);ch_FAc.VFXRust_I.SetActive(false);}}
    public void RestoreRustK()
    {if(K_Unlock){ PlayerStats.instance.K_rustResistance = PlayerStats.instance.K_rustResistanceCont;
    RecognizeCharacters();Rust_K.SetActive(false);ch_K.ReCol();ch_KAc.Idle();ch_KAc.ReCol();
    ch_K.VFXRust.SetActive(false);ch_KAc.VFXRust.SetActive(false);
    ch_K.VFXRust_I.SetActive(false);ch_KAc.VFXRust_I.SetActive(false);}}
    public void RestoreRustS()
    {if(S_Unlock){ PlayerStats.instance.S_rustResistance = PlayerStats.instance.S_rustResistanceCont;
    RecognizeCharacters();Rust_S.SetActive(false);ch_S.ReCol();ch_SAc.Idle();ch_SAc.ReCol();
    ch_S.VFXRust.SetActive(false);ch_SAc.VFXRust.SetActive(false);
    ch_S.VFXRust_I.SetActive(false);ch_SAc.VFXRust_I.SetActive(false);}}
    #endregion
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region PoisonState
    public void PoisonF(){if(F_Unlock){RecognizeCharacters();ch_FAc.Poison();ch_F.Poison();}}
    public void PoisonK(){if(K_Unlock){RecognizeCharacters();ch_KAc.Poison();ch_K.Poison();}}
    public void PoisonS(){if(S_Unlock){ RecognizeCharacters();ch_SAc.Poison();ch_S.Poison();}}
    #endregion
////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Restore
    public void RestoreF()
    {
        RecognizeCharacters();
        if(F_Unlock)
        {PlayerStats.instance.F_paralysisResistance = PlayerStats.instance.F_paralysisResistanceCont;
        PlayerStats.instance.F_poisonResistance = PlayerStats.instance.F_poisonResistanceCont;
        PlayerStats.instance.F_rustResistance = PlayerStats.instance.F_rustResistanceCont;
        PlayerStats.instance.F_sleepResistance = PlayerStats.instance.F_sleepResistanceCont;
        RestoreRustF();
        ch_F.Idle();ch_F.ReCol();ch_FAc.Idle();ch_FAc.ReCol();}
    }
    public void RestoreK()
    {
        RecognizeCharacters();
        if(K_Unlock)
        {PlayerStats.instance.K_paralysisResistance = PlayerStats.instance.K_paralysisResistanceCont;
        PlayerStats.instance.K_poisonResistance = PlayerStats.instance.K_poisonResistanceCont;   
        PlayerStats.instance.K_rustResistance = PlayerStats.instance.K_rustResistanceCont;
        PlayerStats.instance.K_sleepResistance = PlayerStats.instance.K_sleepResistanceCont;
        RestoreRustK();
        ch_K.Idle();ch_K.ReCol();ch_KAc.Idle();ch_KAc.ReCol();}
    }
    public void RestoreS()
    {
        RecognizeCharacters();
        if(S_Unlock)
        {PlayerStats.instance.S_paralysisResistance = PlayerStats.instance.S_paralysisResistanceCont;
        PlayerStats.instance.S_poisonResistance = PlayerStats.instance.S_poisonResistanceCont; 
        PlayerStats.instance.S_rustResistance = PlayerStats.instance.S_rustResistanceCont;  
        PlayerStats.instance.S_sleepResistance = PlayerStats.instance.S_sleepResistanceCont;
        RestoreRustS();
        ch_S.Idle();ch_S.ReCol();ch_SAc.Idle();ch_SAc.ReCol();}
    }
    #endregion   
////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public void Allarm()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.Allarm();ch_F.Attention = true;ch_FAc.Allarm();ch_FAc.Attention = true;}
        if(K_Unlock){ch_K.Allarm();ch_K.warning = false;ch_K.Attention = true;ch_KAc.Allarm();ch_KAc.Attention = true;}
        if(S_Unlock){ch_S.Allarm();ch_S.warning = false;ch_S.Attention = true;ch_SAc.Allarm();ch_SAc.Attention = true;}
    }
    public void StopAllarm()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_FAc.StopAllarm();ch_F.StopAllarm();ch_F.Attention = false;ch_FAc.Attention = false;}
        if(K_Unlock){ch_KAc.StopAllarm();ch_K.StopAllarm();ch_K.Attention = false;ch_KAc.Attention = false;}
        if(S_Unlock){ch_SAc.StopAllarm();ch_S.StopAllarm();ch_S.Attention = false;ch_SAc.Attention = false;}
    }
    public void Esclamation()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.Attention = true;} 
        if(S_Unlock){ch_S.Attention = true;} 
        if(K_Unlock){ch_K.Attention = true;} 
    }
    public void EsclamationStop()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.Attention = false;}         
        if(K_Unlock){ch_K.Attention = false;} 
        if(S_Unlock){ch_S.Attention = false;}
    }
    public void Exploration()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.IDAction = 0;ch_FAc.IDAction = 0;}
        if(S_Unlock){ch_S.IDAction = 0;ch_SAc.IDAction = 0;}
        if(K_Unlock){ch_K.IDAction = 0;ch_KAc.IDAction = 0;}
    }
    public void Battle()
    {
        RecognizeCharacters();
        if(F_Unlock){ch_F.IDAction = 1;ch_FAc.IDAction = 1;}
        if(S_Unlock){ch_S.IDAction = 1;ch_SAc.IDAction = 1;}
        if(K_Unlock){ch_K.IDAction = 1;ch_KAc.IDAction = 1;}
    }
    //public void TakeData(){RecognizeCharacters();}
    public void AddTomoney(int pointsToAdd){money += pointsToAdd; moneyTextM.text = money.ToString();}
    public void ForkUnlock(){Fork.SetActive(true); F_Unlock = true; Manager_F.SwitchScriptsActor();}   
    public void SpoonUnlock(){Spoon.SetActive(true); S_Unlock = true; Manager_S.SwitchScriptsActor();}   
    public void KnifeUnlock(){Knife.SetActive(true); K_Unlock = true; Manager_K.SwitchScriptsActor();}   
    public void K_PlayerReachedLevelUp(){PlayerStats.instance.K_LevelUp();}
    public void S_PlayerReachedLevelUp(){PlayerStats.instance.S_LevelUp();}
    public void F_PlayerReachedLevelUp(){PlayerStats.instance.F_LevelUp();}
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