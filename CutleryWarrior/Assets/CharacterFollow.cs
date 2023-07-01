using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class CharacterFollow : MonoBehaviour
{ public Transform player;
    public Transform img_hero;
    public float followSpeed = 5f;
    public float RunSpeed = 6f;
    public float stoppingDistance = 1f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody characterRigidbody;
    private bool isFollowing;
    private bool isGrounded;
    private bool isWalking;
    [SpineAnimation][SerializeField] private string WalkAnimationName;    
    [SpineAnimation][SerializeField] private string RunAnimationName;
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;

public static CharacterFollow instance;

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
    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
// Verifica se il personaggio è a terra
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        Flip();

        if (isFollowing)
        {
            // Calcola la direzione verso cui il personaggio deve muoversi
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;
            direction.Normalize();

            // Calcola la distanza dal giocatore
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > stoppingDistance)
            {
                if (!CharacterMove.instance.isRun)
                {
                if (!isWalking)
                {
                    isWalking = true;
                    Walk();
                }

                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                characterRigidbody.MovePosition(transform.position + direction * followSpeed * Time.deltaTime);
                } 
                
                if (CharacterMove.instance.isRun)
                {
                if (!isWalking)
                {
                    isWalking = true;
                    Run();
                }

                // Muovi il personaggio verso il giocatore solo se la distanza supera la soglia di arresto
                characterRigidbody.MovePosition(transform.position + direction * RunSpeed * Time.deltaTime);
                } 
            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    Idle();
                }

                // Il personaggio è vicino al giocatore, smette di muoversi
                isFollowing = false;
            }
        }
        else 
        {
            // Verifica se il giocatore si è mosso
            if (transform.position != player.position)
            {
                // Il giocatore si è mosso, il personaggio riprende a seguirlo
                isFollowing = true;
            }
        }
    }
private void Flip()
    {
        if (CharacterMove.instance.SpriteHero.localScale.x > 0f)
        {
    
            transform.localScale = new Vector3(1, 1,1);
    
        } else if (CharacterMove.instance.SpriteHero.localScale.x < 0f)
        {
            transform.localScale = new Vector3(-1, 1,1);

        }
    }
    private void FixedUpdate()
    {
        // Evita che il personaggio cada per terra durante il movimento
        if (isGrounded)
        {
            characterRigidbody.velocity = Vector3.zero;
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

 public void Run()
{
    if (currentAnimationName != RunAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, RunAnimationName, true);
                    currentAnimationName = RunAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }
}
}