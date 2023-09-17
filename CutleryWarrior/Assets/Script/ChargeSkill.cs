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
    private int TimeS;
    public GameObject MP;
    public GameObject VFX;
    public GameObject VFXRAGE;
    public GameObject Mossa;
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
    private bool isSkillLaunched = false;
    public  AnimationManager AM;
    public string Anm;    
    public Transform RPoint;
    public Transform Player;
    [SpineAnimation][SerializeField] string ChargeAnm;
    [SpineAnimation][SerializeField] string Skill0;
    [SpineAnimation][SerializeField] string Skill1;
    [SpineAnimation][SerializeField] string Skill2;
    [SpineAnimation][SerializeField] string Skill3;
    [SpineAnimation][SerializeField] string Skill4;
    [SpineAnimation][SerializeField] string Skill5;
    [SpineAnimation][SerializeField] string Skill6;
    [SpineAnimation][SerializeField] string Skill7;
    [SpineAnimation][SerializeField] string Skill8;
    [SpineAnimation][SerializeField] string Skill9;
    [SpineAnimation][SerializeField] string SkillRage;
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

    public void TakeData(Skill skill)
    {
    if(skill.Utilizzi > 0){
    TimerSkill.instance.Use();
    GameManager.instance.CloseLittleM();
    GameManager.instance.notChange = true;
    GameManager.instance.NotTouchOption = true;
    GameManager.instance.Charge();
    GameManager.instance.ChStopB();
    _spineAnimationState.SetAnimation(0, ChargeAnm, true); 
    fillDuration = skill.MaxDuration; 
    skill.Utilizzi--;
    UpdatePreviewSkill.instance.UpdateInfoPanel(skill);
    nameT = skill.itemName;
    SkillAtt = skill;
    TimeS = skill.TimeSkill;
    GameManager.instance.TimerMenu();
    switch(skill.WhoSkill)
    {
    case 0:
    Anm = Skill0;VFX.SetActive(true);
    break;
    case 1:
    Anm = Skill1;VFX.SetActive(true);
    break;
    case 2:
    Anm = Skill2;VFX.SetActive(true);
    break;
    case 3:
    Anm = Skill3;VFX.SetActive(true);
    break;
    case 4:
    Anm = Skill4;VFX.SetActive(true);
    break;
    case 5:
    Anm = Skill5;VFX.SetActive(true);
    break;
    case 6:
    Anm = Skill6;VFX.SetActive(true);
    break;
    case 7:
    Anm = Skill7;VFX.SetActive(true);
    break;
    case 8:
    Anm = Skill8;VFX.SetActive(true);
    break;
    case 9:
    Anm = Skill9;VFX.SetActive(true);
    break;
    case 10:
    Anm = SkillRage;VFXRAGE.SetActive(true);
    break;
    }
    }
    else
    {AudioManager.instance.PlayUFX(10); TimerSkill.instance.Notuse();}
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
                print("StartSkil");
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
    VFX.SetActive(false);
    VFXRAGE.SetActive(false);
    Mossa.SetActive(false);
    GameManager.instance.CloseTimerMenu();
    //_spineAnimationState.SetAnimation(0, LunchAnm, false); 
    if(SkillAtt.isRage)
    {AnimationRage.SetActive(true);
    yield return new WaitForSeconds(2f);
    AnimationRage.SetActive(false);}
    AM.PlayAnimation(Anm);
    if(SkillAtt.isRage){RageCurr();}
    switch(SkillAtt.WhoCH)
    {
    case 0:
    PlayerStats.instance.F_curMP -= SkillAtt.CostMP; 
    break;
    case 1:
    PlayerStats.instance.K_curMP -= SkillAtt.CostMP; 
    break;
    case 2:
    PlayerStats.instance.S_curMP -= SkillAtt.CostMP; 
    break;
    }
    yield return new WaitForSeconds(TimeS);
    GameManager.instance.ResumeBattle();
    CameraZoom.instance.ZoomOut();
    if(SkillAtt.isRage){CamSkillBack();}
    curTime = 0;
    isSkillLaunched = false;
    GameManager.instance.ChCanM();
    GameManager.instance.NotTouchOption = false;
    
    GameManager.instance.StopWin();
}
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
    public void CamSkill(){vCam.Follow = RPoint.transform;}
    public void CamSkillBack(){vCam.Follow = Player.transform;}

}