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
    public GameObject Rage;

    [Header("Fork")]
    private GameObject ForkActive;
    private CharacterMove F_Script;
    [HideInInspector] public GameObject Bullet;
    [HideInInspector] public GameObject BigSpell;
    
    /////////////////////////////
    [Header("Spoon")]
    private GameObject SpoonActive;
    private CharacterMove S_Script;
    [HideInInspector] public GameObject Cura;
    [HideInInspector] public GameObject ShiledI;
    [HideInInspector] public bool isDefence = false;
    /////////////////////////////
    [Header("Knife")]
    private GameObject KnifeActive;
    private CharacterMove K_Script;
    [HideInInspector] public GameObject SlashV;
    [HideInInspector] public GameObject Increase;
    [HideInInspector] public GameObject SlashH;
    [HideInInspector] public GameObject SlashB;

    [Header("Animations")]
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    //private bool Boom = false;
    private bool VFX = true;
    public Transform BPoint;
    public Transform RPoint;
    public ChargeSkill CS;
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
        if(GameManager.instance.F_Unlock){F_Script = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.K_Unlock){K_Script = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.S_Unlock){S_Script = GameObject.Find("S_Player").GetComponent<CharacterMove>();}    
    }
    IEnumerator StopVFX_K()
    {
        yield return new WaitForSeconds(1f);
        SlashV.gameObject.SetActive(false);
        SlashH.gameObject.SetActive(false);
        SlashB.gameObject.SetActive(false);
    }
    IEnumerator StopVFX_Rage()
    {
        yield return new WaitForSeconds(3f);
        Rage.gameObject.SetActive(false);
    }
    IEnumerator StopVFX_F()
    {
        //Boom = false;
        yield return new WaitForSeconds(5f);
        VFX = true;
    }
    public void TemporaryChangeColor(Color color){_skeletonAnimation.Skeleton.SetColor(color); Invoke(nameof(ResetColor), 0.5f);}
    public void ChangeColor(){_skeletonAnimation.Skeleton.SetColor(Color.green);}
    public void ResetColor(){_skeletonAnimation.Skeleton.SetColor(Color.white);}
    public void PlayAnimation(string animationName)
    {
        if (currentAnimationName != animationName)
        {_skeletonAnimation.state.SetAnimation(0, animationName, false);}
        _skeletonAnimation.state.GetCurrent(0).Complete += OnAttackAnimationComplete;
    }
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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fork
    if (e.Data.Name == "bigspell" && VFX)
    {AudioManager.instance.PlayUFX(8); Instantiate(BigSpell, BPoint.position, BigSpell.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "rageFork" && VFX)
    {AudioManager.instance.PlayUFX(8); Instantiate(Rage, RPoint.position, Rage.transform.rotation); 
    VFX = false; CS.CamSkill(); StartCoroutine(StopVFX_F());}//Rage.gameObject.SetActive(true); StartCoroutine(StopVFX_Rage());}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Knife
    if (e.Data.Name == "slashV")
    {AudioManager.instance.PlayUFX(8); SlashV.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "slashH")
    {AudioManager.instance.PlayUFX(8); SlashH.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "slashB")
    {AudioManager.instance.PlayUFX(8); SlashB.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "increaseatk")
    {AudioManager.instance.PlayUFX(8); Instantiate(Increase, BPoint.position, Increase.transform.rotation);}
    if (e.Data.Name == "rageKnife" && VFX)
    {AudioManager.instance.PlayUFX(8); Instantiate(Rage, transform.position, Rage.transform.rotation); 
    VFX = false; CS.CamSkill(); StartCoroutine(StopVFX_F());}//Rage.gameObject.SetActive(true); StartCoroutine(StopVFX_Rage());}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Spoon
    if (e.Data.Name == "cura")
    {AudioManager.instance.PlayUFX(8); Instantiate(Cura, BPoint.position, Cura.transform.rotation); }
    if (e.Data.Name == "punch")
    {AudioManager.instance.PlayUFX(8); ShiledI.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
}
}