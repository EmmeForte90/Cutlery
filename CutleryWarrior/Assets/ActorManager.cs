using System.Collections;
using UnityEngine;
using Spine.Unity;
using Spine;

public class ActorManager : MonoBehaviour
{
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    public void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}  
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;   
       
    }
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
}
