using System.Collections;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class ForkSemple : MonoBehaviour
{
   //public int ID;
    [Header("Change Script")]
    public ForkSemple This;

    [Header("Stop For Test")]
    public GameObject player;
    public GameObject Icon;
    public GameObject IconVFX;
     
    private bool take = false; 
    [Header("Hp")]
    public float maxHealth = 100f;
    public float currentHealth;
    public Scrollbar healthBar;
    //public GameObject Stats;
    //public float SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [Header("Status")]
    public float damagePerSecond = 0.1f;
    public float duration = 5.0f;
    private float elapsedTime = 0.0f;
    private bool isDamaging = false;
    public GameObject VFXPoison;
    //private bool poisonState = false;
    public int poisonResistance = 100;
    public int poisonResistanceCont;
    private int TimePoison = 5;   

    [Header("Stun")]
   
    public GameObject VFXStun;
    public bool isStun = false;
    public int StunProbability = 0;
    public int StunProbabilityCount = 2;
    public int StunProbabilityMAX = 10;
    public int result;
    public int timeStun = 3; 
    public int StunTimer = 5;

    [Header("Sleep")]

    public GameObject VFXSleep;
    public bool isSleep = false;
    public int SleepProbability = 0;
    public int SleepProbabilityCount = 2;
    public int SleepProbabilityMAX = 10;
    public int timeSleep = 3;

    [Header("Move")]
    public int WaitAtk = 3;
    public float moveSpeed = 3f;
    public float PointTange = 1f;
    public int defense = 2;
    public int attackPauseDuration = 1;
    public GameObject P1, P2, P3; 
    private bool isAttacking = false;   
    public bool DieB = false;
    public DuelManager DM;
    public int Action = 0;

    public static ForkSemple instance;
    [Header("VFX")]
    [SerializeField] public Transform hitpoint;
    [SerializeField] GameObject VFXHurt;    
    [SerializeField] GameObject VFXDie;
    [Header("Animations")]
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    [SpineAnimation][SerializeField] private string WalkAnimationName;
    [SpineAnimation][SerializeField] private string RunAnimationName;
    [SpineAnimation][SerializeField] private string Atk1AnimationName;
    [SpineAnimation][SerializeField] private string DieAnimationName;
     [SpineAnimation][SerializeField] private string StunStartAnimationName;
    [SpineAnimation][SerializeField] private string StunAnimationName;
    [SpineAnimation][SerializeField] private string StunEndAnimationName;
    [SpineAnimation][SerializeField] private string StunFlashAnimationName;
    [SpineAnimation][SerializeField] private string SleepAnimationName;
    public AnimationManager Anm;
    
    public void Awake()
    {
        if (instance == null){instance = this;}
        currentHealth = maxHealth;
        poisonResistanceCont = poisonResistance;
        DM.EnemyinArena += 1;
    }
    private void Choise()
    {
        // Genera un numero casuale tra 1 e 3
        if(GameManager.instance.F_Unlock &&
        GameManager.instance.S_Unlock &&
        GameManager.instance.K_Unlock){
        int randomNumber = Random.Range(0, 2);
        result = Mathf.RoundToInt(randomNumber);} 
        else if(GameManager.instance.F_Unlock &&
        !GameManager.instance.S_Unlock &&
        !GameManager.instance.K_Unlock){
        result = 0;}
        //Debug.Log("Numero casuale: " + result);
        //Debug.Log(ID + "ha Preso" + result);
        switch(result)
        {
            case 0:
            if(GameManager.instance.F_Unlock){player = GameManager.instance.F_Hero;}
            else if(!GameManager.instance.F_Unlock){Choise();}
            break;
            case 1:
            if(GameManager.instance.K_Unlock){player =  GameManager.instance.K_Hero;}
            else if(!GameManager.instance.K_Unlock){Choise();}
            break;
            case 2:
            if(GameManager.instance.S_Unlock){player =  GameManager.instance.S_Hero;}
            else if(!GameManager.instance.S_Unlock){Choise();}
            break;
        } 
    }
    

    public void Update()
    {
        if(!DieB){
        if(!DM.inputCTR){ 
        if (player == null && !take){Choise(); take = true; }
        healthBar.size = currentHealth / maxHealth;
        healthBar.size = Mathf.Clamp(healthBar.size, 0.01f, 1);
        switch(Action)
        {
            case 0:
            FacePlayer(); if(!isAttacking){ChasePlayer();}
            break;
            case 1:
            Stun();
            break;
            case 2:
            DieB = true; IconVFX.SetActive(true); Die();
            break;
       }
       }
        else if(DM.inputCTR){Anm.PlayAnimationLoop(IdleAnimationName);}
        if(currentHealth < 0){Action = 2;}
        ////////////////////////
        if (isDamaging)
        {
            elapsedTime += Time.deltaTime;
            currentHealth -= damagePerSecond;
            if (elapsedTime >= duration)
            {
                // Il periodo di danno è terminato
                isDamaging = false;
            }
        }
        if(StunProbability >= StunProbabilityMAX)
        {Action = 1;}
       
    }
    }
    


    private void ChasePlayer()
    {
        if(!DM.inputCTR){
        if (player != null)
        {
            if(!isAttacking)
            {
               
                switch(result)
        {
            case 0:
            transform.position = Vector3.MoveTowards(transform.position, P1.transform.position, moveSpeed * Time.deltaTime);
            break;
            case 1:
            transform.position = Vector3.MoveTowards(transform.position, P2.transform.position, moveSpeed * Time.deltaTime);
            break;
            case 2:
            transform.position = Vector3.MoveTowards(transform.position, P3.transform.position, moveSpeed * Time.deltaTime);
            break;
        } 

                
            if(!DieB){Anm.PlayAnimationLoop(RunAnimationName);}}
            if (Vector3.Distance(transform.position, P1.transform.position) <= PointTange ||
            Vector3.Distance(transform.position, P2.transform.position) <= PointTange ||
            Vector3.Distance(transform.position, P3.transform.position) <= PointTange)
            {StartAttack();}
        }}else if(DM.inputCTR){Anm.PlayAnimationLoop(IdleAnimationName);}
    }
    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("F_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack);}} 
        else if (collision.gameObject.CompareTag("F_Stump"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack);}}
        else if (collision.gameObject.CompareTag("K_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.K_attack);}}
        else if (collision.gameObject.CompareTag("K_Stump"))
        {if(!DieB){TakeDamage(PlayerStats.instance.K_attack); StunProbability += StunProbabilityCount;}}
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
    #region Stato Veleno
    public void Poison(){Anm.ChangeColor(); VFXPoison.SetActive(true);}// poisonState = true;} 
    private IEnumerator Poi()
    {
        yield return new WaitForSeconds(TimePoison);
        poisonResistance = poisonResistanceCont; 
        //poisonState = false;
    }
    #endregion
    private void StartAttack()
    {
        isAttacking = true;
        FacePlayer();
        Anm.PlayAnimation(Atk1AnimationName);
        //Debug.Log("Attacco!");
        StartCoroutine(AttackPause());
    }

    private IEnumerator AttackPause()
    {        
        yield return new WaitForSeconds(WaitAtk);
        if(!DieB){Anm.PlayAnimationLoop(IdleAnimationName);}
        yield return new WaitForSeconds(attackPauseDuration);
        take = false;
        isAttacking = false;
    }

    public void TakeDamage(float damage)
    {
    if(!DieB){
    float danno_subito = Mathf.Max(damage - defense, 0);
    currentHealth -= danno_subito;
    AudioManager.instance.PlaySFX(8);
    Debug.Log("danno +"+ danno_subito);
    Instantiate(VFXHurt, transform.position, transform.rotation);
    Anm.TemporaryChangeColor(Color.red);}
    }
    
    public void FacePlayer()
    {
    if (player.transform.position.z > transform.position.z){transform.localScale = new Vector3(1, 1, 1);}
    else if (player.transform.position.z < transform.position.z){transform.localScale = new Vector3(-1, 1, 1);}  
    }
    
    #region Stato Stun

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
    Action = 0;
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
    Action = 0;
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
    Action = 0;
    }
    }
    
    #endregion
     public void Die()
    {
        //Debug.Log("Il nemico è morto!");
        Instantiate(VFXDie, transform.position, transform.rotation);
        VFXStun.SetActive(false);
        AudioManager.instance.PlayUFX(11);
        //Stats.gameObject.SetActive(false);
        DM.EnemyinArena -= 1;
        Anm.ClearAnm();
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
        Gizmos.DrawWireSphere(transform.position, PointTange);
        }
    #endregion
    #endif
}
