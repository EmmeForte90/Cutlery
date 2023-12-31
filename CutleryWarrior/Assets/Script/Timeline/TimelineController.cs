using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using System.Collections;
using TMPro;
    public class TimelineController : MonoBehaviour 
    {    
    public bool isTutorial;
    public Dialogues DialoguesT;
    public TextMeshProUGUI CharacterName; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI dialogueText; // Reference to the TextMeshProUGUI component
    private string[] dialogue; // array of string to store the dialogues
    private float dialogueDuration; // variable to set the duration of the dialogue
    private int dialogueIndex; // variable to keep track of the dialogue status
    private float elapsedTime; // variable to keep track of the elapsed time
    [Header("Timeline")]
    public int ID;
    public int WhatMusic = 1;
    public PlayableDirector _director;
    public GameObject Cutscene;
    public GameObject Triangle;
    [Header("Activate&Deactivate")]
    public bool isCutscene = false;
    public GameObject PointView; // Variabile per il player
    public GameObject FAct;
    public ActorManager F_AM;
    public GameObject KAct;
    public ActorManager K_AM;
    public GameObject SAct;
    public ActorManager S_AM;

     [Header("Fork")]
    private GameObject ForkActive;
    private CharacterMove F_Script;
    private ChangeHeroSkin Skin_F;
    private CharacterFollow AI_F;
    [Header("Spoon")]
    private GameObject SpoonActive;
    private CharacterMove S_Script;
    private CharacterFollow AI_S;
    private ChangeHeroSkin Skin_S;
    [Header("Knife")]
    private GameObject KnifeActive;
    private CharacterMove K_Script;
    private CharacterFollow AI_K;
    private CinemachineVirtualCamera virtualCamera; //riferimento alla virtual camera di Cinemachine
    private GameObject player; // Variabile per il player
    private GameObject AI_1; 
    private GameObject AI_2; 
    private GameObject F_Brain; // Variabile per il player
    private GameObject K_Brain; // Variabile per il player
    private GameObject S_Brain; // Variabile per il player
    public CambioFollow CameraTransition;
    public GameObject[] ActiveTiemAfterScene;
    //private float transitionTimer = 0.0f;
    //private bool isTransitioning = false;
    //private float transitionDuration = 500f;

    private void Start()
    {
        dialogue = DialoguesT.dialogue;
        if (ContainsIdEvent(PlayerStats.instance.Timelines, ID)){gameObject.SetActive(false);}
    }
    public void TakeData()
    {
    virtualCamera = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    GameManager.instance.Minimap.SetActive(false); GameManager.instance.activeMinimap = false;
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
    if(!isTutorial){CharacterName.text = DialoguesT.CharacterName;}
    if(isCutscene){ActivateActor(); virtualCamera.Follow =  PointView.transform; dialogue = DialoguesT.dialogue;}
    }
    bool ContainsIdEvent(bool[] array, int idEvent)
    {
        // Controlla se l'indice idEvent è valido nell'array
        if (idEvent >= 0 && idEvent < array.Length){return array[idEvent];}
        // Restituisci true se l'elemento nell'array corrispondente all'idEvent è true
        return false; 
        // Restituisci false se l'indice idEvent non è valido
    }

    public void CameraONPoint(){CameraTransition.StartTransition();}
    public void CameraONActor(){ActivateActor();}
    private void OnEnable()
    {if(!isTutorial){
    TakeData();ActivateActor();
    GameManager.instance.ChStopWithoutANM();
    if(GameManager.instance.F_Unlock){F_AM.ChangeColorNormal(); GameManager.instance.AM.StopSFX(0);}
    if(GameManager.instance.K_Unlock){K_AM.ChangeColorNormal(); GameManager.instance.AM.StopSFX(0);}
    if(GameManager.instance.S_Unlock){S_AM.ChangeColorNormal(); GameManager.instance.AM.StopSFX(0);}
    }
    
        
    }//GameManager.instance.FadeOut();}}    
    private void OnDisable(){if(!isTutorial){ActivatePlayer();}}
    public void StartFirstMusic(){GameManager.instance.AM.PlayMFX(0);}
    public void FirstDialogue(){dialogue = DialoguesT.dialogue; dialogueIndex = 0; StartCoroutine(ShowDialogue());}
    public void CH_Name_1(){CharacterName.text = DialoguesT.CharacterName;}
    public void CH_Name_2(){CharacterName.text = DialoguesT.CharacterName_1;}
    public void CH_Name_3(){CharacterName.text = DialoguesT.CharacterName_2;}
    public void CH_Name_4(){CharacterName.text = DialoguesT.CharacterName_3;}
    public void CH_Name_5(){CharacterName.text = DialoguesT.CharacterName_4;}
    //public void FadeIn(){GameManager.instance.FadeIn();}
    //public void FadeOut(){GameManager.instance.FadeOut();}
    public void TalkFork(){GameManager.instance.AM.PlaySFX(2);}
    public void TalkKnife(){GameManager.instance.AM.PlaySFX(0);}
    public void TalkSpoon(){GameManager.instance.AM.PlaySFX(1);}

    public void ActivateActor()
    {
        dialogueIndex = 0;
        GameManager.instance.NotTouchOption = true;
        GameManager.instance.StopRunning();
        GameManager.instance.TrasparentCH();
        switch(GameManager.instance.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock){
            player = GameManager.instance.Fork; 
            F_AM.ChangeColorNormal(); 
            if(!isCutscene){virtualCamera.Follow =  FAct.transform;}
            FAct.transform.position = player.transform.position;
            FAct.transform.position = F_Brain.transform.position;
            }
            //
            if(GameManager.instance.K_Unlock){AI_1 = GameManager.instance.Knife;
            K_AM.ChangeColorNormal(); 
            KAct.transform.position = K_Brain.transform.position;
            }
            //
            if(GameManager.instance.S_Unlock){AI_2 = GameManager.instance.Spoon;
            S_AM.ChangeColorNormal();  
            SAct.transform.position = S_Brain.transform.position;
            }
            break;
            //////////////////////////////////////////////////
            case 2:
            if(GameManager.instance.F_Unlock){AI_1 = GameManager.instance.Fork; 
            F_AM.ChangeColorNormal();  
            FAct.transform.position = F_Brain.transform.position;
            }
            //
            if(GameManager.instance.K_Unlock){player = GameManager.instance.Knife;
            K_AM.ChangeColorNormal();  
            KAct.transform.position = K_Brain.transform.position;
            }
            //
            if(GameManager.instance.S_Unlock){AI_2 = GameManager.instance.Spoon;
            S_AM.ChangeColorNormal();  
            SAct.transform.position = S_Brain.transform.position;
            }
            break;
            //////////////////////////////////////////////////
            case 3:
            if(GameManager.instance.F_Unlock){AI_1 = GameManager.instance.Fork; 
            F_AM.ChangeColorNormal(); 
            FAct.transform.position = F_Brain.transform.position;
            }
            //
            if(GameManager.instance.K_Unlock){player = GameManager.instance.Knife;
            K_AM.ChangeColorNormal();  
            KAct.transform.position = K_Brain.transform.position;
            }
            //
            if(GameManager.instance.S_Unlock){player = GameManager.instance.Spoon;
            S_AM.ChangeColorNormal();  
            SAct.transform.position = S_Brain.transform.position;
            }
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
            player.transform.position = FAct.transform.position;
            F_Brain.transform.position = FAct.transform.position;
            virtualCamera.Follow =  F_Brain.transform;
            F_Script.isRun = false;
            F_AM.ChangeColorTrasparent();
            }
            //
            if(GameManager.instance.K_Unlock){AI_1 = GameManager.instance.Knife;
            K_Brain.transform.position = KAct.transform.position;
            K_AM.ChangeColorTrasparent();}
            //
            if(GameManager.instance.S_Unlock){AI_2 = GameManager.instance.Spoon;
            S_Brain.transform.position = SAct.transform.position;
            S_AM.ChangeColorTrasparent();}
            break;
            //////////////////////////////////////////////////
            case 2:
            GameManager.instance.NotTouchOption = false;
            if(GameManager.instance.F_Unlock){AI_1 = GameManager.instance.Fork; 
            F_Brain.transform.position = FAct.transform.position;
            F_AM.ChangeColorTrasparent();}
            //
            if(GameManager.instance.K_Unlock){player = GameManager.instance.Knife;
            K_Brain.transform.position = KAct.transform.position;
            virtualCamera.Follow =  K_Brain.transform;
            K_Script.isRun = false;
            K_AM.ChangeColorTrasparent();}
            //
            if(GameManager.instance.S_Unlock){AI_2 = GameManager.instance.Spoon;
            S_Brain.transform.position = SAct.transform.position;
            S_AM.ChangeColorTrasparent();}
            break;
            //////////////////////////////////////////////////
            case 3:
            GameManager.instance.NotTouchOption = false;
            if(GameManager.instance.F_Unlock){AI_1 = GameManager.instance.Fork; 
            F_Brain.transform.position = FAct.transform.position;
            F_Script.isRun = false;S_Script.isRun = false;K_Script.isRun = false;
            F_AM.ChangeColorTrasparent();}
            //
            if(GameManager.instance.K_Unlock){AI_2 = GameManager.instance.Knife;
            K_Brain.transform.position = KAct.transform.position;
            K_AM.ChangeColorTrasparent();}
            //
            if(GameManager.instance.S_Unlock){player = GameManager.instance.Spoon;
            S_Brain.transform.position = SAct.transform.position;
            virtualCamera.Follow =  S_Brain.transform;
            S_Script.isRun = false;
            S_AM.ChangeColorTrasparent();}
            break;
        }   
        GameManager.instance.ResetTrasparentCH();
        virtualCamera.transform.rotation = Quaternion.Euler(18f, -90f, 0f);
        PlayerStats.instance.TimelineEnd(ID);
        GameManager.instance.NotTouchOption = false;
        GameManager.instance.ChCanM();
    }


    public void NextDialogue()
    {
        elapsedTime = 0; // reset elapsed time
        dialogueIndex++; // Increment the dialogue index
        if (dialogueIndex >= dialogue.Length){dialogueIndex = 0;}
        else{StartCoroutine(ShowDialogue());}
    }

     IEnumerator ShowDialogue()
{
    elapsedTime = 0; // reset elapsed time
    string currentDialogue = dialogue[dialogueIndex]; // Get the current dialogue
    dialogueText.text = ""; // Clear the dialogue text
    for (int i = 0; i < currentDialogue.Length; i++)
    {
        dialogueText.text += currentDialogue[i]; // Add one letter at a time
        elapsedTime += Time.deltaTime; // Update the elapsed time
        if (elapsedTime >= dialogueDuration){break;}
        yield return new WaitForSeconds(0.001f); // Wait before showing the next letter
    }
    dialogueText.text = currentDialogue; // Set the dialogue text to the full current dialogue
}

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetButton("Fire1")) && _director.time != 0){StartTimeline();}
       /* if (isTransitioning)
        {
            transitionTimer += Time.deltaTime;

            float t = Mathf.Clamp01(transitionTimer / transitionDuration);
            //virtualCamera.transform.rotation = Quaternion.Slerp(virtualCamera.transform.rotation, targets[currentTargetIndex].rotation, t);
            virtualCamera.transform.rotation = Quaternion.Euler(14f, -90f, 0f);
            if (t >= 1.0f)
            {
                isTransitioning = false;
            }
        }*/
    }

    public  void StartMusicG()
    {
        if(AudioManager.instance == null) return;
        AudioManager.instance.PlayMFX(WhatMusic);
    }

    public  void ResetCamera()
    {
        virtualCamera.Follow =  player.transform;
        virtualCamera.transform.rotation = Quaternion.Euler(18f, -90f, 0f);
        GameManager.instance.StopWin();
        GameManager.instance.ChCanM();  
        GameManager.instance.notChange = false;
    }
    public  void ResetCameraActor()
    {
         switch(GameManager.instance.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock){
            virtualCamera.Follow =  F_Brain.transform;
            virtualCamera.transform.rotation = Quaternion.Euler(18f, -90f, 0f);}
            break;
            //////////////////////////////////////////////////
            case 2:
            if(GameManager.instance.F_Unlock){
            virtualCamera.Follow =  K_Brain.transform;
            virtualCamera.transform.rotation = Quaternion.Euler(18f, -90f, 0f);}
            break;
            //////////////////////////////////////////////////
            case 3:
            GameManager.instance.NotTouchOption = false;
            if(GameManager.instance.F_Unlock){
            virtualCamera.Follow =  S_Brain.transform;
            virtualCamera.transform.rotation = Quaternion.Euler(18f, -90f, 0f);}
            break;
    
}}
    public void Take(){Destroy(gameObject);}
    public void CancellTimeline(){PlayerStats.instance.TimelineEnd(ID);}
    public void RestoreGameplay(){foreach (GameObject arenaObject in ActiveTiemAfterScene){arenaObject.SetActive(true);}}

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