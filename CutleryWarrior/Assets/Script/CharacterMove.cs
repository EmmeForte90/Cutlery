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
    [SpineAnimation][SerializeField]  string Atk4AnimationName;
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
        if(Interact){Anm.PlayAnimationLoop(TalkingAnimationName);}
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
        if (!isRun){Anm.PlayAnimationLoop(WalkAnimationName); stand = false;} 
        else if (isRun){Anm.PlayAnimationLoop(RunAnimationName); stand = false;}
        }
        else{Anm.PlayAnimationLoop(IdleAnimationName); stand = true;}
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
        if (!isRun){Anm.PlayAnimationLoop(WalkBAnimationName); stand = false;} 
        else if (isRun){Anm.PlayAnimationLoop(RunBAnimationName); stand = false;}
        }
        else{Anm.PlayAnimationLoop(IdleBAnimationName); stand = true;}
        hor = Input.GetAxisRaw("Horizontal");     
    //DODGE
        // Rileva l'input del tasto spazio
        if (Input.GetButtonDown("Fire2") && Time.time - DodgeTime > DodgeSTimer)
        {
            Dodge();
            //DodgeFAnm();      
            DodgeTime = Time.time; // Aggiorna l'ultimo momento di attacco
        }
    
    //Attack
        if ((Input.GetMouseButtonDown(0) && ((float)Input.mousePosition.x / (float)Screen.width) > (140f / 800f) 
        || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) && DuelManager.instance.CharacterID == 1
        && DuelManager.instance.FcurrentMP > 20)
            {
                Stop();
                Anm.PlayAnimation(Atk4AnimationName);
                DuelManager.instance.FcurrentMP -= 20;
                
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
    {Anm.PlayAnimationLoop(WalkBAnimationName); stand = false;} 
    else if (isRun && !StopM)
    {Anm.PlayAnimationLoop(RunBAnimationName);stand = false;}
    } 
    else
    {Anm.PlayAnimationLoop(IdleBAnimationName);stand = true;}
    hor = Input.GetAxisRaw("Horizontal");

    //DODGE
        if (Input.GetButtonDown("Fire2") && Time.time - DodgeTime > DodgeSTimer)
        {
            Dodge();
            //DodgeFAnm();      
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
                Anm.PlayAnimation(Atk1AnimationName); 
                DuelManager.instance.KcurrentMP -= DuelManager.instance.KcostMP;
                //_spineAnimationState.Event += HandleEvent;                //Debug.Log("Combo 1");
                break;
            case 2:
                Stop();
                Anm.PlayAnimation(Atk2AnimationName); 
                DuelManager.instance.KcurrentMP -= DuelManager.instance.KcostMP;
                //_spineAnimationState.Event += HandleEvent;                //Debug.Log("Combo 2");
                break;
            case 3:
                Stop();
                Anm.PlayAnimation(Atk3AnimationName); 
                DuelManager.instance.KcurrentMP -= DuelManager.instance.KcostMP;
                //_spineAnimationState.Event += HandleEvent;
                break;
            default:
                comboCount = 1;
                Stop();
                Anm.PlayAnimation(Atk1AnimationName); 
                DuelManager.instance.KcurrentMP -= DuelManager.instance.KcostMP;
                //_spineAnimationState.Event += HandleEvent;
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

    public void Posebattle(){Anm.PlayAnimation(IdleBAnimationName);}
    public void TakeCamera(){cam = GameObject.FindWithTag("MainCamera").transform;}
    public void Idle(){Anm.PlayAnimationLoop(IdleAnimationName);}
    public void Allarm(){Anm.PlayAnimationLoop(AllarmAnimationName);}

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
    /*IEnumerator StopVFX()
    {
        yield return new WaitForSeconds(1f);
        SlashV.gameObject.SetActive(false);
        SlashH.gameObject.SetActive(false);
        SlashB.gameObject.SetActive(false);
    }*/
    public void Direction(){transform.localScale = new Vector3(-1, 1,1);}

    public void OnCollisionEnter(Collision collision)
    {
        // Controlliamo se il player ha toccato il collider
        if (collision.gameObject.CompareTag("Collider")){Anm.PlayAnimationLoop(IdleAnimationName); StopM = true;}// rb.AddForce(-transform.position + moveDir * 0.1f * SpeedB);}
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

}