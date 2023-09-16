using System.Collections;
using UnityEngine;
using TMPro;
using Spine.Unity;
public class NPCDialogueWithStop : MonoBehaviour
{
    #region Header
    [Header("Data")]
    public Dialogues Dialogue;
    private int IDDialogue;
    public int IDCharacter;
    private GameObject player; // Reference to the player's position
    [Header("Dialogue")]
    public TextMeshProUGUI dialogueText; // Reference to the TextMeshProUGUI component
    public GameObject button;
    public GameObject dialogueBox;
    public TextMeshProUGUI CharacterName; // Reference to the TextMeshProUGUI component
    private string[] dialogue; // array of string to store the dialogues
    public float dialogueDuration; // variable to set the duration of the dialogue
    private int dialogueIndex; // variable to keep track of the dialogue status
    private float elapsedTime; // variable to keep track of the elapsed time
    private Animator anim; // componente Animator del personaggio
    private bool notGo = false;
    public bool isInteragible;
    public bool heFlip;
    public bool FirstD = true;
    private bool StopButton = false; // o la variabile che deve attivare la sostituzione
    private bool _isInTrigger;
    private bool Talk = false;
    private bool _isDialogueActive;
    [Header("Animations")]
    [SpineAnimation][SerializeField] private string TalnkAnimationName;
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    public static NPCDialogueWithStop instance;
    [Header("Audio")]
    [Tooltip("0,1-Male 2,3-Female 4-Kid 5-Oldman 6-Oste")]
    public int IDAudio;
    #endregion
    void Awake()
    {
            //player = GameObject.FindWithTag("Player");
            IDDialogue = Dialogue.id;
            CharacterName.text = Dialogue.CharacterName;
            if (instance == null){instance = this;}
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}        
            _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
            _spineAnimationState = _skeletonAnimation.AnimationState;
            _skeleton = _skeletonAnimation.skeleton;
    }
    void Start()
    {        
        button.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueText.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (FirstD){dialogue = Dialogue.Startdialogue;}//Start
        else if (Dialogue.Middle){dialogue = Dialogue.Middledialogue;}//Middle
        else if (Dialogue.End){dialogue = Dialogue.Endingdialogue;}//EndD
        if(Talk){Talking();}
        if(!Talk){Idle();}
        if(heFlip){FacePlayer();}

        if(!notGo)
        {
        if (_isInTrigger && Input.GetButtonDown("Fire1") && !_isDialogueActive && !GameManager.instance.stopInput)
        {
            dialogueIndex = 0;
            CharacterMove.instance.Interact = true;
            StartCoroutine(ShowDialogue());
        }
        else if (_isDialogueActive && Input.GetButtonDown("Fire1") && StopButton && !GameManager.instance.stopInput)
        {
            NextDialogue();
            StopButton = false;
        }
    }
}
    private void OnTriggerEnter(Collider collision)
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
    }
}
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
        {
            button.gameObject.SetActive(false); // Initially hide the dialogue text
            _isInTrigger = false;
            StopCoroutine(ShowDialogue());
            dialogueIndex++; // Increment the dialogue index
            if (dialogueIndex >= dialogue.Length)
            {
                dialogueIndex = 0;
                _isDialogueActive = false;
                dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
                dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            }
        }
    }
    IEnumerator ShowDialogue()
    {
    Talk = true;
    AudioManager.instance.PlaySFX(IDAudio);

    //talk.Play();
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
        yield return new WaitForSeconds(0); // Wait before showing the next letter
    }
            dialogueText.text = currentDialogue; // Set the dialogue text to the full current dialogue
            StopButton = true;
}
    void NextDialogue()
    {
        elapsedTime = 0; // reset elapsed time
        dialogueIndex++; // Increment the dialogue index
        if (dialogueIndex >= dialogue.Length)
        {
            dialogueIndex = 0;
            _isDialogueActive = false;
            Talk = false;
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            if(FirstD){StartCoroutine(StartQuest());}
            else if(Dialogue.Middle){StartCoroutine(EndQuest());}
            else{CharacterMove.instance.Interact = false;}
        }
        else{StartCoroutine(ShowDialogue());}
    }
    IEnumerator EndQuest()
    {
            notGo = true;
            yield return new WaitForSeconds(0); 
            Dialogue.Middle = false;
            Dialogue.End = true;
            notGo = false;
            CharacterMove.instance.Interact = false;
    }       
    IEnumerator StartQuest()
    {            
            notGo = true;
            Dialogue.Middle = true;
            yield return new WaitForSeconds(0); 
            CharacterMove.instance.Interact = false;
            notGo = false;
            FirstD = false;
    }
    void FacePlayer()
    {
        if (player != null)
        {
            if (player.transform.localScale.x > transform.position.x){transform.localScale = new Vector3(1, 1, 1);}
            else{transform.localScale = new Vector3(-1, 1, 1);}
        }
    }
    
 #region Animations
     public void Idle()
{
    if (currentAnimationName != IdleAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, IdleAnimationName, true);
                    currentAnimationName = IdleAnimationName;
                }
}
 public void Talking()
{
    if (currentAnimationName != TalnkAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, TalnkAnimationName, true);
                    currentAnimationName = TalnkAnimationName;
                }
}
#endregion
}