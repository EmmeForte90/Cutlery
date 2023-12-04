using System.Collections;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using TMPro;
public class BossMiniera : MonoBehaviour
{
    [Header("Change Script")]
    public BossMiniera This;
    [Header("Stop For Test")]
    public GameObject player;
    public GameObject Icon;
    public GameObject IconVFX;
    public string NameBoss;
    [SerializeField] public TextMeshProUGUI NameBossText;
    private bool take = false; 
    private int N_Target = 0;
    [Header("Hp")]
    public float maxHealth = 100f;
    public float currentHealth;
    public bool DieB = false;
    public Scrollbar healthBar;
    public DuelManager DM;
    public int result;
    [Header("Move")]
    public float moveSpeed = 3f;
    [Header("Attack")]
    public Vector3 launchDirection = Vector3.right; // Direzione del lancio iniziale
    //public float randomRadius = 5f; // Puoi regolare questo valore in base alle tue esigenze
    public GameObject Bullets;
    [Tooltip("Il tempo dedicato all'attacco")]
    public int WaitAtk = 1;
    [Tooltip("Il tempo che deve aspettare per il prossimo attacco")]
    public int attackPauseDuration = 1;
    public float attackRange = 1.5f;
    public int defense = 2;
    private bool isAttacking = false;   
    /////////////////////////////////////////////////////////////////////////////////
    [Header("Actions")]
    public int Action_P1,Action_P2,Action_P3 = 0;
    private bool Lock_P2,Lock_P3 = false;
    private bool Lock_P1 = true;
    bool isMoving = false;
    private float lerpTime = 2f; //Tempo interpolazione
    /////////////////////////////////////////////////////////////////////////////////

    [Header("Status")]
    public float damagePerSecond = 0.1f;
    public float duration = 5.0f;
    private float elapsedTime = 0.0f;
    private bool isDamaging = false;
    
    [Header("Poison")]
    public GameObject VFXPoison;
    public int poisonResistance = 100;
    public int poisonResistanceCont;
    private int TimePoison = 5;   

    [Header("Stun")]
    public GameObject VFXStun;
    public bool isStun = false;
    public int StunProbability = 0;
    public int StunProbabilityCount = 2;
    public int StunProbabilityMAX = 10;
    public int timeStun = 3;
    public int StunTimer = 5;

    [Header("Sleep")]
    public GameObject VFXSleep;
    public bool isSleep = false;
    public int SleepProbability = 0;
    public int SleepProbabilityCount = 2;
    public int SleepProbabilityMAX = 10;
    public int timeSleep = 3;

    [Header("VFX")]
    [SerializeField] GameObject VFX_Barier;
    [SerializeField]  Transform hitpoint;
    [SerializeField] GameObject CenterPoint;
    [SerializeField] GameObject VFXHurt;    
    [SerializeField] GameObject VFXDie;

    [Header("Move")]
    [Tooltip("Il tempo dedicato all'attacco")]
    public int WaitAtk_P2 = 1;
    [Tooltip("Il tempo che deve aspettare per il prossimo attacco")]
    public int attackPauseDuration_P2 = 1;
    
     [Header("Animations")]
    [SpineAnimation][SerializeField] private string IdleP1AnimationName;
    [SpineAnimation][SerializeField] private string IdleP2AnimationName;
    [SpineAnimation][SerializeField] private string IdleP3AnimationName;
    [SpineAnimation][SerializeField] private string WalkAnimationName;
    [SpineAnimation][SerializeField] private string RunAnimationName;
    [SpineAnimation][SerializeField] private string Atk1AnimationName;
    [SpineAnimation][SerializeField] private string Atk2AnimationName;
    [SpineAnimation][SerializeField] private string Atk3AnimationName;
    [SpineAnimation][SerializeField] private string StunStartAnimationName;
    [SpineAnimation][SerializeField] private string StunAnimationName;
    [SpineAnimation][SerializeField] private string StunEndAnimationName;
    [SpineAnimation][SerializeField] private string StunFlashAnimationName;
    [SpineAnimation][SerializeField] private string SleepAnimationName;
    [SpineAnimation][SerializeField] private string StartP2AnimationName;
    [SpineAnimation][SerializeField] private string StartP3AnimationName;
    [SpineAnimation][SerializeField] private string DieAnimationName;
    [SpineAnimation][SerializeField] private string PredieAnimationName;

