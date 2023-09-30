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
    public float Speed = 5.0f;
    public float SpeedB = 3.0f;
    public float Run = 3.0f;
    private Transform cam;
    Vector2 input;
    public Transform SpriteHero;
    private bool stand = true;
    public bool isRun = false;
    private bool StopRun = false;
    public bool inputCTR = false;
    public bool Interact = false;
    public bool Win = false;
    private int comboCount = 0;
    private bool canAttack = true;
    public float comboCooldown = 0.3f; // Tempo di cooldown tra le combo in secondi
    
    private Vector3 moveDirection = Vector3.zero;
    private bool isDodging = false;
    [Header("Dodge")]

    public float dodgeSpeed = 20.0f;
    public float dodgeDuration = 1f;
    public float cooldownTime = 0.5f;
    private bool canDodge = true;
    public float stumpCooldown = 1f;
    private bool Stump = true;
    public bool warning = false;
    private float hor;
    private float defense;
    private float danno_subito;
    private bool poisonState = false;
    private int TimePoison = 5;   
    private bool Right = true; 
    public bool isMoving;
   
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
    [SpineAnimation][SerializeField]  string StumpAnimationName;
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
    [Header("VFX")]
    public GameObject VFXDodge;
    public GameObject VFXHhitShield;
    public GameObject VFXStump;
    public GameObject VFXPoison;
    public GameObject VFXHurt;
    [Header("Attacks")]
    private bool isAttacking = false;
    public float comboTimer = 0.5f; // Tempo di attesa tra le combo
    public float DodgeSTimer = 0.5f; // Tempo di attesa tra le combo
    private float lastAttackTime = 0f;
    private float DodgeTime = 0f;
    private CharacterController characterController; // Riferimento al CharacterController
    public float gravity = 9.81f;  // Gravità personalizzata, puoi regolarla come desideri
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
        characterController = GetComponent<CharacterController>();
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
        {
        /*if(!StopRun){if(Run >= 8 || Run <= 8){Run = 8;}}
        else if(StopRun){if(Run >= 8 || Run <= 8){Run = 5;}}*/
        switch(IDAction){
        case 0:  
        ////////////////////////////////////////
        SimpleMove();
        break;
        ////////////////////////////////////////
        case 1: 
        /*if(!StopRun){if(Run >= 8 || Run <= 8){Run = 8;}}
        else if(StopRun){if(Run >= 8 || Run <= 8){Run = 5;}}*/
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
        //
        /*camF = cam.forward;camR = cam.right;camF.y = 0;camR.y = 0;
        camF = camF.normalized;camR = camR.normalized;  
        moveDir = camR * input.x + camF * input.y;*/
        //
        // Calcola la direzione del movimento in base agli input dell'utente
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        if(Input.GetButton("Fire3")){isRun = true; GameManager.instance.isRun = true;} 
        if (Input.GetButtonUp("Fire3")){isRun = false; GameManager.instance.isRun = false;} 
        // Gestisci la gravità
        if (!characterController.isGrounded)
        {
            // Applica la gravità personalizzata se necessario
            Vector3 gravityVector = new Vector3(0, -gravity, 0);
            characterController.Move(gravityVector * Time.deltaTime);
        }
        if (!inputCTR)
        {
        // Trasforma la direzione del movimento in base alla rotazione del personaggio
        moveDirection = transform.TransformDirection(moveDirection);
        //
        if (!Interact && !isRun && isMoving)//Sta camminando
        {Anm.PlayAnimationLoop(WalkAnimationName); stand = false; 
        characterController.Move(moveDirection * Speed * Time.deltaTime);
        } 
        else if (!Interact && isRun && isMoving)//Sta correndo
        {Anm.PlayAnimationLoop(RunAnimationName); stand = false; 
        characterController.Move(moveDirection * Run * Time.deltaTime);
        }
        else if (!Interact && !isRun && !isMoving)//Sta fermo
        {Anm.PlayAnimationLoop(IdleAnimationName); stand = true;}
        hor = Input.GetAxisRaw("Horizontal");  
        isMoving = Mathf.Abs(hor) > 0.0f || Mathf.Abs(verticalInput) > 0.0f;
        }
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
        {Dodge(); PlayerStats.instance.K_curMP -= 5;}

    if (isDodging){characterController.Move(moveDirection * Time.fixedDeltaTime);}
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
    private void Dodge()
    {
        if (!isDodging)
        {
            isDodging = true;
            canDodge = false;
            if (hor > 0f){moveDirection = new Vector3(0f, 0f, dodgeSpeed);PlayComboAnimation(DodgeFAnimationName);}
            else if (hor < 0f){moveDirection = new Vector3(0f, 0f, -dodgeSpeed);PlayComboAnimation(DodgeFAnimationName);}
            Invoke("StopDodge", dodgeDuration);
            Invoke("ResetDodgeCooldown", cooldownTime);
        }
    }
    private void StopDodge(){isDodging = false; moveDirection = Vector3.zero;}
    private void ResetDodgeCooldown(){canDodge = true;}
    
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
        //SpecialeKnife
        if (Input.GetMouseButtonDown(1) && Stump)
        {StumpK(); PlayerStats.instance.K_curMP -= 50;}
        
    //Attack
        if (Input.GetMouseButtonDown(0) && canAttack && PlayerStats.instance.K_curMP > 20 && Stump)
        {HandleComboAttackK(); PlayerStats.instance.K_curMP -= PlayerStats.instance.K_CostMP;} 
        else {AudioManager.instance.PlayUFX(10);}
    }
       
    private void HandleComboAttackK()
    {
        comboCount = (comboCount % 3) + 1;
        PlayComboAnimation("Battle/attack_" + comboCount.ToString());
        canAttack = false;
        StartCoroutine(ComboCooldown());
    }
    private void StumpK()
    {
        Stump = false;
        StartCoroutine(StumpKTime());
    }
    
    private IEnumerator StumpKTime()
    {
        yield return new WaitForSeconds(1);
        Anm.PlayAnimationLoop(IdleBAnimationName);
        Stump = true;
    }  
#endregion
#region Spoon
    public void SpoonB()
    {
           MoveB();  
    //DODGE
        // Rileva l'input del tasto spazio
        if (Input.GetMouseButtonDown(1) && PlayerStats.instance.S_curMP > 20)
        {isDefence = true;}

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
    private void PlayDodgeAnimation(string animationName)
    {if (_skeletonAnimation != null){_skeletonAnimation.AnimationState.SetAnimation(0, animationName, true);}}
    private IEnumerator ComboCooldown()
    {
        yield return new WaitForSeconds(comboCooldown);
        canAttack = true;
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
            if(!canDodge)
            {PlayerStats.instance.F_curHP -= danno_subito;
            AudioManager.instance.PlaySFX(8);
            Instantiate(VFXHurt, transform.position, transform.rotation);
            Anm.TemporaryChangeColor(Color.red);
            }
            break;
            case 1:
            PlayerStats.instance.K_curHP -= danno_subito;
            break; 
            case 2:
            if(!isDefence)
            {PlayerStats.instance.S_curHP -= danno_subito;
            AudioManager.instance.PlaySFX(8);
            Instantiate(VFXHurt, transform.position, transform.rotation);
            Anm.TemporaryChangeColor(Color.red);
            }else if(isDefence){
                PlayerStats.instance.S_curMP -= PlayerStats.instance.S_CostMP;
                Instantiate(VFXHhitShield, transform.position, transform.rotation);
            }
            break;
        }
        //Debug.Log("danno "+ danno_subito);
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
  
    #region Move
    //For Knife
        public void MoveB()
        {if(cam == null){cam = GameObject.FindWithTag("MainCamera").transform;}
        Flip();  
        ////////////////////////////////
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        // Gestisci la gravità
        if (!characterController.isGrounded)
        {
            // Applica la gravità personalizzata se necessario
            Vector3 gravityVector = new Vector3(0, -gravity, 0);
            characterController.Move(gravityVector * Time.deltaTime);
        }
        if (!inputCTR)
        {
        // Trasforma la direzione del movimento in base alla rotazione del personaggio
        moveDirection = transform.TransformDirection(moveDirection);
        //
        if (isDefence && !isMoving && Stump)
        {Anm.PlayAnimationLoop(GuardAnimationName); stand = false;} 
        else if (!isDefence && isMoving && Stump)
        {Anm.PlayAnimationLoop(RunBAnimationName); stand = false; 
        characterController.Move(moveDirection * SpeedB * Time.deltaTime);}
        else if (isDefence && isMoving && Stump)
        {Anm.PlayAnimationLoop(GuardWalkAnimationName); stand = false; 
        characterController.Move(moveDirection * Speed * Time.deltaTime);}
        else if (!isDefence && !isMoving && Stump)
        {Anm.PlayAnimationLoop(IdleBAnimationName); stand = true;}
        else if (!Stump)
        {Anm.PlayAnimationLoop(StumpAnimationName); stand = true;}
        hor = Input.GetAxisRaw("Horizontal");  
        isMoving = (Mathf.Abs(hor) > 0.0f || Mathf.Abs(verticalInput) > 0.0f) && !isDefence;
        if (poisonState){StartCoroutine(Poi());}     
        }
        }
#endregion
    public void Stop(){rb.velocity = new Vector3(0f, 0f, 0f);}
    public void Flip()
    {
        if (hor > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (hor < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }   
    public void RightD(){transform.localScale = new Vector3(1, 1,1);}
    public void LeftD(){transform.localScale = new Vector3(-1, 1,1);}
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
    public void OnCollisionEnter(Collision collision)
    {if (collision.gameObject.CompareTag("Collider")){StopRun = true;}
    if (collision.gameObject.CompareTag("Question")){Attention = true;}
    /*if (collision.gameObject.CompareTag("Scene"))
    {transform.localScale = new Vector3(-1, 1,1);}*/
    }

    public void OnCollisionExit(Collision collision)
    {if (collision.gameObject.CompareTag("Collider")){StopRun = false;}
    if (collision.gameObject.CompareTag("Question")){Attention = false;}}
    
}