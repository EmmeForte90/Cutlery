using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Spine.Unity;
using Spine;
using Unity.VisualScripting;

public class CharacterMove : MonoBehaviour
{
    [Header("Character")]
    [Tooltip("Scegli personaggi 0.Fork 1.Knife 2.Spoon")]
    [Range(0, 2)]
    public int kindCh;

    [Tooltip("0 - Exploration, 1 - Battle")]
    public int IDAction = 0; //Che tipo di personaggio è
    public GameObject Esclamation;
     public bool Attention;
    public GameObject Bullet;
    public Transform BPoint;
    private Rigidbody rb;  
    [Header("Move")]
    public float Speed = 1;
    public float SpeedB = 2;
    public float Run = 5;
    private Transform cam;
    Vector2 input;
    public Transform SpriteHero;
    private bool stand = true;
    public bool isRun = false;
    public bool inputCTR = false;
    public bool Interact = false;
    public bool Win = false;
    private int comboCount = 0;
    private bool canAttack = true;
    public float comboCooldown = 0.3f; // Tempo di cooldown tra le combo in secondi
    public float dodgeCooldown = 0.4f;
    private bool canDodge = true;
    public bool warning = false;
    private float hor;
    private float defense;
    private float danno_subito;
    public GameObject VFXPoison;
    public GameObject VFXHurt;
    private bool poisonState = false;
    private int TimePoison = 5;   
    private bool Right = true; 
   
    [Header("Animations")]
    [SpineAnimation][SerializeField]  string WalkAnimationName;
    [SpineAnimation][SerializeField]  string RunAnimationName;
    [SpineAnimation][SerializeField]  string IdleAnimationName;
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    [SpineAnimation][SerializeField]  string WalkBAnimationName;
    [SpineAnimation][SerializeField]  string RunBAnimationName;
    [SpineAnimation][SerializeField]  string TalkingAnimationName;
    [SpineAnimation][SerializeField]  string AllarmAnimationName;
    [SpineAnimation][SerializeField]  string Atk1AnimationName;
    [SpineAnimation][SerializeField]  string Atk2AnimationName;
    [SpineAnimation][SerializeField]  string Atk3AnimationName;
    [SpineAnimation][SerializeField]  string Atk4AnimationName;
    [SpineAnimation][SerializeField]  string GuardAnimationName;
    [SpineAnimation][SerializeField]  string GuardWalkAnimationName;
    [SpineAnimation][SerializeField]  string GuardRunAnimationName;
    [SpineAnimation][SerializeField]  string GuardHitAnimationName;
    [SpineAnimation][SerializeField]  string DodgeFAnimationName;
    [SpineAnimation][SerializeField]  string DodgeBAnimationName;
    [SpineAnimation][SerializeField]  string WinAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    private SwitchCharacter Switch;
    private Transform Player;
    private bool isDefence = false;
    public AnimationManager Anm;
    Vector3 camF,camR,moveDir;  
    [Header("Dodge and Knockback")]    
    private DodgeController DodgeController;
    private KnockbackController knockbackController;
    [Header("Attacks")]
    private bool isAttacking = false;
    public float comboTimer = 0.5f; // Tempo di attesa tra le combo
    public float DodgeSTimer = 0.5f; // Tempo di attesa tra le combo
    private float lastAttackTime = 0f;
    private float DodgeTime = 0f;
    public static CharacterMove instance;
public void Awake()
    {
         if (instance == null)
        {instance = this;}
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}  
        cam = GameObject.FindWithTag("MainCamera").transform;      
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;        
        knockbackController = GetComponent<KnockbackController>();
        DodgeController = GetComponent<DodgeController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();}
    }
   
    public void Update()
    {
        if(Interact){Anm.PlayAnimationLoop(TalkingAnimationName);}
        //if(Win){Anm.PlayAnimationLoop(WinAnimationName);}
        if(warning){Anm.PlayAnimationLoop(AllarmAnimationName);}
        //
        if(Attention){Esclamation.SetActive(true);}
        else if(!Attention){Esclamation.SetActive(false);}
        //
        if(!inputCTR)
        {switch(IDAction){
        case 0:  
        ////////////////////////////////////////
        SimpleMove();
        break;
        ////////////////////////////////////////
        case 1: 
        if(Run >= 5){ Run = 3;}
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
        break;
        }}
    }
