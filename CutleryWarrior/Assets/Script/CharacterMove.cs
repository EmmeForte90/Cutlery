using System.Collections;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    [Header("Character")]
    float horizontalInput;
    float verticalInput;
    [Tooltip("Scegli personaggi 0.Fork 1.Knife 2.Spoon")]
    [Range(0, 2)]
    public int kindCh;
    [Tooltip("0 - Exploration, 1 - Battle")]
    public int IDAction = 0; //Che tipo di personaggio è
    public GameObject Esclamation;
    public bool Attention;
    private Rigidbody rb;  
    [Header("Move")]
    public float Speed = 5.0f;
    public float SpeedB = 3.0f;
    public float Run = 3.0f;
    private Transform cam;
    public bool isRun = false;
    public bool inputCTR = false;
    public bool Interact = false;
    public bool Win = false;
    private int comboCount = 0;
    private bool canAttack = true;
    public float comboCooldown = 0.5f; // Tempo di cooldown tra le combo in secondi
    public float comboCooldownK = 0.3f; // Tempo di cooldown tra le combo in secondi
    private bool isAttacking = false; // Aggiunto il flag per controllare se il personaggio sta attaccando
    private bool top = true;
    private bool StopRanm = false;
    private bool isCharging = false; // Flag per il colpo caricato
    public float chargeStartTime; // Tempo di inizio della carica
    public float chargeTime;
    public float maxChargeTime = 1f; // Tempo massimo di carica
    private Vector3 moveDirection = Vector3.zero;
    public bool isDodging = false;
    public bool isKnock = false;       
    ////////////////////////////////////////
    private CapsuleCollider capsuleCollider; // Riferimento al capsule collider
    public float expandedRadius = 3.0f; // Raggio del capsule collider quando è allargato
    private float originalRadius; // Raggio originale del capsule collider
    [Header("Dodge")]
    public float dodgeSpeed = 20.0f;
    public float dodgeDuration = 1f;
    public float cooldownTime = 0.5f;
    private bool canDodge = true;
    public bool canKnock = true;
    private bool Stump = true;
    public bool warning = false;
    private float hor;
    private float danno_subito;
    private bool poisonState = false;
    private bool rustState = false;
    private bool stunState = false;
    private bool sleepState = false;
    private bool deathState = false;
    private int TimePoison = 5;   
    private int TimeRust = 50;   
    public float TimeStun = 5;
    public float TimeSleep = 5;

    public bool isMoving;
    [Header("Animations")]
    [SpineAnimation][SerializeField]  string WalkAnimationName;
    [SpineAnimation][SerializeField]  string WalkUPAnimationName;
    [SpineAnimation][SerializeField]  string RunAnimationName;
    [SpineAnimation][SerializeField]  string RunUPAnimationName;
    [SpineAnimation][SerializeField]  string IdleAnimationName;
    [SpineAnimation][SerializeField]  string IdleUPAnimationName;
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    [SpineAnimation][SerializeField]  string RunBAnimationName;
    [SpineAnimation][SerializeField]  string TalkingAnimationName;
    [SpineAnimation][SerializeField]  string AllarmAnimationName;
    [SpineAnimation][SerializeField]  string ChargeFAnimationName;
    [SpineAnimation][SerializeField]  string ReleaseChargeFAnimationName;
    [SpineAnimation][SerializeField]  string GuardAnimationName;
    [SpineAnimation][SerializeField]  string GuardWalkAnimationName;
    [SpineAnimation][SerializeField]  string DodgeFAnimationName;
    [SpineAnimation][SerializeField]  string StumpAnimationName;
    [SpineAnimation][SerializeField]  string StunAnimationName;
    [SpineAnimation][SerializeField]  string SleepAnimationName;
    [SpineAnimation][SerializeField]  string DieAnimationName;
    [SpineAnimation][SerializeField]  string OpenBookAnimationName;
    [SpineAnimation][SerializeField]  string CloseBookAnimationName;
    [SpineAnimation][SerializeField]  string WinAnimationName;
    [SpineAnimation][SerializeField]  string KnockbackAnimationName;
    [SpineAnimation][SerializeField]  string UpKnockbackAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    public bool isDefence = false;
    public AnimationManager Anm;
    [Header("Dodge and Knockback")]    
    private DodgeController DodgeController;
    private KnockbackController knockbackController;       
    [Header("VFX Knife")]
    public GameObject SlashV;
    public GameObject SlashH;
    public GameObject SlashB;

    [Header("VFX Spoon")]
    public GameObject ShiledT;
    public GameObject ShiledB;
    public GameObject Crush;
    public GameObject VFXHhitShield;
    [Header("VFX")]
    public GameObject VFXPoison;
    public GameObject VFXPoison_I;
    public GameObject VFXRust;
    public GameObject VFXRust_I;
    public GameObject VFXSleep;
    public GameObject VFXSleep_I;
    public GameObject VFXStun;
    public GameObject VFXStun_I;
    public GameObject VFXHurt;
    public GameObject VFXCharge;
    public GameObject VFXChargeComplete;
    public GameObject VFXChargeMAX;
    public GameObject VFXCantATK;
    public GameObject BP;

    [Header("Attacks")]
    public Scrollbar KChargeATK;
    public GameObject TimeBar;
    private CharacterController characterController; // Riferimento al CharacterController
    public float gravity = 9.81f;  // Gravità personalizzata, puoi regolarla come desideri
    public static CharacterMove instance;
