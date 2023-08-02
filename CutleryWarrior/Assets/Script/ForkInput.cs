using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class ForkInput : MonoBehaviour
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
    public static ForkInput instance;
  
    [Header("Attacks")]
    private bool isAttacking = false;
    public float comboTimer = 0.5f; // Tempo di attesa tra le combo

    public float DodgeSTimer = 0.5f; // Tempo di attesa tra le combo
    private float lastAttackTime = 0f;
    private float DodgeTime = 0f;

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
    public float hor;
    bool Right = true;
    bool StopM = false;

    [Header("Dodge")]    
    
    private DodgeController DodgeController;

    private KnockbackController knockbackController;
    
    public GameObject Bullet;

    public Transform BPoint;


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
    if(!DuelManager.instance.inputCTR)
    {
    Flip();
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
    } else if (isRun && !StopM)
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

    //DODGE
        // Rileva l'input del tasto spazio
        if (Input.GetButtonDown("Fire2") && Time.time - DodgeTime > DodgeSTimer)
        {
            Dodge();
            DodgeFAnm();
                    
            DodgeTime = Time.time; // Aggiorna l'ultimo momento di attacco

        }
    
    //Attack
        if ((Input.GetMouseButtonDown(0) && ((float)Input.mousePosition.x / (float)Screen.width) > (140f / 800f) 
        || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) && DuelManager.instance.CharacterID == 1
        && DuelManager.instance.FcurrentMP > 20)
            {
                Stop();
                PlayAnimation(Atk3AnimationName);
                DuelManager.instance.FcurrentMP -= 20;
                Instantiate(Bullet, BPoint.position, Bullet.transform.rotation);
                //GameObject newParticle = Instantiate<GameObject>(currentCategory.GetChild(index).GetChild(0).gameObject);
                //newParticle.transform.SetParent(particleParent, false);
                //Destroy(newParticle, 10);
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
        if(!DuelManager.instance.inputCTR)
    {

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
        if (Right && hor < 0f || !Right && hor > 0f)
        {
            Right = !Right;
            Vector3 localScale = SpriteHero.localScale;
            localScale.x *= -1f;
            SpriteHero.localScale = localScale;
        }
    }

private void OnCollisionEnter(Collision collision)
{
    // Controlliamo se il player ha toccato il collider
    if (collision.gameObject.CompareTag("Collider"))
    {Idle();  StopM = true; isRun = false;}// rb.AddForce(-transform.position + moveDir * 0.1f * SpeedB);}
    else {StopM = false;}
}

private void OnCollisionExit(Collision collision)
{
    // Controlliamo se il player ha smesso di collidere con l'oggetto
    if (collision.gameObject.CompareTag("Collider"))
    {StopM = false;}
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
                    _spineAnimationState.SetAnimation(0, GuardAnimationName, true);
                    currentAnimationName = GuardAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}

public void GuardHitAnm()
{
    if (currentAnimationName != GuardHitAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, GuardHitAnimationName, false);
                    currentAnimationName = GuardHitAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}
 public void Atk1Anm()
{
    if (currentAnimationName != Atk1AnimationName)
                {
                    _spineAnimationState.SetAnimation(0, Atk1AnimationName, false);
                    currentAnimationName = Atk1AnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                //_spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}

 public void Atk2Anm()
{
    if (currentAnimationName != Atk2AnimationName)
                {
                    _spineAnimationState.SetAnimation(0, Atk2AnimationName, false);
                    currentAnimationName = Atk2AnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}
 public void Atk3Anm()
{
    if (currentAnimationName != Atk3AnimationName)
                {
                    _spineAnimationState.SetAnimation(0, Atk3AnimationName, false);
                    currentAnimationName = Atk3AnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }                _spineAnimationState.GetCurrent(0).Complete += OnAttackAnimationComplete;

}
 public void DodgeFAnm()
{
    if (currentAnimationName != DodgeFAnimationName)
                {
                    _spineAnimationState.SetAnimation(1, DodgeFAnimationName, true);
                    currentAnimationName = DodgeFAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }_spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;

}
 public void DodgeBAnm()
{
    if (currentAnimationName != DodgeBAnimationName)
                {
                    _spineAnimationState.SetAnimation(1, DodgeBAnimationName, true);
                    currentAnimationName = DodgeBAnimationName;
                }_spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;

}

 public void Walk()
{
    if (currentAnimationName != WalkAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, WalkAnimationName, true);
                    currentAnimationName = WalkAnimationName;
                }

}
 public void Running()
{
    if (currentAnimationName != RunAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, RunAnimationName, true);
                    currentAnimationName = RunAnimationName;
                }

}

 public void Idle()
{
    if (currentAnimationName != IdleAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, IdleAnimationName, true);
                    currentAnimationName = IdleAnimationName;
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
}