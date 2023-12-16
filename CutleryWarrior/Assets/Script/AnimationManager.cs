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
    [Header("Items")]
    public GameObject Potion;//HP
    public GameObject MediaPotion;//HP
    public GameObject AltaPotion;//HP
    public GameObject Intruglio;//MP
    public GameObject MediaIntruglio;//MP
    public GameObject AltaIntruglio;//MP
    public GameObject Vaccino;//Cura il veleno
    public GameObject Aglio;//Cura il sonno
    public GameObject Malox;//Cura il mutismo
    public GameObject Caffé;//Cura la paralisi
    public GameObject Panacea;//Cura tutto
    public GameObject Ristoro;//Cura la morte
    //-----------------------//
    public GameObject BombaPiccola;//Danneggia il nemico
    public GameObject BombaMedia;//Danneggia il nemico
    public GameObject BombaGrande;//Danneggia il nemico
    public GameObject Veleno;//Avvelena il nemico
    public GameObject Fumogeno;//Blocca il nemico
    public GameObject Spine;//Crea un area che piò Danneggiare il nemico finché ci resta sopra
    public GameObject Flash;//Blocca il nemico
    public GameObject Camomilla;//Blocca il nemico
    public GameObject Barricata;//Crea un ostacolo per il nemico
    public GameObject Bengala;//Crea un area dove curarsi
    public float Cooldown = 0.5f; // Tempo di cooldown tra le combo in secondi

    [Header("Impronte")]
    [HideInInspector]public bool canImp = false;
    [HideInInspector]public GameObject impronte;
    [HideInInspector]public Transform Foot;
    [HideInInspector]public GameObject Rage;

    [Header("Enemy")]
    [HideInInspector] public GameObject VfxEnmSlash;
    [HideInInspector] public GameObject VfxCrush;

    [Header("Fork")]
    private GameObject ForkActive;
    private CharacterMove F_Script;
    [HideInInspector] public GameObject BulletP;
    [HideInInspector] public GameObject Bullet_AI;
    [HideInInspector] public GameObject Bullet;
    [HideInInspector] public GameObject BigSB;
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
    [HideInInspector] public GameObject ShiledT;
    [HideInInspector] public GameObject ShiledB; 
    [HideInInspector] public GameObject Crush;
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
    [HideInInspector] public GameObject Motivation;
    /////////////////////////////////////////////////
    [HideInInspector] public TimerSkill Skill_0;
    [HideInInspector] public TimerSkill Skill_1;
    [HideInInspector] public TimerSkill Skill_2;
    [HideInInspector] public TimerSkill Skill_3;
    [HideInInspector] public TimerSkill Skill_4;
    [HideInInspector] public TimerSkill Skill_5;
    [HideInInspector] public TimerSkill Skill_6;
    [HideInInspector] public TimerSkill Skill_7;
    [HideInInspector] public TimerSkill Skill_8;
    public TimerSkill ItemTimer;
    [Header("Animations")]
    [SpineAnimation][SerializeField]  string IdleAnimationName;
    [SpineAnimation][SerializeField]  string IdleBAnimationName;
    [SpineAnimation][SerializeField]  string WalkBAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    public bool VFX = true;
    public bool VFXSkills = true;
    private int sound = 0;

    [HideInInspector]public Transform SkillPoint;
    public Transform BPoint;
    [HideInInspector]public ChargeSkill CS;
    public static AnimationManager instance;
    #endregion
    public void Start()
    {
         if (instance == null){instance = this;}
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}  
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;   
        if(GameManager.instance.F_Unlock){F_Script = GameManager.instance.F_Hero.GetComponent<CharacterMove>();}
        if(GameManager.instance.K_Unlock){K_Script = GameManager.instance.K_Hero.GetComponent<CharacterMove>();}
        if(GameManager.instance.S_Unlock){S_Script = GameManager.instance.S_Hero.GetComponent<CharacterMove>();}    
    }

    public void Update(){if(!VFXSkills){StartCoroutine(StopVFX_Skills());}}
    IEnumerator StopVFX_K()
    {
        yield return new WaitForSeconds(1f);
        if(knife){
        SlashV.gameObject.SetActive(false);
        SlashH.gameObject.SetActive(false);
        SlashB.gameObject.SetActive(false);
        }
        if(Enemy){VfxEnmSlash.gameObject.SetActive(false);VfxCrush.gameObject.SetActive(false);}
    }
    IEnumerator StopVFX_S()
    {
        yield return new WaitForSeconds(1f);
        if(spoon){
        ShiledT.gameObject.SetActive(false);
        ShiledB.gameObject.SetActive(false);
        Crush.gameObject.SetActive(false);
        }
        if(Enemy){VfxEnmSlash.gameObject.SetActive(false);}
    }
    IEnumerator StopVFX_K2()
    {
        yield return new WaitForSeconds(1.5f);
        if(knife){
        BigSlash.gameObject.SetActive(false);}
        if(Enemy){VfxEnmSlash.gameObject.SetActive(false);}
    }
    IEnumerator StopVFX_Rage()
    {
        yield return new WaitForSeconds(3f);
        Rage.gameObject.SetActive(false);
    }
    IEnumerator StopVFX_F()
    {
        yield return new WaitForSeconds(5f);
        VFX = true;
    }
    IEnumerator StopVFX_FNormal()
    {
        yield return new WaitForSeconds(2f);
        VFX = true;
    }
    IEnumerator StopVFX_Skills()
    {
        yield return new WaitForSeconds(1f);
        VFXSkills = true;
    }
    IEnumerator StopVFX_Rapid()
    {
        yield return new WaitForSeconds(0.1f);
        VFX = true;
    }
    

    public void TemporaryChangeColor(Color color){_skeletonAnimation.Skeleton.SetColor(color); Invoke(nameof(ResetColor), 0.5f);}
    public void ChangeColorP(){_skeletonAnimation.Skeleton.SetColor(Color.green);}
    public void ChangeColorR(){_skeletonAnimation.Skeleton.SetColor(new Color32(193, 155, 26, 255));}
    public void ChangeColorTrasparent()
    {
        // Imposta il canale alpha del colore a un valore più basso per rendere il personaggio trasparente
        Color32 nuovoColore = new Color32(193, 155, 26, 0); 
        // 0 è un valore di alpha che indica una trasparenza totale
        _skeletonAnimation.Skeleton.SetColor(nuovoColore);
    }
    public void ChangeColorNormal()
    {
        // Imposta il canale alpha del colore a un valore più basso per rendere il personaggio trasparente
        Color32 nuovoColore = new Color32(255, 255, 255, 255); 
        // 0 è un valore di alpha che indica una trasparenza totale
        _skeletonAnimation.Skeleton.SetColor(nuovoColore);
    }
    public void ResetColor(){_skeletonAnimation.Skeleton.SetColor(Color.white);}
    public void PlayAnimation(string animationName)
    {
        if (currentAnimationName != animationName)
        {_skeletonAnimation.state.SetAnimation(0, animationName, false); 
        currentAnimationName = animationName; _spineAnimationState.Event += HandleEvent;}
        _skeletonAnimation.state.GetCurrent(0).Complete += OnAttackAnimationComplete;
    }
    public void PlayAnimationStop(string animationName)
    {
        if (currentAnimationName != animationName)
        {_skeletonAnimation.state.SetAnimation(0, animationName, false); 
        currentAnimationName = animationName; _spineAnimationState.Event += HandleEvent;}
    }

    public void PlayAnimationExplore(string animationName)
    {
        if (currentAnimationName != animationName)
        {_skeletonAnimation.state.SetAnimation(0, animationName, false); 
        currentAnimationName = animationName; _spineAnimationState.Event += HandleEvent;}
        _skeletonAnimation.state.GetCurrent(0).Complete += OnExploreAnimationComplete;
    }
    public void PlayAnimationLoop(string animationName)
    {
    if (currentAnimationName != animationName)
    {_skeletonAnimation.state.SetAnimation(0, animationName, true);
    currentAnimationName = animationName;
    _spineAnimationState.Event += HandleEvent;}
    }
    private void StopAtk(){VFX = true;}

    public void ClearAnm()
    {
        _skeletonAnimation.state.ClearTrack(0);
        currentAnimationName = null;
    }
    private void OnExploreAnimationComplete(Spine.TrackEntry trackEntry)
    {
        trackEntry.Complete -= OnExploreAnimationComplete;
        _skeletonAnimation.state.ClearTrack(0);
    _skeletonAnimation.state.SetAnimation(0, IdleAnimationName, true);
    }
    private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
    {
        trackEntry.Complete -= OnAttackAnimationComplete;
        _skeletonAnimation.state.ClearTrack(0);
    _skeletonAnimation.state.SetAnimation(0, IdleBAnimationName, true);
    }
        public void SoundImp(int soundEff)
    {
        sound = soundEff;
    }
    void HandleEvent (TrackEntry trackEntry, Spine.Event e) {
    //Normal VFX
    if (e.Data.Name == "walk"){AudioManager.instance.PlayUFX(sound);}
    if (e.Data.Name == "impronte" && VFX){if(canImp){Instantiate(impronte, Foot.position, impronte.transform.rotation);
    StartCoroutine(StopVFX_Rapid()); VFX = false; }}
    if (e.Data.Name == "stump" && VFX){Instantiate(Stump, Foot.position, Stump.transform.rotation);
    StartCoroutine(StopVFX_FNormal()); VFX = false; }
    if (e.Data.Name == "dodge" && VFX){Instantiate(Dodge, Foot.position, Dodge.transform.rotation);
    StartCoroutine(StopVFX_Rapid()); VFX = false; }
    if (e.Data.Name == "EndAtk" && VFX){PlayAnimationLoop(WalkBAnimationName);}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ///UsingItems
    if (e.Data.Name == "item/potion" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use(); Instantiate(Potion, SkillPoint.position, Potion.transform.rotation); 
      VFXSkills = false; }
     if (e.Data.Name == "item/mediapotion" && VFX)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use(); Instantiate(MediaPotion, SkillPoint.position, MediaPotion.transform.rotation); 
      VFXSkills = false; }
     if (e.Data.Name == "item/altapotion" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(AltaPotion, SkillPoint.position, AltaPotion.transform.rotation); 
      VFXSkills = false; }  
     if (e.Data.Name == "item/mana" && VFXSkills)
    {AudioManager.instance.PlayUFX(8);ItemTimer.Use(); Instantiate(Intruglio, SkillPoint.position, Intruglio.transform.rotation); 
      VFXSkills = false; } 
     if (e.Data.Name == "item/mediamana" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(MediaIntruglio, SkillPoint.position, MediaIntruglio.transform.rotation); 
      VFXSkills = false; }  
     if (e.Data.Name == "item/altamana" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(AltaIntruglio, SkillPoint.position, AltaIntruglio.transform.rotation); 
      VFXSkills = false; }
     if (e.Data.Name == "item/vaccino" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Vaccino, SkillPoint.position, Vaccino.transform.rotation); 
      VFXSkills = false; }
     if (e.Data.Name == "item/aglio" && VFX)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Aglio, SkillPoint.position, Aglio.transform.rotation); 
      VFXSkills = false; } 
     if (e.Data.Name == "item/panacea" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Panacea, SkillPoint.position, Panacea.transform.rotation); 
      VFXSkills = false; } 
     if (e.Data.Name == "item/coffe" && VFXSkills)
    {AudioManager.instance.PlayUFX(8);ItemTimer.Use(); Instantiate(Caffé, SkillPoint.position, Caffé.transform.rotation); 
      VFXSkills = false; } 
     if (e.Data.Name == "item/malox" && VFXSkills)
    {AudioManager.instance.PlayUFX(8);ItemTimer.Use(); Instantiate(Malox, SkillPoint.position, Malox.transform.rotation); 
      VFXSkills = false; } 
     if (e.Data.Name == "item/ristoro" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Ristoro, SkillPoint.position, Ristoro.transform.rotation); 
      VFXSkills = false; }  
     //----------------------------------------//
    if (e.Data.Name == "item/bomb" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(BombaPiccola, SkillPoint.position, BombaPiccola.transform.rotation); 
      VFXSkills = false; } 
    if (e.Data.Name == "item/mediabomb" && VFX)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(BombaMedia, SkillPoint.position, BombaMedia.transform.rotation); 
      VFXSkills = false; }   
    if (e.Data.Name == "item/altabomb" && VFX)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(BombaGrande, SkillPoint.position, BombaGrande.transform.rotation); 
      VFXSkills = false; } 
    if (e.Data.Name == "item/flash" && VFX)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Flash, SkillPoint.position, Flash.transform.rotation); 
      VFXSkills = false; }
    if (e.Data.Name == "item/spine" && VFX)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Spine, SkillPoint.position, Spine.transform.rotation); 
      VFXSkills = false; }  
    if (e.Data.Name == "item/poison" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Veleno, SkillPoint.position, Veleno.transform.rotation); 
      VFXSkills = false; }
     if (e.Data.Name == "item/smoke" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Fumogeno, SkillPoint.position, Fumogeno.transform.rotation); 
      VFXSkills = false; }  
     if (e.Data.Name == "item/calm" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use();Instantiate(Camomilla, SkillPoint.position, Camomilla.transform.rotation); 
      VFXSkills = false; }
     if (e.Data.Name == "item/bengala" && VFXSkills)
    {AudioManager.instance.PlayUFX(8);ItemTimer.Use();Instantiate(Bengala, SkillPoint.position, Bengala.transform.rotation); 
     VFXSkills = false; } 
     if (e.Data.Name == "item/barricata" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); ItemTimer.Use(); Instantiate(Barricata, SkillPoint.position, Barricata.transform.rotation); 
     VFXSkills = false; }  
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Enemy
    if (e.Data.Name == "atk"){AudioManager.instance.PlayUFX(0); VfxEnmSlash.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "crash"){AudioManager.instance.PlayUFX(0); VfxCrush.gameObject.SetActive(true); StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "shootEnm" && VFX){Instantiate(Bullet, BPoint.position, Bullet.transform.rotation); 
    StartCoroutine(StopVFX_FNormal()); VFX = false;}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fork
    if (e.Data.Name == "shootAI" && VFX){Instantiate(Bullet_AI, BPoint.position, Bullet_AI.transform.rotation); 
    StartCoroutine(StopVFX_Rapid()); VFX = false;}
    if (e.Data.Name == "shoot" && VFX)
    {AudioManager.instance.PlayUFX(8); Instantiate(Bullet, BPoint.position, Bullet.transform.rotation); 
    VFX = false;}
    if (e.Data.Name == "bigshoot" && VFX)
    {AudioManager.instance.PlayUFX(8); Skill_0.Use(); Instantiate(BigSB, BPoint.position, BigSB.transform.rotation); 
    StartCoroutine(StopVFX_F()); VFX = false; }
    //--------------------------------------//
    if (e.Data.Name == "bigspell" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_0.Use(); Instantiate(BigSpell, BPoint.position, BigSpell.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "bigfork" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_1.Use(); Instantiate(BigForks, SkillPoint.position, BigForks.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "flame" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_2.Use(); Instantiate(Flame, BPoint.position, Flame.transform.rotation); 
    VFXSkills = false; }
     if (e.Data.Name == "impulsum" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_3.Use(); Instantiate(Impulsium, BPoint.position, Impulsium.transform.rotation); 
    VFXSkills = false; }
     if (e.Data.Name == "smug" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_4.Use(); Instantiate(Smug, BPoint.position, Smug.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "bombing" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_5.Use(); Instantiate(RainFire, SkillPoint.position, RainFire.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "fenix" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_6.Use(); Instantiate(BenedictioFenix, BPoint.position, BenedictioFenix.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "hellflame" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_7.Use(); Instantiate(HellFlame, BPoint.position, HellFlame.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "hole" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_8.Use(); Instantiate(Hole, BPoint.position, Hole.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "rageFork" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Instantiate(Rage, SkillPoint.position, Rage.transform.rotation); 
    CS.CamSkill(); VFXSkills = false; }//Rage.gameObject.SetActive(true); StartCoroutine(StopVFX_Rage());}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Knife
    if (e.Data.Name == "slashV")
    {AudioManager.instance.PlayUFX(8); SlashV.gameObject.SetActive(true);} //StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "slashH")
    {AudioManager.instance.PlayUFX(8); SlashH.gameObject.SetActive(true);} //StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "slashB")
    {AudioManager.instance.PlayUFX(8); SlashB.gameObject.SetActive(true);} //StartCoroutine(StopVFX_K());}
    if (e.Data.Name == "bigslash")
    {AudioManager.instance.PlayUFX(8); BigSlash.gameObject.SetActive(true); StartCoroutine(StopVFX_K2());}
    //--------------------------------------//
    if (e.Data.Name == "fury" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_1.Use(); Instantiate(Fury, BPoint.position, Fury.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "dance" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_2.Use(); Instantiate(DanceSwords, BPoint.position, DanceSwords.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "multislash" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_3.Use(); Instantiate(SlashBombing, BPoint.position, SlashBombing.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "rain" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_4.Use(); Instantiate(RainSwords, SkillPoint.position, RainSwords.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "saw" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_5.Use(); Instantiate(SawTrain, BPoint.position, SawTrain.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "stalactites" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_6.Use(); Instantiate(Stalactites, BPoint.position, Stalactites.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "turbine" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_7.Use(); Instantiate(SawTrain, transform.position, SawTrain.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "motivation" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_8.Use(); Instantiate(Motivation, transform.position, Motivation.transform.rotation); 
    VFXSkills = false; }
    if (e.Data.Name == "rageKnife" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Instantiate(Rage, transform.position, Rage.transform.rotation); 
    CS.CamSkill(); VFXSkills = false;}//Rage.gameObject.SetActive(true); StartCoroutine(StopVFX_Rage());}
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Spoon
     if (e.Data.Name == "punch")
    {AudioManager.instance.PlayUFX(8); ShiledT.gameObject.SetActive(true);} //StartCoroutine(StopVFX_S());}
     if (e.Data.Name == "punch2")
    {AudioManager.instance.PlayUFX(8); ShiledB.gameObject.SetActive(true);} //StartCoroutine(StopVFX_S());}
     if (e.Data.Name == "crush")
    {AudioManager.instance.PlayUFX(8); Crush.gameObject.SetActive(true);} //StartCoroutine(StopVFX_S());}
    //--------------------------------------//
    if (e.Data.Name == "defence" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_0.Use(); Instantiate(BenedictionTower, BPoint.position, BenedictionTower.transform.rotation);
    VFXSkills = false; }
    if (e.Data.Name == "cura" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_1.Use(); Instantiate(Cura, SkillPoint.position, Cura.transform.rotation);
    VFXSkills = false; }
     if (e.Data.Name == "shockwave" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_2.Use(); Instantiate(ShockWave, BPoint.position, ShockWave.transform.rotation);
    VFXSkills = false; }
    if (e.Data.Name == "shield" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_3.Use(); Instantiate(Shields, transform.position, Shields.transform.rotation);
    VFXSkills = false; }
    if (e.Data.Name == "explosion" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_4.Use(); Instantiate(Explosion, BPoint.position, Explosion.transform.rotation);
    VFXSkills = false; }
    if (e.Data.Name == "stun" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_5.Use(); Instantiate(HitStun, SkillPoint.position, HitStun.transform.rotation);
    VFXSkills = false; }
    if (e.Data.Name == "revive" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_6.Use(); Instantiate(Revive, SkillPoint.position, Revive.transform.rotation);
    VFXSkills = false; }
    if (e.Data.Name == "reflect" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_7.Use(); Instantiate(Reflect, SkillPoint.position, Reflect.transform.rotation);
    VFXSkills = false; }
     if (e.Data.Name == "pana" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Skill_8.Use(); Instantiate(Reflect, SkillPoint.position, Reflect.transform.rotation);
    VFXSkills = false; }
     if (e.Data.Name == "rageSpoon" && VFXSkills)
    {AudioManager.instance.PlayUFX(8); Instantiate(Rage, transform.position, Rage.transform.rotation); 
    CS.CamSkill(); VFXSkills = false;}
}
}