using UnityEngine;
using Spine.Unity;
public class NPCMove : MonoBehaviour
{
    #region Header
    private GameObject player;
    private GameObject ForkActive;
	private GameObject SpoonActive;
	private GameObject KnifeActive;
    public Transform[] waypoints; // Array di punti verso cui muoversi
    private float moveSpeed = 5f; // Velocità di movimento del personaggio
    private float RunSpeed = 6f; // Velocità di movimento del personaggio
    private float pauseTime = 2f; // Tempo di pausa in secondi quando raggiunge un punto
    bool Right = true;
    private int currentWaypointIndex = 0; // Indice del punto attuale
    private bool isPaused = false; // Flag per indicare se è in pausa
    private float pauseTimer = 0f; // Timer per il conteggio della pausa
    public int Behav = 0; // Tempo di pausa in secondi quando raggiunge un punto
    public Transform Agro;
    public float agroDistance = 1f;
    private SwitchCharacter rotationSwitcher;
    [Header("Animations")]
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    [SpineAnimation][SerializeField] private string WalkAnimationName;
    [SpineAnimation][SerializeField] private string RunAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    #endregion
    public void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        rotationSwitcher = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();
        ForkActive = GameObject.Find("F_Player");
        SpoonActive = GameObject.Find("S_Player");
        KnifeActive = GameObject.Find("K_Player");
        if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}        
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;
        if (waypoints.Length > 0){transform.position = waypoints[0].position;}
    }
    public void Update()
    {
        PlayerTaking();
        if ((transform.position - player.transform.position).sqrMagnitude > agroDistance * agroDistance)
        {Behav = 0;} 
        else if ((transform.position - player.transform.position).sqrMagnitude < agroDistance * agroDistance)
        {Behav = 1;}
        switch(Behav)
        {
            case 0:
            if (!isPaused)
            {MoveToWaypoint(); Walk(); Flip();}
            else
            {PauseAtWaypoint(); Idle(); Flip();}
            break;
            case 1:
            ChasePlayer(); Run(); FacePlayer();
            break;
            case 2:
            PauseAtWaypoint(); Idle();
            break;
        }
    }
    private void ChasePlayer()
    {
        if (player != null)
        {transform.position = Vector3.MoveTowards(transform.position, player.transform.position, RunSpeed * Time.deltaTime);}
    }
    private void PlayerTaking()
    {
        switch(rotationSwitcher.ConInt)
        {
            case 1:
			player = ForkActive;
            break;
            case 2:
			player = KnifeActive;
            break;
            case 3:
			player = SpoonActive;
            break;
        }
    }
    private void MoveToWaypoint()
    {
    if (waypoints.Length > 1 && currentWaypointIndex < waypoints.Length - 1)
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex + 1].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {isPaused = true; pauseTimer = 0f;}
    }
    else if (currentWaypointIndex == waypoints.Length - 1)
    {
        Vector3 initialPosition = waypoints[0].position;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
        if (transform.position == initialPosition)
        {isPaused = true; pauseTimer = 0f; currentWaypointIndex = 0;}
    }}
    private void PauseAtWaypoint()
    {
        if (pauseTimer < pauseTime){pauseTimer += Time.deltaTime;}
        else{isPaused = false; currentWaypointIndex++;}
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
    private void FacePlayer()
    {
        switch(SwitchCharacter.instance.rotationSwitcher.CharacterID)
        {
            case 1:
            player = GameObject.Find("F_Player");
            break;
            case 2:
            player = GameObject.Find("K_Player");       
            break;
            case 3:
            player = GameObject.Find("S_Player");
            break;
        }
        if (player != null)
        {
            if (player.transform.position.z > transform.position.z){transform.localScale = new Vector3(1, 1, 1);}
            else{transform.localScale = new Vector3(-1, 1, 1);}
        }
    }
    public void EnableScript(){enabled = true;}
    public void DisableScript(){enabled = false;}
    #if(UNITY_EDITOR)
    #region Gizmos
        private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Agro.position, agroDistance);
    }
    #endregion
    #endif
    #region Animazione
    public void Walk()
    {
    if (currentAnimationName != WalkAnimationName)
        {
        _spineAnimationState.SetAnimation(0, WalkAnimationName, true);
        currentAnimationName = WalkAnimationName;
        }
    }
    public void Run()
    {
    if (currentAnimationName != RunAnimationName)
        {
        _spineAnimationState.SetAnimation(0, RunAnimationName, true);
        currentAnimationName = RunAnimationName;
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
    trackEntry.Complete -= OnAttackAnimationComplete;
    _skeletonAnimation.state.ClearTrack(1);
    _skeletonAnimation.state.SetAnimation(0, IdleAnimationName, true);
    }
    #endregion
}