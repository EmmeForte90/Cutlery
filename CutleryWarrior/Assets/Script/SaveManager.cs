using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private string percorsoSalvataggio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
                percorsoSalvataggio = Path.Combine(Application.persistentDataPath, "datigioco.json");

    }
    #region Header
    [System.Serializable]
    public class PlayerStats
    {
    [Header("Stats")]
    [Header("Fork")]
    [SerializeField] public int F_LV = 1;
    [SerializeField] public float F_HP = 0;
    [SerializeField] public float F_curHP = 0;
    [SerializeField] public float F_MP = 0;
    [SerializeField] public float F_curMP = 0;
    [SerializeField] public float F_curRage = 0;
    [SerializeField] public float F_Rage = 100;
    [SerializeField] public float F_CostMP = 0;
    [SerializeField] public float F_Exp = 0;
    [SerializeField] public float F_curExp = 0;
    [SerializeField] public int F_attack = 10;
    [SerializeField] public int F_defense = 5;
    [SerializeField] public int F_poisonResistance = 0;
    [SerializeField] public int F_paralysisResistance = 0;
    [SerializeField] public int F_sleepResistance = 0;
    [SerializeField] public int F_rustResistance = 0;
    //
    [HideInInspector] public float F_HPCont;
    [HideInInspector] public float F_curHPCont;
    [HideInInspector] public float F_MPCont;
    [HideInInspector] public float F_curMPCont;
    [HideInInspector] public float F_CostMPCont;
    [HideInInspector] public float F_ExpCont;
    [HideInInspector] public float F_curExpCont;
    [HideInInspector] public int F_attackCont;
    [HideInInspector] public int F_defenseCont;
    [HideInInspector] public int F_poisonResistanceCont;
    [HideInInspector] public int F_paralysisResistanceCont;
    [HideInInspector] public int F_sleepResistanceCont;
    [HideInInspector] public int F_rustResistanceCont;
    [Header("Spoon")]
    [SerializeField] public int S_LV = 1;
    [SerializeField] public float S_HP = 0;
    [SerializeField] public float S_curHP = 0;
    [SerializeField] public float S_MP = 0;
    [SerializeField] public float S_curMP = 0;
    [SerializeField] public float S_curRage = 0;
    [SerializeField] public float S_Rage = 100;
    [SerializeField] public float S_CostMP = 0;
    [SerializeField] public float S_Exp = 0;
    [SerializeField] public float S_curExp = 0;
    [SerializeField] public int S_attack = 10;
    [SerializeField] public int S_defense = 5;
    [SerializeField] public int S_poisonResistance = 0;
    [SerializeField] public int S_paralysisResistance = 0;
    [SerializeField] public int S_sleepResistance = 0;
    [SerializeField] public int S_rustResistance = 0; 
    //
    [HideInInspector] public float S_HPCont;
    [HideInInspector] public float S_curHPCont;
    [HideInInspector] public float S_MPCont;
    [HideInInspector] public float S_curMPCont;
    [HideInInspector] public float S_CostMPCont;
    [HideInInspector] public float S_ExpCont;
    [HideInInspector] public float S_curExpCont;
    [HideInInspector] public int S_attackCont;
    [HideInInspector] public int S_defenseCont;
    [HideInInspector] public int S_poisonResistanceCont;
    [HideInInspector] public int S_paralysisResistanceCont;
    [HideInInspector] public int S_sleepResistanceCont;
    [HideInInspector] public int S_rustResistanceCont;
    [Header("Knife")]
    [SerializeField] public int K_LV = 1;
    [SerializeField] public float K_HP = 0;
    [SerializeField] public float K_curHP = 0;
    [SerializeField] public float K_MP = 0;
    [SerializeField] public float K_curMP = 0;
    [SerializeField] public float K_CostMP = 0;
    [SerializeField] public float K_curRage = 0;
    [SerializeField] public float K_Rage = 100;
    [SerializeField] public float K_Exp = 0;
    [SerializeField] public float K_curExp = 0;
    [SerializeField] public int K_attack = 10;
    [SerializeField] public int K_defense = 5;
    [SerializeField] public int K_poisonResistance = 0;
    [SerializeField] public int K_paralysisResistance = 0;
    [SerializeField] public int K_sleepResistance = 0;
    [SerializeField] public int K_rustResistance = 0; 
    //
    [HideInInspector] public float K_HPCont;
    [HideInInspector] public float K_curHPCont;
    [HideInInspector] public float K_MPCont;
    [HideInInspector] public float K_curMPCont;
    [HideInInspector] public float K_CostMPCont;
    [HideInInspector] public float K_ExpCont;
    [HideInInspector] public float K_curExpCont;
    [HideInInspector] public int K_attackCont;
    [HideInInspector] public int K_defenseCont;
    [HideInInspector] public int K_poisonResistanceCont;
    [HideInInspector] public int K_paralysisResistanceCont;
    [HideInInspector] public int K_sleepResistanceCont;
    [HideInInspector] public int K_rustResistanceCont;
    //
    [Header("Enemies List")]
    public bool[] Enemies;
    [Header("Treasure List")]
    public bool[] Treasure;
    public static PlayerStats instance;
    [Header("Skill List")]
    public bool[] Skill_F;
    public GameObject[] Skill_FI;
    public GameObject[] Skill_FIB;
    public bool[] Skill_K;
    public GameObject[] Skill_KI;
    public GameObject[] Skill_KIB;
    public bool[] Skill_S;
    public GameObject[] Skill_SI;
    public GameObject[] Skill_SIB;
    }
    #endregion



    // Salvataggio
    public void SalvaDati(PlayerStats dati)
    {
        string datiJson = JsonUtility.ToJson(dati);
        File.WriteAllText(percorsoSalvataggio, datiJson);
    }

    // Caricamento
    public PlayerStats CaricaDati()
    {
        if (File.Exists(percorsoSalvataggio))
        {
            string datiJson = File.ReadAllText(percorsoSalvataggio);
            return JsonUtility.FromJson<PlayerStats>(datiJson);
        }
        else
        {
            return new PlayerStats(); // Ritorna nuovi dati se il file non esiste
        }
    }
}