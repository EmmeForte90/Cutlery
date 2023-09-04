using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    #region Header
    [Header("Stats")]
    [Header("Fork")]
    [SerializeField] public int F_LV = 1;
    [SerializeField] public float F_HP = 0;
    [SerializeField] public float F_curHP = 0;
    [SerializeField] public float F_MP = 0;
    [SerializeField] public float F_curMP = 0;
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
    #endregion
    public void Awake(){if (instance == null){instance = this;}}

    public void DeactivateENM()
    {
        // Cerca tutti i GameObjects con il tag "Enemy"
        GameObject[] ENMIT = GameObject.FindGameObjectsWithTag("Enemy");
    
    foreach (GameObject Character in ENMIT)
        {
            // Ottiene il componente QuestCharacters
            TouchPlayer Enm = Character.GetComponent<TouchPlayer>();

            // Verifica se il componente esiste
            if (Enm != null)
            {
                // Verifica se l'id della quest corrisponde all'id di un gameobject in OrdaliaActive
                int Id = Enm.IdENM;
                for (int i = 0; i <  Enemies.Length; i++)
                {
                    if ( Enemies[i] && i == Id)
                    {
                        // Imposta ordaliT.FirstD a false
                        Enm.Take();
                        break;
                    }
                }
            }
        }
    }
    public void DeactivateCHEST()
    {
        // Cerca tutti i GameObjects con il tag "Enemy"
        GameObject[] Chest = GameObject.FindGameObjectsWithTag("Chest");
    
    foreach (GameObject Character in Chest)
        {
            // Ottiene il componente QuestCharacters
            Treasure tre = Character.GetComponent<Treasure>();

            // Verifica se il componente esiste
            if (tre != null)
            {
                // Verifica se l'id della quest corrisponde all'id di un gameobject in OrdaliaActive
                int Id = tre.IdChest;
                for (int i = 0; i <  Enemies.Length; i++)
                {
                    if ( Treasure[i] && i == Id)
                    {
                        // Imposta ordaliT.FirstD a false
                        tre.Take();
                        break;
                    }
                }
            }
        }
    }
    public void FSkillATT(int Act){Skill_F[Act] = true; Skill_FI[Act].SetActive(true); Skill_FIB[Act].SetActive(true);}
    public void SSkillATT(int Act){Skill_S[Act] = true; Skill_SI[Act].SetActive(true); Skill_SIB[Act].SetActive(true);}
    public void KSkillATT(int Act){Skill_K[Act] = true; Skill_KI[Act].SetActive(true); Skill_KIB[Act].SetActive(true);}

    public void EnemyDefeatArea(int Defeat){Enemies[Defeat] = true;}
    public void TreasureOpen(int Open){Treasure[Open] = true;}

    #region Levelup
    public void F_LevelUp()
    {
        F_HP += 50;
        F_MP = +50;
        F_attack += 10;
        F_defense += 5;
        F_poisonResistance += 2;
        F_paralysisResistance += 2;
        F_sleepResistance += 2;
        F_rustResistance += 2;
        F_HPCont = F_HP;
        F_MPCont = F_MP;
        F_attackCont = F_attack;
        F_defenseCont = F_defense;
        F_poisonResistanceCont = F_poisonResistance;
        F_paralysisResistanceCont = F_paralysisResistance;
        F_sleepResistanceCont = F_sleepResistance;
        F_rustResistanceCont = F_rustResistance;
        F_LV++;
        F_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
        F_curExp = 0;
        GameManager.instance.StatPlayer();
    }
    public void K_LevelUp()
    {
        K_HP += 100;
        K_MP = +30;
        K_attack += 20;
        K_defense += 5;
        K_poisonResistance += 1;
        K_paralysisResistance += 1;
        K_sleepResistance += 1;
        K_rustResistance += 1;
        K_HPCont = K_HP;
        K_MPCont = K_MP;
        K_attackCont = K_attack;
        K_defenseCont = K_defense;
        K_poisonResistanceCont = K_poisonResistance;
        K_paralysisResistanceCont = K_paralysisResistance;
        K_sleepResistanceCont = K_sleepResistance;
        K_rustResistanceCont = K_rustResistance;
        K_LV++;
        K_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
        K_curExp = 0;
        GameManager.instance.StatPlayer();
    }
    public void S_LevelUp()
    {
        S_HP += 50;
        S_MP = +40;
        S_attack += 5;
        S_defense += 10;
        S_poisonResistance += 3;
        S_paralysisResistance += 3;
        S_sleepResistance += 3;
        S_rustResistance += 3;
        S_HPCont = S_HP;
        S_MPCont = S_MP;
        S_attackCont = S_attack;
        S_defenseCont = S_defense;
        S_poisonResistanceCont = S_poisonResistance;
        S_paralysisResistanceCont = S_paralysisResistance;
        S_sleepResistanceCont = S_sleepResistance;
        S_rustResistanceCont = S_rustResistance;
        S_LV++;
        S_Exp += 500; // Ad esempio, aumentiamo di 50 ogni volta che si sale di livello
        S_curExp = 0;
        GameManager.instance.StatPlayer();
    }
#endregion
}