#region MoveExploration
    public void SimpleMove()
    {
        if(cam == null){cam = GameObject.FindWithTag("MainCamera").transform;}
        Flip();  
        ////////////////////////////////
        if(!Interact)
        {if(!warning)
        {if(!Win)
        {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1); 
        if(Input.GetButton("Fire3")){isRun = true;} 
        if (Input.GetButtonUp("Fire3")){isRun = false;} 
        //
        camF = cam.forward;camR = cam.right;camF.y = 0;camR.y = 0;
        camF = camF.normalized;camR = camR.normalized;  
        moveDir = camR * input.x + camF * input.y;
        //
        if (moveDir.magnitude > 0)
        {
        if (!isRun){Anm.PlayAnimationLoop(WalkAnimationName); stand = false;} 
        else if (isRun){Anm.PlayAnimationLoop(RunAnimationName); stand = false;}
        }
        else{Anm.PlayAnimationLoop(IdleAnimationName); stand = true;}
        hor = Input.GetAxisRaw("Horizontal");      
        }
    }}}
#endregion
#region Fork
    public void ForkB()
    {
        MoveB();
    //DODGE
        // Rileva l'input del tasto spazio
        if (Input.GetMouseButtonDown(1) && canDodge)
        {DodgeF();}
    
    //Attack
        if (Input.GetMouseButtonDown(0) && canAttack && PlayerStats.instance.F_curMP > 20)
            {
                HandleComboAttackF();
                Stop();
                AudioManager.instance.PlayUFX(8);
                AudioManager.instance.PlayUFX(0); 
                Instantiate(Bullet, BPoint.position, Bullet.transform.rotation); 
                PlayerStats.instance.F_curMP -= PlayerStats.instance.F_CostMP;  
                //lastAttackTime = Time.time;
            }else {AudioManager.instance.PlayUFX(10);}     
    }
    private void DodgeF()
    {
        Vector3 DodgeDirection = transform.position;
        //Anm.PlayAnimation(DodgeFAnimationName);
        PlayComboAnimation("Battle/dodge_front");
        DodgeController.ApplyDodge(DodgeDirection);
        canDodge = false;
        StartCoroutine(DodgeCooldown());
    }
    
    private void HandleComboAttackF()
    {
        comboCount = (comboCount % 2) + 1;
        PlayComboAnimation("Battle/attack_" + comboCount.ToString());
        canAttack = false;
        StartCoroutine(ComboCooldown());
    }
#endregion
#region Knife
    public void KnifeB()
    {
        MoveB();
        //DODGE
        if (Input.GetMouseButtonDown(1) && canDodge)
        {DodgeK();}
        
    //Attack
        if (Input.GetMouseButtonDown(0) && canAttack && PlayerStats.instance.K_curMP > 20)
        {HandleComboAttackK(); PlayerStats.instance.K_curMP -= PlayerStats.instance.K_CostMP;} 
        else {AudioManager.instance.PlayUFX(10);}
    }
    

    private void DodgeK()
    {
        Vector3 DodgeDirection = transform.position;
        //Anm.PlayAnimation(DodgeFAnimationName);
        PlayComboAnimation("Battle/dodge_front");
        DodgeController.ApplyDodge(DodgeDirection);
        canDodge = false;
        StartCoroutine(DodgeCooldown());
    }

    
    private void HandleComboAttackK()
    {
        comboCount = (comboCount % 3) + 1;
        PlayComboAnimation("Battle/attack_" + comboCount.ToString());
        canAttack = false;
        StartCoroutine(ComboCooldown());
    }
    
#endregion
#region Spoon
    public void SpoonB()
    {
           MoveB();  
    //DODGE
        // Rileva l'input del tasto spazio
        if (Input.GetMouseButtonDown(1) && PlayerStats.instance.S_curMP > 20)
        {isDefence = true; Anm.PlayAnimationLoop(GuardAnimationName);}

        // Verifica se il tasto del mouse è stato rilasciato
        if (Input.GetMouseButtonUp(1)){isDefence = false;}

        // Continua ad eseguire l'azione mentre il tasto del mouse è premuto
        //if (isDefence){Anm.PlayAnimationLoop(GuardAnimationName);}
    
    //Attack
       // Verifica se il tasto del mouse è stato premuto
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime > comboTimer 
        && PlayerStats.instance.S_curMP > 20)
            {
                Stop();
                Anm.PlayAnimation(Atk1AnimationName);
                PlayerStats.instance.S_curMP -= PlayerStats.instance.S_CostMP;  
                lastAttackTime = Time.time;
            } else {AudioManager.instance.PlayUFX(10);}
    }
    
