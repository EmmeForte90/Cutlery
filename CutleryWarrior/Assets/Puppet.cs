using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class Puppet : MonoBehaviour
{
    [SpineAnimation][SerializeField] private string Idle_atkAnimationName;
    [SpineAnimation][SerializeField] private string Idle_DefAnimationName;
    [SpineAnimation][SerializeField] private string DefAnimationName;
    [SpineAnimation][SerializeField] private string PrepareATKAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;

    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    public static Puppet instance;

private void Awake()
    {
       
         if (instance == null)
        {
            instance = this;
        }
    //////////////////////////
        
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {
            Debug.LogError("Componente SkeletonAnimation non trovato!");
        }        
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;
        //////////////////////////
    }


}
