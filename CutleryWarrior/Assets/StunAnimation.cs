using System.Collections;
using UnityEngine;
using Spine.Unity;

public class StunAnimation : MonoBehaviour
{
    public Spine.AnimationState spineAnimationState;    
    public SkeletonAnimation skeletonAnimation;
    public GameObject VFX;
    public bool isPlayer;
    [SpineAnimation][SerializeField]  string StunAnimationName;
    public void Awake()
    {spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        spineAnimationState = skeletonAnimation.AnimationState;}
    public void Start()
    {
         if(!isPlayer){StartCoroutine(Death()); spineAnimationState.SetAnimation(0, StunAnimationName, false);}
        else if(isPlayer){StunLoop();}
    }
    private void OnDisable(){VFX.SetActive(false);}
    private void OnEnable() 
    {
        VFX.SetActive(true);
         if(!isPlayer){StartCoroutine(Death()); spineAnimationState.SetAnimation(0, StunAnimationName, false);}
        else if(isPlayer){StunLoop();}
    }
    void Update(){}    
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    public void StunLoop(){spineAnimationState.SetAnimation(0, StunAnimationName, true);}
}