using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

    public class TimelineController : MonoBehaviour 
    {    
    [Header("Timeline")]
    public int WhatMusic = 1;
    public PlayableDirector _director;
    public GameObject Cutscene;
    public GameObject Triangle;
    [Header("Activate&Deactivate")]
    public bool isCutscene = false;
    public GameObject PointView; // Variabile per il player
    public int ID;
    public GameObject FAct;
    public GameObject KAct;
    public GameObject SAct;
   
     [Header("Fork")]
    private GameObject ForkActive;
    private CharacterMove F_Script;
    //public GameObject F_point; // Variabile per il player
    private ChangeHeroSkin Skin_F;
    private CharacterFollow AI_F;
    [Header("Spoon")]
    private GameObject SpoonActive;
    private CharacterMove S_Script;
    //public GameObject S_point; // Variabile per il player
    private CharacterFollow AI_S;
    private ChangeHeroSkin Skin_S;
    [Header("Knife")]
    private GameObject KnifeActive;
    private CharacterMove K_Script;
    private CharacterFollow AI_K;
    //public GameObject K_point; // Variabile per il player
    private CinemachineVirtualCamera virtualCamera; //riferimento alla virtual camera di Cinemachine
    private GameObject player; // Variabile per il player
    private GameObject AI_1; 
    private GameObject AI_2; 
    private GameObject F_Brain; // Variabile per il player
    private GameObject K_Brain; // Variabile per il player
    private GameObject S_Brain; // Variabile per il player
    public CambioFollow CameraTransition;
    public GameObject[] ActiveTiemAfterScene;



    private void Start()
    {
    virtualCamera = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    
    if(GameManager.instance.S_Unlock){AI_S = GameManager.instance.S_Hero.GetComponent<CharacterFollow>();}
    if(GameManager.instance.F_Unlock){AI_F = GameManager.instance.F_Hero.GetComponent<CharacterFollow>();}
    if(GameManager.instance.K_Unlock){AI_K = GameManager.instance.K_Hero.GetComponent<CharacterFollow>();}
    //
    if(GameManager.instance.F_Unlock){F_Script = GameManager.instance.F_Hero.GetComponent<CharacterMove>();}
    if(GameManager.instance.K_Unlock){K_Script = GameManager.instance.K_Hero.GetComponent<CharacterMove>();}
    if(GameManager.instance.S_Unlock){S_Script = GameManager.instance.S_Hero.GetComponent<CharacterMove>();}
    //
    if(GameManager.instance.F_Unlock){F_Brain = GameManager.instance.F_Hero;}
    if(GameManager.instance.K_Unlock){K_Brain = GameManager.instance.K_Hero;}
    if(GameManager.instance.S_Unlock){S_Brain = GameManager.instance.S_Hero;}
    if(isCutscene){ActivateActor();} //GameManager.instance.ChStop();
    //if(isCutscene){virtualCamera.Follow =  PointView.transform;}
    if(isCutscene){virtualCamera.Follow =  PointView.transform;}
    }

    public void CameraONPoint(){CameraTransition.StartTransition();}

    public void CameraONActor(){ActivateActor();}
    
    public void ActivateActor()
    {
        //if(isCutscene){virtualCamera.Follow =  PointView.transform;}
        switch(GameManager.instance.CharacterID)
        {
            case 1:
            GameManager.instance.NotTouchOption = true;
            if(GameManager.instance.F_Unlock){
            player = GameManager.instance.Fork; 
            FAct.SetActive(true); 
            if(isCutscene){virtualCamera.Follow =  PointView.transform;}
            else if(!isCutscene){virtualCamera.Follow =  FAct.transform;}
            FAct.transform.position = player.transform.position;
            FAct.transform.position = F_Brain.transform.position;
            player.SetActive(false);}
            //
            if(GameManager.instance.K_Unlock){AI_1 = GameManager.instance.Knife;
            KAct.SetActive(true); 
            KAct.transform.position = K_Brain.transform.position;
            AI_1.SetActive(false);}
            //
            if(GameManager.instance.S_Unlock){AI_2 = GameManager.instance.Spoon;
            SAct.SetActive(true); 
            SAct.transform.position = S_Brain.transform.position;
            AI_2.SetActive(false);}
            break;
            //////////////////////////////////////////////////
            case 2:
            GameManager.instance.NotTouchOption = true;
            if(GameManager.instance.F_Unlock){AI_1 = GameManager.instance.Fork; 
            FAct.SetActive(true); 
            FAct.transform.position = F_Brain.transform.position;
            AI_1.SetActive(false);}
            //
            if(GameManager.instance.K_Unlock){player = GameManager.instance.Knife;
            KAct.SetActive(true); 
            KAct.transform.position = K_Brain.transform.position;
            player.SetActive(false);}
            //
            if(GameManager.instance.S_Unlock){AI_2 = GameManager.instance.Spoon;
            SAct.SetActive(true); 
            SAct.transform.position = S_Brain.transform.position;
            AI_2.SetActive(false);}
            break;
            //////////////////////////////////////////////////
            case 3:
            GameManager.instance.NotTouchOption = true;
            if(GameManager.instance.F_Unlock){AI_1 = GameManager.instance.Fork; 
            FAct.SetActive(true); 
            FAct.transform.position = F_Brain.transform.position;
            AI_1.SetActive(false);}
            //
            if(GameManager.instance.K_Unlock){player = GameManager.instance.Knife;
            KAct.SetActive(true); 
            KAct.transform.position = K_Brain.transform.position;
            AI_2.SetActive(false);}
            //
            if(GameManager.instance.S_Unlock){player = GameManager.instance.Spoon;
            SAct.SetActive(true); 
            SAct.transform.position = S_Brain.transform.position;
            player.SetActive(false);}
            break;
        }   
    }
    public void ActivatePlayer()
    {
        switch(GameManager.instance.CharacterID)
        {
            case 1:
            GameManager.instance.NotTouchOption = false;
            if(GameManager.instance.F_Unlock){
            player = GameManager.instance.Fork; 
            player.SetActive(true); 
            player.transform.position = FAct.transform.position;
            F_Brain.transform.position = FAct.transform.position;
            virtualCamera.Follow =  F_Brain.transform;
            FAct.SetActive(false); }
            //
            if(GameManager.instance.K_Unlock){AI_1 = GameManager.instance.Knife;
            AI_1.SetActive(true);
            K_Brain.transform.position = KAct.transform.position;
            KAct.SetActive(false);}
            //
            if(GameManager.instance.S_Unlock){AI_2 = GameManager.instance.Spoon;
            AI_2.SetActive(true);
            S_Brain.transform.position = SAct.transform.position;
            SAct.SetActive(false);}
            break;
            //////////////////////////////////////////////////
            case 2:
            GameManager.instance.NotTouchOption = false;
            if(GameManager.instance.F_Unlock){AI_1 = GameManager.instance.Fork; 
            AI_1.SetActive(true);
            F_Brain.transform.position = FAct.transform.position;
            FAct.SetActive(false); }
            //
            if(GameManager.instance.K_Unlock){player = GameManager.instance.Knife;
            player.SetActive(true);
            K_Brain.transform.position = KAct.transform.position;
            virtualCamera.Follow =  K_Brain.transform;
            KAct.SetActive(false);}
            //
            if(GameManager.instance.S_Unlock){AI_2 = GameManager.instance.Spoon;
            AI_2.SetActive(true);
            S_Brain.transform.position = SAct.transform.position;
            SAct.SetActive(false);}
            break;
            //////////////////////////////////////////////////
            case 3:
            GameManager.instance.NotTouchOption = false;
            if(GameManager.instance.F_Unlock){AI_1 = GameManager.instance.Fork; 
            AI_1.SetActive(true);
            F_Brain.transform.position = FAct.transform.position;
            FAct.SetActive(false); }
            //
            if(GameManager.instance.K_Unlock){AI_2 = GameManager.instance.Knife;
            AI_2.SetActive(true);
            K_Brain.transform.position = KAct.transform.position;
            KAct.SetActive(false);}
            //
            if(GameManager.instance.S_Unlock){player = GameManager.instance.Spoon;
            player.SetActive(true);
            S_Brain.transform.position = SAct.transform.position;
            virtualCamera.Follow =  S_Brain.transform;
            SAct.SetActive(false);}
            break;
        }   
    }



    private void Update()
    {if ((Input.GetMouseButtonDown(0) || Input.GetButton("Fire1")) && _director.time != 0){StartTimeline();}}


public  void StartMusicG()
{
    if(AudioManager.instance == null) return;
    AudioManager.instance.PlayMFX(WhatMusic);
}

public  void ResetCamera()
{
    virtualCamera.Follow =  player.transform;
    GameManager.instance.StopWin();
    GameManager.instance.ChCanM();  
    GameManager.instance.ActiveMinimap(); 
    Destroy(this);
}
public void Take(){Destroy(gameObject);}
public void CancellTimeline(){PlayerStats.instance.TimelineEnd(ID);}
public void RestoreGameplay(){ActivatePlayer();  
foreach (GameObject arenaObject in ActiveTiemAfterScene){arenaObject.SetActive(true);}}

//public  void TimelineRepeat(){CutsceneManager.Instance.TimelineStart(ID);}

//public  void TimelineDontRepeat(){CutsceneManager.Instance.TimelineEnd(ID);}

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