#endregion

    private void PlayComboAnimation(string animationName)
    {if (_skeletonAnimation != null){_skeletonAnimation.AnimationState.SetAnimation(0, animationName, false);}}
    private IEnumerator ComboCooldown()
    {
        yield return new WaitForSeconds(comboCooldown);
        canAttack = true;
    }
    private IEnumerator DodgeCooldown()
    {
        yield return new WaitForSeconds(dodgeCooldown);
        PlayComboAnimation("Battle/walk_battle");
        canDodge = true;
    }
    public void Posebattle(){Anm.PlayAnimation(IdleBAnimationName);}
    public void TakeCamera(){cam = GameObject.FindWithTag("MainCamera").transform;}
    public void Idle(){Anm.PlayAnimationLoop(IdleAnimationName);}
    public void Allarm(){warning = true;}
    public void StopAllarm(){warning = false;}
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
    public void FixedUpdate()
    {if(!inputCTR)
    {if(!Interact && !isRun || isDefence)
    {rb.MovePosition(transform.position + moveDir * 0.1f * Speed);} 
    else if(!Interact && isRun  && !isDefence)//!StopM && !isDefence)
    {rb.MovePosition(transform.position + moveDir * 0.1f * Run);
    }else if(!Interact && !isDefence)//!StopM && !isDefence)
    {rb.MovePosition(transform.position + moveDir * 0.1f * SpeedB);}
    if(poisonState){StartCoroutine(Poi());}
    }}
    #region Move
    //For Knife
    /*public void Move()
    {if(cam == null){cam = GameObject.FindWithTag("MainCamera").transform;}
        Flip();  
        ////////////////////////////////
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
        
        if(Input.GetButton("Fire3")){isRun = true;} 
        if (Input.GetButtonUp("Fire3")){isRun = false;}
        
        camF = cam.forward;
        camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;  
        moveDir = camR * input.x + camF * input.y;
        
        if (moveDir.magnitude > 0)
        {
        if (!isRun && !isDefence){Anm.PlayAnimationLoop(WalkBAnimationName); stand = false;}
        else if(!isRun && isDefence){Anm.PlayAnimationLoop(GuardWalkAnimationName); stand = false;} 
        if (isRun && !isDefence){Anm.PlayAnimationLoop(RunBAnimationName); stand = false;}
        else if(isRun && isDefence){Anm.PlayAnimationLoop(GuardRunAnimationName); stand = false;} 
        }
        else if(!isDefence){Anm.PlayAnimationLoop(IdleBAnimationName); stand = true;}
        else if(isDefence){Anm.PlayAnimationLoop(GuardAnimationName); stand = true;}
        hor = Input.GetAxisRaw("Horizontal");}
*/
        public void MoveB()
    {if(cam == null){cam = GameObject.FindWithTag("MainCamera").transform;}
        Flip();  
        ////////////////////////////////
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
        
        camF = cam.forward;
        camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;  
        moveDir = camR * input.x + camF * input.y;
        
        if(moveDir.magnitude > 0 && !isDefence)
        {Anm.PlayAnimationLoop(RunBAnimationName);  isRun = true;}
        else if(moveDir.magnitude > 0 && isDefence){Anm.PlayAnimationLoop(GuardRunAnimationName); isRun = false;}
        else if(!isDefence){Anm.PlayAnimationLoop(IdleBAnimationName); stand = true; isRun = false;}
        else if(isDefence){Anm.PlayAnimationLoop(GuardAnimationName); stand = true; isRun = false;}
        hor = Input.GetAxisRaw("Horizontal");}
#endregion
    public void Stop(){rb.velocity = new Vector3(0f, 0f, 0f);}
    public void Flip()
    {
        if (hor > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (hor < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }   
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
    public void OnCollisionEnter(Collision collision)
    {if (collision.gameObject.CompareTag("Collider")){Run = 1;}
    if (collision.gameObject.CompareTag("Question")){Attention = true;}}
    public void OnCollisionExit(Collision collision)
    {if (collision.gameObject.CompareTag("Collider")){Run = 5;}
    if (collision.gameObject.CompareTag("Question")){Attention = false;}}
    
}