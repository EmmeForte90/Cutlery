using System.Collections;
using UnityEngine;
using Spine.Unity;
public class CharacterFollow : MonoBehaviour
{   
    #region Header
    [Tooltip("0 - Exploration, 1 - Battle")]
    public int IDAction = 0; //Che tipo di personaggio è
    [Header("Character")]
    [Tooltip("Scegli personaggi 0.Fork 1.Knife 2.Spoon")]
    [Range(0, 2)]
    public int kindCh;
    public Transform Fork;
    public Transform Knife;
    public Transform Spoon;
    public int order = 0;
    private Transform Player;
     public GameObject Esclamation;
     public bool Attention;
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
    private float defense;
    private float danno_subito;
    public GameObject VFXPoison;
    public GameObject VFXHurt;
    private bool poisonState = false;
    private int TimePoison = 5;       
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
    public bool Allarming;
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
        if(GameManager.instance.F_Unlock){F_b = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.K_Unlock){K_b = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.S_Unlock){S_b = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
    }
    public void RetakeCh()
    {
        if(GameManager.instance.F_Unlock){F_b = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.K_Unlock){K_b = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.S_Unlock){S_b = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
    }
    public void Update()
    {
        if(Allarming){Anm.PlayAnimationLoop(AllarmAnimationName);}
        //if(Win){Anm.PlayAnimationLoop(WinAnimationName);}
        //
        if(Attention){Esclamation.SetActive(true);}
        else if(!Attention){Esclamation.SetActive(false);}
        //
        if(!inputCTR){
        switch(IDAction)//Combatte o esplora?
        {case 0:  
        if(!Allarming || !Attention)
        {SimpleMove();
        if(Switch.isElement1Active){Player = Spoon;Flip();}
        else if(Switch.isElement2Active){Player = Fork;Flip();} 
        else if(Switch.isElement3Active){Player = Knife;Flip();}} 
        break;
        ////////////////////////////////////////
        case 1: 
        if(!Win){
        if (target == null && !take){Choise(); take = true;}
        if(poisonState){StartCoroutine(Poi());}
        switch (kindCh)
        {
            case 0:
            ForkB();
            break;
            case 1:
            KnifeB();
            break; 
            case 2:
            SpoonB();
            break;
        }
        ///////////////////////////////////////
        }
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
                if (!isWalking)
                {
                    isWalking = true;
                    Anm.PlayAnimationLoop(GameManager.instance.isRun ? RunAnimationName : WalkAnimationName);
                }
                
                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                float speed = GameManager.instance.isRun ? RunSpeed : followSpeed;
                characterRigidbody.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    Anm.PlayAnimationLoop(IdleAnimationName);
                }
                
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
    public void Allarm(){Allarming = true;}   
    //public void PoseWin(){Win = true;}    
    //public void StopWin(){Win = false;}    
    public void StopAllarm(){Allarming = false;}    
    private void Flip()
    {
        if (Player.localScale.x > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (Player.localScale.x < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }
    public void FixedUpdate()
    {if (isGrounded){characterRigidbody.velocity = Vector3.zero;}}
    
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
    if(target == null)
    {DefenceEnm();}
    }
    private void ChaseEnm()
    {if (target != null)
        {
            if(!isAttacking)
            {transform.position = Vector3.MoveTowards(transform.position, target.transform.position, AiSpeed * Time.deltaTime);
            Anm.PlayAnimationLoop(RunBAnimationName);}
            if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
            {StartAttack();}
        }else if(target == null)
    {DefenceEnm();}
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

    public void TakeDamage(float damage)
    {
        switch (kindCh)
        {
            case 0:
            defense = PlayerStats.instance.F_defense;
            break;
            case 1:
            defense = PlayerStats.instance.K_defense;
            break; 
            case 2:
            defense = PlayerStats.instance.S_defense;
            break;
        }
        danno_subito = Mathf.Max(damage - defense, 0);
        switch (kindCh)
        {
            case 0:
            PlayerStats.instance.F_curHP -= danno_subito;
            break;
            case 1:
            PlayerStats.instance.K_curHP -= danno_subito;
            break; 
            case 2:
            PlayerStats.instance.S_curHP -= danno_subito;
            break;
        }
    AudioManager.instance.PlaySFX(8);
    //Debug.Log("danno "+ danno_subito);
    Instantiate(VFXHurt, transform.position, transform.rotation);
    Anm.TemporaryChangeColor(Color.red);
    }
     #region Stato Veleno
    public void Poison(){Anm.ChangeColor(); VFXPoison.SetActive(true); poisonState = true;} 
    private IEnumerator Poi()
    {
        yield return new WaitForSeconds(TimePoison);
        if(poisonState){
        switch (kindCh)
        {
            case 0:
            GameManager.instance.RestoreF(); poisonState = false;
            break;
            case 1:
            GameManager.instance.RestoreK(); poisonState = false;
            break; 
            case 2:
            GameManager.instance.RestoreS(); poisonState = false;
            break;
        }}
    }
    #endregion
    public void ReCol(){Anm.ResetColor(); VFXPoison.SetActive(false);}

#if(UNITY_EDITOR)
#region Gizmos
private void OnDrawGizmos()
    {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, attackRange);
    // disegna un Gizmo che rappresenta il Raycast
    //Gizmos.DrawLine(transform.position, transform.position + new Vector3(transform.localScale.x, 0, 0) * wallDistance);
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
#endregion
#endif
}