using System.Collections;
using UnityEngine;
using Spine.Unity;
using Spine;
public class AnimationManager : MonoBehaviour
{
    #region Header
    [Header("Stats")]
    [Header("Character")]
    public bool fork;
    public bool knife;
    public bool spoon;
    [Header("Fork")]
    private GameObject ForkActive;
    private CharacterMove F_Script;
    [Header("Spoon")]
    private GameObject SpoonActive;
    private CharacterMove S_Script;
    [Header("Knife")]
    private GameObject KnifeActive;
    private CharacterMove K_Script;
    [Header("Animations")]
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    private bool Boom = false;
    [HideInInspector]
    public GameObject Bullet;
    [HideInInspector]
    public Transform BPoint;
    [HideInInspector]
    public GameObject SlashV;
    [HideInInspector]
    public GameObject SlashH;
    [HideInInspector]
    public GameObject SlashB;
    [HideInInspector]
    public bool isDefence = false;
    public static AnimationManager instance;
    #endregion
    public void Awake()
    {
         if (instance == null){instance = this;}
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}  
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;   
        F_Script = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        K_Script = GameObject.Find("K_Player").GetComponent<CharacterMove>();
        S_Script = GameObject.Find("S_Player").GetComponent<CharacterMove>();     
    }
    IEnumerator StopVFX_K()
    {
        yield return new WaitForSeconds(1f);
        SlashV.gameObject.SetActive(false);
        SlashH.gameObject.SetActive(false);
        SlashB.gameObject.SetActive(false);
    }
    IEnumerator StopVFX_F()
    {
        Boom = false;
        yield return new WaitForSeconds(0.5f);
        Boom = true;
    }
    public void TemporaryChangeColor(Color color){_skeletonAnimation.Skeleton.SetColor(color); Invoke(nameof(ResetColor), 0.5f);}
    private void ResetColor(){_skeletonAnimation.Skeleton.SetColor(Color.white);}
    public void PlayAnimation(string animationName)
    {if (currentAnimationName != animationName){_skeletonAnimation.state.SetAnimation(0, animationName, false);}
    _skeletonAnimation.state.GetCurrent(0).Complete += OnAttackAnimationComplete;}
    public void PlayAnimationLoop(string animationName)
    {
    if (currentAnimationName != animationName)
                {
                    _spineAnimationState.SetAnimation(0, animationName, true);
                    currentAnimationName = animationName;
                    _spineAnimationState.Event += HandleEvent;
                }
    }
    private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    trackEntry.Complete -= OnAttackAnimationComplete;
    _skeletonAnimation.state.ClearTrack(0);
   _skeletonAnimation.state.SetAnimation(0, IdleBAnimationName, true);
}
    void HandleEvent (TrackEntry trackEntry, Spine.Event e) {
    //Normal VFX
    if (e.Data.Name == "walk"){AudioManager.instance.PlayUFX(0);}
    //Normal VFX
    if (e.Data.Name == "slashV")
    {AudioManager.instance.PlayUFX(8); SlashV.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    //
    if (e.Data.Name == "slashH")
    {AudioManager.instance.PlayUFX(8); SlashH.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    //
    if (e.Data.Name == "slashB")
    {AudioManager.instance.PlayUFX(8); SlashB.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
}
}