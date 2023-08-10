using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.UI;
using TMPro;
public class SimpleEnemy : MonoBehaviour
{
    [Header("Hp")]
    public float maxHealth = 100f;
    public float currentHealth;
    public Scrollbar healthBar;
    public GameObject Stats;
    public float SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [Header("Move")]
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int attackDamage = 20;
    public int defense = 2;
    public float attackPauseDuration = 1.5f;
    private Transform player;
    private bool isAttacking = false;   
    private bool DieB = false;
    private DuelManager DM;

    //private bool Diefu = false;
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
    public void Update()
    {
        if(!DieB){
        if(!DuelManager.instance.inputCTR){ 
        healthBar.size = currentHealth / maxHealth;
        healthBar.size = Mathf.Clamp(healthBar.size, 0.01f, 1);
        FacePlayer(); if (!isAttacking){ChasePlayer();}
        }
        if(currentHealth < 0){DieB = true; Die();}
        }
    }
    public void TakePlayer(){player = null;}
    private void ChasePlayer()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            Anm.PlayAnimationLoop(WalkAnimationName);
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {StartAttack();}
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("F_Coll"))
        {TakeDamage(PlayerStats.instance.F_attack);} 
        else if (collision.gameObject.CompareTag("K_Coll"))
        {TakeDamage(PlayerStats.instance.K_attack);} 
        else if (collision.gameObject.CompareTag("S_Coll"))
        {TakeDamage(PlayerStats.instance.S_attack);} 
    }
    
    private void StartAttack()
    {
        isAttacking = true;
        Anm.PlayAnimation(Atk1AnimationName);
        Debug.Log("Attacco!");
        StartCoroutine(AttackPause());
    }

    private IEnumerator AttackPause()
    {
        Anm.PlayAnimationLoop(IdleAnimationName);
        yield return new WaitForSeconds(attackPauseDuration);
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
    int danno_subito = Mathf.Max(damage - defense, 0);
    currentHealth -= danno_subito;
    Debug.Log("danno +"+ danno_subito);
    Instantiate(VFXHurt, hitpoint.position, transform.rotation);
    Anm.TemporaryChangeColor(Color.red);;
    }
    
    public void FacePlayer()
    {
    //if (player.transform.position.x > transform.position.x){transform.localScale = new Vector3(-1, 1, 1);}
    //else if (player.transform.position.x < transform.position.x){transform.localScale = new Vector3(1, 1, 1);}  
    }
    public void Die()
    {
        Debug.Log("Il nemico è morto!");
        Instantiate(VFXDie, hitpoint.position, transform.rotation);
        Stats.gameObject.SetActive(false);
        DM.EnemyinArena -= 1;
        Anm.PlayAnimation(DieAnimationName);
        StartCoroutine(TimeDestroy());
    }
    private IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}