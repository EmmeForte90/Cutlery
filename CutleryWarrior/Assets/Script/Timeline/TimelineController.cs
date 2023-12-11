using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using System.Collections;
using TMPro;

    public class TimelineController : MonoBehaviour 
    {    
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
    //public GameObject SavePositionCamera;



    private void Start()
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
    CharacterName.text = DialoguesT.CharacterName;
    dialogue = DialoguesT.dialogue;
    if(isCutscene){ActivateActor();}
    if(isCutscene){virtualCamera.Follow =  PointView.transform;}
    if (ContainsIdEvent(PlayerStats.instance.Timelines, ID))
        {
            // Se la condizione è vera, disattiva il gameObject
            gameObject.SetActive(false);
        }
    }
    bool ContainsIdEvent(bool[] array, int idEvent)
    {
        // Controlla se l'indice idEvent è valido nell'array
        if (idEvent >= 0 && idEvent < array.Length)
        {
            // Restituisci true se l'elemento nell'array corrispondente all'idEvent è true
            return array[idEvent];
        }

        // Restituisci false se l'indice idEvent non è valido
        return false;
    }

    public void CameraONPoint(){CameraTransition.StartTransition();}

    public void CameraONActor(){ActivateActor();}

    public void TalkFork(){AudioManager.instance.PlaySFX(2);}
    public void TalkKnife(){AudioManager.instance.PlaySFX(0);}
    public void TalkSpoon(){AudioManager.instance.PlaySFX(1);}

    public void ActivateActor()
    {
        dialogueIndex = 0;
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
            virtualCamera.transform.rotation = Quaternion.Euler(18f, -90f, 0f);
            F_Script.isRun = false;
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
            F_Script.isRun = false;S_Script.isRun = false;K_Script.isRun = false;
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
        PlayerStats.instance.TimelineEnd(ID);
    }

    public void NextDialogue()
    {
        elapsedTime = 0; // reset elapsed time
        dialogueIndex++; // Increment the dialogue index
        if (dialogueIndex >= dialogue.Length)
        {
            dialogueIndex = 0;
            
        }
        else{StartCoroutine(ShowDialogue());}
    }

     IEnumerator ShowDialogue()
{
    //_isDialogueActive = true;
    elapsedTime = 0; // reset elapsed time
    string currentDialogue = dialogue[dialogueIndex]; // Get the current dialogue
    dialogueText.text = ""; // Clear the dialogue text
    for (int i = 0; i < currentDialogue.Length; i++)
    {
        dialogueText.text += currentDialogue[i]; // Add one letter at a time
        elapsedTime += Time.deltaTime; // Update the elapsed time
        if (elapsedTime >= dialogueDuration)
        {
            break;
        }
        yield return new WaitForSeconds(0.001f); // Wait before showing the next letter
    }
            dialogueText.text = currentDialogue; // Set the dialogue text to the full current dialogue
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
    GameManager.instance.notChange = false;
    Destroy(this);
}
public void Take(){Destroy(gameObject);}
public void CancellTimeline(){PlayerStats.instance.TimelineEnd(ID);}
public void RestoreGameplay(){foreach (GameObject arenaObject in ActiveTiemAfterScene){arenaObject.SetActive(true);}}

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