using System.Collections;
using UnityEngine;
using Spine.Unity;

public class StunAnimation : MonoBehaviour
{
    public Spine.AnimationState spineAnimationState;    
    public SkeletonAnimation skeletonAnimation;
    public GameObject VFX;
    public bool isPlayer;
    [Tooltip("Scegli personaggi 0.Fork 1.Knife 2.Spoon")]
    [Range(0, 2)]
    public int kindCh;
    public float TimeStun;

    [SpineAnimation][SerializeField]  string StunAnimationName;
    public void Awake()
    {spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState; spineAnimationState = skeletonAnimation.AnimationState;}
    private void OnDisable(){VFX.SetActive(false);}
    private void OnEnable() 
    {
        VFX.SetActive(true);
         if(!isPlayer){StartCoroutine(Stun()); spineAnimationState.SetAnimation(0, StunAnimationName, false);}
        else if(isPlayer){StunLoop(); StartCoroutine(Stun());}
    }
    void Update(){}    
    private IEnumerator Stun()
    {
        yield return new WaitForSeconds(TimeStun);
        switch (kindCh)
        {
            case 0:
            GameManager.instance.RestoreF();
            break;
            case 1:
            GameManager.instance.RestoreK();
            break; 
            case 2:
            GameManager.instance.RestoreS();
            break;
        }
    }
    public void StunLoop(){spineAnimationState.SetAnimation(0, StunAnimationName, true);}
}