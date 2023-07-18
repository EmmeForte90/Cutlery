using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class NPCMove : MonoBehaviour
{
    public Transform[] waypoints; // Array di punti verso cui muoversi
    public float moveSpeed = 5f; // Velocità di movimento del personaggio
    public float pauseTime = 2f; // Tempo di pausa in secondi quando raggiunge un punto
    bool Right = true;

    private int currentWaypointIndex = 0; // Indice del punto attuale
    private bool isPaused = false; // Flag per indicare se è in pausa
    private float pauseTimer = 0f; // Timer per il conteggio della pausa
    

    [Header("Animations")]
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    [SpineAnimation][SerializeField] private string WalkAnimationName;

    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    private void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {
            Debug.LogError("Componente SkeletonAnimation non trovato!");
        }        
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position; // Posiziona il personaggio al primo waypoint
        }
    }

    private void Update()
    {
        Flip();
        if (!isPaused)
        {
            MoveToWaypoint();
            Walk();
        }
        else
        {
            PauseAtWaypoint();
            Idle();
        }
    }

    private void MoveToWaypoint()
{
    if (waypoints.Length > 1 && currentWaypointIndex < waypoints.Length - 1)
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex + 1].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            // Raggiunto il punto, attiva la pausa
            isPaused = true;
            pauseTimer = 0f;
        }
    }
    else if (currentWaypointIndex == waypoints.Length - 1)
    {
        // Raggiunto l'ultimo punto, ritorna al punto iniziale
        Vector3 initialPosition = waypoints[0].position;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

        if (transform.position == initialPosition)
        {
            // Raggiunto il punto iniziale, ricomincia il percorso
            isPaused = true;
            pauseTimer = 0f;
            currentWaypointIndex = 0;
            
        }
    }
}
 private void Flip()
    {
        if (Right && transform.localScale.x < 0f || !Right && transform.localScale.x > 0f)
        {
            Right = !Right;
            Vector3 localScale = transform.localScale;
            localScale.x *= 1f;
            transform.localScale = localScale;
        }
    }

 // Metodo per attivare lo script
    public void EnableScript()
    {
        enabled = true;
    }

    // Metodo per disattivare lo script
    public void DisableScript()
    {
        enabled = false;
    }
    private void PauseAtWaypoint()
    {
        if (pauseTimer < pauseTime)
        {
            pauseTimer += Time.deltaTime;
        }
        else
        {
            // Riprendi il movimento al prossimo waypoint
            isPaused = false;
            currentWaypointIndex++;
        }
    }

    public void Walk()
{
    if (currentAnimationName != WalkAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, WalkAnimationName, true);
                    currentAnimationName = WalkAnimationName;
                }

}
 public void Idle()
{
    if (currentAnimationName != IdleAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, IdleAnimationName, true);
                    currentAnimationName = IdleAnimationName;
                }

}

private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    // Remove the event listener
    trackEntry.Complete -= OnAttackAnimationComplete;

    // Clear the track 1 and reset to the idle animation
    _skeletonAnimation.state.ClearTrack(1);
    _skeletonAnimation.state.SetAnimation(0, IdleAnimationName, true);
}
}
