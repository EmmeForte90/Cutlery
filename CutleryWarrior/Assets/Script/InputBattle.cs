using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class InputBattle : MonoBehaviour
{
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
    public static InputBattle instance;
  
    [Header("Attacks")]
     [SerializeField] private float comboTimeThreshold = 0.5f;

    private bool isAttacking = false;
    private float lastAttackTime = 0f;
    private int comboCount = 0;

    private Rigidbody rb;

    [Header("Movements")]
    public float Speed = 1;
    public float Run = 3;
    public Transform cam;
    Vector2 input;
    public Transform SpriteHero;
    public bool stand = true;
    public bool isRun = false;
    public bool inputCTR = false;
    public float hor;
    bool Right = true;
    bool StopM = false;

    [Header("Dodge")]    
    
    private DodgeController DodgeController;

    private KnockbackController knockbackController;

   
    Vector3 camF,camR,moveDir;
       
private void Awake()
    {
         if (instance == null)
        {
            instance = this;
        }
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {
            Debug.LogError("Componente SkeletonAnimation non trovato!");
        }        
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;
        knockbackController = GetComponent<KnockbackController>();
        DodgeController = GetComponent<DodgeController>();
        }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
{
    Flip();
    if(!inputCTR)
    {
        
    input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    input = Vector2.ClampMagnitude(input, 1);
    
    if(Input.GetButton("Fire3"))
    {
        isRun = true;
    } 
    if (Input.GetButtonUp("Fire3"))
    {
        isRun = false;
    }
    
    
    camF = cam.forward;
    camR = cam.right;

    camF.y = 0;
    camR.y = 0;
    camF = camF.normalized;
    camR = camR.normalized;
    
    moveDir = camR * input.x + camF * input.y;
    

    if (moveDir.magnitude > 0)
    {
        if (!isRun)
    { 
        Walk();
        stand = false;
    } else if (isRun)
    { 
        Running();
        stand = false;
    }
    } else
    {
        Idle();
        stand = true;
    }
    hor = Input.GetAxisRaw("Horizontal");
    
    // Input per attaccare
// Controlla se il giocatore preme il pulsante di attacco
        // Controlla se il giocatore preme il pulsante di attacco
        // Controlla se il giocatore preme il pulsante di attacco
       
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            if (Time.time - lastAttackTime > comboTimeThreshold)
            {
                // Resettare il conteggio del combo se è passato troppo tempo dall'ultimo attacco
                comboCount = 0;
            }

            if (comboCount == 0)
            {
                // Riproduci l'animazione di attacco base
                //PlayAnimation(Atk1AnimationName);
                _skeletonAnimation.AnimationName = Atk1AnimationName;
                Debug.Log("Combo0");

            }
            else
            {
                // Riproduci l'animazione di combo corrispondente al conteggio
                //PlayAnimation(Atk2AnimationName + comboCount.ToString());
                _skeletonAnimation.AnimationName = Atk2AnimationName;
                Debug.Log("Combo1");

            }

            lastAttackTime = Time.time;
            comboCount++;

            isAttacking = true;
        }

        if (isAttacking && Time.time - lastAttackTime > _skeletonAnimation.state.GetCurrent(0).Animation.Duration)
        {
            // L'attacco è terminato quando è passato il tempo dell'animazione corrente
            isAttacking = false;
        }



    }
    }
    
    private void Dodge()
    {
        Vector3 DodgeDirection = transform.position;
        DodgeController.ApplyDodge(DodgeDirection);
    }

    void FixedUpdate()
    {
        if(!inputCTR)
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//DODGE
        // Rileva l'input del tasto spazio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dodge();
            DodgeFAnm();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Move
        if(!isRun)
    {
        rb.MovePosition(transform.position + moveDir * 0.1f * Speed);
    } else if(isRun && !StopM)
    {
        rb.MovePosition(transform.position + moveDir * 0.1f * Run);
    }
    }
    }

     public void Stop()
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
    }

    private void Flip()
    {
        if (Right && hor > 0f || !Right && hor < 0f)
        {
            Right = !Right;
            Vector3 localScale = SpriteHero.localScale;
            localScale.x *= -1f;
            SpriteHero.localScale = localScale;
        }
    }

private void OnCollisionEnter(Collision collision)
{
    // Controlliamo se il player ha colliso con l'oggetto
    if (collision.gameObject.CompareTag("Collider"))
    {
        StopM = true;
        Vector3 knockbackDirection = transform.position - collision.transform.position;
        knockbackController.ApplyKnockback(knockbackDirection);
    }
}

private void OnCollisionExit(Collision collision)
{
    // Controlliamo se il player ha smesso di collidere con l'oggetto
    if (collision.gameObject.CompareTag("Collider"))
    {
        StopM = false;
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Animation

private void PlayAnimation(string animationName)
    {
        _skeletonAnimation.state.SetAnimation(0, animationName, false);
        _skeletonAnimation.state.GetCurrent(0).Complete += OnAttackAnimationComplete;
    }

public void GuardAnm()
{
    if (currentAnimationName != GuardAnimationName)
                {
                    _spineAnimationState.SetAnimation(1, GuardAnimationName, true);
                    currentAnimationName = GuardAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;

}

public void GuardHitAnm()
{
    if (currentAnimationName != GuardHitAnimationName)
                {
                    _spineAnimationState.SetAnimation(1, GuardHitAnimationName, false);
                    currentAnimationName = GuardHitAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;

}
 public void Atk1Anm()
{
    if (currentAnimationName != Atk1AnimationName)
                {
                    _spineAnimationState.SetAnimation(1, Atk1AnimationName, false);
                    currentAnimationName = Atk1AnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;

}

 public void Atk2Anm()
{
    if (currentAnimationName != Atk2AnimationName)
                {
                    _spineAnimationState.SetAnimation(1, Atk2AnimationName, false);
                    currentAnimationName = Atk2AnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;

}
 public void Atk3Anm()
{
    if (currentAnimationName != Atk3AnimationName)
                {
                    _spineAnimationState.SetAnimation(1, Atk3AnimationName, false);
                    currentAnimationName = Atk3AnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;

}
 public void DodgeFAnm()
{
    if (currentAnimationName != DodgeFAnimationName)
                {
                    _spineAnimationState.SetAnimation(1, DodgeFAnimationName, false);
                    currentAnimationName = DodgeFAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }_spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;

}
 public void DodgeBAnm()
{
    if (currentAnimationName != DodgeBAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, DodgeBAnimationName, false);
                    currentAnimationName = DodgeBAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }_spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}

 public void Walk()
{
    if (currentAnimationName != WalkAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, WalkAnimationName, false);
                    currentAnimationName = WalkAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }_spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}
 public void Running()
{
    if (currentAnimationName != RunAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, RunAnimationName, false);
                    currentAnimationName = RunAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }_spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}

 public void Idle()
{
    if (currentAnimationName != IdleAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, IdleAnimationName, true);
                    currentAnimationName = IdleAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }_spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}
private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    // Remove the event listener
    trackEntry.Complete -= OnAttackAnimationComplete;

    // Clear the track 1 and reset to the idle animation
    _skeletonAnimation.state.ClearTrack(0);
    _skeletonAnimation.state.SetAnimation(0, IdleAnimationName, false);
}
}