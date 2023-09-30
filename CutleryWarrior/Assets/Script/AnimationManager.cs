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
    public bool Enemy;

    [Header("Impronte")]
    public bool canImp = false;
    public GameObject impronte;
    public Transform Foot;
    public GameObject Rage;
    [Header("Enemy")]
    [HideInInspector] public GameObject VfxEnmSlash;

    [Header("Fork")]
    private GameObject ForkActive;
    private CharacterMove F_Script;
    [HideInInspector] public GameObject BulletP;
    [HideInInspector] public GameObject Bullet;
    [HideInInspector] public GameObject BigSpell;
    [HideInInspector] public GameObject BigForks;
    [HideInInspector] public GameObject Flame;
    [HideInInspector] public GameObject Impulsium;
    [HideInInspector] public GameObject Smug;
    [HideInInspector] public GameObject RainFire;
    [HideInInspector] public GameObject BenedictioFenix;
    [HideInInspector] public GameObject HellFlame;
    [HideInInspector] public GameObject Hole;
    [HideInInspector] public GameObject Dodge;
    /////////////////////////////
    [Header("Spoon")]
    private GameObject SpoonActive;
    private CharacterMove S_Script;
    [HideInInspector] public GameObject ShiledI;
    [HideInInspector] public GameObject BenedictionTower;
    [HideInInspector] public GameObject Cura;
    [HideInInspector] public GameObject ShockWave;
    [HideInInspector] public GameObject Shields;
    [HideInInspector] public GameObject Explosion;
    [HideInInspector] public GameObject HitStun;
    [HideInInspector] public GameObject Revive;
    [HideInInspector] public GameObject Reflect;
    [HideInInspector] public bool isDefence = false;
    /////////////////////////////
    [Header("Knife")]
    private GameObject KnifeActive;
    private CharacterMove K_Script;
    [HideInInspector] public GameObject Stump;
    [HideInInspector] public GameObject SlashV;
    [HideInInspector] public GameObject SlashH;
    [HideInInspector] public GameObject SlashB;
    [HideInInspector] public GameObject BigSlash;
    [HideInInspector] public GameObject Fury;
    [HideInInspector] public GameObject DanceSwords;
    [HideInInspector] public GameObject SlashBombing;
    [HideInInspector] public GameObject RainSwords;
    [HideInInspector] public GameObject SawTrain;
    [HideInInspector] public GameObject Stalactites;
    [HideInInspector] public GameObject Whirlwinds;
    /////////////////////////////////////////////////
    public TimerSkill Skill_0;
    public TimerSkill Skill_1;
    public TimerSkill Skill_2;
    public TimerSkill Skill_3;
    public TimerSkill Skill_4;
    public TimerSkill Skill_5;
    public TimerSkill Skill_6;
    public TimerSkill Skill_7;
    public TimerSkill Skill_8;

    [Header("Animations")]
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    //private bool Boom = false;
    private bool VFX = true;
    public Transform SkillPoint;
    public Transform BPoint;
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
        if(knife){
        SlashV.gameObject.SetActive(false);
        SlashH.gameObject.SetActive(false);
        SlashB.gameObject.SetActive(false);}
        if(Enemy){VfxEnmSlash.gameObject.SetActive(false);}
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
    IEnumerator StopVFX_FNormal()
    {
        //Boom = false;
        yield return new WaitForSeconds(2f);
        VFX = true;
    }
    IEnumerator StopVFX_Rapid()
    {
        //Boom = false;
        yield return new WaitForSeconds(0.1f);
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
    if (e.Data.Name == "impronte" && VFX){if(canImp){Instantiate(impronte, Foot.position, impronte.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_Rapid());}}
    if (e.Data.Name == "stump" && VFX){Instantiate(Stump, Foot.position, Stump.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_FNormal());}
     if (e.Data.Name == "dodge" && VFX){Instantiate(Dodge, Foot.position, Dodge.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_FNormal());}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    if (e.Data.Name == "atk"){AudioManager.instance.PlayUFX(0); VfxEnmSlash.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fork
    /*if (e.Data.Name == "shoot" && VFX)
    {AudioManager.instance.PlayUFX(8); Instantiate(Bullet, BPoint.position, Bullet.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_Rapid());}*/
    if (e.Data.Name == "bigspell" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_0.Use(); Instantiate(BigSpell, BPoint.position, BigSpell.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "bigfork" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_1.Use(); Instantiate(BigForks, SkillPoint.position, BigForks.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "flame" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_2.Use(); Instantiate(Flame, BPoint.position, Flame.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
     if (e.Data.Name == "impulsum" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_3.Use(); Instantiate(Impulsium, BPoint.position, Impulsium.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
     if (e.Data.Name == "smug" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_4.Use(); Instantiate(Smug, BPoint.position, Smug.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "bombing" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_5.Use(); Instantiate(RainFire, SkillPoint.position, RainFire.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "fenix" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_6.Use(); Instantiate(BenedictioFenix, BPoint.position, BenedictioFenix.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "hellflame" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_7.Use(); Instantiate(HellFlame, BPoint.position, HellFlame.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "hole" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_8.Use(); Instantiate(Hole, BPoint.position, Hole.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "rageFork" && VFX)
    {AudioManager.instance.PlayUFX(8); Instantiate(Rage, SkillPoint.position, Rage.transform.rotation); 
    VFX = false; CS.CamSkill(); StartCoroutine(StopVFX_F());}//Rage.gameObject.SetActive(true); StartCoroutine(StopVFX_Rage());}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Knife
    if (e.Data.Name == "slashV")
    {AudioManager.instance.PlayUFX(8); SlashV.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "slashH")
    {AudioManager.instance.PlayUFX(8); SlashH.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "slashB")
    {AudioManager.instance.PlayUFX(8); SlashB.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "bigslash" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_0.Use(); Instantiate(BigSlash, BPoint.position, BigSlash.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "fury")
    {AudioManager.instance.PlayUFX(8); Skill_1.Use(); Instantiate(Fury, BPoint.position, Fury.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "dance" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_2.Use(); Instantiate(DanceSwords, BPoint.position, DanceSwords.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "multislash" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_3.Use(); Instantiate(SlashBombing, BPoint.position, SlashBombing.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "rain" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_4.Use(); Instantiate(RainSwords, SkillPoint.position, RainSwords.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "saw" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_5.Use(); Instantiate(SawTrain, BPoint.position, SawTrain.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "stalactites" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_6.Use(); Instantiate(Stalactites, BPoint.position, Stalactites.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "turbine" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_7.Use(); Instantiate(SawTrain, transform.position, SawTrain.transform.rotation); 
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "rageKnife" && VFX)
    {AudioManager.instance.PlayUFX(8); Instantiate(Rage, transform.position, Rage.transform.rotation); 
    VFX = false; CS.CamSkill(); StartCoroutine(StopVFX_F());}//Rage.gameObject.SetActive(true); StartCoroutine(StopVFX_Rage());}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Spoon
    if (e.Data.Name == "defence")
    {AudioManager.instance.PlayUFX(8); Skill_0.Use(); Instantiate(BenedictionTower, BPoint.position, BenedictionTower.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "cura")
    {AudioManager.instance.PlayUFX(8); Skill_1.Use(); Instantiate(Cura, SkillPoint.position, Cura.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_F());}
     if (e.Data.Name == "shockwave")
    {AudioManager.instance.PlayUFX(8); Skill_2.Use(); Instantiate(ShockWave, BPoint.position, ShockWave.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "shield")
    {AudioManager.instance.PlayUFX(8); Skill_3.Use(); Instantiate(Shields, transform.position, Shields.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "explosion")
    {AudioManager.instance.PlayUFX(8); Skill_4.Use(); Instantiate(Explosion, BPoint.position, Explosion.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "stun")
    {AudioManager.instance.PlayUFX(8); Skill_5.Use(); Instantiate(HitStun, SkillPoint.position, HitStun.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "revive")
    {AudioManager.instance.PlayUFX(8); Skill_6.Use(); Instantiate(Revive, SkillPoint.position, Revive.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "reflect")
    {AudioManager.instance.PlayUFX(8); Skill_7.Use(); Instantiate(Reflect, SkillPoint.position, Reflect.transform.rotation);
    VFX = false; StartCoroutine(StopVFX_F());}
     if (e.Data.Name == "rageSpoon" && VFX)
    {AudioManager.instance.PlayUFX(8); Instantiate(Rage, transform.position, Rage.transform.rotation); 
    VFX = false; CS.CamSkill(); StartCoroutine(StopVFX_F());}
    if (e.Data.Name == "punch")
    {AudioManager.instance.PlayUFX(8); ShiledI.gameObject.SetActive(true);}
}
}