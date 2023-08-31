using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Spine.Unity;
using Cinemachine;
public class TouchPlayer : MonoBehaviour
{
    #region Header
    public string spawnPointTag = "SpawnPoint";
    private CinemachineVirtualCamera vCam;
    public bool camFollowPlayer = true;
    private SceneEvent sceneEvent;
    public string sceneName;
    public float stoppingDistance = 1f;
    public Vector3 savedPosition;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    private SwitchCharacter Switch;
    public bool takeCoo = false;

    [Header("Move")]
    [Tooltip("Il personaggio si muove?")]
    public bool IsMove = false;
    bool movingB = false;
    public Transform[] waypoints; // Array di punti verso cui muoversi
    public float moveSpeed = 5f; // Velocità di movimento del personaggio
    public float pauseTime = 2f; // Tempo di pausa in secondi quando raggiunge un punto
    bool Right = true;
    private int currentWaypointIndex = 0; // Indice del punto attuale
    private bool isPaused = false; // Flag per indicare se è in pausa
    private float pauseTimer = 0f; // Timer per il conteggio della pausa    
    
    [Header("Animations")]
    [SpineAnimation][SerializeField] private string TalnkAnimationName;
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    [SpineAnimation][SerializeField]  string WalkAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    public int IDAudio;
    #endregion
    public void Start()
    {
    if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
    sceneEvent = GetComponent<SceneEvent>();
    sceneEvent.onSceneChange.AddListener(ChangeScene);
    Fork = GameObject.Find("F_Player").transform;
    Spoon = GameObject.Find("S_Player").transform;
    Knife = GameObject.Find("K_Player").transform;
    _skeletonAnimation = GetComponent<SkeletonAnimation>();
    if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}        
    _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
    _spineAnimationState = _skeletonAnimation.AnimationState;
    _skeleton = _skeletonAnimation.skeleton;
    if(IsMove)
        {movingB = true;}
        if (waypoints.Length > 0 && IsMove)
        {transform.position = waypoints[0].position;}
        // Posiziona il personaggio al primo waypoint   
    }
    public void Update()
    {
    if(Switch.isElement1Active){Player = Spoon;}
    else if(Switch.isElement2Active){Player = Fork;} 
    else if(Switch.isElement3Active){Player = Knife;} 
    if(!takeCoo){
    if ((transform.position - Player.transform.position).sqrMagnitude < stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = true;}}
    if ((transform.position - Player.transform.position).sqrMagnitude > stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = false;}
    }
    private void ChangeScene()
    {   
    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){SceneManager.sceneLoaded -= OnSceneLoaded;}
    IEnumerator WaitForSceneLoad()
    {   
    GameManager.instance.ChStop();
    yield return new WaitForSeconds(1f);
    GameManager.instance.battle = true;
    GameManager.instance.savedPosition = savedPosition;
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(1f);
    GameManager.instance.StopAllarm();
    GameManager.instance.Posebattle();
    sceneEvent.InvokeOnSceneChange();
    }

    public void MoveToWaypoint()
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
    public void Flip()
    {
        if (Player.localScale.x > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (Player.localScale.x < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {                
        AudioManager.instance.CrossFadeOUTAudio(0);
        GameManager.instance.NotChange();
        AudioManager.instance.PlayUFX(7);
        GameManager.instance.ChStop();
        GameManager.instance.Allarm();
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.CrossFadeINAudio(1);
        StartCoroutine(WaitForSceneLoad());
    }}
    #if(UNITY_EDITOR)
    #region Gizmos
    private void OnDrawGizmos()
        {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + new Vector3(transform.localScale.x, 0, 0) * wallDistance);
        //Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
        }
    #endregion
    #endif
}