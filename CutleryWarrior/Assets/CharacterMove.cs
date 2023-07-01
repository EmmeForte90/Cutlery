using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class CharacterMove : MonoBehaviour
{
   
    private Rigidbody rb;

    public float Speed = 1;
    public float SpeedB = 2;
    public float Run = 5;
    public Transform cam;
    Vector2 input;
    public Transform SpriteHero;
    public bool stand = true;
    public bool isRun = false;
    public bool isBattle = false;
    public bool inputCTR = false;
    public bool Interact = false;
    public float hor;
    bool Right = true;
    [SpineAnimation][SerializeField] private string WalkAnimationName;
    [SpineAnimation][SerializeField] private string RunAnimationName;
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    [SpineAnimation][SerializeField] private string TalkingAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;

    Vector3 camF,camR,moveDir;
public static CharacterMove instance;
       
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

    if(Interact)
    {
        Talking();
    }
    
    if(!inputCTR)
    {
        if(!Interact)
    {
    input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    input = Vector2.ClampMagnitude(input, 1);
    
    if(!isBattle)
    {
    if(Input.GetButton("Fire3"))
    {
        isRun = true;
    } 
    if (Input.GetButtonUp("Fire3"))
    {
        isRun = false;
    }
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
       

    }
    else
    {

        Idle();
        stand = true;
    }



    hor = Input.GetAxisRaw("Horizontal");
    }
    }
}

    void FixedUpdate()
    {
        if(!inputCTR)
    {
        if(!Interact && !isRun)
    {
        rb.MovePosition(transform.position + moveDir * 0.1f * Speed);
    } else if(!Interact && isRun && !isBattle)
    {
        rb.MovePosition(transform.position + moveDir * 0.1f * Run);
    }else if(!Interact && isBattle)
    {
        rb.MovePosition(transform.position + moveDir * 0.1f * SpeedB);
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
private void OnTriggerEnter(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("Collider"))
    {
        Idle();
        Stop();
    }

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
                    //_spineAnimationState.Event += HandleEvent;
                }
}

 public void Running()
{
    if (currentAnimationName != RunAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, RunAnimationName, true);
                    currentAnimationName = RunAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
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
}

