using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Spine.Unity;
using UnityEngine.Audio;

public class NPCDialogue : MonoBehaviour
{
    public Dialogues DManager;
    public List<Dialogues> ListDialogue;
    private bool changeD = false; // o la variabile che deve attivare la sostituzione
    private bool StopButton = false; // o la variabile che deve attivare la sostituzione

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
    public bool moreDialogue;
    private bool _isInTrigger;
    private bool _isDialogueActive;
    private bool Talk = false;
    
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


public static NPCDialogue instance;


void Awake()
{
    _skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (_skeletonAnimation == null) {
            Debug.LogError("Componente SkeletonAnimation non trovato!");
        }        
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;
    player = GameObject.FindWithTag("Player");
    dialogue = DManager.dialogue;
    CharacterName.text = DManager.CharacterName;
}

public void changeDialogue()
    {
        if (changeD) // o qualsiasi condizione basata sulla variabile specificata
        {
            foreach (Dialogues dialogueObject in ListDialogue)
            {
                if (dialogueObject != DManager)
                {
                    DManager = dialogueObject;
                    dialogue = DManager.dialogue;
                    break;
                }
            }
        }
    }


    void Start()
    {        
        button.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueText.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        if(IsMove)
        {movingB = true;}
        if (waypoints.Length > 0 && IsMove)
        {
            transform.position = waypoints[0].position; // Posiziona il personaggio al primo waypoint
        }    
    }

    void Update()
    {
        if(Talk && !movingB)
        {Talking();}
        if(!Talk && !movingB)
        {Idle();}

        

        if(movingB)
        {if (!isPaused)
        {
            MoveToWaypoint();
            Walk();
        }
        else
        {
            PauseAtWaypoint();
            Idle();
        }}
        if (_isInTrigger && Input.GetButtonDown("Fire1") && !_isDialogueActive && !GameManager.instance.stopInput)
        {
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

    private void MoveToWaypoint()
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

 // Metodo per attivare lo script
    public void EnableScript()
    {
        enabled = true;
    }

    // Metodo per disattivare lo script
    public void DisableScript()
    {
        enabled = false;
    }
    private void PauseAtWaypoint()
    {
        if (pauseTimer < pauseTime)
        {
            pauseTimer += Time.deltaTime;
        }
        else
        {
            // Riprendi il movimento al prossimo waypoint
            isPaused = false;
            currentWaypointIndex++;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
        {
            movingB = false;            
            button.gameObject.SetActive(true); // Initially hide the dialogue text
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
            movingB = true;
            GameManager.instance.ChInteractStop();//false
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
                //StopMFX(1);

            }
        }
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



    void NextDialogue()
    {
        StopButton = true;
        elapsedTime = 0; // reset elapsed time
        dialogueIndex++; // Increment the dialogue index
        if (dialogueIndex >= dialogue.Length)
        {
            //StopMFX(1);
            dialogueIndex = 0;
            _isDialogueActive = false;
            Talk = false;
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            GameManager.instance.ChInteractStop();//false
            if(moreDialogue)
            {changeD = true;}
            changeDialogue();
        }
        else
        {
            StartCoroutine(ShowDialogue());
        }
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

public void Walk()
{
    if (currentAnimationName != WalkAnimationName)
                {
                    _spineAnimationState.SetAnimation(2, WalkAnimationName, true);
                    currentAnimationName = WalkAnimationName;
                }

}
}
