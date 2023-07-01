using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class hero_rule : MonoBehaviour
{
    private Rigidbody rb;

    public float velocita_movimento=1;

    float heading=0;
    public Transform cam;
    Vector2 input;
    public Transform img_hero;
    public bool stand = true;

    public float input_horizontal;
    bool bool_dir_dx=true;
    [SpineAnimation][SerializeField] private string WalkAnimationName;
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;

    Vector3 camF,camR,moveDir;
public static hero_rule instance;
       
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
    input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    input = Vector2.ClampMagnitude(input, 1);

    camF = cam.forward;
    camR = cam.right;

    camF.y = 0;
    camR.y = 0;
    camF = camF.normalized;
    camR = camR.normalized;
    moveDir = camR * input.x + camF * input.y;

    if (moveDir.magnitude > 0)
    {
        Walk();
        stand = false;

    }
    else
    {
        Idle();
        stand = true;
    }

    input_horizontal = Input.GetAxisRaw("Horizontal");
    Flip();
}

    void FixedUpdate()
    {
        rb.MovePosition(transform.position+moveDir*0.1f*velocita_movimento);
    }

    

    private void Flip()
    {
        if (bool_dir_dx && input_horizontal > 0f || !bool_dir_dx && input_horizontal < 0f)
        {
            bool_dir_dx = !bool_dir_dx;
            Vector3 localScale = img_hero.localScale;
            localScale.x *= -1f;
            img_hero.localScale = localScale;
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
}
