using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AttStats : MonoBehaviour
{
    #region Header
    [Header("Stats")]
    [HideInInspector] public int F_LV;
    [Header("Fork")]
    [SerializeField] public GameObject F_Window;
    [SerializeField] public Scrollbar F_ExpScrol;
    [SerializeField] public TextMeshProUGUI F_LVTextM;
    [SerializeField] public GameObject F_LevelUP;
    [SerializeField] public GameObject F_Stat;
    [SerializeField] public TextMeshProUGUI F_Def;
    [SerializeField] public TextMeshProUGUI F_Atk;
    [SerializeField] public TextMeshProUGUI F_Pois;
    [SerializeField] public TextMeshProUGUI F_Rust;
    [SerializeField] public TextMeshProUGUI F_Sleep;
    [SerializeField] public TextMeshProUGUI F_Stun;
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
    //
    [HideInInspector] public int S_LV;
    [Header("Spoon")]
    [SerializeField] public GameObject S_Window;
    [SerializeField] public Scrollbar S_ExpScrol;
    [SerializeField] public TextMeshProUGUI S_LVTextM;
    [SerializeField] public GameObject S_LevelUP;
    [SerializeField] public GameObject S_Stat;
    [SerializeField] public TextMeshProUGUI S_Def;
    [SerializeField] public TextMeshProUGUI S_Atk;
    [SerializeField] public TextMeshProUGUI S_Pois;
    [SerializeField] public TextMeshProUGUI S_Rust;
    [SerializeField] public TextMeshProUGUI S_Sleep;
    [SerializeField] public TextMeshProUGUI S_Stun;
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
    //
    [HideInInspector] public int K_LV;
    [Header("Knife")]
    [SerializeField] public GameObject K_Window;

    [SerializeField] public Scrollbar K_ExpScrol;
    [SerializeField] public TextMeshProUGUI K_LVTextM;
    [SerializeField] public GameObject K_LevelUP;
    [SerializeField] public GameObject K_Stat;
    [SerializeField] public TextMeshProUGUI K_Def;
    [SerializeField] public TextMeshProUGUI K_Atk;
    [SerializeField] public TextMeshProUGUI K_Pois;
    [SerializeField] public TextMeshProUGUI K_Rust;
    [SerializeField] public TextMeshProUGUI K_Sleep;
    [SerializeField] public TextMeshProUGUI K_Stun;
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
    public static AttStats instance;
    #endregion
    public void Awake()
    {if (instance == null){instance = this;} 
    K_Window.SetActive(false);S_Window.SetActive(false);F_Window.SetActive(false);}
    public void Update()
    {
        if(GameManager.instance.K_Unlock){
        K_Window.SetActive(true);
        K_ExpScrol.size = PlayerStats.instance.K_curExp / PlayerStats.instance.K_Exp;
        K_ExpScrol.size = Mathf.Clamp(K_ExpScrol.size, 0.01f, 5);
        K_LV = PlayerStats.instance.K_LV;
        K_LVTextM.text = K_LV.ToString();
        }
        //
        if(GameManager.instance.S_Unlock){
        S_Window.SetActive(true);
        S_ExpScrol.size = PlayerStats.instance.S_curExp / PlayerStats.instance.S_Exp;
        S_ExpScrol.size = Mathf.Clamp(S_ExpScrol.size, 0.01f, 5);
        S_LV = PlayerStats.instance.S_LV;
        S_LVTextM.text = S_LV.ToString();
        }
        //
        if(GameManager.instance.F_Unlock){
        F_Window.SetActive(true);
        F_ExpScrol.size = PlayerStats.instance.F_curExp / PlayerStats.instance.F_Exp;
        F_ExpScrol.size = Mathf.Clamp(F_ExpScrol.size, 0.01f, 5);
        F_LV = PlayerStats.instance.F_LV;
        F_LVTextM.text = F_LV.ToString();
        }
        //
    }
    public void F_GainExperience(int amount)
    {
        PlayerStats.instance.F_curExp += amount;
        if (PlayerStats.instance.F_curExp >= PlayerStats.instance.F_Exp)
        {PlayerStats.instance.F_LevelUp();
        F_LevelUP.gameObject.SetActive(true); 
        F_Stat.gameObject.SetActive(true); 
        F_LevelUPatt();}
    }
    public void K_GainExperience(int amount)
    {
        PlayerStats.instance.K_curExp += amount;
        if (PlayerStats.instance.K_curExp >= PlayerStats.instance.K_Exp)
        {PlayerStats.instance.K_LevelUp();
        K_LevelUP.gameObject.SetActive(true); 
        K_Stat.gameObject.SetActive(true); 
        K_LevelUPatt();}
    }
    public void S_GainExperience(int amount)
    {
        PlayerStats.instance.S_curExp += amount;
        if (PlayerStats.instance.S_curExp >= PlayerStats.instance.S_Exp)
        {PlayerStats.instance.S_LevelUp();
        S_LevelUP.gameObject.SetActive(true); 
        S_Stat.gameObject.SetActive(true); 
        S_LevelUPatt();}
    }
    public void K_LevelUPatt()
    {        
        K_HPCont = PlayerStats.instance.K_HP;
        PlayerStats.instance.K_curHP = K_HPCont;
        K_MPCont = PlayerStats.instance.K_MP;
        K_attackCont = PlayerStats.instance.K_attack;
        K_defenseCont = PlayerStats.instance.K_defense;
        K_poisonResistanceCont = PlayerStats.instance.K_poisonResistance;
        K_paralysisResistanceCont = PlayerStats.instance.K_paralysisResistance;
        K_sleepResistanceCont = PlayerStats.instance.K_sleepResistance;
        K_rustResistanceCont = PlayerStats.instance.K_rustResistance;
        K_LV = PlayerStats.instance.K_LV;
        K_LVTextM.text = K_LV.ToString();
        K_Atk.text = K_attackCont.ToString();
        K_Def.text = K_defenseCont.ToString();
        K_Pois.text = K_poisonResistanceCont.ToString();
        K_Stun.text = K_paralysisResistanceCont.ToString();
        K_Sleep.text = K_sleepResistanceCont.ToString();
        K_Rust.text = K_rustResistanceCont.ToString(); 
    }
    public void F_LevelUPatt()
    {        
        F_HPCont = PlayerStats.instance.F_HP;
        PlayerStats.instance.F_curHP = F_HPCont;        
        F_MPCont = PlayerStats.instance.F_MP;
        F_attackCont = PlayerStats.instance.F_attack;
        F_defenseCont = PlayerStats.instance.F_defense;
        F_poisonResistanceCont = PlayerStats.instance.F_poisonResistance;
        F_paralysisResistanceCont = PlayerStats.instance.F_paralysisResistance;
        F_sleepResistanceCont = PlayerStats.instance.F_sleepResistance;
        F_rustResistanceCont = PlayerStats.instance.F_rustResistance;
        F_LV = PlayerStats.instance.F_LV;
        F_LVTextM.text = F_LV.ToString();
        F_Atk.text = F_attackCont.ToString();
        F_Def.text = F_defenseCont.ToString();
        F_Pois.text = F_poisonResistanceCont.ToString();
        F_Stun.text = F_paralysisResistanceCont.ToString();
        F_Sleep.text = F_sleepResistanceCont.ToString();
        F_Rust.text = F_rustResistanceCont.ToString(); 
    }
    public void S_LevelUPatt()
    {        
        S_HPCont = PlayerStats.instance.S_HP;
        PlayerStats.instance.S_curHP = S_HPCont;        
        S_MPCont = PlayerStats.instance.S_MP;
        S_attackCont = PlayerStats.instance.S_attack;
        S_defenseCont = PlayerStats.instance.S_defense;
        S_poisonResistanceCont = PlayerStats.instance.S_poisonResistance;
        S_paralysisResistanceCont = PlayerStats.instance.S_paralysisResistance;
        S_sleepResistanceCont = PlayerStats.instance.S_sleepResistance;
        S_rustResistanceCont = PlayerStats.instance.S_rustResistance;
        S_LV = PlayerStats.instance.S_LV;
        S_LVTextM.text = S_LV.ToString();
        S_Atk.text = S_attackCont.ToString();
        S_Def.text = S_defenseCont.ToString();
        S_Pois.text = S_poisonResistanceCont.ToString();
        S_Stun.text = S_paralysisResistanceCont.ToString();
        S_Sleep.text = S_sleepResistanceCont.ToString();
        S_Rust.text = S_rustResistanceCont.ToString(); 
    }
}