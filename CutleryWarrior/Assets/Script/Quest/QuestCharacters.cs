using System.Collections;
using UnityEngine;
using TMPro;
using Spine.Unity;
public class QuestCharacters : MonoBehaviour
{
    #region Header
    public Quests Quest;
    private int IDQuest;
    public int IDCharacter;
    public TextMeshProUGUI CharacterName; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI QNameE; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI QNameS; // Reference to the TextMeshProUGUI component
    private GameObject player; // Reference to the player's position
    public TextMeshProUGUI dialogueText; // Reference to the TextMeshProUGUI component
    public GameObject button;
    public GameObject dialogueBox;
    public GameObject QuestStart;
    public GameObject QuestEnd;
     [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-Weapom 4-Armor")]
    private int KindItem;
    public Item Reward;
    public bool NeedKey = false;
    public Item KeyForQuest;
    public int specificQuant;
    private string[] dialogue; // array of string to store the dialogues
    public float dialogueDuration; // variable to set the duration of the dialogue
    private int dialogueIndex; // variable to keep track of the dialogue status
    private float elapsedTime; // variable to keep track of the elapsed time
    private bool notGo = false;
    public bool isInteragible;
    public bool heFlip;
    public bool FirstD = true;
    public bool StopButton = false; // o la variabile che deve attivare la sostituzione
    private bool _isInTrigger;
    private bool _isDialogueActive;
    [Header("Minimap Icons")]
    public GameObject QuestAt;
    public GameObject QuestCo;
    public GameObject Esclama;

    [Header("Audio")]
    [Tooltip("0,1-Male 2,3-Female 4-Kid")]
    public int IDAudio;
    [Header("Animations")]
    [SpineAnimation][SerializeField] private string idleAnimationName;
    [SpineAnimation][SerializeField] private string HitAnimationName;
    private string currentAnimationName;
    private SkeletonAnimation _skeletonAnimation;
    private Spine.AnimationState _spineAnimationState;
    private Spine.Skeleton _skeleton;
    //Spine.EventData eventData;
    public static QuestCharacters instance;
    #endregion
    public void Awake()
    {
            if (instance == null){instance = this;}
            IDQuest = Quest.id;
            CharacterName.text = Quest.CharacterName;
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}        
            _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
            _spineAnimationState = _skeletonAnimation.AnimationState;
            _skeleton = _skeletonAnimation.skeleton;
             button.gameObject.SetActive(false); // Initially hide the dialogue text
            dialogueText.gameObject.SetActive(false); // Initially hide the dialogue text
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
    }
    public void Update()
    {
        if (FirstD){dialogue = Quest.Startdialogue; Esclama.SetActive(true);} //Start
        else if (Quest.isActive){dialogue = Quest.Middledialogue; Esclama.SetActive(false);} //Middle
        else if (Quest.isComplete){dialogue = Quest.Endingdialogue; Esclama.SetActive(true); QuestAt.SetActive(false);} //EndD
        else if (Quest.AfterQuest){dialogue = Quest.Afterdialogue; Esclama.SetActive(false); QuestAt.SetActive(false);} //After
        Idle();
        if (Quest.isActive){
        if(QuestsManager.instance.QuestSegnal[Quest.id]){QuestAt.SetActive(true); QuestCo.SetActive(false);}
        else if(!QuestsManager.instance.QuestSegnal[Quest.id]){QuestAt.SetActive(false); QuestCo.SetActive(true);}}
        if(heFlip){FacePlayer();}
        if(!notGo)
        {
        if (_isInTrigger && Input.GetButtonDown("Fire1") && !_isDialogueActive && !GameManager.instance.stopInput)
        {
            GameManager.instance.ChInteract();//True
            GameManager.instance.notChange = true;
            CameraZoom.instance.ZoomIn();
            dialogueIndex = 0;
            StartCoroutine(ShowDialogue());
        }
        else if (_isDialogueActive && Input.GetButtonDown("Fire1") && StopButton && !GameManager.instance.stopInput)
        {
            NextDialogue();
            //StopButton = false;
        }}
    }
    
