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
    public int TimeRush = 20;
    public Transform[] waypoints;
    public float speed = 2.0f;
    
    private int currentWaypointIndex = 0;
    [Header("Attack")]
    public Transform target;
    public GameObject TargetLaserOBJ;
    public GameObject LaserOBJ;
    bool Start_Laser = false;
    bool isLaser = false;
    bool  LaserAnimation = true;
    bool  LaserAnimationStop = true;
    public float TimeLaser = 5f;
    public GameObject objectToSpawn;
    public GameObject objectToSpawn_3;
    public float spawnRadius = 5f;
    bool Bomb_1 = true;
    /*bool Bomb_2 = true;
    bool Bomb_3 = true;
    bool Bomb_4 = true;
    bool Bomb_5 = true;
    bool Bomb_6 = true;*/
    [Tooltip("Il tempo dedicato all'attacco")]
    public int WaitAtk = 1;
    [Tooltip("Il tempo che deve aspettare per il prossimo attacco")]
    public int attackPauseDuration = 1;
    public float attackRange = 1.5f;
    public int defense = 2;
    private bool isAttacking = false;   
    /////////////////////////////////////////////////////////////////////////////////
    [Header("Actions")]
    public GameObject[] Cristals;
    public int CurrentCrystal = 0;
    [HideInInspector] public int MaxCrystal = 5;
    public float TouchDistance = 1f;
    public int PhaseM,Action_P1,Action_P2,Action_P3 = 0;

    private bool Lock_P2 = false;
    private bool Lock_P3 = false;
    private bool P_2 = false;
    private bool isRaffica = false;
    private bool isMove = false;
    private bool isRafficaRunning = false;
    private bool isMoveRunning = false;
    private bool P_3 = false;
    bool StartP2Anm,EndP2Anm = true;
    bool StartP3Anm,EndP3Anm = true;
    bool Right = true;
    private float pauseTimer = 0f; // Timer per il conteggio della pausa
    /////////////////////////////////////////////////////////////////////////////////
    [Header("Status")]
    //public float damagePerSecond = 0.1f;
    //public float duration = 5.0f;
    //private float elapsedTime = 0.0f;
    //private bool isDamaging = false;   
    [Header("Poison")]
    public GameObject VFXPoison;
    public int poisonResistance = 100;
    public int poisonResistanceCont;
    private int TimePoison = 5;   
    /*[Header("Stun")]
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
    public int timeSleep = 3;*/
    /////////////////////////////////////////////////////////////////////////////////
    [Header("VFX")]
    [SerializeField] GameObject VFX_Barier;
    [SerializeField] GameObject VFX_Blam;
    //[SerializeField] Transform hitpoint;
    [SerializeField] GameObject CenterPoint;
    [SerializeField] GameObject CenterPointTop;
    [SerializeField] GameObject TopArena;
    [SerializeField] GameObject VFXHurt;    
    [SerializeField] GameObject VFXDie;

    [Header("Animations")]
    [SpineAnimation][SerializeField] private string IdleP1AnimationName;
    [SpineAnimation][SerializeField] private string IdleP2AnimationName;
    [SpineAnimation][SerializeField] private string IdleP3AnimationName;
    [SpineAnimation][SerializeField] private string WalkAnimationName;
    //[SpineAnimation][SerializeField] private string RunAnimationName;
    [SpineAnimation][SerializeField] private string Atk1AnimationName;
    //[SpineAnimation][SerializeField] private string Atk2AnimationName;
    [SpineAnimation][SerializeField] private string Atk3AnimationName;
    //[SpineAnimation][SerializeField] private string StunStartAnimationName;
    //[SpineAnimation][SerializeField] private string StunAnimationName;
    //[SpineAnimation][SerializeField] private string StunEndAnimationName;
    //[SpineAnimation][SerializeField] private string StunFlashAnimationName;
    //[SpineAnimation][SerializeField] private string SleepAnimationName;
    [SpineAnimation][SerializeField] private string StartP2AnimationName;
     [SpineAnimation][SerializeField] private string EndP2AnimationName;
    [SpineAnimation][SerializeField] private string StartP3AnimationName;
    [SpineAnimation][SerializeField] private string ShootStartAnimationName;
    [SpineAnimation][SerializeField] private string ShootLoopAnimationName;
    [SpineAnimation][SerializeField] private string ShootEndAnimationName;
    [SpineAnimation][SerializeField] private string BombingP2AnimationName;
    [SpineAnimation][SerializeField] private string BombingP3AnimationName;
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
        CurrentCrystal = MaxCrystal;
    }
    
    /////////////////////////////////////////////////////////////////////////////////
    public void SpawnObjectInRandomPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPoint.x, 1f, randomPoint.y) + transform.position;
        Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
    }
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
        //State Machines
        if (currentHealth > 3500 && !DieB && !P_2 && !P_3){PhaseM = 0;}
        //
        else if (currentHealth <= 3500 && !P_2){P_2 = true;}
        //
        else if (currentHealth <= 2000 && !P_3){P_3 = true;}
        //
        else if (currentHealth <= 0){DieB = true;}
        //
        if(P_2){if(!Lock_P2){Action_P1 = 2;}else if(Lock_P2){PhaseM = 1;}if(CurrentCrystal == 0){Action_P2 = 1;}}
        //
        if(P_3){if(!Lock_P3){Action_P2 = 3;}else if(Lock_P3){PhaseM = 2;}if(CurrentCrystal == 0){Action_P3 = 3;}}
        //
        if(DieB){Action_P3 = 4; IconVFX.SetActive(true); PreDie();}
        //
        if(isMove){moveSpeed = 20f; 
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        float distanceToTarget = Vector3.Distance(transform.position, targetWaypoint.transform.position);
        Anm.PlayAnimationLoop(IdleP3AnimationName);
        if (distanceToTarget > TouchDistance)
        {
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);
        }
        else if(distanceToTarget < TouchDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        StartCoroutine(StopMoving());}
        
        
    }}}
    /////////////////////////////////////////////////////////////////////////////////
    ///For Test
    public void Fase2(){currentHealth = 3499;}public void Fase3(){currentHealth = 1999;} public void Fase_Die(){currentHealth = 0;}
    ////////////////////////////////////////////////////////////////////////////////////
    public void FixedUpdate(){Phase_Master();}
    public void Phase_Master()
    {
        switch (PhaseM)
        {
            case 0:
            // Fase 0
            Phase_1Move();
            break;
            case 1:
            // Fase 1
            Phase_2Move();
            break;
            case 2:
            // Fase 2
            Phase_3Move();
            break;
            case 3:
            // Fase 2
            Die();
            break;
            default:
            // Altre fasi o gestione degli errori
            break;

        }
    }
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
            if(!isAttacking){Shoot();}
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
            Wait();
            break;
            case 3:
            // Fase 2
            VFX_Barier.SetActive(false);
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
            if (!isAttacking)
            {FacePlayer();Raffica(); VFX_Blam.SetActive(false);}
            break;
        case 1:
            MovingPoints(); VFX_Blam.SetActive(true); 
            break;
        case 2:
            // Puoi inserire qui la logica per la terza azione
            break;
        case 3:
            CanHurt_3();
            break;
        case 4:
            PreDie();
            break;
        default:
            break;
    }
}
    //////////////////////////////////////////////////////////////////////////
    private void StartP2()
        {
        if(!DM.inputCTR)
        {
        if(EndP2Anm){
        float distanceToTarget = Vector3.Distance(transform.position, CenterPoint.transform.position);
        moveSpeed = 10f; TargetLaserOBJ.SetActive(false);LaserOBJ.SetActive(false);
        if(StartP2Anm){Anm.ClearAnm(); Anm.PlayAnimationLoop(StartP2AnimationName); StartP2Anm = false;}
        if (distanceToTarget > TouchDistance)
        {
        transform.position = Vector3.MoveTowards(transform.position, CenterPoint.transform.position, moveSpeed * Time.deltaTime);
        }
        else if(distanceToTarget < TouchDistance)
        {Anm.ClearAnm(); StartCoroutine(MoveTowardsCenterPoint());}
        }}
        }
    private IEnumerator MoveTowardsCenterPoint()
        {
        EndP2Anm = false;
        Anm.PlayAnimationStop(EndP2AnimationName);
        yield return new WaitForSeconds(1);
        VFX_Barier.SetActive(true); VFX_Barier.transform.position = transform.position;
        yield return new WaitForSeconds(1);
        ResetBool(); Anm.PlayAnimationLoop(IdleP2AnimationName); 
        foreach (GameObject arenaObject in Cristals){arenaObject.SetActive(true);}
        Action_P2 = 0; isAttacking = false; Lock_P2 = true;
        
        }
    //////////////////////////////////////////////////////////////////////////
    private void StartP3()
     {
        if(!DM.inputCTR)
        {
        if(EndP3Anm){
        float distanceToTarget = Vector3.Distance(transform.position, CenterPoint.transform.position);
        moveSpeed = 5; 
        if(StartP3Anm)
        {VFX_Barier.SetActive(false); 
        foreach (GameObject arenaObject in Cristals){arenaObject.SetActive(false);}
        StartP3Anm = false;}
        if (distanceToTarget > TouchDistance)
        {
        transform.position = Vector3.MoveTowards(transform.position, CenterPoint.transform.position, moveSpeed * Time.deltaTime);
        }
        else if(distanceToTarget < TouchDistance)
        {  StartCoroutine(StartP3_Time());}
        }}
        }
    private IEnumerator StartP3_Time()
    {            
        EndP3Anm = false;
        Anm.PlayAnimationStop(StartP3AnimationName);
        yield return new WaitForSeconds(2);
        ResetBool(); Anm.PlayAnimationLoop(IdleP3AnimationName); VFX_Blam.SetActive(true);
        foreach (GameObject arenaObject in Cristals){arenaObject.SetActive(true);}
        Action_P3 = 0; isAttacking = false; Lock_P3 = true;
        yield break;
    }
    //////////////////////////////////////////////////////////////////////////
    public void ResetBool()
    {
        Anm.ClearAnm();pauseTimer = 0f; Start_Laser = false;
        isLaser = false; LaserAnimation = true; LaserAnimationStop = true;
        isAttacking = false;isRaffica = false; isMove = false;
    }
    //////////////////////////////////////////////////////////////////////////
    ///Fase_1 
    #region Fase_1        
    private void ChasePlayer()
        {
            if(!DM.inputCTR){
            if (player != null)
            {
            if(!isAttacking)
            {transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            Anm.PlayAnimationLoop(WalkAnimationName);}
            if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {StartAttack();}
            }}
        }
    private void StartAttack()
    {
        isAttacking = true;  print("F1_Atk1");
        Anm.PlayAnimation(Atk1AnimationName);
        StartCoroutine(AttackPause());
    }
    private IEnumerator AttackPause()
    {        
        yield return new WaitForSeconds(WaitAtk);        
        Anm.PlayAnimationLoop(IdleP1AnimationName);
        yield return new WaitForSeconds(attackPauseDuration);
        if (Action_P1 == 0){Choise();ResetBool();Action_P1 = 1;}
        yield break;
    }
    //----//
    private void Shoot()
{
    if (!DM.inputCTR && player != null)
    {
        //Creare la possibilità al boss di spostarsi i un punto e poi sparare il laser per evitare compenetrazioni strane
        float distanceToTarget = Vector3.Distance(transform.position, TopArena.transform.position);
        moveSpeed = 10; TargetLaserOBJ.SetActive(false);LaserOBJ.SetActive(false);
        Anm.PlayAnimationLoop(WalkAnimationName); 
        if (distanceToTarget > TouchDistance)
        {
        transform.position = Vector3.MoveTowards(transform.position, TopArena.transform.position, moveSpeed * Time.deltaTime);
        }
        else if(distanceToTarget < TouchDistance)
        {
            if (!isLaser)
        {
            if (LaserAnimation)
            {
                Anm.PlayAnimationStop(ShootStartAnimationName);
                LaserAnimation = false;
            }
            StartCoroutine(StartShooting());
        }
        else if (target != null && Start_Laser)
        {
            isAttacking = true; print("F1_Atk2");
            Anm.PlayAnimationLoop(ShootLoopAnimationName);
            StartCoroutine(StopShooting());
        }
        }
        
    }
}
    private IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(2); // Il tempo per attivare il Laser

        TargetLaserOBJ.SetActive(true);
        LaserOBJ.SetActive(true);
        Start_Laser = true;
        isLaser = true;
        yield break;
    }
    private IEnumerator StopShooting()
    {
    yield return new WaitForSeconds(TimeLaser); // Il tempo per disattivare il Laser

    TargetLaserOBJ.SetActive(false);
    LaserOBJ.SetActive(false);
    if (LaserAnimationStop)
    {
        Anm.PlayAnimationStop(ShootEndAnimationName);
        yield return new WaitForSeconds(0.4f);
        LaserAnimationStop = false;
        moveSpeed = 3f;
    }
    yield return new WaitForSeconds(attackPauseDuration);
    if (Action_P1 == 1){Choise();ResetBool();Action_P1 = 0;}
     yield break;
    }    
    #endregion
    /////////////////////////////////////////////////////////////////////////////
    ///Fase_2
    #region  Fase_2
    private void Bombing()
        {
            if(!DM.inputCTR){
                if(!isAttacking)
                {
                    Anm.PlayAnimationStop(BombingP2AnimationName);
                    if(Bomb_1){Bomb_1 = false;SpawnObjectInRandomPosition();}
                    StartCoroutine(BombingTime()); isAttacking = true;          
                }                       
            }
        }   
    private IEnumerator BombingTime()
    {        
        yield return new WaitForSeconds(2);
        Anm.PlayAnimationLoop(IdleP2AnimationName); 
        VFX_Barier.SetActive(true); VFX_Barier.transform.position = transform.position;
        yield return new WaitForSeconds(3);
        if (Action_P2 == 0){Choise();Action_P2 = 2;}
        //yield break;
    }
    private void Wait(){StartCoroutine(RestoreAtk());}
    private IEnumerator RestoreAtk()
    {        
        yield return new WaitForSeconds(1);
        Bomb_1 = true; isAttacking = false;
        yield return new WaitForSeconds(3);
        if (Action_P2 == 2){Action_P2 = 0;}
        yield break;
    }
    //----//
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
        yield return new WaitForSeconds(10); 
        foreach (GameObject arenaObject in Cristals){arenaObject.SetActive(true);}
        VFX_Barier.SetActive(true); VFX_Barier.transform.position = transform.position;
        CurrentCrystal = MaxCrystal;
        take = false; isAttacking = false;
        if (Action_P2 == 1){Choise();Action_P2 = 2;}
        yield break;
    }
    #endregion
    //////////////////////////////////////////////////////////////////////////
    //////Fase_3
    #region  Fase_3  
    private void Raffica()
        {
            if(!DM.inputCTR){
            if (player != null)
            {
            if(!isRaffica)
            {transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            Anm.PlayAnimationLoop(IdleP3AnimationName);}
            if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {RafficaAtk();}
            }}
        }
    private void RafficaAtk()
    {
        isRaffica = true; isAttacking = true; print("F3_Atk3");
        Anm.PlayAnimation(Atk3AnimationName);
        Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation);
        StartCoroutine(RafficaAtkPause());
    }
    private IEnumerator RafficaAtkPause()
    {        
        yield return new WaitForSeconds(WaitAtk);        
        Anm.PlayAnimationLoop(IdleP3AnimationName);
        yield return new WaitForSeconds(attackPauseDuration);
        if (Action_P3 == 0){Choise();ResetBool(); 
        isRaffica = false; isAttacking = false; Action_P3 = 1;}
        //yield break;
    }
    //----//
    private void MovingPoints()
    {
        // Muovi il GameObject verso il waypoint corrente
        if(!DM.inputCTR){isMove = true;}
    }
    private IEnumerator StopMoving()
    {        
        yield return new WaitForSeconds(TimeRush);
        print("F3_Atk2");
        if (Action_P3 == 1){Choise();VFX_Blam.SetActive(false); ResetBool(); 
        isRaffica = false; isAttacking = false; isMove = false; Action_P3 = 0;}
        //yield break;
    }
    //----//
    private void CanHurt_3()
        {
            if(!DM.inputCTR){
                //Creare la possibilità al boss di spostarsi i un punto e poi sparare il laser per evitare compenetrazioni strane
        float distanceToTarget = Vector3.Distance(transform.position, CenterPoint.transform.position);
        moveSpeed = 10; VFX_Blam.SetActive(false);
        Anm.PlayAnimationLoop(IdleP3AnimationName);
        if (distanceToTarget > TouchDistance)
        {
        transform.position = Vector3.MoveTowards(transform.position, CenterPoint.transform.position, moveSpeed * Time.deltaTime);
        }
        else if(distanceToTarget < TouchDistance)
        {StartCoroutine(VulnerableTime_3());VFX_Blam.SetActive(false);}
        }}
    private IEnumerator VulnerableTime_3()
    {        
        yield return new WaitForSeconds(10); 
        Action_P3 = 0;
        foreach (GameObject arenaObject in Cristals){arenaObject.SetActive(false);}
        VFX_Blam.SetActive(true);
        CurrentCrystal = MaxCrystal; isAttacking = false;
        if (Action_P3 == 3){Choise();ResetBool();Action_P3 = 0;}
         yield break;
    }
    //----//
   
    #endregion
    //////////////////////////////////////////////////////////////////////////
    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("F_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack);}} 
        else if (collision.gameObject.CompareTag("F_Stump"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack);}} 
        else if (collision.gameObject.CompareTag("K_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.K_attack);}}
        else if (collision.gameObject.CompareTag("K_Stump"))
        {if(!DieB){TakeDamage(PlayerStats.instance.K_attack);}}
        else if (collision.gameObject.CompareTag("S_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.S_attack);}}
         else if (collision.gameObject.CompareTag("S_Stump"))
        {if(!DieB){TakeDamage(PlayerStats.instance.S_attack);}}
        else if (collision.gameObject.CompareTag("Spell"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack + Bullet.instance.damage);}} 
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
    #region Stun
    /*public void Stun()
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
        }*/
    
    #endregion

    #region Stato StunFlash

    /*public void StunFlash()
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
    }*/
    
    #endregion

    #region Stato Sleep

/*    public void Sleep()
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
    }*/
    
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
    public void PreDie(){Anm.PlayAnimationLoop(PredieAnimationName);}
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
         Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, TouchDistance);
        }
    #endregion
    #endif
}