using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestsManager : MonoBehaviour
{
    #region Header
    [Header("Items Quest")]
    public List<Item> itemList = new List<Item>();
    public List<int> quantityList = new List<int>();
    public GameObject inventoryQuestsItem;
    List<InventorySlot> slotListItem = new List<InventorySlot>();
    [Header("Quest")]
    [HideInInspector] public int qID;
    // Scriptable Object delle quest
    public List<Quests> questDatabase;
     // Array di booleani che mantengono lo stato delle quest
    public bool[] quest;
    public bool[] QuestActive;
    public bool[] QuestComplete;
    private GameObject[] QuestS;
    [Header("List Quest UI")]
    public Sprite Desicon;
    [SerializeField] public TextMeshProUGUI NameQ;
    [SerializeField] public TextMeshProUGUI DescriptionQ;
    public Image previewImages;
    public Transform QuestContent;
    public GameObject InventoryQuest;
    public Transform QuestContent_M;
    public Transform QuestContent_C;
    public Transform QuestContent_R;
    public Transform QuestContent_V;

    #endregion

    #region Singleton
    public static QuestsManager instance;
    public void Awake(){instance = this;}
    #endregion
    public void Start()
    {foreach (InventorySlot child in inventoryQuestsItem.GetComponentsInChildren<InventorySlot>()){slotListItem.Add(child);}}
    
    /*private void OnSceneLoaded()
    {
        // Cerca tutti i GameObjects con il tag "Ch_Quest"
        GameObject[] QuestCH = GameObject.FindGameObjectsWithTag("QuestCH");
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Itera attraverso tutti gli oggetti trovati
        foreach (GameObject Character in QuestCH)
        {
            // Ottiene il componente QuestCharacters
            TriggerOrdalia ordaliT = Character.GetComponent<TriggerOrdalia>();

            // Verifica se il componente esiste
            if (ordaliT != null)
            {
                // Verifica se l'id della quest corrisponde all'id di un gameobject in OrdaliaActive
                int Id = ordaliT.id;
                for (int i = 0; i < OrdaliaActive.Length; i++)
                {
                    if (OrdaliaActive[i] && i == Id)
                    {
                        // Imposta ordaliT.FirstD a false
                        ordaliT.OrdaliaDoesntExist();
                        break;
                    }
                }
            }
        }
    }*/

    // Metodo per aggiungere una nuova quest al database
    public void AddQuest(Quests newQuest){questDatabase.Add(newQuest);}
    public void QuestStart(int id){quest[id] = true;}
    public void QuestActiveF(int id){QuestActive[id] = true;}
    public void QuestCompleteF(int id){QuestComplete[id] = true;}

    #region UpdateUIQuest
    public void ListQuest(int questId)
{
    // Cerca la quest con l'id specificato
    Quests quest = questDatabase.Find(q => q.id == questId);
    if (quest != null)
    {
        // Istanzia il prefab del bottone della quest nella lista UI
        switch(quest.KindQuest)
        {
            case 0:
            QuestContent =  QuestContent_M;
            break;
            case 1:
            QuestContent =  QuestContent_R;
            break; 
            case 2:
            QuestContent =  QuestContent_C;
            break; 
            case 3:
            QuestContent =  QuestContent_V;
            break; 
        }
        GameObject obj = Instantiate(InventoryQuest, QuestContent);
        // Recupera il riferimento al componente del titolo della quest e del bottone
        var questT = obj.transform.Find("Title_quest").GetComponent<TextMeshProUGUI>();
        var questI = obj.transform.Find("Icon_item").GetComponent<Image>();
        // Assegna l'id univoco al game object istanziato
        obj.name = "QuestButton_" + quest.id;
        // Assegna il nome della quest al componente del titolo
        questT.text = quest.questName;
        questI.sprite = quest.Bigicon;
        // Assegna i valori desiderati ai componenti dell'immagine di preview e della descrizione del pulsante della quest
        previewImages.sprite = quest.Desicon;
        DescriptionQ.text = quest.Description;
        NameQ.text = quest.questName;
        // Aggiungi un listener per il click del bottone
        var button = obj.GetComponent<Button>();
        button.onClick.AddListener(() => OnQuestButtonClicked(quest.id, previewImages, DescriptionQ, questI));
    }
}
public void OnQuestButtonClicked(int questId, Image previewImages, TextMeshProUGUI descriptions, Image questI)
{    
    if (questId >= 0)
    {    
        previewImages.sprite = questDatabase.Find(q => q.id == questId).Desicon;
        descriptions.text = questDatabase.Find(q => q.id == questId).Description;
        NameQ.text = questDatabase.Find(q => q.id == questId).questName;
        if(QuestComplete[questId]){questI.color = Color.black; previewImages.sprite = Desicon;}
    }
}
    #endregion
   
    #region QuestItemInventory
    public void AddItem(Item itemAdded, int quantityAdded)
    {  
        if (itemAdded.Stackable)
        {
            if (itemList.Contains(itemAdded))
            {quantityList[itemList.IndexOf(itemAdded)] = quantityList[itemList.IndexOf(itemAdded)] + quantityAdded;}
            else
            {
                if (itemList.Count < slotListItem.Count)
                {itemList.Add(itemAdded); quantityList.Add(quantityAdded);}else{}
            }
        }
        else
        {
            for (int i = 0; i < quantityAdded; i++)
            {if (itemList.Count < slotListItem.Count){itemList.Add(itemAdded); quantityList.Add(1);} else{}}
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
                {quantityList.RemoveAt(itemList.IndexOf(itemRemoved)); itemList.RemoveAt(itemList.IndexOf(itemRemoved));}
            }
        }
        else
        {
            for (int i = 0; i < quantityRemoved; i++)
            {quantityList.RemoveAt(itemList.IndexOf(itemRemoved));itemList.RemoveAt(itemList.IndexOf(itemRemoved));}
        }
        UpdateInventoryUI();
    }
    public void UpdateInventoryUI()
    {
    int ind = 0;
      foreach(InventorySlot slot in slotListItem)
        {
            if (itemList.Count != 0)
            {
                if (ind < itemList.Count)
                {slot.UpdateSlot(itemList[ind], quantityList[ind]); ind = ind + 1;}
                else {slot.UpdateSlot(null, 0);}
            }
            else {slot.UpdateSlot(null, 0);}
        }
    }
#endregion
}