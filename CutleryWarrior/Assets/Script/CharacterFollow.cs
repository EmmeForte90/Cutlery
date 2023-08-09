using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class CharacterFollow : MonoBehaviour
{   
    [Tooltip("0 - Exploration, 1 - Battle")]
    public int IDAction = 0; //Che tipo di personaggio è

    [Header("Character")]
    public bool fork;
    public Transform Fork;
    public bool knife;
    public Transform Knife;
    public bool spoon;
    public Transform Spoon;
   
    private Transform Player;
    private SwitchCharacter Switch;
    private CharacterMove F_b;
    private CharacterMove S_b;
    private CharacterMove K_b;

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
    public AnimationManager Anm;
    [HideInInspector]
    public bool Allarming;
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
        Player = GameObject.FindGameObjectWithTag("F_Player").transform;
        F_b = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        K_b = GameObject.Find("S_Player").GetComponent<CharacterMove>();
        S_b = GameObject.Find("K_Player").GetComponent<CharacterMove>();
        }

    
    public void Update()
    {
        switch(IDAction)
        {
        case 0:  
        ////////////////////////////////////////
        if(!Allarming)
        {SimpleMove();
        if(Switch.isElement1Active){Player = Spoon;Flip();}
        else if(Switch.isElement2Active){Player = Fork;Flip();} 
        else if(Switch.isElement3Active){Player = Knife;Flip();}} 
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
    // Verifica se il personaggio è a terra
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        if (!isFollowing){Anm.PlayAnimationLoop(IdleAnimationName); isWalking = false;}

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
                if (!F_b.isRun || !S_b.isRun || !K_b.isRun)
                {
                if (!isWalking)
                {isWalking = true; Anm.PlayAnimationLoop(WalkAnimationName);}

                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                characterRigidbody.MovePosition(transform.position + direction * followSpeed * Time.deltaTime);
                } 
                
                if (F_b.isRun || S_b.isRun || K_b.isRun)
                {
                if (!isWalking)
                {isWalking = true; Anm.PlayAnimationLoop(RunAnimationName);}

                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                characterRigidbody.MovePosition(transform.position + direction * RunSpeed * Time.deltaTime);
                } 
            }
            else if (!F_b.isRun || !S_b.isRun || !K_b.isRun)
            {
                if (isWalking)
                {isWalking = false; Anm.PlayAnimationLoop(IdleAnimationName);}
                // Il personaggio è vicino al giocatore, smette di muoversi
                isFollowing = false;
            }
        }
    }
    #endregion

    #region Fork
    public void ForkB()
    {
    Anm.PlayAnimationLoop(IdleBAnimationName);
    }
#endregion

    #region Knife
    public void KnifeB()
    {
    Anm.PlayAnimationLoop(IdleBAnimationName);
    }
#endregion

    #region Spoon
    public void SpoonB()
    {
    Anm.PlayAnimationLoop(IdleBAnimationName);
    }
#endregion

    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
    public void Posebattle(){Anm.PlayAnimation(IdleBAnimationName);}
    public void Idle(){Anm.PlayAnimationLoop(IdleAnimationName);}
    public void Allarm(){Anm.PlayAnimationLoop(AllarmAnimationName); Allarming = true;}    
    public void StopAllarm(){Allarming = false;}    
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
}