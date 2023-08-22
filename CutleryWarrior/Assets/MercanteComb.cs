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
public class MercanteComb : MonoBehaviour
{
     #region Header
    public int IDCharacter;
    [Header("Che tipo di mercante è?")]
    [Tooltip("0-Armaiolo 1-Alchimista 2-Ambulante 3-Fruttivendolo 4-Fruttivendolo")]
    public int Tipo;
    private List<Item> itemList = new List<Item>();
    private List<int> quantityList = new List<int>();
    //
    private List<Item> F_List = new List<Item>();
    private List<int> F_quantityList = new List<int>();
    //
    private List<Item> K_List = new List<Item>();
    private List<int> K_quantityList = new List<int>();
    //
    private List<Item> S_List = new List<Item>();
    private List<int> S_quantityList = new List<int>();
    //
    private List<Item> Q_List = new List<Item>();
    private List<int> Q_quantityList = new List<int>();
    //
    private readonly List<SellSlot> slotListItem = new();
    public Item[] objectToCheck;
    public int obj1;
    public int obj2;
    public GameObject inventoryItem;
    [Header("UI")]
    public TextMeshProUGUI CharacterName; 
    private GameObject player; 
    public TextMeshProUGUI dialogueText; 
    public TextMeshProUGUI dialogueMenu; 
    public TextMeshProUGUI Nameitem; 
    public TextMeshProUGUI Description; 
    public Image previewImages;
    private int prices;
    private int IDItem;
    public TextMeshProUGUI Value;
    public TextMeshProUGUI ValueS; 
    public TextMeshProUGUI ValueItem; 
    private Item specificItem;
    private readonly int specificQuant = 1;
    public Dialogues Dial;
    public GameObject button;
    public GameObject dialogueBox;
    public GameObject Menu;
    public GameObject Sell;
    public GameObject SelectionOp;
    public GameObject Box;
    private string[] dialogue; 
    public float dialogueDuration; 
    private int dialogueIndex;
    private float elapsedTime; 
    public bool isInteragible;
    public bool heFlip;
    private bool StopButton = false;
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
    private Inventory Inv;
    private EquipM_F M_F;
    private EquipM_K M_K;
    private EquipM_S M_S;
    private QuestsManager M_Q;
    public static MercanteComb instance;
    #endregion
    public void Awake()
    {
        instance = this;   
        _skeletonAnimation = GetComponent<SkeletonAnimation>();    
        _spineAnimationState = GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState;
        _spineAnimationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;
        button.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueText.gameObject.SetActive(false); // Initially hide the dialogue text
        dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        foreach (SellSlot child in inventoryItem.GetComponentsInChildren<SellSlot>())
        {slotListItem.Add(child);}
    }
    public  void OnEnable() 
    {StartCoroutine(List());}
    IEnumerator List(){
    yield return new WaitForSeconds(1); 
    Inv = GameObject.FindWithTag("Manager").GetComponent<Inventory>();
    itemList = GameObject.FindWithTag("Manager").GetComponent<Inventory>().itemList; //ottieni il riferimento alla virtual camera di Cinemachine
    quantityList = GameObject.FindWithTag("Manager").GetComponent<Inventory>().quantityList;
    //
    M_Q = GameObject.FindWithTag("Manager").GetComponent<QuestsManager>();    
    Q_List = GameObject.FindWithTag("Manager").GetComponent<QuestsManager>().itemList;    
    Q_quantityList = GameObject.FindWithTag("Manager").GetComponent<QuestsManager>().quantityList;
    //
    M_F = GameObject.Find("EquipManager").GetComponent<EquipM_F>();
    F_List = GameObject.Find("EquipManager").GetComponent<EquipM_F>().itemList;
    F_quantityList = GameObject.Find("EquipManager").GetComponent<EquipM_F>().quantityList;
    //
    M_K = GameObject.Find("EquipManager").GetComponent<EquipM_K>();
    K_List = GameObject.Find("EquipManager").GetComponent<EquipM_K>().itemList;
    K_quantityList = GameObject.Find("EquipManager").GetComponent<EquipM_K>().quantityList;
    //
    M_S = GameObject.Find("EquipManager").GetComponent<EquipM_S>();
    S_List = GameObject.Find("EquipManager").GetComponent<EquipM_S>().itemList;
    S_quantityList = GameObject.Find("EquipManager").GetComponent<EquipM_S>().quantityList;
    UpdateInventoryUI();
    }
    
