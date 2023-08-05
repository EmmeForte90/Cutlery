using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using Spine.Unity;
using Spine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Mercante : MonoBehaviour
{
    public int IDCharacter;
    public TextMeshProUGUI CharacterName; // Reference to the TextMeshProUGUI component
    private GameObject player; // Reference to the player's position
    public TextMeshProUGUI dialogueText; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI dialogueMenu; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI Nameitem; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI Description; // Reference to the TextMeshProUGUI component
    public Image previewImages;
    private int prices;
    private int IDItem;

    public TextMeshProUGUI Value; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI ValueItem; // Reference to the TextMeshProUGUI component
    // In case of specific, this two parameters become active in the Editor
    private Item specificItem;
    private readonly int specificQuant = 1;

    public Dialogues Dial;

    public GameObject button;
    public GameObject dialogueBox;
    public GameObject Menu;

    private string[] dialogue; // array of string to store the dialogues
    public float dialogueDuration; // variable to set the duration of the dialogue
    private int dialogueIndex; // variable to keep track of the dialogue status
    private float elapsedTime; // variable to keep track of the elapsed time
    //private Animator anim; // componente Animator del personaggio
    public bool isInteragible;
    public bool heFlip;
    private bool StopButton = false; // o la variabile che deve attivare la sostituzione
    private bool Talk = false;
    private bool EndDia = false;

    private bool _isInTrigger;
    private bool _isDialogueActive;

    [Header("Animations")]
    [SpineAnimation][SerializeField] private string idleAnimationName;
    [SpineAnimation][SerializeField] private string HitAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    private Spine.AnimationState _spineAnimationState;
    private Spine.Skeleton _skeleton;
    Spine.EventData eventData;

    //public GameObject Sashimi, BackB,Kunai, Shuriken, Onigiri;


public static Mercante instance;


public void Awake()
{
        instance = this;   
        //player = GameObject.FindWithTag("Player");
        _skeletonAnimation = GetComponent<SkeletonAnimation>();    
         _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;
}

public void Start()
    {        
        button.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueText.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
    }

  public void Update()
    {

        //dialogueDuration = GameplayManager.instance.dialogueDuration;
        Value.text = GameManager.instance.money.ToString();
        //ValueItem.text = 
        dialogue = Dial.dialogue; // Reference to the TextMeshProUGUI component

        if(Talk)
        {Hit();}
        else
        {Idle();}

        /*if(EndDia)
        {Menu.gameObject.SetActive(true);}
        else if(!EndDia)
        {Menu.gameObject.SetActive(false);}*/     
                
        //anim.SetBool("talk", Talk);
        if(heFlip)
        {
        FacePlayer();
        }

        if (_isInTrigger && Input.GetButtonDown("Fire1") && !_isDialogueActive)
        {
            //Move.instance.stopInput = true;
            //Move.instance.Stop();
            //Move.instance.Stooping();
            GameManager.instance.ChInteract();
            dialogueIndex = 0;
            StartCoroutine(ShowDialogue());
        }
        else if (_isDialogueActive && Input.GetButtonDown("Fire1") && StopButton)
        {
            //Cursor.visible = true;
            NextDialogue();
            StopButton = false;
        }
        
        if (Input.GetButtonDown("Fire1") && EndDia)
        {
           // Move.instance.NotStrangeAnimationTalk = false;
            button.gameObject.SetActive(false); // Initially hide the dialogue text
            _isInTrigger = false;
            _isDialogueActive = false;
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            //dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            //Menu.gameObject.SetActive(false);
            Talk = false;
            EndDia = false;
            //Move.instance.stopInput = false;
            //Move.instance.NotStrangeAnimationTalk = false; 
        }
}

public void Back()
{
            button.gameObject.SetActive(false); // Initially hide the dialogue text
            _isInTrigger = false;
            _isDialogueActive = false;
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            Menu.gameObject.SetActive(false);
            Talk = false;
            EndDia = false;
            GameManager.instance.ChInteractStop();            
}


public void AddItem(Item newItem)
    {
        if(GameManager.instance.money >= prices)
    { 
    //IDItem = newItem.id;
    //PlayMFX(0);
    specificItem = newItem;
    dialogueMenu.text = "Thank you!"; // Reference to the TextMeshProUGUI component
    GameManager.instance.money -= prices;
    GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
    Inventory.instance.AddItem(specificItem, specificQuant);

    }else if(GameManager.instance.money < prices)
    {
    dialogueMenu.text = "Sorry, buddy, you don't have much money"; // Reference to the TextMeshProUGUI component
    //PlayMFX(1);
    }
    }


public void Preview(Item newItem)
{
prices = newItem.price;
ValueItem.text = prices.ToString();
Nameitem.text = newItem.itemName; // Reference to the TextMeshProUGUI component
Description.text = newItem.itemDes; // Reference to the TextMeshProUGUI component
previewImages.sprite = newItem.itemIcon;
//dialogueMenu.text = newItem.Dialogue; // Reference to the TextMeshProUGUI component
//PuppetM.Instance.Hit();
}



    public void OnTriggerEnter(Collider collision)
{
    if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
    {
        //Move.instance.NotStrangeAnimationTalk = true;
        button.gameObject.SetActive(true);
        _isInTrigger = true;
        if (!isInteragible)
        {
            dialogueIndex = 0; // Reset the dialogue index to start from the beginning
            StartCoroutine(ShowDialogue());
        }
    }
}

    public void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
        {
            //GameManager.instance.ChInteractStop();            
            button.gameObject.SetActive(false); // Initially hide the dialogue text
            _isInTrigger = false;
            StopCoroutine(ShowDialogue());
            dialogueIndex++; // Increment the dialogue index
            if (dialogueIndex >= dialogue.Length)
            {
                dialogueIndex = 0;
                _isDialogueActive = false;
                dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
                //dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
                //talk.Stop();

            }
        }
    }

    IEnumerator ShowDialogue()
{    
    Talk = true;
    //sgm[1].Play();
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
            EndDia = true;
            //GameManager.instance.ChInteractStop();            
            Menu.gameObject.SetActive(true);
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            //Debug.Log("Arrivato al punto");            

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
             if (currentAnimationName != idleAnimationName)
                {  
                    _spineAnimationState.SetAnimation(1, idleAnimationName, true);
                    currentAnimationName = idleAnimationName;
                }            
}

public void Hit()
{
             if (currentAnimationName != HitAnimationName)
                { 
                    //_spineAnimationState.ClearTrack(1);
                    _spineAnimationState.SetAnimation(1, HitAnimationName, false);
                    currentAnimationName = HitAnimationName;
                }
                // Add event listener for when the animation completes
                _spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;
}

private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    // Remove the event listener
    trackEntry.Complete -= OnAttackAnimationComplete;

    // Clear the track 1 and reset to the idle animation
    //_spineAnimationState.ClearTrack(1);
    _spineAnimationState.SetAnimation(1, idleAnimationName, true);
    currentAnimationName = idleAnimationName;

}
}

