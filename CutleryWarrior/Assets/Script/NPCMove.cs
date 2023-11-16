using UnityEngine;
using Spine.Unity;
public class NPCMove : MonoBehaviour
{
    #region Header
    private GameObject player;
    private GameObject ForkActive;
	private GameObject SpoonActive;
	private GameObject KnifeActive;
    public bool isMonster, isWalk, isRun, top = false;
    public Transform[] waypoints; // Array di punti verso cui muoversi
    private float moveSpeed = 5f; // Velocità di movimento del personaggio
    private float RunSpeed = 6f; // Velocità di movimento del personaggio
    private float pauseTime = 2f; // Tempo di pausa in secondi quando raggiunge un punto
    bool Right = true;
    public float stoppingDistance = 1f;
    private int currentWaypointIndex = 0; // Indice del punto attuale
    public bool isPaused = false; // Flag per indicare se è in pausa
    private float pauseTimer = 0f; // Timer per il conteggio della pausa
    public int Behav = 0; // Tempo di pausa in secondi quando raggiunge un punto
    public Transform Agro;
    public float agroDistance = 1f;
    public Transform TouchO;
    public float TouchDistance = 1f;
    private CharacterController characterController;
    private float previousZPosition; // Aggiungi questa variabile

    public float gravity = 9.81f;  // Gravità personalizzata, puoi regolarla come desideri

    private SwitchCharacter rotationSwitcher;
    [Header("Animations")]
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    [SpineAnimation][SerializeField] private string WalkAnimationName;
    [SpineAnimation][SerializeField] private string RunAnimationName;
    [SpineAnimation][SerializeField] private string IdleUPAnimationName;
    [SpineAnimation][SerializeField] private string WalkUPAnimationName;
    [SpineAnimation][SerializeField] private string RunUPAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    #endregion
    public void Start()
    {
        characterController = GetComponent<CharacterController>();
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
    Gravity();

    if (top && isWalk && !isRun)
    {WalkUP();}
    else if (!top  && isWalk && !isRun)
    {Walk();}
    else if (top && !isWalk && isRun)
    {RunUP();}
    else if (!top && !isWalk && isRun)
    {Run();}
    else if (top && !isRun && !isWalk)
    {IdleUP();}
    else if (!top && !isRun && !isWalk)
    {Idle();}

    // Verifica della distanza tra il nemico e il giocatore
    if ((transform.position - player.transform.position).sqrMagnitude > agroDistance * agroDistance)
    {
        Behav = 0;
    }
    else if ((transform.position - player.transform.position).sqrMagnitude < agroDistance * agroDistance && isMonster)
    {
        Behav = 1;
        AudioManager.instance.PlaySFX(14);
    }

    switch (Behav)
    {
        case 0:
            if (!isPaused)
            {
                MoveToWaypoint();
                Flip();
                isWalk = true;
                isRun = false;
            }
            else
            {
                PauseAtWaypoint();
                isWalk = false;
                isRun = false;
                Flip();
            }
            break;
        case 1:
            ChasePlayer();
            isWalk = false;
            isRun = true;
            FacePlayer();
            break;
        case 2:
            FacePlayer();
            isWalk = false;
            isRun = false;
            break;
    }
}

    private void Gravity()
    {
    if (!characterController.isGrounded)
        {
            // Applica la gravità personalizzata se necessario
            Vector3 gravityVector = new Vector3(0, -gravity, 0);
            characterController.Move(gravityVector * Time.deltaTime);
        }
    }
    private void ChasePlayer()
    {
        float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
        float currentZPosition = transform.position.z;
        if (player != null && distanceToTarget > TouchDistance)
        {transform.position = Vector3.MoveTowards(transform.position, player.transform.position, RunSpeed * Time.deltaTime);}
        else if(player != null && distanceToTarget < TouchDistance)
        {Behav = 2;}
         // Ruota il personaggio in base all'asse locale X o Z
            if (currentZPosition > previousZPosition)
            {
                top = false;
            }
            else
            {
                top = true;
            }

            previousZPosition = currentZPosition;
    
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
    float currentZPosition = transform.position.z;

    if (waypoints.Length > 1 && currentWaypointIndex < waypoints.Length - 1)
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex + 1].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // Verifica se il personaggio è vicino al punto di destinazione
        if (Vector3.Distance(transform.position, targetPosition) < stoppingDistance)
        {
            isPaused = true;
            pauseTimer = 0f;
            transform.localScale = new Vector3(-1, 1,1);

            // Ruota il personaggio in base all'asse locale X o Z
            if (currentZPosition > previousZPosition)
            {
                top = false;
            }
            else
            {
                top = true;
            }

            previousZPosition = currentZPosition;
        }
    }
    else if (currentWaypointIndex == waypoints.Length - 1)
    {
        Vector3 initialPosition = waypoints[0].position;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

        // Verifica se il personaggio è vicino al punto di destinazione
        if (Vector3.Distance(transform.position, initialPosition) < stoppingDistance)
        {
            isPaused = true;
            pauseTimer = 0f;
            transform.localScale = new Vector3(1, 1,1);

            // Incrementa l'indice del waypoint o torna al punto 0 se siamo all'ultimo
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            // Ruota il personaggio in base all'asse locale X o Z
            if (currentZPosition > previousZPosition)
            {
                top = false;
            }
            else
            {
                top = true;
            }

            previousZPosition = currentZPosition;
        }
    }
}



    private void PauseAtWaypoint()
    {
        if (pauseTimer < pauseTime){pauseTimer += Time.deltaTime;}
        else{isPaused = false; currentWaypointIndex++;}
    }
    private void Flip()
    {
        if (Right && transform.localScale.z < 0f || !Right && transform.localScale.z > 0f)
        {
            Right = !Right;
            Vector3 localScale = transform.localScale;
            localScale.z *= -1f;
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
            if (player.transform.position.z > transform.position.z){transform.localScale = new Vector3(-1, 1, 1);}
            else{transform.localScale = new Vector3(1, 1, 1);}
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
         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(TouchO.position, TouchDistance);
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

    public void WalkUP()
    {
    if (currentAnimationName != WalkUPAnimationName)
        {
        _spineAnimationState.SetAnimation(0, WalkUPAnimationName, true);
        currentAnimationName = WalkUPAnimationName;
        }
    }
    public void RunUP()
    {
    if (currentAnimationName != RunUPAnimationName)
        {
        _spineAnimationState.SetAnimation(0, RunUPAnimationName, true);
        currentAnimationName = RunUPAnimationName;
        }
    }
    public void IdleUP()
    {
    if (currentAnimationName != IdleUPAnimationName)
        {
        _spineAnimationState.SetAnimation(0, IdleUPAnimationName, true);
        currentAnimationName = IdleUPAnimationName;
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