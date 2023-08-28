using System.Collections;
using UnityEngine;
using Spine.Unity;
public class CharacterFollow : MonoBehaviour
{   
    #region Header
    [Tooltip("0 - Exploration, 1 - Battle")]
    public int IDAction = 0; //Che tipo di personaggio è
    [Header("Character")]
    public bool fork;
    public Transform Fork;
    public bool knife;
    public Transform Knife;
    public bool spoon;
    public Transform Spoon;
    public int order = 0;
    private Transform Player;
    private SwitchCharacter Switch;
    private CharacterMove F_b;
    private CharacterMove S_b;
    private CharacterMove K_b;
    public bool inputCTR = false;
    public float AiSpeed = 3f;
    public float followSpeed = 5f;
    public float RunSpeed = 6f;
    public float stoppingDistance = 1f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;
    private Rigidbody characterRigidbody;
    private bool isFollowing;
    private bool isGrounded;
    private bool isWalking;
    private bool isGuard;
    [SpineAnimation][SerializeField]  string WalkAnimationName;    
    [SpineAnimation][SerializeField]  string RunAnimationName;
    [SpineAnimation][SerializeField]  string RunBAnimationName;    
    [SpineAnimation][SerializeField]  string IdleAnimationName;
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    [SpineAnimation][SerializeField]  string AllarmAnimationName;
    [SpineAnimation][SerializeField]  string WinAnimationName;
    [SpineAnimation][SerializeField]  string GuardAnimationName;
    [SpineAnimation][SerializeField]  string Atk1AnimationName;
    [Header("Battle")]
    public int attackPauseDuration = 1;
    public float attackRange = 3f;
    private GameObject target;
    private bool isAttacking = false;   
    private bool take = false; 
    private bool Die = false;
    public int result;
    public AnimationManager Anm;
    [HideInInspector]
    public bool Allarming;
    [HideInInspector]
    public bool Win;
    private string currentAnimationName;
    private float distance;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    public static CharacterFollow instance;
    #endregion
    public void Awake()
    {
         if (instance == null){instance = this;}
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");} 
        if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();;} 
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;
        characterRigidbody = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("F_Player").transform;
        F_b = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        K_b = GameObject.Find("S_Player").GetComponent<CharacterMove>();
        S_b = GameObject.Find("K_Player").GetComponent<CharacterMove>();
    }
    public void Update()
    {
        if(!inputCTR){
        switch(IDAction)
        {case 0:  
        if(!Allarming)
        {SimpleMove();
        if(Switch.isElement1Active){Player = Spoon;Flip();}
        else if(Switch.isElement2Active){Player = Fork;Flip();} 
        else if(Switch.isElement3Active){Player = Knife;Flip();}} 
        break;
        ////////////////////////////////////////
        case 1: 
        if(!Win){
        if (target == null && !take){Choise(); take = true;}
        if(fork && !knife && !spoon) {ForkB();} //Se è forchetta
        else if(!fork && knife && !spoon) {KnifeB();} //Se è Coltello
        else if(!fork && !knife && spoon) {SpoonB();} //Se è Cucchiaio
        } else if(Win) {Anm.PlayAnimationLoop(WinAnimationName);} //Se è forchetta
        break;
        }}  
    }
    
    #region MoveExploration
    public void SimpleMove()
    {
    isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    if (!isFollowing){Anm.PlayAnimationLoop(IdleAnimationName); isWalking = false;}
    if ((transform.position - Player.transform.position).sqrMagnitude > stoppingDistance * stoppingDistance){isFollowing = true;}
    if ((transform.position - Player.transform.position).sqrMagnitude < stoppingDistance * stoppingDistance){isFollowing = false;}

    if (isFollowing && (transform.position - Player.transform.position).sqrMagnitude > stoppingDistance * stoppingDistance)
    {
            // Calcola la direzione verso cui il personaggio deve muoversi
            Vector3 direction = Player.position - transform.position;
            direction.y = 0f;
            direction.Normalize();
            // Calcola la distanza dal giocatore
            distance = Vector3.Distance(transform.position, Player.position);
            
            if (distance > stoppingDistance)
            {
                if (!F_b.isRun || !S_b.isRun || !K_b.isRun)
                {
                if (!isWalking)
                {isWalking = true; Anm.PlayAnimationLoop(WalkAnimationName);}
                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                characterRigidbody.MovePosition(transform.position + direction * followSpeed * Time.deltaTime);
                } 
                if (F_b.isRun || S_b.isRun || K_b.isRun)
                {
                if (!isWalking)
                {isWalking = true; Anm.PlayAnimationLoop(RunAnimationName);}
                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                characterRigidbody.MovePosition(transform.position + direction * RunSpeed * Time.deltaTime);
                } 
            }
            else if (!F_b.isRun || !S_b.isRun || !K_b.isRun)
            {
                if (isWalking)
                {isWalking = false; Anm.PlayAnimationLoop(IdleAnimationName);}
                // Il personaggio è vicino al giocatore, smette di muoversi
                isFollowing = false;
            }
        }
    }
    #endregion

    #region Fork
    public void ForkB()
    {
    switch(order)
        {
            case 0:
            Posebattle();
            break;
            case 1:
            if(!inputCTR){AttackEnmF();}
            else if(inputCTR){Anm.PlayAnimation(IdleBAnimationName);}
            break;
            case 2:
            DefenceEnm();
            break;
            case 3:
            break;
            case 4:
            break;
            case 5:
            break;
        }
    }
