using System.Collections;
using UnityEngine;
using Spine.Unity;
using JetBrains.Annotations;
public class CharacterFollow : MonoBehaviour
{   
    #region Header
    [Tooltip("0 - Exploration, 1 - Battle")]
    public int IDAction = 0; //Che tipo di personaggio è
    [Header("Character")]
    [Tooltip("Scegli personaggi 0.Fork 1.Knife 2.Spoon")]
    [Range(0, 2)]
    public int kindCh;
    public GameObject Indicatore;
    public GameObject StartP;
    public Transform MoveP;
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
    public float gravity = 9.81f;  // Gravità personalizzata, puoi regolarla come desideri
    public float followSpeed = 5f;
    public float RunSpeed = 6f;
    public float stoppingDistance = 1f;
    public float  OrderDistance = 2f;
    //public float groundCheckDistance = 0.2f;
    //public LayerMask groundLayer;
    private Rigidbody characterRigidbody;
    private bool isFollowing;
    //private bool isGrounded;
    private bool isWalking;
    public bool isGuard;
    private float defense;
    private float danno_subito;
    public GameObject VFXPoison;
    public GameObject VFXHurt;
    private bool poisonState = false;
    private int TimePoison = 5;     
    private CharacterController characterController;  
    [SpineAnimation][SerializeField]  string WalkAnimationName;    
    [SpineAnimation][SerializeField]  string RunAnimationName;
    [SpineAnimation][SerializeField]  string RunBAnimationName;    
    [SpineAnimation][SerializeField]  string IdleAnimationName;
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    [SpineAnimation][SerializeField]  string AllarmAnimationName;
    //[SpineAnimation][SerializeField]  string WinAnimationName;
    [SpineAnimation][SerializeField]  string GuardAnimationName;
    [SpineAnimation][SerializeField]  string Atk1AnimationName;
    [Header("Battle")]
    public int attackPauseDuration = 1;
    public float attackRange = 3f;
    public GameObject target;
    private bool isAttacking = false;   
    private bool take = false; 
    public int result;
    public AnimationManager Anm;
    public bool Allarming;
    public bool Win;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    //Spine.EventData eventData;
    public static CharacterFollow instance;
    public DuelManager DM;
    #endregion
    public void Start()
    {
         if (instance == null){instance = this;}
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");} 
        if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();;} 
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;
        characterController = GetComponent<CharacterController>();
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
        //
        if(Attention){Esclamation.SetActive(true);}
        else if(!Attention){Esclamation.SetActive(false);}
        //
        if(!inputCTR){
        //Combatte o esplora?
        switch(IDAction)
        {case 0:  
        if(!Allarming || !Attention)
        {
        SimpleMove();
        TargetPlayer();
        }
        break;
        ////////////////////////////////////////
        case 1: 
        if(!Win){
        if (target == null && !take)
        {Choise();         
        DM = GameObject.Find("DuelManager").GetComponent<DuelManager>();
        take = true;}
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

    public void TargetPlayer()
    {
        switch(GameManager.instance.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock)
            {Player = Fork.transform; Flip();}
            break;
            case 2:
            if(GameManager.instance.K_Unlock)
            {Player = Knife;Flip();}  
            break;
            case 3:
            if(GameManager.instance.S_Unlock)
            {Player = Spoon;Flip();}
            break;
        }
    }

    public void SimpleMove()
    {
    if (!characterController.isGrounded)
        {
            // Applica la gravità personalizzata se necessario
            Vector3 gravityVector = new Vector3(0, -gravity, 0);
            characterController.Move(gravityVector * Time.deltaTime);
        }

        if (!isFollowing)
        {
            // Animate idle when not following
            Anm.PlayAnimationLoop(IdleAnimationName);
            isWalking = false;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        if (isFollowing)
        {
            // Calculate the direction to move the character
            Vector3 direction = Player.position - transform.position;
            direction.y = 0f;
            direction.Normalize();

            if (distanceToPlayer > stoppingDistance)
            {
                if (!isWalking)
                {
                    isWalking = true;
                    Anm.PlayAnimationLoop(GameManager.instance.isRun ? RunAnimationName : WalkAnimationName);
                }

                // Move the character towards the player only if the distance exceeds the stopping threshold
                float speed = RunSpeed; // Use RunSpeed when running
                if (!GameManager.instance.isRun)
                {
                    speed = followSpeed; // Use followSpeed when not running
                }

                characterController.Move(direction * speed * Time.deltaTime);
            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    Anm.PlayAnimationLoop(IdleAnimationName);
                }

                // The character is close to the player, stop moving
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
            MoveInPoint();
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
            MoveInPoint();
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
            MoveInPoint();
            break;
            case 4:
            break;
            case 5:
            break;
        }
    }
#endregion
    public void Character(int ord){DM.Character(ord); order = 0; }//order = ord;}
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
    public void Posebattle(){Anm.PlayAnimation(IdleBAnimationName);}

    public void Idle(){Anm.PlayAnimationLoop(IdleAnimationName);}
    public void Allarm(){Allarming = true;}       
    public void StopAllarm(){Allarming = false;}    
    private void Flip()
    {
        if (Player.localScale.x > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (Player.localScale.x < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }
        
    #region Attack
    public void AttackEnm(){isGuard = false; if(!isAttacking){ChaseEnm();}}
    public void AttackEnmF(){isGuard = false; if(!isAttacking){StartAttack();}}

    private void PlayComboAnimation(string animationName)
    {if (_skeletonAnimation != null){_skeletonAnimation.AnimationState.SetAnimation(0, animationName, false);}}
    private void Choise()
    {
    if(!Win){
    int randomNumber = Random.Range(0, 2);
    result = Mathf.RoundToInt(randomNumber);
    switch(result)
    {
            case 0:
            target = GameObject.Find("Enm_Spoon");
            if(target == null){Choise(); isAttacking = false;}
            break;
            case 1:
            target = GameObject.Find("Enm_Fork");
            if(target == null){Choise(); isAttacking = false;}
            break;
            case 2:
            target = GameObject.Find("Enm_Knife");
            if(target == null){Choise(); isAttacking = false;}
            break;
    } 
    }else if(Win){order = 0;}
    }
    private void ChaseEnm()
    {
    if (target != null)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        bool isEnemyAbove = directionToTarget.z > 0;
        //Flippa
        if (isEnemyAbove && transform.position.z < target.transform.position.z)
        {transform.localScale = new Vector3(1, 1,1);}
        else if (!isEnemyAbove && transform.position.z > target.transform.position.z)
        {transform.localScale = new Vector3(-1, 1,1);}
        //Insegue
        if (!isAttacking)
        {
        if (target != null){transform.position = Vector3.MoveTowards(transform.position, target.transform.position, AiSpeed * Time.deltaTime);
        isAttacking = false;}}
        else if (target != null){order = 2;}
        //Attacca altrimenti insegue
        if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
        {StartAttack();}
        else if (Vector3.Distance(transform.position, target.transform.position) > attackRange)
        { isAttacking = false; Anm.PlayAnimationLoop(RunBAnimationName);}
    }else if (target == null){order = 2;}
    }
    public void PointStart(){Indicatore.transform.position = StartP.transform.position;}
    public void MoveInPoint()
    {
    float distanceToTarget = Vector3.Distance(transform.position, MoveP.transform.position);
    // Flippa il personaggio sull'asse X in base alla posizione relativa del nemico
    if (transform.position.z < MoveP.transform.position.z){transform.localScale = new Vector3(1, 1,1);}
    else if (transform.position.z > MoveP.transform.position.z){transform.localScale = new Vector3(-1, 1,1);}

    if (distanceToTarget > OrderDistance)
    {
        transform.position = Vector3.MoveTowards(transform.position, MoveP.transform.position, AiSpeed * Time.deltaTime);
        Anm.PlayAnimationLoop(RunBAnimationName);
    }
    else if (distanceToTarget < OrderDistance)
    {
        // Quando il personaggio raggiunge il punto di destinazione, puoi fare qualcosa qui, ad esempio:
        order = 2;//Si mette in difesa
        if (transform.position.z < target.transform.position.z){transform.localScale = new Vector3(1, 1,1);}
        else if (transform.position.z > target.transform.position.z){transform.localScale = new Vector3(-1, 1,1);}
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
            if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curRage +=  5;}
            break;
            case 1:
            PlayerStats.instance.K_curHP -= danno_subito;
            if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curRage +=  5;}
            break; 
            case 2:
            PlayerStats.instance.S_curHP -= danno_subito;
            if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curRage +=  5;}
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
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    Gizmos.color = Color.black;
    Gizmos.DrawWireSphere(transform.position, OrderDistance);
    }
#endregion
#endif
}