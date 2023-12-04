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
    public Transform target;
    public GameObject TargetLaserOBJ;
    public GameObject LaserOBJ;
    bool Start_Laser = false;
    bool isLaser = false;
    bool  LaserAnimation = true;
    bool  LaserAnimationStop = true;
    public float TimeLaser = 5f;
    public GameObject objectToSpawn;
    public float spawnRadius = 5f;
    bool Bomb_1,Bomb_2,Bomb_3,Bomb_4,Bomb_5,Bomb_6 = true;
    [Tooltip("Il tempo dedicato all'attacco")]
    public int WaitAtk = 1;
    [Tooltip("Il tempo che deve aspettare per il prossimo attacco")]
    public int attackPauseDuration = 1;
    public float attackRange = 1.5f;
    public int defense = 2;
    private bool isAttacking = false;   
    /////////////////////////////////////////////////////////////////////////////////
    [Header("Actions")]
    public int PhaseM,Action_P1,Action_P2,Action_P3 = 0;
    private bool Lock_P2,Lock_P3 = false;
    private bool Lock_P1 = true;
    bool isMoving, isWalk = false;
    private float lerpTime = 2f; //Tempo interpolazione
    bool Right = true;
    public float stoppingDistance = 1f;
    private int currentWaypointIndex = 0; // Indice del punto attuale
    public Transform[] waypoints; // Array di punti verso cui muoversi
    public bool isPaused = false; // Flag per indicare se è in pausa
    private float pauseTimer = 0f; // Timer per il conteggio della pausa
    private float pauseTime = 2f; // Tempo di pausa in secondi quando raggiunge un punto
    private float previousZPosition; // Aggiungi questa variabile
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
    string AN;
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
    [SpineAnimation][SerializeField] private string StartP3AnimationName;
    [SpineAnimation][SerializeField] private string ShootStartAnimationName;
    [SpineAnimation][SerializeField] private string ShootLoopAnimationName;
    [SpineAnimation][SerializeField] private string ShootEndAnimationName;
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
        Phase_Master();
        healthBar.size = currentHealth / maxHealth;
        healthBar.size = Mathf.Clamp(healthBar.size, 0.01f, 1);
        if (currentHealth > 3500 && !DieB)
        {
            // Fase 1
            PhaseM = 0;
            //Lock_P1 = true;Lock_P2 = false;Lock_P3 = false;
        }
        else if (currentHealth <= 3500 && currentHealth > 2500)
        {
            // Fase 2
            if(Lock_P2){Action_P1 = 2;}else if(!Lock_P2){PhaseM = 1;}
            //Lock_P1 = false;Lock_P2 = true;Lock_P3 = false;
        }
        else if (currentHealth <= 2500 && currentHealth < 3500)
        {
            // Fase 3
            if(Lock_P3){Action_P2 = 3;}else if(!Lock_P3){PhaseM = 2;}
        }
        else if (currentHealth <= 0)
        {
            // Morte
            DieB = true; IconVFX.SetActive(true); Die();
        }
    }}}
    /////////////////////////////////////////////////////////////////////////////////
    ///For Test
    public void Fase2(){currentHealth = 3499;}public void Fase3(){currentHealth = 2499;}
    ////////////////////////////////////////////////////////////////////////////////////
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
            moveSpeed *= 2;
            if (!isPaused)
            {
                MoveToWaypoint();
                Flip();
                isWalk = true;
            }
            else
            {
                PauseAtWaypoint();
                isWalk = false;
                Flip();
            }
            break;
            case 1:
            // Fase 1
            if(!isAttacking){FacePlayer();Shoot();}
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
        yield return new WaitForSeconds(10);
        VFX_Barier.SetActive(true);
        Lock_P2 = false;
        Action_P2 = 0;
        }
    //////////////////////////////////////////////////////////////////////////
    private void StartP3()
    {if(!DM.inputCTR){Anm.ClearAnm();Anm.PlayAnimation(StartP3AnimationName);StartCoroutine(StartP3_Time());}}
    private IEnumerator StartP3_Time()
    {            
        yield return new WaitForSeconds(5);
        VFX_Barier.SetActive(true);
        Action_P3 = 0;
    }
    //////////////////////////////////////////////////////////////////////////
    public void ResetBool()
    {
        Anm.ClearAnm();
        pauseTimer = 0f;
        Start_Laser = false;
        isLaser = false;
        LaserAnimation = true;
        LaserAnimationStop = true;
        isAttacking = false;
    }
    //////////////////////////////////////////////////////////////////////////
    private void MoveToWaypoint()
{
    float currentZPosition = transform.position.z;
     if(GameManager.instance.activeMinimap){GameManager.instance.AllarmMap.SetActive(false);}

    if (waypoints.Length > 1 && currentWaypointIndex < waypoints.Length - 1)
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex + 1].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // Verifica se il personaggio è vicino al punto di destinazione
        if (Vector3.Distance(transform.position, targetPosition) < stoppingDistance)
        {
            isPaused = true;
            Action_P3 = 1;
            transform.localScale = new Vector3(-1, 1,1);
            previousZPosition = currentZPosition;
        }
    }
    else if (currentWaypointIndex == waypoints.Length - 1)
    {
        Vector3 initialPosition = waypoints[0].position;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

        // Verifica se il personaggio è vicino al punto di destinazione
        if (Vector3.Distance(transform.position, initialPosition) < stoppingDistance)
        {
            isPaused = true;
            Action_P3 = 1;
            transform.localScale = new Vector3(1, 1,1);

            // Incrementa l'indice del waypoint o torna al punto 0 se siamo all'ultimo
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            previousZPosition = currentZPosition;
        }
    }
}
    private void PauseAtWaypoint()
    {
        if (pauseTimer < pauseTime){pauseTimer += Time.deltaTime;}
        else{isPaused = false; currentWaypointIndex++;}
    }
    private void Flip()
    {
        if (Right && transform.localScale.z < 0f || !Right && transform.localScale.z > 0f)
        {
            Right = !Right;
            Vector3 localScale = transform.localScale;
            localScale.z *= -1f;
            transform.localScale = localScale;
        }
    }
    //////////////////////////////////////////////////////////////////////////  
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
        isAttacking = true;
        Anm.PlayAnimation(Atk1AnimationName);
        StartCoroutine(AttackPause());
    }
    private IEnumerator AttackPause()
    {        
        yield return new WaitForSeconds(WaitAtk);        
        Anm.PlayAnimationLoop(IdleP1AnimationName);
        yield return new WaitForSeconds(attackPauseDuration);
        if (Action_P1 == 0){Choise();ResetBool();Action_P1 = 1;}

    }
    /////////////////////////////////////////////////////////////////////////////
   private void Shoot()
{
    if (!DM.inputCTR && player != null)
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
            isAttacking = true;
            Anm.PlayAnimationLoop(ShootLoopAnimationName);
            StartCoroutine(StopShooting());
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
    }
    yield return new WaitForSeconds(attackPauseDuration);
    if (Action_P1 == 1){Choise();ResetBool();Action_P1 = 0;}
}

    /////////////////////////////////////////////////////////////////////////////
    private void Bombing()
        {
            if(!DM.inputCTR){
            if (player != null)
            {
                if(!isAttacking)
                {
                    if(Bomb_1){SpawnObjectInRandomPosition(); Bomb_1 = false;}
                    if(Bomb_2){SpawnObjectInRandomPosition(); Bomb_2 = false;}
                    if(Bomb_3){SpawnObjectInRandomPosition(); Bomb_3 = false;}
                    if(Bomb_4){SpawnObjectInRandomPosition(); Bomb_4 = false;}
                    if(Bomb_5){SpawnObjectInRandomPosition(); Bomb_5 = false;}
                    if(Bomb_6){SpawnObjectInRandomPosition(); Bomb_6 = false;}
                    StartCoroutine(BombingTime());
                }   
            }}
            else if(DM.inputCTR && !DieB && currentHealth > 3500){Anm.PlayAnimationLoop(IdleP1AnimationName);}
            else if(DM.inputCTR && !DieB && currentHealth <= 2500){Anm.PlayAnimationLoop(IdleP3AnimationName);}
            
        }
    public void SpawnObjectInRandomPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) + transform.position;
        Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
    }
    private IEnumerator BombingTime()
    {        
        yield return new WaitForSeconds(5); 
        if(DM.inputCTR && !DieB && currentHealth > 3500){Action_P2 = 2;}
        else if(DM.inputCTR && !DieB && currentHealth <= 2500){Action_P3 = 0;}
        VFX_Barier.SetActive(true);
        Choise();
        take = false;
        isAttacking = false;

    }
    private void Wait()
    {
        Anm.PlayAnimationLoop(IdleP2AnimationName);
        Bomb_1 = true; Bomb_2 = true; Bomb_3 = true; Bomb_4 = true; Bomb_5 = true; Bomb_6 = true; 
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    #endregion
    #endif
}