    private void OnTriggerEnter(Collider collision)
    {if(collision.CompareTag("F_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {Touch();}
    else if (collision.CompareTag("K_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {Touch();}
    else if (collision.CompareTag("S_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {Touch();}}
        
    private void Touch()
    {
            button.gameObject.SetActive(true); // Initially hide the dialogue text
            _isInTrigger = true;
            if (!isInteragible)
            {
                 dialogueIndex = 0; // Reset the dialogue index to start from the beginning
                StartCoroutine(ShowDialogue());
            }
    }



    public void OnTriggerExit(Collider collision)
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
            GameManager.instance.notChange = false;
        }
    }
     IEnumerator ShowDialogue()
{
    //Talk = true;
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
        elapsedTime = 0; // reset elapsed time
        dialogueIndex++; // Increment the dialogue index
        if (dialogueIndex >= dialogue.Length)
        {
            dialogueIndex = 0;
            _isDialogueActive = false;
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            if(FirstD){StartCoroutine(StartQuest());} 
            else if(!FirstD && !Quest.isComplete){
            GameManager.instance.ChInteractStop();
            CameraZoom.instance.ZoomOut();
            GameManager.instance.notChange = false;
            GameManager.instance.ChCanM();}
            else if(!FirstD && Quest.isComplete){StartCoroutine(EndQuest());}
            //else {GameManager.instance.ChInteractStop();}
        }
        else{StartCoroutine(ShowDialogue());}
    }
    IEnumerator EndQuest()
{
        notGo = true;
        QNameE.text = Quest.questName;
        QuestEnd.gameObject.SetActive(true); 
        AudioManager.instance.PlaySFX(9);//AudioQuestComplete
        yield return new WaitForSeconds(5f); 
        //Instantiate(Reward, RewardPoint.position, transform.rotation);
        KindItem = Reward.KindItem;
        AddSpecificItem();
        QuestEnd.gameObject.SetActive(false); 
        Inventory.instance.Reward(Reward, specificQuant);
        yield return new WaitForSeconds(1f); 
        QuestsManager.instance.QuestCompleteF(IDQuest);
        Quest.isActive = false;
        Quest.isComplete = false;
        Quest.AfterQuest = true;
        notGo = false;
        GameManager.instance.ChInteractStop();
        CameraZoom.instance.ZoomOut();
        GameManager.instance.notChange = false;
        GameManager.instance.ChCanM();
    }    
    IEnumerator StartQuest()
    {            
            notGo = true;
            QNameS.text = Quest.questName;
            Quest.isActive = true;
            GameManager.instance.Allarm();
            AudioManager.instance.PlayUFX(7);
            yield return new WaitForSeconds(1f); 
            AudioManager.instance.PlaySFX(10);//AudioQuestStart
            GameManager.instance.StopAllarm();
            QuestStart.gameObject.SetActive(true); 
            QuestsManager.instance.AddQuest(Quest);
            QuestsManager.instance.ListQuest(IDQuest);
            QuestsManager.instance.QuestStart(IDQuest);
            yield return new WaitForSeconds(5f); 
            QuestsManager.instance.QuestActiveF(IDQuest);
            QuestStart.gameObject.SetActive(false); 
            GameManager.instance.ChInteractStop();
            CameraZoom.instance.ZoomOut();
            GameManager.instance.notChange = false;
            GameManager.instance.ChCanM();
            if(NeedKey)
            {KeyManager.instance.AddItem(KeyForQuest, specificQuant);
            Inventory.instance.Reward(KeyForQuest, specificQuant);}
            notGo = false;
            FirstD = false;
    }
    public void AddSpecificItem()
    {
        switch(KindItem)
        {
            case 0:
            Inventory.instance.AddItem(Reward, specificQuant);  
            InventoryB.instance.AddItem(Reward, specificQuant);
            break;
            case 1:
            QuestsManager.instance.AddItem(Reward, specificQuant);            
            break;
            case 2:
            KeyManager.instance.AddItem(Reward, specificQuant);            
            break;
            case 3:
            EquipM_F.instance.AddItem(Reward, specificQuant);            
            break;
            case 4:
            EquipM_K.instance.AddItem(Reward, specificQuant);            
            break;
            case 5:
            EquipM_S.instance.AddItem(Reward, specificQuant);            
            break;
        }
    } 
    
    void FacePlayer()
    {
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
        if (player != null)
        {
            if (player.transform.position.z > transform.position.z){transform.localScale = new Vector3(1, 1, 1);}
            else{transform.localScale = new Vector3(-1, 1, 1);}
        }
    }
    #region Animations
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
                    _spineAnimationState.SetAnimation(2, HitAnimationName, true);
                    currentAnimationName = HitAnimationName;
                }
                // Add event listener for when the animation completes
                _spineAnimationState.GetCurrent(2).Complete += OnAttackAnimationComplete;
}
private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    trackEntry.Complete -= OnAttackAnimationComplete;
    _spineAnimationState.ClearTrack(2);
    _spineAnimationState.SetAnimation(1, idleAnimationName, true);
    currentAnimationName = idleAnimationName;
}
#endregion
}