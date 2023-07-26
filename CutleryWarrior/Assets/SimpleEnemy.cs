using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
   public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int attackDamage = 20;
    public float attackPauseDuration = 1.5f;

    private Transform player;
    private bool isAttacking = false;

    //public bool inputCTR = false;    
    
    public static SimpleEnemy instance;

    private void Start()
    {
         if (instance == null)
        {
            instance = this;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(!DuelManager.instance.inputCTR){
        if (!isAttacking)
        {
            ChasePlayer();
        } 



        /*if (Input.GetKeyDown(KeyCode.Space))
        {
        Debug.Log("Cambio!");
        player = GameObject.Find("F_Player").transform;

        }   */
        
        }

    }
    public void TakePlayer()
    {
    player = null;
    player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void ChasePlayer()
    {
        if (player != null)
        {
            // Movimento verso il player
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Se il nemico ha raggiunto il player, inizia l'attacco
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                StartAttack();
            }
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        // Ferma il nemico per attaccare
        // Inserisci qui l'animazione dell'attacco, se presente
        Debug.Log("Attacco!");

        // Dopo l'attacco, avvia una coroutine per la pausa prima di riprendere l'inseguimento
        StartCoroutine(AttackPause());
    }

    private IEnumerator AttackPause()
    {
        yield return new WaitForSeconds(attackPauseDuration);
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        // Inserisci qui la logica per subire danni
    }

    private void Die()
    {
        // Inserisci qui la logica per la morte del nemico
        Debug.Log("Il nemico è morto!");
        Destroy(gameObject);
    }
}