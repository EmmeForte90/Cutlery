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
    public float SpeedRestore = 5f; // il massimo valore di essenza disponibile

    [Header("Move")]
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int attackDamage = 20;
    public float attackPauseDuration = 1.5f;
    private Transform player;
    private bool isAttacking = false;   
    private bool DieB = false;
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
        DuelManager.instance.EnemyinArena += 1;
    }
    public void Update()
    {
        if(!DieB){
        if(!DuelManager.instance.inputCTR){ 
        healthBar.size = currentHealth / maxHealth;
        healthBar.size = Mathf.Clamp(healthBar.size, 0.01f, 1);
        FacePlayer(); if (!isAttacking){ChasePlayer();}
        }}
        if(currentHealth <= 0){DieB = true; Die();}
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
        if (collision.gameObject.CompareTag("F_Coll")||
        collision.gameObject.CompareTag("K_Coll")||
        collision.gameObject.CompareTag("S_Coll"))
        {TakeDamage(10);}
        
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
    currentHealth -= damage;
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
        DuelManager.instance.EnemyinArena -= 1;
        Anm.PlayAnimation(DieAnimationName);
        StartCoroutine(TimeDestroy());
    }
    private IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}