    public void Update()
    {
        UpdateInventoryUI();
        Value.text = GameManager.instance.money.ToString();
        ValueS.text = GameManager.instance.money.ToString();
        dialogue = Dial.dialogue;

        if(Talk){Hit();}else{Idle();}

        if(heFlip)
        {FacePlayer();}

        if (_isInTrigger && Input.GetButtonDown("Fire1") && !_isDialogueActive && !GameManager.instance.stopInput)
        {
            GameManager.instance.ChInteract();
            GameManager.instance.Interact = true;
            dialogueIndex = 0;
            StartCoroutine(ShowDialogue());
        }
        else if (_isDialogueActive && Input.GetButtonDown("Fire1") && StopButton && !GameManager.instance.stopInput)
        {
            NextDialogue();
            StopButton = false;
        }
        
        if (Input.GetButtonDown("Fire1") && EndDia)
        {
            button.gameObject.SetActive(false); // Initially hide the dialogue text
            _isInTrigger = false;
            _isDialogueActive = false;
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
            Talk = false;
            EndDia = false;
        }
    }
    public void Back()
        {
                    button.gameObject.SetActive(false); // Initially hide the dialogue text
                    _isInTrigger = false;
                    _isDialogueActive = false;
                    dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
                    dialogueText.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
                    SelectionOp.gameObject.SetActive(false);
                    Talk = false;
                    EndDia = false;
                    GameManager.instance.ChInteractStop();   
                    GameManager.instance.Interact = false;
        }
    public void ItemNeed1(int K_obj1){obj1 = K_obj1;}
    public void ItemNeed2(int K_obj2){obj2 = K_obj2;}
    public void AddCombinedItem(Item newItem)
    {
    if(GameManager.instance.money >= prices 
    && Inv.itemList.Contains(objectToCheck[obj1]) 
    && Inv.itemList.Contains(objectToCheck[obj2]))
    { 
        specificItem = newItem;
        GameManager.instance.money -= prices;
        Inv.RemoveItem(objectToCheck[obj1], 1);
        Inv.RemoveItem(objectToCheck[obj2], 1);
        GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        if(newItem.KindItem == 0)
        {Inv.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 1)
        {QuestsManager.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 2)
        {KeyManager.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 3)
        {EquipM_F.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 4)
        {EquipM_K.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 5)
        {EquipM_S.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you!";
    }else
    {
        AudioManager.instance.PlayUFX(10);
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        dialogueMenu.text = "Nothing to do!";
    }
    }
   public void AddQuestItem(Item newItem)
    {
    if(GameManager.instance.money >= prices 
    && M_Q.itemList.Contains(objectToCheck[obj1]) 
    && M_Q.itemList.Contains(objectToCheck[obj2]))
    { 
        specificItem = newItem;
        GameManager.instance.money -= prices;
        M_Q.RemoveItem(objectToCheck[obj1], 1);
        M_Q.RemoveItem(objectToCheck[obj2], 1);
        GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        if(newItem.KindItem == 1)
        {QuestsManager.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you!";
    }else
    {
        AudioManager.instance.PlayUFX(10);
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        dialogueMenu.text = "Nothing to do!";
    }
    }
   public void AddCombinedWeapomF(Item newItem)
    {
    if(GameManager.instance.money >= prices 
    && Inv.itemList.Contains(objectToCheck[obj1]) 
    && M_F.itemList.Contains(objectToCheck[obj2]))
    { 
        specificItem = newItem;
        GameManager.instance.money -= prices;
        M_F.RemoveItem(objectToCheck[obj1], 1);
        M_F.RemoveItem(objectToCheck[obj2], 1);
        GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        if(newItem.KindItem == 3)
        {EquipM_F.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you!";
    }else
    {
        AudioManager.instance.PlayUFX(10);
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        dialogueMenu.text = "Nothing to do!";
    }
    }
    public void AddCombinedWeapomK(Item newItem)
    {
    if(GameManager.instance.money >= prices 
    && Inv.itemList.Contains(objectToCheck[obj1]) 
    && M_K.itemList.Contains(objectToCheck[obj2]))
    { 
        specificItem = newItem;
        GameManager.instance.money -= prices;
        M_K.RemoveItem(objectToCheck[obj1], 1);
        M_K.RemoveItem(objectToCheck[obj2], 1);
        GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        if(newItem.KindItem == 3)
        {EquipM_K.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you!";
    }else
    {
        AudioManager.instance.PlayUFX(10);
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        dialogueMenu.text = "Nothing to do!";
    }
    }
    public void AddCombinedWeapomS(Item newItem)
    {
    if(GameManager.instance.money >= prices 
    && Inv.itemList.Contains(objectToCheck[obj1]) 
    && M_S.itemList.Contains(objectToCheck[obj2]))
    { 
        specificItem = newItem;
        GameManager.instance.money -= prices;
        M_S.RemoveItem(objectToCheck[obj1], 1);
        M_S.RemoveItem(objectToCheck[obj2], 1);
        GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        if(newItem.KindItem == 3)
        {EquipM_S.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you!";
    }else
    {
        AudioManager.instance.PlayUFX(10);
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        dialogueMenu.text = "Nothing to do!";
    }
    }

     public void AddCombinedAlchemy(Item newItem)
    {
    if(GameManager.instance.money >= prices 
    && Inv.itemList.Contains(objectToCheck[obj1]) 
    && Inv.itemList.Contains(objectToCheck[obj2]))
    { 
        specificItem = newItem;
        GameManager.instance.money -= prices;
        Inv.RemoveItem(objectToCheck[obj1], 1);
        Inv.RemoveItem(objectToCheck[obj2], 1);
        GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        if(newItem.KindItem == 3)
        {EquipM_S.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you!";
    }else
    {
        AudioManager.instance.PlayUFX(10);
        Box.gameObject.SetActive(true);
        StartCoroutine(BoxDel());
        dialogueMenu.text = "Nothing to do!";
    }
    }
   
    public void AddItem(Item newItem)
    {
    if(GameManager.instance.money >= prices)
    { 
    specificItem = newItem;
    GameManager.instance.money -= prices;
    GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
    Box.gameObject.SetActive(true);
    StartCoroutine(BoxDel());
    switch(Tipo)
    {
        case 0:
        if(newItem.KindItem == 3)
        {EquipM_F.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 4)
        {EquipM_K.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 5)
        {EquipM_S.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 0)
        {Inventory.instance.AddItem(specificItem, specificQuant);
        InventoryB.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Ah! So you have money! Good for you, or better... For me!"; // Reference to the TextMeshProUGUI component
        break;
        case 1:
        if(newItem.KindItem == 0)
        {Inventory.instance.AddItem(specificItem, specificQuant);
        InventoryB.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 1)
        {QuestsManager.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 2)
        {KeyManager.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you so kind, you don't will have regrets."; // Reference to the TextMeshProUGUI component
        break;
        case 2:
        if(newItem.KindItem == 0)
        {Inventory.instance.AddItem(specificItem, specificQuant);
        InventoryB.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 1)
        {QuestsManager.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 2)
        {KeyManager.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you my friends!"; // Reference to the TextMeshProUGUI component
        break;
        case 3:
        if(newItem.KindItem == 0)
        {Inventory.instance.AddItem(specificItem, specificQuant);
        InventoryB.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 1)
        {QuestsManager.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 2)
        {KeyManager.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you and come back again!"; // Reference to the TextMeshProUGUI component
        break;
        case 4:
        if(newItem.KindItem == 0)
        {Inventory.instance.AddItem(specificItem, specificQuant);
        InventoryB.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 1)
        {QuestsManager.instance.AddItem(specificItem, specificQuant);}
        else if(newItem.KindItem == 2)
        {KeyManager.instance.AddItem(specificItem, specificQuant);}
        dialogueMenu.text = "Thank you, buddy!"; // Reference to the TextMeshProUGUI component
        break;
    }
    }else if(GameManager.instance.money < prices)
    {AudioManager.instance.PlayUFX(10);
    Box.gameObject.SetActive(true);
    StartCoroutine(BoxDel());
    switch(Tipo)
    {
        case 0:
        dialogueMenu.text = "You don't have much money. What you think? I don't do charity"; // Reference to the TextMeshProUGUI component
        break;
        case 1:
        dialogueMenu.text = "Ah, we have a beggar!"; // Reference to the TextMeshProUGUI component
        break;
        case 2:
        dialogueMenu.text = "Sorry, buddy, you don't have much money..."; // Reference to the TextMeshProUGUI component
        break;
        case 3:
        dialogueMenu.text = "Hen, you don't have much money... So.., maybe the next time?"; // Reference to the TextMeshProUGUI component
        break;
        case 4:
        dialogueMenu.text = "You don't have money, what you think?"; // Reference to the TextMeshProUGUI component
        break;
    }
    }}
    
    #region ItemInventory
    public void AddItem(Item itemAdded, int quantityAdded)
    {
        if (itemAdded.Stackable)
        {
            if (itemList.Contains(itemAdded))
            {
                quantityList[itemList.IndexOf(itemAdded)] = quantityList[itemList.IndexOf(itemAdded)] + quantityAdded;
            }
            else
            {
                if (itemList.Count < slotListItem.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(quantityAdded);
                }else{}  
            }
        }
        else
        {
            for (int i = 0; i < quantityAdded; i++)
            {
                if (itemList.Count < slotListItem.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(1);
                }else{}
            }  
        }
        UpdateInventoryUI();
    }
    public void RemoveItem(Item itemRemoved, int quantityRemoved)
    {
        if (itemRemoved.Stackable)
        {
            if (itemList.Contains(itemRemoved))
            {
                quantityList[itemList.IndexOf(itemRemoved)] = quantityList[itemList.IndexOf(itemRemoved)] - quantityRemoved;
                if (quantityList[itemList.IndexOf(itemRemoved)]<= 0)
                {
                    quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                    itemList.RemoveAt(itemList.IndexOf(itemRemoved));
                }
            }
        }
        else
        {
            for (int i = 0; i < quantityRemoved; i++)
            {
                quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                itemList.RemoveAt(itemList.IndexOf(itemRemoved));
            }
        }
        UpdateInventoryUI();
    }
    #endregion
    public void Preview(Item newItem)
    {
    prices = newItem.price;
    ValueItem.text = prices.ToString();
    Nameitem.text = newItem.itemName; // Reference to the TextMeshProUGUI component
    Description.text = newItem.itemDes; // Reference to the TextMeshProUGUI component
    previewImages.sprite = newItem.itemIcon;
    }
    
    #region Collision
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
    IEnumerator BoxDel(){yield return new WaitForSeconds(5);Box.gameObject.SetActive(false);}
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
            Menu.gameObject.SetActive(true);
            dialogueBox.gameObject.SetActive(false); // Hide dialogue text when player exits the trigger
        }
        else{StartCoroutine(ShowDialogue());}
    }
    public void UpdateInventoryUI()
    {
    int ind = 0;
    foreach(SellSlot slot in slotListItem)
        {
            if (itemList.Count != 0)
            {
                if (ind < itemList.Count)
                {
                    slot.UpdateSlot(itemList[ind], quantityList[ind]);
                    ind = ind + 1;
                }
                else{slot.UpdateSlot(null, 0);}
            }
            else{slot.UpdateSlot(null, 0);}
        }
    }
    void FacePlayer()
    {
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x){transform.localScale = new Vector3(1, 1, 1);}
            else{transform.localScale = new Vector3(-1, 1, 1);}
        }
    }

    #region Animazione
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
                    _spineAnimationState.SetAnimation(1, HitAnimationName, false);
                    currentAnimationName = HitAnimationName;
                }
                _spineAnimationState.GetCurrent(1).Complete += OnAttackAnimationComplete;
}
private void OnAttackAnimationComplete(Spine.TrackEntry trackEntry)
{
    trackEntry.Complete -= OnAttackAnimationComplete;
    _spineAnimationState.SetAnimation(1, idleAnimationName, true);
    currentAnimationName = idleAnimationName;
}
#endregion
}