public void Awake()
    {
         if (instance == null)
        {instance = this;}
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}  
        cam = GameManager.instance.vcam.transform;      
        capsuleCollider = GetComponent<CapsuleCollider>();
        originalRadius = capsuleCollider.radius; // Salva il raggio originale
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;        
        knockbackController = GetComponent<KnockbackController>();
        DodgeController = GetComponent<DodgeController>();
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        rb.freezeRotation = true;
        //if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();}
        //Stats = GameObject.Find("Stats").GetComponent<PlayerStats>();
        VFXCantATK.SetActive(false);
    }
   
    public void Update()
    {
        if(Interact){Anm.PlayAnimationLoop(TalkingAnimationName);}
        if(warning){Anm.PlayAnimationLoop(AllarmAnimationName);}
        //
        if(Attention){Esclamation.SetActive(true);}
        else if(!Attention){Esclamation.SetActive(false);}
        //
        if(isCharging){chargeTime = Time.time - chargeStartTime;}
        //
        if(!inputCTR)
        {
        /*if(!StopRun){if(Run >= 8 || Run <= 8){Run = 8;}}
        else if(StopRun){if(Run >= 8 || Run <= 8){Run = 5;}}*/
        switch(IDAction){
        case 0:  
        ////////////////////////////////////////
        SimpleMove(); RestoreStuts();
        break;
        ////////////////////////////////////////
        case 1: 
        switch (kindCh)
        {
            case 0:
            ForkB();
            if(PlayerStats.instance.F_curMP > 19){VFXCantATK.SetActive(false);}
            break;
            case 1:
            KnifeB();
            if(PlayerStats.instance.K_curMP > 19){VFXCantATK.SetActive(false);}
            KChargeATK.size = chargeTime / maxChargeTime;
            KChargeATK.size = Mathf.Clamp(KChargeATK.size, 0.01f, 1);
            break; 
            case 2:
            SpoonB();
            if(PlayerStats.instance.S_curMP > 19){VFXCantATK.SetActive(false);}
            break;
        }
        break;
        ////////////////////////////////////////
        case 2: 
        StunLoop();
        break;
        ////////////////////////////////////////
        case 3: 
        Sleep();
        break;
        ////////////////////////////////////////
        case 4: 
        Death();
        break;
        ////////////////////////////////////////
        case 5: 
        WinFunc();
        break;
        }}
    }

    public void RestoreStuts()
    {
        VFXStun.SetActive(false);
        VFXPoison.SetActive(false);
        VFXSleep.SetActive(false);
        VFXRust.SetActive(false);
    }
    
