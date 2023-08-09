using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class CharacterFollow : MonoBehaviour
{ 
    private Transform Player;
    public Transform Fork;
    public Transform Spoon;
    public Transform Knife;
    private SwitchCharacter Switch;

    public float followSpeed = 5f;
    public float RunSpeed = 6f;
    public float stoppingDistance = 1f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody characterRigidbody;
    private bool isFollowing;
    private bool isGrounded;
    private bool isWalking;
    [SpineAnimation][SerializeField]  string WalkAnimationName;    
    [SpineAnimation][SerializeField]  string RunAnimationName;
    [SpineAnimation][SerializeField]  string IdleAnimationName;
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    [SpineAnimation][SerializeField]  string AllarmAnimationName;

    private string currentAnimationName;
    private float distance;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;

    public static CharacterFollow instance;

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
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        }

    
    public void Update()
    {
        if(Switch.isElement1Active)
        {Player = Spoon;Flip();}
        else if(Switch.isElement2Active)
        {Player = Fork;Flip();} 
        else if(Switch.isElement3Active)
        {Player = Knife;Flip();} 

        // Verifica se il personaggio è a terra
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        if (!isFollowing){Idle(); isWalking = false;}


        if ((transform.position - Player.transform.position).sqrMagnitude > stoppingDistance * stoppingDistance)
        {isFollowing = true;}

        if ((transform.position - Player.transform.position).sqrMagnitude < stoppingDistance * stoppingDistance)
        {isFollowing = false;}



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
                if (!CharacterMove.instance.isRun)
                {
                if (!isWalking)
                {isWalking = true; Walk();}

                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                characterRigidbody.MovePosition(transform.position + direction * followSpeed * Time.deltaTime);
                } 
                
                if (CharacterMove.instance.isRun)
                {
                if (!isWalking)
                {isWalking = true; Run();}

                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                characterRigidbody.MovePosition(transform.position + direction * RunSpeed * Time.deltaTime);
                } 
            }
            else if (!CharacterMove.instance.isRun)
            {
                if (isWalking)
                {isWalking = false; Idle();}
                // Il personaggio è vicino al giocatore, smette di muoversi
                isFollowing = false;
            }
        }
        
    }
    public void Direction(){transform.localScale = new Vector3(-1, 1,1);}
    public void Posebattle(){PlayAnimation(IdleBAnimationName);}
    private void Flip()
    {
        if (Player.localScale.x > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (Player.localScale.x < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }
    public void FixedUpdate()
    {
        // Evita che il personaggio cada per terra durante il movimento
        if (isGrounded)
        {characterRigidbody.velocity = Vector3.zero;}
    }

#if(UNITY_EDITOR)
#region Gizmos
private void OnDrawGizmos()
    {
    Gizmos.color = Color.red;
    // disegna un Gizmo che rappresenta il Raycast
    //Gizmos.DrawLine(transform.position, transform.position + new Vector3(transform.localScale.x, 0, 0) * wallDistance);
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
#endregion
#endif

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
                    //_spineAnimationState.Event += HandleEvent;
                }
}

 public void Run()
{
    if (currentAnimationName != RunAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, RunAnimationName, true);
                    currentAnimationName = RunAnimationName;
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
private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    // Remove the event listener
    trackEntry.Complete -= OnAttackAnimationComplete;

    // Clear the track 1 and reset to the idle animation
    _skeletonAnimation.state.ClearTrack(1);
    _skeletonAnimation.state.SetAnimation(0, IdleAnimationName, true);
}
}