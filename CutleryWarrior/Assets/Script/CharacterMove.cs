using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Spine.Unity;
using Spine;

public class CharacterMove : MonoBehaviour
{
    [Header("Character")]
    public bool fork;
    public bool knife;
    public bool spoon;
    [Tooltip("0 - Exploration, 1 - Battle")]
    public int IDAction = 0; //Che tipo di personaggio è

    private Rigidbody rb;
        
    [Header("Move")]
    public float Speed = 1;
    public float SpeedB = 2;
    public float Run = 5;
    private Transform cam;
    Vector2 input;
    public Transform SpriteHero;
    [HideInInspector]
    private bool stand = true;
    [HideInInspector]
    public bool isRun = false;
    public bool isBattle = false;
    public bool inputCTR = false;
    [HideInInspector]
    public bool Interact = false;
    private float hor;
    private bool Right = true;    
    private bool StopM = false;

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
    [SpineAnimation][SerializeField]  string GuardAnimationName;
    [SpineAnimation][SerializeField]  string GuardHitAnimationName;
    [SpineAnimation][SerializeField]  string DodgeFAnimationName;
    [SpineAnimation][SerializeField]  string DodgeBAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    private SwitchCharacter Switch;
    private Transform Player;

    Vector3 camF,camR,moveDir;
        
    [Header("Dodge and Knockback")]    
    
    private DodgeController DodgeController;
    private KnockbackController knockbackController;
        
    [HideInInspector]
    public GameObject Bullet;
    [HideInInspector]
    public Transform BPoint;
    [HideInInspector]
    public GameObject SlashV;
    [HideInInspector]
    public GameObject SlashH;
    [HideInInspector]
    public GameObject SlashB;
    [HideInInspector]
    public bool isDefence = false;

    [Header("Attacks")]
    private bool isAttacking = false;
    public float comboTimer = 0.5f; // Tempo di attesa tra le combo
    public float DodgeSTimer = 0.5f; // Tempo di attesa tra le combo
    private float lastAttackTime = 0f;
    private float DodgeTime = 0f;
    private int comboCount = 0;

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



    // Update is called once per frame
    public void Update()
    {
        switch(IDAction)
        {
        case 0:  
        ////////////////////////////////////////
        SimpleMove();
        break;
        ////////////////////////////////////////
        case 1: 
        if(fork && !knife && !spoon) {ForkB();} //Se è forchetta
        else if(!fork && knife && !spoon) {KnifeB();} //Se è Coltello
        else if(!fork && !knife && spoon) {SpoonB();} //Se è Cucchiaio
        break;
        }
    }
#region MoveExploration
    public void SimpleMove()
    {
        if(cam == null){cam = GameObject.FindWithTag("MainCamera").transform;}
        Flip();  
        if(Interact){Talking();}
        ////////////////////////////////
        if(!inputCTR)
        {
        if(!Interact)
        {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
        
        if(!isBattle)
        {
        if(Input.GetButton("Fire3")){isRun = true;} 
        if (Input.GetButtonUp("Fire3")){isRun = false;}
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
        if (!isRun){Walk(); stand = false;} 
        else if (isRun){Running(); stand = false;}
        }
        else{Idle(); stand = true;}
        hor = Input.GetAxisRaw("Horizontal");      
        }}
    }
#endregion

#region Fork
    public void ForkB()
    {
    if(!inputCTR)
    {
        if(cam == null){cam = GameObject.FindWithTag("MainCamera").transform;}
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
        if (!isRun){WalkB(); stand = false;} 
        else if (isRun){RunningB(); stand = false;}
        }
        else{IdleB(); stand = true;}
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
            }
    }
    }
#endregion

#region Knife
    public void KnifeB()
    {
    if(!inputCTR)
    {
    Flip();
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
    if (!isRun)
    {WalkB(); stand = false;} 
    else if (isRun && !StopM)
    {RunningB();stand = false;}
    } 
    else
    {IdleB();stand = true;}
    hor = Input.GetAxisRaw("Horizontal");

    //DODGE
        if (Input.GetButtonDown("Fire2") && Time.time - DodgeTime > DodgeSTimer)
        {
            Dodge();
            DodgeFAnm();      
            DodgeTime = Time.time; // Aggiorna l'ultimo momento di attacco
        }
    
    //Attack
        if (Input.GetButtonDown("Fire1") && Time.time - lastAttackTime > comboTimer && DuelManager.instance.CharacterID == 2 
        && DuelManager.instance.KcurrentMP > 20)
    {
        comboCount++;
        switch (comboCount)
        {
            case 1:
                Stop();
                PlayAnimation(Atk1AnimationName); 
                DuelManager.instance.KcurrentMP -= DuelManager.instance.KcostMP;
                _spineAnimationState.Event += HandleEvent;                //Debug.Log("Combo 1");
                break;
            case 2:
                Stop();
                PlayAnimation(Atk2AnimationName);
                DuelManager.instance.KcurrentMP -= DuelManager.instance.KcostMP;
                _spineAnimationState.Event += HandleEvent;                //Debug.Log("Combo 2");
                break;
            case 3:
                Stop();
                PlayAnimation(Atk3AnimationName);
                DuelManager.instance.KcurrentMP -= DuelManager.instance.KcostMP;
                _spineAnimationState.Event += HandleEvent;
                break;
            default:
                comboCount = 1;
                Stop();
                PlayAnimation(Atk1AnimationName);
                DuelManager.instance.KcurrentMP -= DuelManager.instance.KcostMP;
                _spineAnimationState.Event += HandleEvent;
                break;
        }

        lastAttackTime = Time.time; // Aggiorna l'ultimo momento di attacco
    }
    }
    }
