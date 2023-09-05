using System.Collections;
using UnityEngine;
using Spine.Unity;

public class DeathAnimation : MonoBehaviour
{
    public Spine.AnimationState _spineAnimationState;    
    public SkeletonAnimation _skeletonAnimation;
    public bool isPlayer;
    public void Awake()
    {_spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;}
    [SpineAnimation][SerializeField]  string DeathAnimationName;
    public void Update()
    {
        if(!isPlayer){StartCoroutine(Death());}
        else if(isPlayer)
        {
            DeathLoop();
            //Meccanica di restore
        }
    }    
    private IEnumerator Death()
    {
        _spineAnimationState.SetAnimation(0, DeathAnimationName, false);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    public void DeathLoop(){_spineAnimationState.SetAnimation(0, DeathAnimationName, true);}
}
