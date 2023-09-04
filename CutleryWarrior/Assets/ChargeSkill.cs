using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using System.Collections;
public class ChargeSkill : MonoBehaviour
{
    [Header("Timer")]
    public Scrollbar TimeBar;
    private Skill SkillAtt;
    public GameObject MP;
    public float fillDuration;  // Durata desiderata per riempire la barra in secondi
    private float curTime = 0;       // Tempo trascorso
    public Spine.AnimationState _spineAnimationState;    
    public SkeletonAnimation _skeletonAnimation;
    private bool isSkillLaunched = false;

    [SpineAnimation][SerializeField] string ChargeAnm;

    public void Awake()
    {_spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState; 
    _spineAnimationState = _skeletonAnimation.AnimationState;}

    public void TakeData(Skill skill)
    {
    GameManager.instance.Charge();
    GameManager.instance.TimerMenu();
    _spineAnimationState.SetAnimation(0, ChargeAnm, true); 
    fillDuration = skill.MaxDuration; 
    SkillAtt = skill;
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
    yield return new WaitForSeconds(3f);
    print("LunchSkill");
    GameManager.instance.ResumeBattle();
    //GameManager.instance.StopWin();
}

    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
}