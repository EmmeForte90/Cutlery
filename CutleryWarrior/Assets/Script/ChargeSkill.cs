using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class ChargeSkill : MonoBehaviour
{
    [Header("Timer")]
    public Scrollbar TimeBar;
    private Skill SkillAtt;
    public GameObject MP;
    public GameObject VFX;
    public GameObject Mossa;
    public TextMeshProUGUI nameText;
    private string nameT;
    public float fillDuration;  // Durata desiderata per riempire la barra in secondi
    private float curTime = 0;       // Tempo trascorso
    public Spine.AnimationState _spineAnimationState;    
    public SkeletonAnimation _skeletonAnimation;
    private bool isSkillLaunched = false;
    public  AnimationManager AM;
    [SpineAnimation][SerializeField] string ChargeAnm;
    [SpineAnimation][SerializeField] string LunchAnm;

    public void Awake()
    {_spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState; 
    _spineAnimationState = _skeletonAnimation.AnimationState;}

    public void TakeData(Skill skill)
    {
    GameManager.instance.Charge();
    GameManager.instance.TimerMenu();
    _spineAnimationState.SetAnimation(0, ChargeAnm, true); 
    fillDuration = skill.MaxDuration; 
    nameT = skill.itemName;
    SkillAtt = skill;
    VFX.SetActive(true);
    PlayerStats.instance.F_CostMP -= skill.CostMP;
    switch(skill.WhoCH)
    {
    case 0:
    PlayerStats.instance.F_CostMP -= skill.CostMP;
    break;
    case 1:
    PlayerStats.instance.K_CostMP -= skill.CostMP;
    break;
    case 2:
    PlayerStats.instance.S_CostMP -= skill.CostMP;
    break;
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
            float fillPercentage = curTime / fillDuration;

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
    Mossa.SetActive(false);
    GameManager.instance.CloseTimerMenu();
    //_spineAnimationState.SetAnimation(0, LunchAnm, false); 
    AM.PlayAnimation(LunchAnm);
    print("LunchSkill");
    yield return new WaitForSeconds(3f);
    GameManager.instance.ResumeBattle();
    CameraZoom.instance.ZoomOut();
    GameManager.instance.StopWin();
}

    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
}