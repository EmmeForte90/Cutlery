using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Cinemachine;

public class ChargeSkill : MonoBehaviour
{
    [Header("Character")]
    [Tooltip("Scegli personaggi 0.Fork 1.Knife 2.Spoon")]
    [Range(0, 2)]
    public int kindCh;
    [Header("Timer")]    
    private PlayerStats Stats;
    public Scrollbar TimeBar;
    private Skill SkillAtt;
    private Item itemUse;
    private int TimeS;
    public GameObject MP;
    public GameObject VFX;
    public GameObject VFXRAGE;
    public GameObject Mossa;
    public GameObject Indicatore;
    public GameObject Indicatore_Item;
    public FollowMouse Character;
    public GameObject AnimationRage;
    public TextMeshProUGUI nameText; 
    //public TextMeshProUGUI Utilizzi;    
    private CinemachineVirtualCamera vCam;
    private string nameT;
    public float fillDuration;  // Durata desiderata per riempire la barra in secondi
    public float curTime = 0;       // Tempo trascorso
    public float fillPercentage;
    public Spine.AnimationState _spineAnimationState;    
    public SkeletonAnimation _skeletonAnimation;
    private bool isSkillLaunched = true;
    public  AnimationManager AM;
    public string Anm;    
    public Transform RPoint;
    public Transform Player;
    [SpineAnimation][SerializeField] string ChargeAnm;
    [SpineAnimation][SerializeField] string SearchAnm;
    [SpineAnimation][SerializeField] string Skill_0;
    [SpineAnimation][SerializeField] string Skill_1;
    [SpineAnimation][SerializeField] string Skill_2;
    [SpineAnimation][SerializeField] string Skill_3;
    [SpineAnimation][SerializeField] string Skill_4;
    [SpineAnimation][SerializeField] string Skill_5;
    [SpineAnimation][SerializeField] string Skill_6;
    [SpineAnimation][SerializeField] string Skill_7;
    [SpineAnimation][SerializeField] string Skill_8;
    [SpineAnimation][SerializeField] string Skill_9;
    [SpineAnimation][SerializeField] string SkillRage;
    /////////////////////////////////////////////////////
    [Header("Recupero")]    
    [SpineAnimation][SerializeField] string item_0;
    [SpineAnimation][SerializeField] string item_1;
    [SpineAnimation][SerializeField] string item_2;
    [SpineAnimation][SerializeField] string item_3;
    [SpineAnimation][SerializeField] string item_4;
    [SpineAnimation][SerializeField] string item_5;
    [SpineAnimation][SerializeField] string item_6;
    [SpineAnimation][SerializeField] string item_7;
    [SpineAnimation][SerializeField] string item_8;
    [SpineAnimation][SerializeField] string item_9;
    [SpineAnimation][SerializeField] string item_10;
    [SpineAnimation][SerializeField] string item_11;
    /////////////////////////////////////////////////////
    [Header("Trappole")]    
    [SpineAnimation][SerializeField] string item_12;
    [SpineAnimation][SerializeField] string item_13;
    [SpineAnimation][SerializeField] string item_14;
    [SpineAnimation][SerializeField] string item_15;
    [SpineAnimation][SerializeField] string item_16;
    [SpineAnimation][SerializeField] string item_17;
    [SpineAnimation][SerializeField] string item_18;
    [SpineAnimation][SerializeField] string item_19;
    [SpineAnimation][SerializeField] string item_20;

    public static ChargeSkill instance;

    public void Awake()
    {
    if (instance == null){instance = this;} 
    _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState; 
    _spineAnimationState = _skeletonAnimation.AnimationState;
    vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
    }
    
    public void RageCurr()
    {
    if(SkillAtt.isRage)
    {switch(kindCh)
    {
    case 0:
        PlayerStats.instance.F_curRage =  0;
        break;
    case 1:
        PlayerStats.instance.K_curRage =  0;
        break;
    case 2:
        PlayerStats.instance.S_curRage =  0;
    break;
    }}}
    public void ItemData(Item Item)
    {
        TimerSkill.instance.Use();//Tempo per utilizzare di nuovo la skill
        VFX.SetActive(true);
        GameManager.instance.notChange = true;
        GameManager.instance.NotTouchOption = true;
        GameManager.instance.Charge();
        AudioManager.instance.PlayUFX(13);
        GameManager.instance.ChStopB();
        _spineAnimationState.SetAnimation(0, SearchAnm, true); 
        nameT = Item.itemName;
        TimeS = Item.TimeItem;//Tempo per ripristinare la battle
        fillDuration = Item.MaxDurationItem; 
        GameManager.instance.CloseLittleMStop();
        Indicatore_Item.SetActive(true);
        Indicatore_Item.transform.position = MP.transform.position; 
        Character.Character = kindCh; 
    }

