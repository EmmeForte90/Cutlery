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

[SpineAnimation][SerializeField] private string TalnkAnimationName;
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
[Header("Audio")]
    [HideInInspector] public float basePitch = 1f;
    [HideInInspector] public float randomPitchOffset = 0.1f;
    [SerializeField] public AudioClip[] listSound; // array di AudioClip contenente tutti i suoni che si vogliono riprodurre
    private AudioSource[] bgm; // array di AudioSource che conterrà gli oggetti AudioSource creati
    public AudioMixer SFX;
    private bool bgmActive = false;

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
    bgm = new AudioSource[listSound.Length]; // inizializza l'array di AudioSource con la stessa lunghezza dell'array di AudioClip
        for (int i = 0; i < listSound.Length; i++) // scorre la lista di AudioClip
        {
            bgm[i] = gameObject.AddComponent<AudioSource>(); // crea un nuovo AudioSource come componente del game object attuale (quello a cui è attaccato lo script)
            bgm[i].clip = listSound[i]; // assegna l'AudioClip corrispondente all'AudioSource creato
            bgm[i].playOnAwake = false; // imposto il flag playOnAwake a false per evitare che il suono venga riprodotto automaticamente all'avvio del gioco
            bgm[i].loop = false; // imposto il flag playOnAwake a false per evitare che il suono venga riprodotto automaticamente all'avvio del gioco

        }
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
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Talk)
        {Talking();}
        if(!Talk)
        {Idle();}
        //anim.SetBool("talk", Talk);
        if(heFlip)
        {
        FacePlayer();
        }

        if (_isInTrigger && Input.GetButtonDown("Fire1") && !_isDialogueActive)
        {
            CharacterMove.instance.Interact = true;
            dialogueIndex = 0;
            StartCoroutine(ShowDialogue());
        }
        else if (_isDialogueActive && Input.GetButtonDown("Fire1") && StopButton)
        {
            NextDialogue();
            //StopButton = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
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
        if (collision.CompareTag("Player"))
        {
            CharacterMove.instance.Interact = false;
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
                StopMFX(1);

            }
        }
    }

  public void StopMFX(int soundToPlay)
    {
        if (bgmActive)
        {
            bgm[soundToPlay].Stop();
            bgmActive = false;
        }
    }

public void PlayMFX(int soundToPlay)
    {
        bgm[soundToPlay].Stop();
        // Imposta la pitch dell'AudioSource in base ai valori specificati.
        bgm[soundToPlay].pitch = basePitch + Random.Range(-randomPitchOffset, randomPitchOffset); 
        bgm[soundToPlay].Play();
    }


    IEnumerator ShowDialogue()
{
    Talk = true;
    PlayMFX(1);
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
            StopMFX(1);
            dialogueIndex = 0;
            _isDialogueActive = false;
            Talk = false;
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            CharacterMove.instance.Interact = false;
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
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
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
