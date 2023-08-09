using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
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
 // Nome dell'animazione di attacco base
    //[SerializeField] private string attackAnimationName = "attack";

    // Nome delle animazioni di combo (aggiunto a un numero per formare il nome completo)
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    private void Start()
    {
         if (instance == null)
        {
            instance = this;
        }
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {
            Debug.LogError("Componente SkeletonAnimation non trovato!");
        }        
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;    
    }

    private void Update()
    {
        if(!DuelManager.instance.inputCTR)
        {FacePlayer();
        if (!isAttacking)
        {ChasePlayer();} 
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
            Walk();
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
        PlayAnimation(Atk1AnimationName); 
        _spineAnimationState.Event += HandleEvent;
        // Ferma il nemico per attaccare
        // Inserisci qui l'animazione dell'attacco, se presente
        Debug.Log("Attacco!");

        // Dopo l'attacco, avvia una coroutine per la pausa prima di riprendere l'inseguimento
        StartCoroutine(AttackPause());
    }

    private IEnumerator AttackPause()
    {
        Idle();
        yield return new WaitForSeconds(attackPauseDuration);
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        // Inserisci qui la logica per subire danni
    }
    void FacePlayer()
    {
        
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        
    }
    private void Die()
    {
        // Inserisci qui la logica per la morte del nemico
        Debug.Log("Il nemico è morto!");
        Destroy(gameObject);
    }

    private void PlayAnimation(string animationName)
    {
        _skeletonAnimation.state.SetAnimation(0, animationName, false);
        _skeletonAnimation.state.GetCurrent(0).Complete += OnAttackAnimationComplete;
    }
    public void Walk()
{
    if (currentAnimationName != WalkAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, WalkAnimationName, true);
                    currentAnimationName = WalkAnimationName;
                     _spineAnimationState.Event += HandleEvent;
                }

}
 public void Running()
{
    if (currentAnimationName != RunAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, RunAnimationName, true);
                    currentAnimationName = RunAnimationName;
                     _spineAnimationState.Event += HandleEvent;
                }

}

 public void Idle()
{
    if (currentAnimationName != IdleAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, IdleAnimationName, true);
                    currentAnimationName = IdleAnimationName;
                     _spineAnimationState.Event += HandleEvent;
                }

}

    private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    // Remove the event listener
    trackEntry.Complete -= OnAttackAnimationComplete;

    // Clear the track 1 and reset to the idle animation
    _skeletonAnimation.state.ClearTrack(1);
    _skeletonAnimation.state.SetAnimation(0, IdleAnimationName, true);
}
void HandleEvent (TrackEntry trackEntry, Spine.Event e) 
{
//Normal VFX
    if (e.Data.Name == "slashV") 
    {}
}
}