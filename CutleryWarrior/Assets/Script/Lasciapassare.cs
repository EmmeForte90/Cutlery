using System.Collections;
using UnityEngine;
using TMPro;
using Spine.Unity;

public class Lasciapassare : MonoBehaviour
{
    #region Header
    [Header("Data")]
    public int IdEvent;
    private GameObject player; // Reference to the player's position
    private KeyManager M_K;
    public GameObject Collider; // Reference to the player's position
    public Item[] objectToCheck;
    private GameObject Fork;
    private GameObject Spoon;
    private GameObject Knife;
    public int obj1;
    [Header("Dialogue")]
    public TextMeshProUGUI dialogueText; // Reference to the TextMeshProUGUI component
    [TextArea(1, 3)]
    public string TextNO;
    [TextArea(1, 3)]
    public string TextYES;
    public GameObject button;
    public GameObject dialogueBox;
    public bool heFlip;
    private bool _isInTrigger;
    private bool Talk = false;
    private bool _isDialogueActive;
    private bool start = false;
    [Header("Animations")]
    [SpineAnimation][SerializeField] private string TalnkAnimationName;
    [SpineAnimation][SerializeField] private string IdleAnimationName;
    private string currentAnimationName;
    public SkeletonAnimation _skeletonAnimation;
    public Spine.AnimationState _spineAnimationState;
    public Spine.Skeleton _skeleton;
    Spine.EventData eventData;
    [Header("Audio")]
    [Tooltip("0,1-Male 2,3-Female 4-Kid 5-Oldman 6-Oste")]
    public int IDAudio;
    #endregion
    
    public void Take(){Destroy(gameObject);}
    void Awake()
    {
            if (M_K == null){StartCoroutine(StartData());}
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            if (_skeletonAnimation == null) {Debug.LogError("Componente SkeletonAnimation non trovato!");}        
            _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
            _spineAnimationState = _skeletonAnimation.AnimationState;
            _skeleton = _skeletonAnimation.skeleton;
    }
     IEnumerator StartData()
    {yield return new WaitForSeconds(0.01f);
    if (M_K == null) {M_K = GameManager.instance.KM.GetComponent<KeyManager>();}}
    void Start()
    {        
        button.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueText.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
    }
    void Update()
    {
        if(Talk){Talking();}
        if(!Talk){Idle();}
        if(heFlip){FacePlayer();}
        if (_isInTrigger && Input.GetButtonDown("Fire1") && !_isDialogueActive && !GameManager.instance.stopInput)
        {
            CharacterMove.instance.Interact = true;
            AddQuestItem();
        }
        if (_isInTrigger && Input.GetButtonDown("Fire1") && _isDialogueActive)
        {
            Talk = false;
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            CharacterMove.instance.Interact = false;
            _isDialogueActive = false;
        }

    if(start)
    {
    if (GameManager.instance.CharacterID == 1)
    {if(GameManager.instance.F_Unlock)
    {Fork = GameManager.instance.F_Hero; player = Fork;}}
    //
    if (GameManager.instance.CharacterID == 2)
    {if(GameManager.instance.K_Unlock)
    {Knife = GameManager.instance.K_Hero; player = Knife;}}
    //
    if (GameManager.instance.CharacterID == 3)
    {if(GameManager.instance.S_Unlock)
    {Spoon = GameManager.instance.S_Hero; player = Spoon;}}
    }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
    if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
    {            
        button.gameObject.SetActive(true);
        _isInTrigger = true;
    }
    }
    private void OnTriggerExit(Collider collision)
    {
    if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
    {button.gameObject.SetActive(false);  _isInTrigger = false;}
    }
    public void AddQuestItem()
    {
    _isDialogueActive = true;
    if(M_K.itemList.Contains(objectToCheck[obj1]))
    { 
        dialogueBox.gameObject.SetActive(true); 
        dialogueText.gameObject.SetActive(true); 
        dialogueText.text = TextYES; //"Oh, you have permission. Ok then, you can go!";
        PlayerStats.instance.EventDesertEnd(IdEvent);
        Collider.SetActive(false);
        //StartCoroutine(BoxDel());
    }else
    {
        GameManager.instance.AM.PlayUFX(10);
        dialogueBox.gameObject.SetActive(true); 
        dialogueText.gameObject.SetActive(true); 
        dialogueText.text = TextNO;
        //StartCoroutine(BoxDel());
    }
    }
    /*IEnumerator BoxDel()
    {yield return new WaitForSeconds(3);
    _isDialogueActive = false;
    Talk = false;
    dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
    dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
    CharacterMove.instance.Interact = false;}*/
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
                    _spineAnimationState.SetAnimation(0, IdleAnimationName, true);
                    currentAnimationName = IdleAnimationName;
                }
}
 public void Talking()
{
    if (currentAnimationName != TalnkAnimationName)
                {
                    _spineAnimationState.SetAnimation(0, TalnkAnimationName, true);
                    currentAnimationName = TalnkAnimationName;
                }
}
#endregion
}