#endregion

    #region Knife
    public void KnifeB()
    {
    switch(order)
        {
            case 0:
            Posebattle();
            break;
            case 1:
            if(!inputCTR){AttackEnm();}
            else if(inputCTR){Anm.PlayAnimation(IdleBAnimationName);}
            break;
            case 2:
            DefenceEnm();
            break;
            case 3:
            break;
            case 4:
            break;
            case 5:
            break;
        }
    }
#endregion

    #region Spoon
    public void SpoonB()
    {
        switch(order)
        {
            case 0:
            Posebattle();
            break;
            case 1:
            if(!inputCTR){AttackEnm();}
            else if(inputCTR){Anm.PlayAnimation(IdleBAnimationName);}
            break;
            case 2:
            DefenceEnm();
            break;
            case 3:
            break;
            case 4:
            break;
            case 5:
            break;
        }
    }
#endregion
    public void Ordini(int ord){order = ord;}
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
    public void Posebattle(){Anm.PlayAnimation(IdleBAnimationName);}
    public void Idle(){Anm.PlayAnimationLoop(IdleAnimationName);}
    public void Allarm(){Anm.PlayAnimationLoop(AllarmAnimationName); Allarming = true;}   
    public void PoseWin(){Win = true;}    
    public void StopWin(){Win = false;}    
    public void StopAllarm(){Allarming = false;}    
    private void Flip()
    {
        if (Player.localScale.x > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (Player.localScale.x < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }
    public void FixedUpdate(){if (isGrounded){characterRigidbody.velocity = Vector3.zero;}}
    
    #region Attack
    public void AttackEnm(){isGuard = false; if(!isAttacking){ChaseEnm();}}
    public void AttackEnmF(){isGuard = false; if(!isAttacking){StartAttack();}}
    private void Choise()
    {
    // Genera un numero casuale tra 1 e 3
    int randomNumber = Random.Range(0, 2);
    result = Mathf.RoundToInt(randomNumber);
    //Debug.Log("Numero casuale: " + result);
    switch(result)
    {
            case 0:
            target = GameObject.Find("Spoon");
            break;
            case 1:
            target = GameObject.Find("Fork");
            break;
            case 2:
            target = GameObject.Find("Knife");
            break;
    } 
    }
    private void ChaseEnm()
    {if (target != null)
        {
            if(!isAttacking)
            {transform.position = Vector3.MoveTowards(transform.position, target.transform.position, AiSpeed * Time.deltaTime);
            Anm.PlayAnimationLoop(RunBAnimationName);}
            if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
            {StartAttack();}
        }
    }
    private void StartAttack()
    {
        isAttacking = true;
        Anm.PlayAnimation(Atk1AnimationName);
        StartCoroutine(AttackPause());
    }
    private IEnumerator AttackPause()
    {        
        yield return new WaitForSeconds(attackPauseDuration);
        take = false;
        isAttacking = false;
    }
    #endregion

//Creare la function di danno prima di proseguire con la difesa

    #region Defence
    public void DefenceEnm(){Anm.PlayAnimationLoop(GuardAnimationName); isGuard = true;}
    #endregion

    /*public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enm_Coll"))
        {TakeDamage(PlayerStats.instance.F_attack);} 
    }

    public void TakeDamage(int damage)
    {
    if(!Die){
    //int danno_subito = Mathf.Max(damage - defense, 0);
    //currentHealth -= danno_subito;
    AudioManager.instance.PlaySFX(8);
    //Debug.Log("danno +"+ danno_subito);
    Instantiate(VFXHurt, transform.position, transform.rotation);
    Anm.TemporaryChangeColor(Color.red);}
    }*/

#if(UNITY_EDITOR)
#region Gizmos
private void OnDrawGizmos()
    {
    Gizmos.color = Color.red;
    // disegna un Gizmo che rappresenta il Raycast
    //Gizmos.DrawLine(transform.position, transform.position + new Vector3(transform.localScale.x, 0, 0) * wallDistance);
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
#endregion
#endif
}