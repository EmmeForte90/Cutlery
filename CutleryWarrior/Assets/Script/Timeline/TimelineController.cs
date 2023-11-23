using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

    public class TimelineController : MonoBehaviour 
    {    
    [Header("Timeline")]
    public PlayableDirector _director;
    public GameObject Cutscene;
    public GameObject Triangle;
    [Header("Activate&Deactivate")]
    public bool isCutscene = false;
    public GameObject PointView; // Variabile per il player
    public int ID;
    private CinemachineVirtualCamera virtualCamera; //riferimento alla virtual camera di Cinemachine
    private GameObject player; // Variabile per il player

    private void Awake()
    {
    virtualCamera = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    switch(GameManager.instance.CharacterID)
        {
            case 1:
            player = GameManager.instance.F_Hero;
            break;
            case 2:
            player = GameManager.instance.K_Hero;
            break;
            case 3:
            player = GameManager.instance.S_Hero;
            break;
        }
    GameManager.instance.ChStop();
    if(isCutscene)
    {
    virtualCamera.Follow =  PointView.transform;
    }}

    private void Update()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && _director.time != 0)
        { 
            StartTimeline();
        }
    }


public  void StartMusicG()
{
    if(AudioManager.instance == null) return;
    AudioManager.instance.PlayMFX(1);
}

public  void ResetCamera()
{
    virtualCamera.Follow =  player.transform;
    GameManager.instance.StopWin();
    GameManager.instance.ChCanM();  
    GameManager.instance.ActiveMinimap(); 
    Destroy(this);
}

public  void TimelineRepeat()
{
    CutsceneManager.Instance.TimelineStart(ID);
}

public  void TimelineDontRepeat()
{
    CutsceneManager.Instance.TimelineEnd(ID);
}

    public void StartTimeline()
    {  
        Triangle.SetActive(false);
        _director.time = _director.time;
        _director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }

    public void StopTimeline()
    {
        Triangle.SetActive(true);
        _director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }  
}