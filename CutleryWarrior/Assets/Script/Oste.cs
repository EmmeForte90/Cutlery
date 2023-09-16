using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Spine.Unity;
using Cinemachine;
public class Oste : MonoBehaviour
{
    public Material newSkyboxMaterial_G; // Il nuovo materiale Skybox che desideri applicare
    public GameObject Giorno; // Il nuovo materiale Skybox che desideri applicare
    public Material newSkyboxMaterial_N; // Il nuovo materiale Skybox che desideri applicare
    public GameObject Notte; // Il nuovo materiale Skybox che desideri applicare
    public bool changeSkyboxOnTrigger = true; // Imposta questo booleano su "true" se vuoi cambiare il materiale Skybox quando il trigger viene attivato
    public GameObject Menu;

    public Dialogues DManager;
    private bool changeD = false; // o la variabile che deve attivare la sostituzione
    private bool StopButton = false; // o la variabile che deve attivare la sostituzione
    public GameObject PointSpawn;
    private CinemachineConfiner confiner;
    public Collider NewConfiner;
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;  
    private CinemachineVirtualCamera vCam;
    public bool needDeactivateObject;
    public GameObject[] objDeactivate;
    public GameObject[] objActivate;
    public int IDCharater;
    private string[] dialogue; // array of string to store the dialogues
    private GameObject player; // Reference to the player's position
    public TextMeshProUGUI dialogueText; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI CharacterName; // Reference to the TextMeshProUGUI component
    public GameObject button;
    public GameObject dialogueBox;
    public float dialogueDuration; // variable to set the duration of the dialogue
    private int dialogueIndex; // variable to keep track of the dialogue status
    private float elapsedTime; // variable to keep track of the elapsed time
    private Animator anim; // componente Animator del personaggio
    public bool isInteragible;
    public bool heFlip;    
    private bool EndDia = false;
    public bool moreDialogue;
    private bool _isInTrigger;
    private bool _isDialogueActive;
    private bool Talk = false;