#endregion

#region Spoon
    public void SpoonB()
    {
        //Ancora non è pronto
    }
#endregion

    public void Posebattle(){PlayAnimation(IdleBAnimationName);}
    public void TakeCamera(){cam = GameObject.FindWithTag("MainCamera").transform;}

    public void FixedUpdate()
    {
    if(!inputCTR)
    {
    if(!Interact && !isRun)
    {rb.MovePosition(transform.position + moveDir * 0.1f * Speed);} 
    else if(!Interact && isRun && !isBattle && !StopM)
    {rb.MovePosition(transform.position + moveDir * 0.1f * Run);
    }else if(!Interact && isBattle && !StopM)
    {rb.MovePosition(transform.position + moveDir * 0.1f * SpeedB);}
    }}

    public void Stop(){rb.velocity = new Vector3(0f, 0f, 0f);}

    public void Flip()
    {
        if (hor > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (hor < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }
    IEnumerator StopVFX()
    {
        yield return new WaitForSeconds(1f);
        SlashV.gameObject.SetActive(false);
        SlashH.gameObject.SetActive(false);
        SlashB.gameObject.SetActive(false);

    }
    public void Direction(){transform.localScale = new Vector3(-1, 1,1);}

    public void OnCollisionEnter(Collision collision)
    {
        // Controlliamo se il player ha toccato il collider
        if (collision.gameObject.CompareTag("Collider")){Idle();  StopM = true;}// rb.AddForce(-transform.position + moveDir * 0.1f * SpeedB);}
        else {StopM = false;}
    }

    public void OnCollisionExit(Collision collision)
    {
        // Controlliamo se il player ha smesso di collidere con l'oggetto
        if (collision.gameObject.CompareTag("Collider")){StopM = false;}
    }
    private void Dodge()
        {
            Vector3 DodgeDirection = transform.position;
            DodgeController.ApplyDodge(DodgeDirection);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Animation
#region Animations
private void PlayAnimation(string animationName)
    {
        _skeletonAnimation.state.SetAnimation(0, animationName, false);
        _skeletonAnimation.state.GetCurrent(0).Complete += OnAttackAnimationComplete;
    }
 public void Idle()
{
    if (currentAnimationName != IdleAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, IdleAnimationName, true);
                    currentAnimationName = IdleAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }
}
 public void Walk()
{
    if (currentAnimationName != WalkAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, WalkAnimationName, true);
                    currentAnimationName = WalkAnimationName;
                    _spineAnimationState.Event += HandleEvent;
                }
}

 public void Running()
{
    if (currentAnimationName != RunAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, RunAnimationName, true);
                    currentAnimationName = RunAnimationName;
                    _spineAnimationState.Event += HandleEvent;
                }
}

public void IdleB()
{
    if (currentAnimationName != IdleBAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, IdleBAnimationName, true);
                    currentAnimationName = IdleBAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }
}
 public void WalkB()
{
    if (currentAnimationName != WalkBAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, WalkBAnimationName, true);
                    currentAnimationName = WalkBAnimationName;
                    _spineAnimationState.Event += HandleEvent;
                }
}

 public void RunningB()
{
    if (currentAnimationName != RunBAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, RunBAnimationName, true);
                    currentAnimationName = RunBAnimationName;
                    _spineAnimationState.Event += HandleEvent;
                }
}
 public void Talking()
{
    if (currentAnimationName != TalkingAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, TalkingAnimationName, true);
                    currentAnimationName = TalkingAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }
}

public void Allarm()
{
    if (currentAnimationName != AllarmAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, AllarmAnimationName, false);
                    currentAnimationName = AllarmAnimationName;
                }
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
private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    // Remove the event listener
    trackEntry.Complete -= OnAttackAnimationComplete;

    // Clear the track 1 and reset to the idle animation
    _skeletonAnimation.state.ClearTrack(1);
    _skeletonAnimation.state.SetAnimation(0, IdleAnimationName, true);
}
#endregion
    void HandleEvent (TrackEntry trackEntry, Spine.Event e) {
    //Normal VFX
    if (e.Data.Name == "walk"){AudioManager.instance.PlayUFX(0);}
    //Normal VFX
    if (e.Data.Name == "slashV"){AudioManager.instance.PlayUFX(3); SlashV.gameObject.SetActive(true); StartCoroutine(StopVFX());}
    //
    if (e.Data.Name == "slashH"){AudioManager.instance.PlayUFX(3); SlashH.gameObject.SetActive(true); StartCoroutine(StopVFX());}
    //
    if (e.Data.Name == "slashB"){AudioManager.instance.PlayUFX(3); SlashB.gameObject.SetActive(true); StartCoroutine(StopVFX());}
}}