    public void TakeData(Skill skill)
    {
    //Calcola il numero di utilizzi
    if(skill.Utilizzi > 0){
    TimerSkill.instance.Use();//Tempo per utilizzare di nuovo la skill
    VFX.SetActive(true);
    GameManager.instance.notChange = true;
    GameManager.instance.NotTouchOption = true;
    GameManager.instance.Charge();
    AudioManager.instance.PlayUFX(13);
    GameManager.instance.ChStopB();
    _spineAnimationState.SetAnimation(0, ChargeAnm, true); 
    //Se non è una skill rage si comporta diversamente
    if(!skill.isRage){UpdatePreviewSkill.instance.UpdateInfoPanel(skill);}
    nameT = skill.itemName;
    SkillAtt = skill;
    TimeS = skill.TimeSkill;//Tempo per ripristinare la battle
    fillDuration = skill.MaxDuration; 
    skill.Utilizzi--;
    //Se è direzionale attiva il marker
    if(skill.IsDirectional){
    GameManager.instance.CloseLittleMStop();
    Indicatore.SetActive(true);
    Indicatore.transform.position = MP.transform.position; 
    Character.Character = kindCh; 
    }
    else //Se non è direziola enon lo attiva e fa partire il timer direttamente
    {
    isSkillLaunched = false;
    GameManager.instance.CloseLittleM();
    GameManager.instance.TimerMenu();
    switch(skill.WhoSkill)
    {
    case 0:Anm = Skill_0;break;
    case 1:Anm = Skill_1;break;
    case 2:Anm = Skill_2;break;
    case 3:Anm = Skill_3;break;
    case 4:Anm = Skill_4;break;
    case 5:Anm = Skill_5;break;
    case 6:Anm = Skill_6;break;
    case 7:Anm = Skill_7;break;
    case 8:Anm = Skill_8;break;
    case 9:Anm = Skill_9;break;
    case 10:Anm = SkillRage;VFX.SetActive(false);VFXRAGE.SetActive(true);break;
    }}
    }
    else
    {AudioManager.instance.PlayUFX(10); TimerSkill.instance.Notuse();}
    }

    //Fa partire l'animazione che instanziera la skill
    public void ActiveSkill()
    {
    isSkillLaunched = false;
    GameManager.instance.TimerMenu();
    switch(SkillAtt.WhoSkill)
    {
    case 0:Anm = Skill_0;break;
    case 1:Anm = Skill_1;break;
    case 2:Anm = Skill_2;break;
    case 3:Anm = Skill_3;break;
    case 4:Anm = Skill_4;break;
    case 5:Anm = Skill_5;break;
    case 6:Anm = Skill_6;break;
    case 7:Anm = Skill_7;break;
    case 8:Anm = Skill_8;break;
    case 9:Anm = Skill_9;break;
    case 10:Anm = SkillRage;VFXRAGE.SetActive(true);break;
    }
    }

    public void ActiveItem()
    {
    isSkillLaunched = false;
    //GameManager.instance.TimerMenu();
    switch(itemUse.WhoConsumable)
    {
    case 0:Anm = item_0;break;
    case 1:Anm = item_1;break;
    case 2:Anm = item_2;break;
    case 3:Anm = item_3;break;
    case 4:Anm = item_4;break;
    case 5:Anm = item_5;break;
    case 6:Anm = item_6;break;
    case 7:Anm = item_7;break;
    case 8:Anm = item_8;break;
    case 9:Anm = item_9;break;
    case 10:Anm = item_10;break;
    case 11:Anm = item_11;break;
    case 12:Anm = item_12;break;
    case 13:Anm = item_13;break;
    case 14:Anm = item_14;break;
    case 15:Anm = item_15;break;
    case 16:Anm = item_16;break;
    case 17:Anm = item_17;break;
    case 18:Anm = item_18;break;
    case 19:Anm = item_19;break;
    case 20:Anm = item_20;break;
    }
    }

   public void Update()
{
    if (!isSkillLaunched)
    {
        if (curTime < fillDuration)
        {

            // Incrementa il tempo trascorso in base a Time.deltaTime
            curTime += Time.deltaTime;

            // Calcola la percentuale di completamento
            fillPercentage = curTime / fillDuration;

            // Imposta la dimensione della barra (assicurandoti che sia compresa tra 0.01f e 1)
            TimeBar.size = Mathf.Clamp(fillPercentage, 0.01f, 1);

            if (curTime >= fillDuration)
            {
                curTime = fillDuration;
                //print("StartSkill");
                StartCoroutine(SkillLunch());
                isSkillLaunched = true; // Imposta il flag per evitare ulteriori avvii
            }
        }
    }
}

IEnumerator SkillLunch()
{    
    GameManager.instance.StopBattle();
    CameraZoom.instance.ZoomIn(); 
    Mossa.SetActive(true);
    nameText.text = nameT.ToString();
    yield return new WaitForSeconds(3f);
    VFX.SetActive(false); VFXRAGE.SetActive(false);Mossa.SetActive(false);
    GameManager.instance.CloseTimerMenu();
    //
    if(SkillAtt.isRage)
    {AnimationRage.SetActive(true);
    yield return new WaitForSeconds(2f);
    AnimationRage.SetActive(false);}
    AM.PlayAnimation(Anm);
    if(SkillAtt.isRage){RageCurr();}
    //
    yield return new WaitForSeconds(TimeS);
    GameManager.instance.ResumeBattle();
    CameraZoom.instance.ZoomOut();
    if(SkillAtt.isRage){CamSkillBack();}
    fillPercentage = 0; curTime = 0; isSkillLaunched = false;
    GameManager.instance.ChCanM();
    GameManager.instance.NotTouchOption = false;
    GameManager.instance.StopWin();
}
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
    public void CamSkill(){vCam.Follow = RPoint.transform;}
    public void CamSkillBack(){vCam.Follow = Player.transform;}

}