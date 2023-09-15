using System.Collections;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
public class SimpleEnemy : MonoBehaviour
{
    public int ID;
    [Header("Change Script")]
    public SimpleEnemy This;
    public DeathAnimation DeathANM;

    [Header("Stop For Test")]
    public GameObject player;
    public GameObject Icon;
    public GameObject IconVFX;
    public int result;
    public bool Test = false;   
    private bool take = false; 
    [Header("Hp")]
    public float maxHealth = 100f;
    public float currentHealth;
    public Scrollbar healthBar;
    public GameObject Stats;
    public float SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [Header("Move")]
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public int attackDamage = 20;
    public int defense = 2;
    public int attackPauseDuration = 1;
    private bool isAttacking = false;   
    public bool DieB = false;
    private DuelManager DM;

    public static SimpleEnemy instance;
    [Header("VFX")]
    [SerializeField] public Transform hitpoint;
    [SerializeField] GameObject VFXHurt;    
    [SerializeField] GameObject VFXDie;
    [Header("Animations")]
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    [SpineAnimation][SerializeField] private string WalkAnimationName;
    [SpineAnimation][SerializeField] private string RunAnimationName;
    [SpineAnimation][SerializeField] private string Atk1AnimationName;
    [SpineAnimation][SerializeField] private string Atk2AnimationName;
    [SpineAnimation][SerializeField] private string Atk3AnimationName;
    [SpineAnimation][SerializeField] private string GuardAnimationName;
    [SpineAnimation][SerializeField] private string GuardHitAnimationName;
    [SpineAnimation][SerializeField] private string DodgeFAnimationName;
    [SpineAnimation][SerializeField] private string DodgeBAnimationName;
    [SpineAnimation][SerializeField] private string DieAnimationName;
    public AnimationManager Anm;
    
    public void Awake()
    {
        if (instance == null){instance = this;}
        currentHealth = maxHealth;
        DM = GameObject.Find("Script").GetComponent<DuelManager>();
        DM.EnemyinArena += 1;
    }
    private void Choise()
    {
        // Genera un numero casuale tra 1 e 3
        int randomNumber = Random.Range(0, 2);
        result = Mathf.RoundToInt(randomNumber);
        //Debug.Log("Numero casuale: " + result);
        //Debug.Log(ID + "ha Preso" + result);
        switch(result)
        {
            case 0:
            player = GameManager.instance.F_Hero;
            break;
            case 1:
            player =  GameManager.instance.K_Hero;
            break;
            case 2:
            player =  GameManager.instance.S_Hero;
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
        FacePlayer(); if(!isAttacking){ChasePlayer();}
        }
        if(currentHealth < 0){DieB = true; IconVFX.SetActive(true); Die();}
        }
    }
    private void ChasePlayer()
    {
        if (player != null)
        {
            if(!isAttacking)
            {transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            if(!DieB){Anm.PlayAnimationLoop(WalkAnimationName);}}
            if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {StartAttack();}
        }
    }
    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("F_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack);}} 
        else if (collision.gameObject.CompareTag("K_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.K_attack);}}
        else if (collision.gameObject.CompareTag("S_Coll"))
        {if(!DieB){TakeDamage(PlayerStats.instance.S_attack);}}
        else if (collision.gameObject.CompareTag("Spell"))
        {if(!DieB){TakeDamage(PlayerStats.instance.F_attack += Bullet.instance.damage);}}
    }
    
    private void StartAttack()
    {
        isAttacking = true;
        Anm.PlayAnimation(Atk1AnimationName);
        //Debug.Log("Attacco!");
        StartCoroutine(AttackPause());
    }

    private IEnumerator AttackPause()
    {        
        yield return new WaitForSeconds(1);
        if(!DieB){Anm.PlayAnimationLoop(IdleAnimationName);}
        yield return new WaitForSeconds(attackPauseDuration);
        take = false;
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
    if(!DieB){
    int danno_subito = Mathf.Max(damage - defense, 0);
    currentHealth -= danno_subito;
    AudioManager.instance.PlaySFX(8);
    //Debug.Log("danno +"+ danno_subito);
    Instantiate(VFXHurt, transform.position, transform.rotation);
    Anm.TemporaryChangeColor(Color.red);}
    }
    
    public void FacePlayer()
    {
    if (player.transform.position.z > transform.position.z){transform.localScale = new Vector3(1, 1, 1);}
    else if (player.transform.position.z < transform.position.z){transform.localScale = new Vector3(-1, 1, 1);}  
    }
    public void Die()
    {
        //Debug.Log("Il nemico è morto!");
        Instantiate(VFXDie, transform.position, transform.rotation);
        AudioManager.instance.PlayUFX(11);
        Stats.gameObject.SetActive(false);
        DM.EnemyinArena -= 1;
        //Anm.PlayAnimation(DieAnimationName);
        Icon.SetActive(false);
        DeathANM.enabled = true; 
        This.enabled = false;
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