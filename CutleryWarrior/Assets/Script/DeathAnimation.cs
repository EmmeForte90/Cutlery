using System.Collections;
using UnityEngine;
using Spine.Unity;

public class DeathAnimation : MonoBehaviour
{
    public Spine.AnimationState spineAnimationState;    
    public SkeletonAnimation skeletonAnimation;
    public bool isPlayer;
    [SpineAnimation][SerializeField]  string DeathAnimationName;
    public void Awake()
    {spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        spineAnimationState = skeletonAnimation.AnimationState;}
    public void Start()
    {
         if(!isPlayer){StartCoroutine(Death()); spineAnimationState.SetAnimation(0, DeathAnimationName, false);}
        else if(isPlayer)
        {
            DeathLoop();
            //Meccanica di restore
        }
    }
    void Update()
    {}    
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    public void DeathLoop(){spineAnimationState.SetAnimation(0, DeathAnimationName, true);}
}
