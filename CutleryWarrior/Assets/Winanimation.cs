using UnityEngine;
using Spine.Unity;
public class Winanimation : MonoBehaviour
{
    //public AnimationManager Anm;
    public Spine.AnimationState _spineAnimationState;    
    public SkeletonAnimation _skeletonAnimation;

    public void Awake()
    {_spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;}
    [SpineAnimation][SerializeField]  string WinAnimationName;
    public void Win(){_spineAnimationState.SetAnimation(0, WinAnimationName, true);}
    void Update()
    {}
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
}