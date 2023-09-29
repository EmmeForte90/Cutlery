using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
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
    /*public GameObject ActorFork;
    public bool F_isRight = false;
    private GameObject ForkActive;
    public GameObject ActorSpoon;
    public bool S_isRight = false;
    private GameObject SpoonActive;
    public GameObject ActorKnife;
    public bool K_isRight = false;
    private GameObject KnifeActive;*/

    public int ID;
    private CinemachineVirtualCamera virtualCamera; //riferimento alla virtual camera di Cinemachine
    private GameObject player; // Variabile per il player
    //private GameObject Camera;


    private void Awake()
    {
    virtualCamera = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    switch(GameManager.instance.CharacterID)
        {
            case 1:
            player = GameObject.FindGameObjectWithTag("F_Player");
            break;
            case 2:
            player = GameObject.FindGameObjectWithTag("K_Player");
            break;
            case 3:
            player = GameObject.FindGameObjectWithTag("S_Player");
            break;
        }
    GameManager.instance.ChStop();
    if(isCutscene)
    {
    virtualCamera.Follow =  PointView.transform;
    /*if(GameManager.instance.F_Unlock)
    {ForkActive = GameObject.Find("F_Player");ForkActive.transform.position = ActorFork.transform.position;}
    if(GameManager.instance.S_Unlock)
    {SpoonActive = GameObject.Find("S_Player");SpoonActive.transform.position = ActorSpoon.transform.position;}
    if(GameManager.instance.K_Unlock)
    {KnifeActive = GameObject.Find("K_Player");KnifeActive.transform.position = ActorKnife.transform.position;}
    }*/
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