#region MoveExploration
    public void SimpleMove()
    {
        if(cam == null){cam = GameManager.instance.vcam.transform;}
        Flip();  
        ////////////////////////////////
        if(!Interact)
        {if(!warning)
        {if(!Win)
        {
        //
        VFXCantATK.SetActive(false);
        //
        // Calcola la direzione del movimento in base agli input dell'utente
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        if(Input.GetButton("Fire3")){isRun = true; GameManager.instance.isRun = true; StopRanm = true;} 
        if (Input.GetButtonUp("Fire3")){isRun = false; GameManager.instance.isRun = false; StopRanm = false;
        } 
        //
        if (verticalInput == 0 && horizontalInput == 0 && !top && isRun && StopRanm)
        {Anm.PlayAnimationLoop(IdleUPAnimationName);} 
        else if (verticalInput == 0 && horizontalInput == 0 && top && isRun && StopRanm )
        {Anm.PlayAnimationLoop(IdleAnimationName);} 
        
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
        {
        if (verticalInput > 0)//Sta fermo
        {Anm.PlayAnimationLoop(WalkUPAnimationName); top = false; } 
        else if (verticalInput < 0)//Sta fermo
        {Anm.PlayAnimationLoop(WalkAnimationName); top = true; } 
        else if (horizontalInput > 0 && !top)//Sta fermo
        {Anm.PlayAnimationLoop(WalkUPAnimationName); top = false; } 
        else if (horizontalInput < 0 && !top)//Sta fermo
        {Anm.ClearAnm(); Anm.PlayAnimationLoop(WalkUPAnimationName); top = false; } 
         else if (horizontalInput > 0 && top)//Sta fermo
        {Anm.PlayAnimationLoop(WalkAnimationName); top = true; } 
        else if (horizontalInput < 0 && top)//Sta fermo
        {Anm.PlayAnimationLoop(WalkAnimationName); top = true; } 
           
        //stand = false;  
        characterController.Move(moveDirection * Speed * Time.deltaTime);
        } 
        else if (!Interact && isRun && isMoving)//Sta correndo
        {
        if (verticalInput > 0)//Sta fermo
        {Anm.PlayAnimationLoop(RunUPAnimationName); top = false; } 
        else if (verticalInput < 0)//Sta fermo
        {Anm.PlayAnimationLoop(RunAnimationName); top = true; }
        else if (horizontalInput > 0 && !top)//Sta fermo
        {Anm.PlayAnimationLoop(RunUPAnimationName); top = false; } 
        else if (horizontalInput < 0 && !top)//Sta fermo
        {Anm.PlayAnimationLoop(RunUPAnimationName); top = false; } 
         else if (horizontalInput > 0 && top)//Sta fermo
        {Anm.PlayAnimationLoop(RunAnimationName); top = true; } 
        else if (horizontalInput < 0 && top)//Sta fermo
        {Anm.PlayAnimationLoop(RunAnimationName); top = true; }  

        //stand = false; 
        characterController.Move(moveDirection * Run * Time.deltaTime);
        }
        else if (!Interact && !isRun && !isMoving)//Sta fermo
        {if (verticalInput == 0 && !top)//Sta fermo
        {Anm.PlayAnimationLoop(IdleUPAnimationName);} 
        else if (verticalInput == 0 && top)//Sta fermo
        {Anm.PlayAnimationLoop(IdleAnimationName);} }
        //stand = true;}
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
        if (Input.GetMouseButtonDown(1)|| Input.GetButton("Fire2") && canDodge && PlayerStats.instance.F_curMP > 2)
        {Dodge(); PlayerStats.instance.F_curMP -= 2;}
        else if(PlayerStats.instance.F_curMP < 20)
        {VFXCantATK.SetActive(true);}

    if (isDodging){characterController.Move(moveDirection * Time.fixedDeltaTime);}
    //Attack
        if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire1") && canAttack && PlayerStats.instance.F_curMP > 20)
            {
                HandleComboAttackF();
                Stop();
                AnimationManager.instance.VFX = true;
                PlayerStats.instance.F_curMP -= PlayerStats.instance.F_CostMP;  
            }else if(PlayerStats.instance.F_curMP < 20){AudioManager.instance.PlayUFX(10); VFXCantATK.SetActive(true);}     
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
    private void StopDodge(){isDodging = false; moveDirection = Vector3.zero; PlayDodgeAnimation(RunBAnimationName);}
    private void ResetDodgeCooldown(){canDodge = true;}
    private void StopAtkF()
    {
    canAttack = true; inputCTR = false; 
    moveDirection = Vector3.zero; 
    if(isMoving){PlayDodgeAnimation(RunBAnimationName);}
    else {PlayDodgeAnimation(IdleBAnimationName);}
    }
    private void HandleComboAttackF()
    {
        comboCount = (comboCount % 3) + 1;
        Stop();
        PlayComboAnimation("Battle/attack_" + comboCount.ToString());
        canAttack = false;
        inputCTR = true;
        Invoke("StopAtkF", comboCooldown);
        //StartCoroutine(ComboCooldown());
    }
#endregion
#region Knife
    public void KnifeB()
{
    if (!isCharging)
    {
        MoveB();
    } 
    else if(isCharging)
    {
        if (chargeTime >= maxChargeTime){VFXChargeMAX.SetActive(true); VFXCharge.SetActive(false);}
        else if (chargeTime < maxChargeTime){VFXChargeMAX.SetActive(false); VFXCharge.SetActive(true);}
    }

    // Inizia a caricare il colpo
    if (Input.GetMouseButtonDown(1)|| Input.GetButton("Fire2") && !isCharging && PlayerStats.instance.K_curMP > 20)
    {
        TimeBar.SetActive(true);
        KChargeATK.transform.position = BP.transform.position;
        isCharging = true;
        chargeStartTime = Time.time;
        Anm.PlayAnimationLoop(ChargeFAnimationName);
    }
    else if (PlayerStats.instance.K_curMP < 20){AudioManager.instance.PlayUFX(10); VFXCantATK.SetActive(true);} 
   

    // Rilascia il colpo caricato
    if (Input.GetMouseButtonUp(1)|| Input.GetButtonUp("Fire2") && isCharging)
    {
        //chargeTime = Time.time - chargeStartTime;
        if (chargeTime >= maxChargeTime)
        {
            ReleaseChargedShot(); // Funzione da implementare per il colpo caricato
            TimeBar.SetActive(false);
            VFXChargeComplete.SetActive(true);
            PlayerStats.instance.K_curMP -= 30;
        }
        else
        {
            // Il tempo di carica non è sufficiente, puoi fare qualcosa qui (ad esempio un feedback visivo o sonoro).
            isCharging = false;
            TimeBar.SetActive(false);
            VFXCharge.SetActive(false);
            VFXChargeMAX.SetActive(false);
            VFXChargeComplete.SetActive(false);
        }
    }

    // Esegue un colpo normale
    if ((Input.GetMouseButtonDown(0) || Input.GetButton("Fire1")) && canAttack && 
    PlayerStats.instance.K_curMP > 20 && !isCharging && !isAttacking)
{
    Stop();
    HandleComboAttackK();
    canAttack = false;
    PlayerStats.instance.K_curMP -= PlayerStats.instance.K_CostMP;
    StartCoroutine(ComboCooldownK());
}
else if (PlayerStats.instance.K_curMP < 20)
{
    AudioManager.instance.PlayUFX(10); 
    VFXCantATK.SetActive(true);
}
}

    private void HandleComboAttackK()
{
    comboCount = (comboCount % 3) + 1;
    PlayComboAnimation("Battle/attack_" + comboCount.ToString());
    isAttacking = true; // Imposta il flag per indicare che il personaggio sta attaccando
    inputCTR = true;
}

private IEnumerator ComboCooldownK()
{
    moveDirection = Vector3.zero;
    yield return new WaitForSeconds(comboCooldownK);
    isAttacking = false; // Resetta il flag quando l'animazione è completa
    //SlashV.SetActive(false); SlashH.SetActive(false); SlashB.SetActive(false);
    inputCTR = false;
    canAttack = true;
}

    private void ReleaseChargedShot()
{
    // Implementa qui il comportamento del colpo caricato
    // Assicurati di reimpostare isCharging dopo il rilascio del colpo caricato.
    VFXChargeMAX.SetActive(false);
    VFXCharge.SetActive(false);
    VFXChargeComplete.SetActive(false);
    Anm.PlayAnimationLoop(ReleaseChargeFAnimationName);
    StumpK();
}

private void StumpK()
{
    Stump = false;
    isCharging = false;
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
        if (Input.GetMouseButtonDown(1)|| Input.GetButton("Fire2") && PlayerStats.instance.S_curMP > 20)
        {isDefence = true; ExpandCapsule();} // Allarga il capsule}}
        else if (PlayerStats.instance.S_curMP < 10)
        {AudioManager.instance.PlayUFX(10); VFXCantATK.SetActive(true);}     

        // Verifica se il tasto del mouse è stato rilasciato
        if (Input.GetMouseButtonUp(1)|| Input.GetButtonUp("Fire2")){isDefence = false; ShrinkCapsule();}

        // Continua ad eseguire l'azione mentre il tasto del mouse è premuto
        //if (isDefence){Anm.PlayAnimationLoop(GuardAnimationName);}
    
    //Attack
       // Verifica se il tasto del mouse è stato premuto
         if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire1") && !isAttacking && canAttack)
        {
            if (PlayerStats.instance.S_curMP > 20)
            {
                Stop();
                HandleComboAttackS();
                canAttack = false;
                PlayerStats.instance.S_curMP -= PlayerStats.instance.S_CostMP;
            }
            else
            {
                AudioManager.instance.PlayUFX(10);
                VFXCantATK.SetActive(true);
            }
        }
    }


private void HandleComboAttackS()
{
        comboCount = (comboCount % 3) + 1;
        Stop();
        PlayComboAnimation("Battle/attack_" + comboCount.ToString());
        canAttack = false;
        inputCTR = true;
        if(comboCount < 3){Invoke("StopAtkS", 0.4f);}
        else if(comboCount >= 3){Invoke("StopAtkS1", 1.3f);}
        //StartCoroutine(ComboCooldown());
}
    private void StopAtkS(){canAttack = true; inputCTR = false; moveDirection = Vector3.zero;
    if(isMoving){PlayDodgeAnimation(RunBAnimationName);}
    else {PlayDodgeAnimation(IdleBAnimationName);}}
    private void StopAtkS1(){canAttack = true;  inputCTR = false; 
    moveDirection = Vector3.zero;  
    if(isMoving){PlayDodgeAnimation(RunBAnimationName);}
    else {PlayDodgeAnimation(IdleBAnimationName);}}
    void ExpandCapsule(){capsuleCollider.radius = expandedRadius;}
    void ShrinkCapsule(){capsuleCollider.radius = originalRadius;}
 
#endregion

    private void PlayComboAnimation(string animationName)
    {if (_skeletonAnimation != null){_skeletonAnimation.AnimationState.SetAnimation(0, animationName, false);}}
    private void PlayDodgeAnimation(string animationName)
    {if (_skeletonAnimation != null){_skeletonAnimation.AnimationState.SetAnimation(0, animationName, true);}}
    
    public void Posebattle(){Anm.PlayAnimation(IdleBAnimationName);}
    public void OpenBook(){Anm.PlayAnimationExplore(OpenBookAnimationName);}
    public void CloseBook(){Anm.PlayAnimationExplore(CloseBookAnimationName);}
    public void TakeCamera(){cam = GameManager.instance.vcam.transform;}
    public void Idle(){Anm.PlayAnimationLoop(IdleAnimationName); VFXCantATK.SetActive(false);}
    public void Allarm(){warning = true;}
    public void StopAllarm(){warning = false;}
    public void TakeDamage(float damage)
{
    if(!deathState){
    if (!isKnock)
    {
    switch (kindCh)
    {
        case 0:
        if (canDodge)
            {danno_subito = Mathf.Max(damage - PlayerStats.instance.F_defense, 0);
            PlayerStats.instance.F_curHP -= danno_subito;
            PlayerStats.instance.F_curRage += 5;
            AudioManager.instance?.PlaySFX(8);
            Instantiate(VFXHurt, transform.position, transform.rotation);
            if(sleepState){GameManager.instance.RestoreSleepF();}
            //print("sleepState" + sleepState);
            Anm?.TemporaryChangeColor(Color.red);}
            //Debug.Log("danno " +  Stats.F_curHP);
            break;
        case 1:
            danno_subito = Mathf.Max(damage - PlayerStats.instance.K_defense, 0);
            PlayerStats.instance.K_curHP -= danno_subito;
            PlayerStats.instance.K_curRage += 5;
            AudioManager.instance?.PlaySFX(8);
            Instantiate(VFXHurt, transform.position, transform.rotation);
            if(sleepState){GameManager.instance.RestoreSleepK();}
            //print("sleepState" + sleepState);
            Anm?.TemporaryChangeColor(Color.red);
            break;
        case 2:
            if (!isDefence)
            {
                danno_subito = Mathf.Max(damage - PlayerStats.instance.S_defense, 0);
                PlayerStats.instance.S_curHP -= danno_subito;
                PlayerStats.instance.S_curRage += 5;
                AudioManager.instance?.PlaySFX(8);
                Instantiate(VFXHurt, transform.position, transform.rotation);
                if(sleepState){SleepRestored();}
                Anm?.TemporaryChangeColor(Color.red);
                //Debug.Log("danno " +  Stats.S_curHP);
            }
            else if (isDefence)
            {
                PlayerStats.instance.S_curMP -= PlayerStats.instance.S_CostMP;
                AudioManager.instance?.PlaySFX(12);
                if(sleepState){GameManager.instance.RestoreSleepS();}
                //print("sleepState" + sleepState);
                Instantiate(VFXHhitShield, BP.transform.position, transform.rotation);
            }
            break;
    }}}
}

    #region Stato Veleno
    public void Poison(){Anm.ChangeColorP(); VFXPoison.SetActive(true);VFXPoison_I.SetActive(true); poisonState = true;}
 
    private IEnumerator Poi()
    {
        yield return new WaitForSeconds(TimePoison);
        if(poisonState){
        switch (kindCh)
        {
            case 0:
            GameManager.instance.RestoreF(); poisonState = false;VFXPoison.SetActive(false);VFXPoison_I.SetActive(false);
            break;
            case 1:
            GameManager.instance.RestoreK(); poisonState = false;VFXPoison.SetActive(false);VFXPoison_I.SetActive(false);
            break; 
            case 2:
            GameManager.instance.RestoreS(); poisonState = false;VFXPoison.SetActive(false);VFXPoison_I.SetActive(false);
            break;
        }}
    }
    #endregion

    #region Stato Rust
    public void Rust(){Anm.ChangeColorR(); VFXRust.SetActive(true);VFXRust_I.SetActive(true); rustState = true;}
    private IEnumerator Rus()
    {
        yield return new WaitForSeconds(TimeRust);
        if(rustState){
        switch (kindCh)
        {
            case 0:
            GameManager.instance.RestoreRustF(); rustState = false; VFXRust.SetActive(false);VFXRust_I.SetActive(false);
            break;
            case 1:
            GameManager.instance.RestoreRustK(); rustState = false; VFXRust.SetActive(false);VFXRust_I.SetActive(false);
            break; 
            case 2:
            GameManager.instance.RestoreRustS(); rustState = false; VFXRust.SetActive(false);VFXRust_I.SetActive(false);
            break;
        }}
    }
    #endregion

    #region Stato Stun
    public void StunLoop(){if(!stunState){Anm.ClearAnm(); Anm.PlayAnimationLoop(StunAnimationName); 
    VFXStun.SetActive(true); VFXStun_I.SetActive(false); stunState = true; isRun = false; Invoke("StunRestored", TimeStun);}}
    private void StunRestored()
    {
        if(stunState){
        switch (kindCh)
        {
            case 0:
            GameManager.instance.RestoreStunF(); stunState = false; VFXStun.SetActive(false);VFXStun_I.SetActive(false);
            break;
            case 1:
            GameManager.instance.RestoreStunK(); stunState = false; VFXStun.SetActive(false);VFXStun_I.SetActive(false);
            break; 
            case 2:
            GameManager.instance.RestoreStunS(); stunState = false; VFXStun.SetActive(false);VFXStun_I.SetActive(false);
            break;
        }
        IDAction = 1; 
    }}
    #endregion

    #region Stato Sleep
    public void Sleep(){if(!sleepState){ Anm.ClearAnm(); 
    Anm.PlayAnimationLoop(SleepAnimationName); VFXSleep.SetActive(true); VFXSleep_I.SetActive(true);sleepState = true; isRun = false;}}
    public void SleepRestored(){ VFXSleep.SetActive(false); VFXSleep_I.SetActive(false); sleepState = false; IDAction = 1;}
    #endregion

    #region Death
    public void Death(){Anm.ClearAnm(); Anm.PlayAnimationLoop(DieAnimationName); deathState = true; isRun = false;}
    public void RestoreDeath(){Anm.ClearAnm(); Anm.PlayAnimationLoop(IdleBAnimationName); deathState = false; IDAction = 1;}
    #endregion
    public void ReCol(){Anm.ResetColor();}
    
    #region Win
    public void WinFunc(){Anm.PlayAnimationLoop(WinAnimationName);}
    public void RestoreWin(){Anm.ClearAnm(); Anm.PlayAnimationLoop(IdleAnimationName); IDAction = 0;}
    #endregion
  
    #region Move
    
        public void MoveB()
        {if(cam == null){cam = GameManager.instance.vcam.transform;}
        Flip();  
        ////////////////////////////////
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
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
        {Anm.PlayAnimationLoop(GuardAnimationName);} 
        else if (!isDefence && isMoving && Stump)
        {Anm.PlayAnimationLoop(RunBAnimationName);  
        characterController.Move(moveDirection * SpeedB * Time.deltaTime);}
        else if (isDefence && isMoving && Stump)
        {Anm.PlayAnimationLoop(GuardWalkAnimationName); 
        characterController.Move(moveDirection * Speed * Time.deltaTime);}
        else if (!isDefence && !isMoving && Stump)
        {Anm.PlayAnimationLoop(IdleBAnimationName);}
        else if (!Stump)
        {Anm.PlayAnimationLoop(StumpAnimationName);}
        if(!isDodging || !canAttack){hor = Input.GetAxisRaw("Horizontal"); 
        isMoving = (Mathf.Abs(hor) > 0.0f || Mathf.Abs(verticalInput) > 0.0f) && !isDefence;}
        if (poisonState){StartCoroutine(Poi());} 
        if (rustState){StartCoroutine(Rus());}     
        }
        }
#endregion
    public void Stop(){rb.velocity = new Vector3(0f, 0f, 0f); verticalInput = 0; horizontalInput = 0;}
    public void Flip()
    {
        if (hor > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (hor < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }   
    public void RightD(){transform.localScale = new Vector3(1, 1,1);}
    public void LeftD(){transform.localScale = new Vector3(-1, 1,1);}
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
    public void OnCollisionEnter(Collision collision)
    {if (collision.gameObject.CompareTag("Collider")){}//StopRun = true;}
    if (collision.gameObject.CompareTag("Question")){Attention = true;}
    }
    public void OnCollisionExit(Collision collision)
    {if (collision.gameObject.CompareTag("Collider")){}//StopRun = false;}
    if (collision.gameObject.CompareTag("Question")){Attention = false;}}
    public void Knockback()
    {
        if (!isKnock && canKnock)
        {
            isKnock = true;
            GameManager.instance.NotTouchOption = true;
            canKnock = false;
            inputCTR = true;

            moveDirection = Vector3.zero;

            if (transform.localScale.x > 0f)
            {
                moveDirection = new Vector3(0f, 0f, -15f);
            }
            else if (transform.localScale.x < 0f)
            {
                moveDirection = new Vector3(0f, 0f, 15f);
            }
            else if (transform.localScale.x == 0f)
            {
                moveDirection = new Vector3(0f, 0f, -15f);
            }

            // Applica la forza di knockback al Rigidbody
            //rb.AddForce(moveDirection, ForceMode.Impulse);
            //characterController.Move(moveDirection * Time.deltaTime);
            StartCoroutine(ApplyKnockback(moveDirection));

            PlayComboAnimation(KnockbackAnimationName);
            Invoke("StopKnock", 0.5f);
            Invoke("ResetKnockCooldown", 2);
        }
    }
     private IEnumerator ApplyKnockback(Vector3 force)
    {
        float elapsed = 0f;

        while (elapsed < 1)
        {
            characterController.Move(force * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void StopKnock()
    {
        isKnock = false;
        PlayComboAnimation(UpKnockbackAnimationName);
        inputCTR = true;
    }

    private void ResetKnockCooldown()
    {
        canKnock = true;
        moveDirection = Vector3.zero;
        GameManager.instance.NotTouchOption = false;
        inputCTR = false;
    }
    
}