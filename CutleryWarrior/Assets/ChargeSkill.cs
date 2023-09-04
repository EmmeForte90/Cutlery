using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using System.Collections;
public class ChargeSkill : MonoBehaviour
{
    [Header("Timer")]
    public GameObject TimerObj;
    public Scrollbar TimeBar;
    private Skill SkillAtt;
    public GameObject MP;
    public float fillDuration;  // Durata desiderata per riempire la barra in secondi
    private float curTime = 0;       // Tempo trascorso
    public Spine.AnimationState _spineAnimationState;    
    public SkeletonAnimation _skeletonAnimation;
    [SpineAnimation][SerializeField] string ChargeAnm;

    public void Awake()
    {_spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState; 
    _spineAnimationState = _skeletonAnimation.AnimationState;}

    public void TakeData(Skill skill)
    {
    TimerObj.SetActive(true);
    TimerObj.transform.position = MP.transform.position;
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
        if(curTime != fillDuration)
        {
         // Incrementa il tempo trascorso in base a Time.deltaTime
        curTime += Time.deltaTime;

        // Calcola la percentuale di completamento
        float fillPercentage = curTime / fillDuration;

        // Imposta la dimensione della barra (assicurandoti che sia compresa tra 0.01f e 1)
        TimeBar.size = Mathf.Clamp(fillPercentage, 0.01f, 1);
        }
        if(curTime >= fillDuration)
        {StartCoroutine(SkillLunch());}
    }
    IEnumerator SkillLunch()
    {_spineAnimationState.SetAnimation(0, ChargeAnm, false);  
     TimerObj.SetActive(false);
    yield return new WaitForSeconds(3f);

    GameManager.instance.StopWin();}
    public void Direction(){transform.localScale = new Vector3(1, 1,1);}
}