    [Header("Animations")]
    [SpineAnimation][SerializeField] private string TalnkAnimationName;
    [SpineAnimation][SerializeField] private string IdleAnimationName;

    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    [Header("Audio")]
    [Tooltip("0,1-Male 2,3-Female 4-Kid")]
    public int IDAudio;    
    void Awake()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
            if (_skeletonAnimation == null) {
                Debug.LogError("Componente SkeletonAnimation non trovato!");
            }        
            _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
            _spineAnimationState = _skeletonAnimation.AnimationState;
            _skeleton = _skeletonAnimation.skeleton;
        //player = GameObject.FindWithTag("Player");
        dialogue = DManager.dialogue;
        CharacterName.text = DManager.CharacterName;
        FAct = GameObject.FindWithTag("F_Player");
        SAct = GameObject.FindWithTag("S_Player");
        KAct = GameObject.FindWithTag("K_Player");        
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferime
    }
     void Update()
    {
        if(Talk)
        {Talking();}
        if(!Talk)
        {Idle();}

        if (_isInTrigger && Input.GetButtonDown("Fire1") && !_isDialogueActive && !GameManager.instance.stopInput)
        {
            CameraZoom.instance.ZoomIn();
            GameManager.instance.notChange = true;
            GameManager.instance.ChInteract();//True
            if(heFlip){FacePlayer();}
            dialogueIndex = 0;
            StartCoroutine(ShowDialogue());
        }
        else if (_isDialogueActive && Input.GetButtonDown("Fire1") && StopButton && !GameManager.instance.stopInput)
        {
            NextDialogue();
            //StopButton = false;
        }
    }




    #region Collision
    public void OnTriggerEnter(Collider collision)
    {
    if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
    {
        button.gameObject.SetActive(true);
        _isInTrigger = true;
        if (!isInteragible)
        {
            dialogueIndex = 0; // Reset the dialogue index to start from the beginning
            StartCoroutine(ShowDialogue());
        }
    }}
    public void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
        {
            button.gameObject.SetActive(false); // Initially hide the dialogue text
            _isInTrigger = false;
            StopCoroutine(ShowDialogue());
            dialogueIndex++;
            if (dialogueIndex >= dialogue.Length)
            {
                dialogueIndex = 0;
                _isDialogueActive = false;
                dialogueBox.gameObject.SetActive(false);
            }
        }
    }
    #endregion
    public void Deactive(){foreach (GameObject arenaObject in objDeactivate){arenaObject.SetActive(false);}}
    public void Activate(){foreach (GameObject arenaObject in objActivate){arenaObject.SetActive(true);}} 
    public void ChangeSkyboxMaterial()
    {
        button.gameObject.SetActive(false); // Initially hide the dialogue text
        _isInTrigger = false;
        _isDialogueActive = false;
        dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        Talk = false;
        Menu.gameObject.SetActive(false);
        GameManager.instance.Interact = false;
        GameManager.instance.FadeIn();
        StartCoroutine(ChangeAreaF());
    }
    
    IEnumerator ChangeAreaF()
    {
        GameManager.instance.ChStop();
        CharacterMove.instance.Idle();
        yield return new WaitForSeconds(2f);
         // Cambia il materiale Skybox
        if(changeSkyboxOnTrigger){
        RenderSettings.skybox = newSkyboxMaterial_N;
        Notte.SetActive(true);
        Giorno.SetActive(false);
        GameManager.instance.Day = false;
        // Ricarica l'illuminazione per riflettere il nuovo Skybox
        DynamicGI.UpdateEnvironment();
        changeSkyboxOnTrigger = false;}
        else if(!changeSkyboxOnTrigger){
        RenderSettings.skybox = newSkyboxMaterial_G;
        Notte.SetActive(false);
        Giorno.SetActive(true);
        // Ricarica l'illuminazione per riflettere il nuovo Skybox
        DynamicGI.UpdateEnvironment(); 
        changeSkyboxOnTrigger = true;
        GameManager.instance.Day = true;}
        if(needDeactivateObject)
        {Deactive(); Activate();}
        CharacterMove.instance.isRun = false;
        ModifyConfiner();
        GameManager.instance.player.transform.position = PointSpawn.transform.position;
        KAct.transform.position = PointSpawn.transform.position;
        FAct.transform.position = PointSpawn.transform.position;
        SAct.transform.position = PointSpawn.transform.position;
        GameManager.instance.ChCanM();
        GameManager.instance.FadeOut();
        button.gameObject.SetActive(false); // Initially hide the dialogue text
        _isInTrigger = false;
        _isDialogueActive = false;
        dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        Talk = false;
        GameManager.instance.ChInteractStop();  
        GameManager.instance.Interact = false;
        Menu.gameObject.SetActive(false);
    }
    public void ModifyConfiner()
    {
        confiner.m_BoundingVolume  = null; 
        confiner.m_BoundingVolume  = NewConfiner;       
        vCam.Follow = GameManager.instance.player.transform;
    }
     IEnumerator ShowDialogue()
    {
        Talk = true;
        AudioManager.instance.PlaySFX(IDAudio);
        //PlayMFX(1);
        _isDialogueActive = true;
        elapsedTime = 0; // reset elapsed time
        dialogueBox.gameObject.SetActive(true); // Show dialogue box
        dialogueText.gameObject.SetActive(true); // Show dialogue text
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
                StopButton = true;

    }

    public void Back()
        {
                    button.gameObject.SetActive(false); // Initially hide the dialogue text
                    _isInTrigger = false;
                    _isDialogueActive = false;
                    dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
                    dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
                    Talk = false;
                    GameManager.instance.ChInteractStop();  
                    GameManager.instance.Interact = false;
                    Menu.gameObject.SetActive(false);
        }



    void NextDialogue()
    {

        elapsedTime = 0; // reset elapsed time
        dialogueIndex++; // Increment the dialogue index
        if (dialogueIndex >= dialogue.Length)
        {
            EndDia = true;
            Menu.gameObject.SetActive(true);
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        }
        else{StartCoroutine(ShowDialogue());}
    }

    void FacePlayer()
    {
        if (player != null)
        {
            if (player.transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (player.transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }


    public void Idle()
{
    if (currentAnimationName != IdleAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, IdleAnimationName, true);
                    currentAnimationName = IdleAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }
}
 public void Talking()
{
    if (currentAnimationName != TalnkAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, TalnkAnimationName, true);
                    currentAnimationName = TalnkAnimationName;
                    //_spineAnimationState.Event += HandleEvent;
                }
}
}