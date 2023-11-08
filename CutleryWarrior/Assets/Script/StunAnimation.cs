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
    public SwitchCharacter SwitcherUI;
    public ManagerCharacter MC;
    public StunAnimation This;

    [SpineAnimation][SerializeField]  string StunAnimationName;
    public GameObject ScriptEnm;

    public void Awake()
    {spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState; spineAnimationState = skeletonAnimation.AnimationState;}
    private void OnDisable(){VFX.SetActive(false);}
    private void OnEnable() 
    {
        VFX.SetActive(true);
         if(!isPlayer){StartCoroutine(Stun()); spineAnimationState.SetAnimation(0, StunAnimationName, true);}
        else if(isPlayer){StunLoop(); StartCoroutine(Stun());}
    }
    void Update(){}    
    private IEnumerator Stun()
    {
        yield return new WaitForSeconds(TimeStun);
        if(isPlayer){
        if(MC.kindCH == 0){
        switch (SwitcherUI.rotationSwitcher.CharacterID)
        {
            case 1:
            GameManager.instance.RestoreF();
            break;
            case 2:
            GameManager.instance.RestoreK();
            break; 
            case 3:
            GameManager.instance.RestoreS();
            break;
        }}
        else if(MC.kindCH == 1){
        switch (SwitcherUI.rotationSwitcher.CharacterIDSec)
        {
            case 1:
            GameManager.instance.RestoreF();
            break;
            case 2:
            GameManager.instance.RestoreK();
            break; 
            case 3:
            GameManager.instance.RestoreS();
            break;
        }
        switch (SwitcherUI.rotationSwitcher.CharacterIDTer)
        {
            case 1:
            GameManager.instance.RestoreF();
            break;
            case 2:
            GameManager.instance.RestoreK();
            break; 
            case 3:
            GameManager.instance.RestoreS();
            break;
        }
        }
        }else if(!isPlayer)
        {This.enabled = false;}
    }
    public void StunLoop(){spineAnimationState.SetAnimation(0, StunAnimationName, true);}
}