    public AnimationManager Anm;
    public static BossMiniera instance;

    void Start()
    {
        if (instance == null){instance = this;}
        NameBossText.text = NameBoss.ToString();
        DM.EnemyinArena += 1;
        N_Target = GameManager.instance.N_Target;
        currentHealth = maxHealth;
        poisonResistanceCont = poisonResistance;
    }
    
    /////////////////////////////////////////////////////////////////////////////////
    private void Choise()
    {
        // Genera un numero casuale tra 1 e 3
        int randomNumber = Random.Range(1, N_Target);
        result = randomNumber;
        Target();
        // Debug.Log("Numero casuale: " + result);
        // Debug.Log(ID + "ha Preso" + result);
    }
    public void Target()
    {
        switch(result)
        {
            case 1:
            if(GameManager.instance.F_Unlock && !DM.F_Die){player = GameManager.instance.F_Hero;}
            else if(!GameManager.instance.F_Unlock || DM.F_Die){Choise();}
            break;
            case 2:
            if(GameManager.instance.K_Unlock && !DM.K_Die){player =  GameManager.instance.K_Hero;}
            else if(!GameManager.instance.K_Unlock || DM.K_Die){Choise();}
            break;
            case 3:
            if(GameManager.instance.S_Unlock && !DM.S_Die){player =  GameManager.instance.S_Hero;}
            else if(!GameManager.instance.S_Unlock || DM.S_Die){Choise();}
            break;
        } 
    }
    public void ChoseFork(){if(GameManager.instance.F_Unlock){player = GameManager.instance.F_Hero;}}
    public void ChoseKnife(){if(GameManager.instance.K_Unlock){player = GameManager.instance.K_Hero;}}
    public void ChoseSpoon(){if(GameManager.instance.S_Unlock){player = GameManager.instance.S_Hero;}}
    public void FacePlayer()
    {
    if(player != null){
    if (player.transform.position.z > transform.position.z){transform.localScale = new Vector3(1, 1, 1);}
    else if (player.transform.position.z < transform.position.z){transform.localScale = new Vector3(-1, 1, 1);}} 
    if(player == null){/*Aspetta*/}
    }
    /////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        if(!DieB){
        if(!DM.inputCTR){ 
        if (player == null && !take){Choise(); take = true;}
        Target();
        healthBar.size = currentHealth / maxHealth;
        healthBar.size = Mathf.Clamp(healthBar.size, 0.01f, 1);
        if (currentHealth > 3500 && !DieB)
        {
            // Fase 1
            Phase_1Move();
            Lock_P1 = true;Lock_P2 = false;Lock_P3 = false;
        }
        else if (currentHealth <= 3500 && currentHealth > 2500 && Lock_P1 && !Lock_P2 && !Lock_P3 && !DieB)
        {
            // Fase 2
            Phase_2Move();
            Lock_P1 = false;Lock_P2 = true;Lock_P3 = false;
        }
        else if (currentHealth <= 2500 && currentHealth < 3500 && !Lock_P1 && Lock_P2 && !Lock_P3 && !DieB)
        {
            // Fase 3
            Phase_3Move();
            Lock_P1 = false;Lock_P2 = false;Lock_P3 = true;
        }
        else if (currentHealth <= 0 && !Lock_P1 && !Lock_P2 && Lock_P3 && !DieB)
        {
            // Morte
            DieB = true; IconVFX.SetActive(true); Die();
        }
    }}}
    /////////////////////////////////////////////////////////////////////////////////
    public void Phase_1Move()
    {
        switch (Action_P1)
        {
            case 0:
            // Fase 0
            if(!isAttacking){FacePlayer();ChasePlayer();}
            break;
            case 1:
            // Fase 1
            if(!isAttacking){FacePlayer();Shoot();}
            break;
            case 2:
            // Fase 2
            StartP2();
            break;
            default:
            // Altre fasi o gestione degli errori
            break;

        }
    }
    public void Phase_2Move()
    {
        switch (Action_P2)
        {
            case 0:
            // Fase 0
            if(!isAttacking){Bombing();}
            break;
            case 1:
            // Fase 1
            CanHurt();
            break;
            case 2:
            // Fase 2
            StartP3();
            break;
            default:
            // Altre fasi o gestione degli errori
            break;

        }
    }
    public void Phase_3Move()
    {
        switch (Action_P3)
        {
            case 0:
            // Fase 0
            if(!isAttacking){FacePlayer();ChasePlayer();}
            break;
            case 1:
            // Fase 1
            if(!isAttacking){Shoot();}
            break;
            case 2:
            // Fase 2
            if(!isAttacking){Bombing();}
            break;
            case 3:
            // Fase 3
            PreDie();
            break;
            default:
            // Altre fasi o gestione degli errori
            break;

        }
    }
    //////////////////////////////////////////////////////////////////////////
    private void StartP2()
        {
            if(!DM.inputCTR)
            {
                Anm.PlayAnimation(StartP2AnimationName);
                StartCoroutine(MoveTowardsCenterPoint());
            }
        }
    private IEnumerator MoveTowardsCenterPoint()
    {
    isMoving = true;

    Vector3 startPosition = transform.position;
    Vector3 targetPosition = CenterPoint.transform.position;
    float elapsedTime = 0f;

    while (elapsedTime < lerpTime)
    {
        transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / lerpTime);
        elapsedTime += Time.deltaTime;
        yield return null;  // Attendi il frame successivo
    }
    transform.position = targetPosition;  // Assicurati che la posizione finale sia esatta
    isMoving = false;
    }
    //////////////////////////////////////////////////////////////////////////
    private void StartP3()
        {
            if(!DM.inputCTR){Anm.PlayAnimation(StartP3AnimationName);}
        }
    //////////////////////////////////////////////////////////////////////////

    private void ChasePlayer()
        {
            if(!DM.inputCTR){
            if (player != null)
            {
                if(!isAttacking)
                {transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                if(!DieB){Anm.PlayAnimationLoop(RunAnimationName);}}
                if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
                {StartAttack();}
            }}
            else if(DM.inputCTR && !DieB && currentHealth > 3500){Anm.PlayAnimationLoop(IdleP1AnimationName);}
            else if(DM.inputCTR && !DieB && currentHealth <= 2500){Anm.PlayAnimationLoop(IdleP3AnimationName);}
        }
    private void StartAttack()
    {
        isAttacking = true;
        if(!DieB && currentHealth > 3500){Anm.PlayAnimation(Atk1AnimationName);}
        else if(!DieB && currentHealth <= 2500){Anm.PlayAnimation(Atk3AnimationName);}

        //Debug.Log("Attacco!");
        StartCoroutine(AttackPause());
    }
    private IEnumerator AttackPause()
    {        
        yield return new WaitForSeconds(WaitAtk);        
        if(!DieB && currentHealth > 3500){Anm.PlayAnimationLoop(IdleP1AnimationName);}
        else if(!DieB && currentHealth <= 2500){Anm.PlayAnimationLoop(IdleP3AnimationName);}
        yield return new WaitForSeconds(attackPauseDuration);
        take = false;
        isAttacking = false;
        if(currentHealth > 3500 && Action_P1 == 0){Action_P1 = 1;}//Prossimo attacco
        else if(currentHealth <= 2500 && Action_P3 == 0){Action_P3 = 1;}//Prossimo attacco

    }
    //////////////////////////////////////////////////////////////////////////
    private void Shoot()
        {
            if(!DM.inputCTR){
            if (player != null)
            {
                if(!isAttacking)
                {

                }   
            }}
            else if(DM.inputCTR && !DieB && currentHealth > 3500){Anm.PlayAnimationLoop(IdleP1AnimationName);}
            else if(DM.inputCTR && !DieB && currentHealth <= 2500){Anm.PlayAnimationLoop(IdleP3AnimationName);}
        }
    private void Bomba()
        {
            if(!DM.inputCTR){
            if (player != null)
            {
                if(!isAttacking)
                {
                    
                }   
            }}
            
        }
    private void Bombing()
        {
            if(!DM.inputCTR){
            if (player != null)
            {
                if(!isAttacking)
                {
                     // Genera una direzione casuale sulla superficie di una sfera
                    //Vector3 randomDirection = Random.onUnitSphere;

                    // Moltiplica la direzione per ottenere una posizione casuale
                    //Vector3 randomPosition = transform.position + randomDirection * randomRadius;

                    // Lauch bomb
                    Instantiate(Bullets, transform.position, transform.rotation);
                }   
            }}
            
        }

    //////////////////////////////////////////////////////////////////////////
    private void CanHurt()
        {
            if(!DM.inputCTR){
            if (player != null)
            {
                 //La barriera si dissolve per un tot di tempo
                 StartCoroutine(VulnerableTime());
                 VFX_Barier.SetActive(false);
            }}
        }
    private IEnumerator VulnerableTime()
    {        
        Action_P2 = 1;
        yield return new WaitForSeconds(5); 
        Action_P2 = 0;
        VFX_Barier.SetActive(true);
        take = false;
        isAttacking = false;

    }
    //////////////////////////////////////////////////////////////////////////
    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("F_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack); ChoseFork();}} 
        else if (collision.gameObject.CompareTag("F_Stump"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack); ChoseFork();}} 
        else if (collision.gameObject.CompareTag("K_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.K_attack); ChoseKnife();}}
        else if (collision.gameObject.CompareTag("K_Stump"))
        {if(!DieB){TakeDamage(PlayerStats.instance.K_attack); ChoseKnife(); StunProbability += StunProbabilityCount;}}
        else if (collision.gameObject.CompareTag("S_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.S_attack); ChoseSpoon();}}
         else if (collision.gameObject.CompareTag("S_Stump"))
        {if(!DieB){TakeDamage(PlayerStats.instance.S_attack); ChoseSpoon();}}
        else if (collision.gameObject.CompareTag("Spell"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack + Bullet.instance.damage); ChoseFork();}} 
        else if (collision.gameObject.CompareTag("Bomb"))
        {if(!DieB){TakeDamage(Bomb.instance.damage);}}
    }
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Rage"))
        {if(!DieB)
        {currentHealth -= DamageColl.instance.damage;
        Debug.Log("danno +"+ currentHealth);
        Instantiate(VFXHurt, transform.position, transform.rotation);
        Anm.TemporaryChangeColor(Color.red);
        }} 
         if (collision.gameObject.CompareTag("Poison_P"))
        {if(poisonResistance > 0)
        {poisonResistance--;
        }else if(poisonResistance <= 0){Poison();}
        } 
    }
    //////////////////////////////////////////////////////////////////////////
    public void TakeDamage(float damage)
    {
    if(!DieB){
    float danno_subito = Mathf.Max(damage - defense, 0);
    currentHealth -= danno_subito;
    AudioManager.instance.PlaySFX(8);
    //Debug.Log("danno +"+ danno_subito);
    Instantiate(VFXHurt, transform.position, transform.rotation);
    Anm.TemporaryChangeColor(Color.red);}
    }
    //////////////////////////////////////////////////////////////////////////
    #region  Stun
    public void Stun()
    {
        if (!isStun && !DieB)
        {
            isStun = true;
            VFXStun.SetActive(true);
            AudioManager.instance.PlayUFX(11);
            Anm.ClearAnm();
            StartCoroutine(StunTime());
        }if (!isStun && DieB)
        {
            VFXStun.SetActive(false);
            StunProbability = 0;
            StunProbabilityCount = 0;
            Die();
        }
    }

    private IEnumerator StunTime()
    {
        if (!DieB)
        {
        Anm.PlayAnimationLoop(StunStartAnimationName);
        yield return new WaitForSeconds(0.5f);
        Anm.PlayAnimationLoop(StunAnimationName);
        yield return new WaitForSeconds(StunTimer);
        Anm.PlayAnimationLoop(StunEndAnimationName);
        yield return new WaitForSeconds(0.5f);
        VFXStun.SetActive(false);
        isStun = false; // Reimposta la flag dopo la fine dello stordimento
        StunProbability = 0;
        StunProbabilityCount = 0;
        //Action = 0;
        }
        }
    
    #endregion

    #region Stato StunFlash

    public void StunFlash()
    {
        if (!isStun && !DieB)
        {
            isStun = true;
            VFXStun.SetActive(true);
            AudioManager.instance.PlayUFX(11);
            Anm.ClearAnm();
            StartCoroutine(StunFlashTime());
        }if (!isStun && DieB)
        {
            VFXStun.SetActive(false);
            StunProbability = 0;
            StunProbabilityCount = 0;
            Die();
        }
    }

    private IEnumerator StunFlashTime()
    {
    if (!DieB)
    {
    yield return new WaitForSeconds(StunTimer);
    Anm.PlayAnimationLoop(StunFlashAnimationName);
    yield return new WaitForSeconds(0.5f);
    VFXStun.SetActive(false);
    isStun = false; // Reimposta la flag dopo la fine dello stordimento
    StunProbability = 0;
    StunProbabilityCount = 0;
    //Action = 0;
    }
    }
    
    #endregion

    #region Stato Sleep

    public void Sleep()
{
    if (!isSleep && !DieB)
    {
        isSleep = true;
        VFXSleep.SetActive(true);
        AudioManager.instance.PlayUFX(11);
        Anm.ClearAnm();
        StartCoroutine(SleepTime());
    }if (!isSleep && DieB)
    {
        VFXSleep.SetActive(false);
        SleepProbability = 0;
        SleepProbabilityCount = 0;
        Die();
    }
}

    private IEnumerator SleepTime()
    {
    if (!DieB)
    {
    yield return new WaitForSeconds(5);
    Anm.PlayAnimationLoop(SleepAnimationName);
    yield return new WaitForSeconds(0.5f);
    VFXSleep.SetActive(false);
    isSleep = false; // Reimposta la flag dopo la fine dello stordimento
    SleepProbability = 0;
    SleepProbabilityCount = 0;
    //Action = 0;
    }
    }
    
    #endregion
    
    #region Stato Veleno
    public void Poison(){Anm.ChangeColorP(); VFXPoison.SetActive(true);}// poisonState = true;} 
    private IEnumerator Poi()
    {
        yield return new WaitForSeconds(TimePoison);
        poisonResistance = poisonResistanceCont; 
        //poisonState = false;
    }
    #endregion
    //////////////////////////////////////////////////////////////////////////
    public void PreDie(){Anm.ClearAnm(); Anm.PlayAnimationLoop(PredieAnimationName);}
    public void Die()
    {
        //Debug.Log("Il nemico è morto!");
        Instantiate(VFXDie, transform.position, transform.rotation);
        //VFXStun.SetActive(false);
        AudioManager.instance.PlayUFX(11);
        DM.EnemyinArena -= 1;
        Anm.ClearAnm();
        Anm.PlayAnimationLoop(PredieAnimationName);
        Icon.SetActive(false);
        StartCoroutine(DieTime());
        //DeathANM.enabled = true; 
        //This.enabled = false;
    }
    private IEnumerator DieTime()
    {
    Anm.PlayAnimationLoop(DieAnimationName);
    yield return new WaitForSeconds(2f);
    Destroy(gameObject);
    }   
    
    #if(UNITY_EDITOR)
    #region Gizmos
    private void OnDrawGizmos()
        {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    #endregion
    #endif
}