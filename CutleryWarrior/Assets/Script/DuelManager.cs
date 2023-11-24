using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEditor;

public class DuelManager : MonoBehaviour
{
    //public LevelChanger LVCH;
    public GameObject ThisBattle; 
    public int WhatMusicAB;
       
    [Header("Arena")]
    public Vector3 savedPosition;
    public Transform MoveP;
    public int EnemyinArena;
    private bool win = true;
    public bool WinEnd = false;
    public bool Ending = false;
    public int DieCont = 0;
    public GameObject GameOverBox;
    public AttStats Stats;
    //public Item[] Rewards;
    private int result;
    private int Money;
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;

    [Header("Fork")]
    public Scrollbar FhealthBar;
    public Image FRageBar;
    public GameObject MaxRageF;
    public float FcurrentMP;
    public Scrollbar FMPBar;
    //public float FcostMP = 20;
    public float F_SpeedRestore = 10f; // il massimo valore di essenza disponibile
    public GameObject[] Enemies; 
    public GameObject[] ActiveObj; 
    [SerializeField] CharacterFollow ch_FAc;
    [Header("Knife")]
    //public float KcurrentHealth;
    public Scrollbar KhealthBar;
    public Image KRageBar;
    public GameObject MaxRageK;
    //public float KcurrentMP;
    public Scrollbar KMPBar;
    //public float KcostMP = 15;
    public float K_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_KAc;
    [Header("Spoon")]
    //public float ScurrentHealth;
    public Scrollbar ShealthBar;
    public Image SRageBar;
    public GameObject MaxRageS;
    //public float ScurrentMP;
    public Scrollbar SMPBar;
    //public float ScostMP = 10;
    public float S_SpeedRestore = 5f; // il massimo valore di essenza disponibile
    [SerializeField] CharacterFollow ch_SAc;
    [Header("Status")]
    public float damagePerSecond = 0.1f;
    public float duration = 5.0f;
    private float elapsedTime = 0.0f;
    private bool isDamaging = false;
    public bool F_Die, K_Die, S_Die = false;
    
    [Header("IndicatoreNemico")]
    public int ATK_Ch;
    public GameObject[] objectsToHighlight;
    public GameObject highlightedObjectIndicator;
    //public float minValue = 0f;
    //public float maxValue = 1f;
    //public float step = 0.1f;
    private int currentIndex = 0;
    private CinemachineVirtualCamera vCam;
    private bool isIndicator = false;
    private bool CamPlayer = true;

    [SerializeField]  GameObject Win;
    private int ID_Enm;
    public bool inputCTR = false;
    
    public int CharacterID;
    [Header("TimelineAfterBattle")]
    public GameObject pointView; 
    private CinemachineVirtualCamera virtualCamera; //riferimento alla virtual camera di Cinemachine
    public bool F_isRight = false;    
    public bool S_isRight = false;
    public bool K_isRight = false;
    public bool isTimeline = false;
    public GameObject ActorSpoon;
    public GameObject ActorKnife;
    public GameObject ActorFork;
    //public bool isMove = true;
    //private Transform Player;
    public static DuelManager instance;
public void Awake()
    {
        if (instance == null){instance = this;}
        savedPosition = GameManager.instance.savedPosition;
        //
        vCam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>();
        //
        if(GameManager.instance.F_Unlock){
        PlayerStats.instance.F_curHP = PlayerStats.instance.F_HP;
        PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        //
        if(GameManager.instance.K_Unlock){
        PlayerStats.instance.K_curHP = PlayerStats.instance.K_HP;
        PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        //
        if(GameManager.instance.S_Unlock){
        PlayerStats.instance.S_curHP = PlayerStats.instance.S_HP;
        PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}
        //CharacterID = 1; 
        if(GameManager.instance.S_Unlock){ch_SAc = GameManager.instance.S_Hero.GetComponent<CharacterFollow>();}
        if(GameManager.instance.F_Unlock){ch_FAc = GameManager.instance.F_Hero.GetComponent<CharacterFollow>();}
        if(GameManager.instance.K_Unlock){ch_KAc = GameManager.instance.K_Hero.GetComponent<CharacterFollow>();}
        //
        if(GameManager.instance.F_Unlock){FAct = GameManager.instance.F_Hero;}
        if(GameManager.instance.S_Unlock){SAct = GameManager.instance.S_Hero;}
        if(GameManager.instance.K_Unlock){KAct = GameManager.instance.K_Hero;}
        //
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curRage = 0;}       
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curRage = 0;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curRage = 0;}
        //
        ch_FAc.MoveP.transform.position = MoveP.transform.position;
        //
        ID_Enm = GameManager.instance.IdENM;
        StartCoroutine(StartAI());    
    }
public void Update()
    {
        if(GameManager.instance.F_Unlock){
        FhealthBar.size = PlayerStats.instance.F_curHP / PlayerStats.instance.F_HP;
        FhealthBar.size = Mathf.Clamp(FhealthBar.size, 0.01f, 1);        
        //
        FMPBar.size = PlayerStats.instance.F_curMP / PlayerStats.instance.F_MP;
        FMPBar.size = Mathf.Clamp(FMPBar.size, 0.01f, 1);
        //
        if(!F_Die){
        FRageBar.fillAmount = PlayerStats.instance.F_curRage / PlayerStats.instance.F_Rage;
        FRageBar.fillAmount = Mathf.Clamp(FRageBar.fillAmount, 0.01f, 1);}}
        ////////////////////////////////////////////////////////
        if(GameManager.instance.K_Unlock){
        KhealthBar.size = PlayerStats.instance.K_curHP / PlayerStats.instance.K_HP;
        KhealthBar.size = Mathf.Clamp(KhealthBar.size, 0.01f, 1);
        //
        KMPBar.size = PlayerStats.instance.K_curMP / PlayerStats.instance.K_MP;
        KMPBar.size = Mathf.Clamp(KMPBar.size, 0.01f, 1);
        //
        if(!K_Die){
        KRageBar.fillAmount = PlayerStats.instance.K_curRage / PlayerStats.instance.K_Rage;
        KRageBar.fillAmount = Mathf.Clamp(KRageBar.fillAmount, 0.01f, 1);}}
        //
        //////////////////////////////////////////////////////////
        if(GameManager.instance.S_Unlock){
        ShealthBar.size = PlayerStats.instance.S_curHP / PlayerStats.instance.S_HP;
        ShealthBar.size = Mathf.Clamp(ShealthBar.size, 0.01f, 1);
        //
        SMPBar.size = PlayerStats.instance.S_curMP / PlayerStats.instance.S_MP;
        SMPBar.size = Mathf.Clamp(SMPBar.size, 0.01f, 1);
        //
        if(!S_Die){
        SRageBar.fillAmount = PlayerStats.instance.S_curRage / PlayerStats.instance.S_Rage;
        SRageBar.fillAmount = Mathf.Clamp(SRageBar.fillAmount, 0.01f, 1);}}
        //           
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curMP += F_SpeedRestore * Time.deltaTime;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curMP += K_SpeedRestore * Time.deltaTime;}
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curMP += S_SpeedRestore * Time.deltaTime;}
        //
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curMP >= PlayerStats.instance.F_MP)
        {PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curMP >= PlayerStats.instance.K_MP)
        {PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curMP >= PlayerStats.instance.S_MP)
        {PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}
        //
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curMP <= 0)
        {PlayerStats.instance.F_curMP = 1;}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curMP <= 0)
        {PlayerStats.instance.S_curMP = 1;}
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curMP <= 0)
        {PlayerStats.instance.K_curMP = 1;}
        //
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curRage >= PlayerStats.instance.K_Rage)
        {MaxRageK.SetActive(true);} 
        else if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curRage < PlayerStats.instance.K_Rage)
        {MaxRageK.SetActive(false);}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curRage >= PlayerStats.instance.S_Rage)
        {MaxRageS.SetActive(true);} 
        else if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curRage < PlayerStats.instance.S_Rage)
        {MaxRageS.SetActive(false);}
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curRage >= PlayerStats.instance.F_Rage)
        {MaxRageF.SetActive(true);} 
        else if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curRage < PlayerStats.instance.F_Rage)
        {MaxRageF.SetActive(false);}
        ///////////////////////////////////////////////////////////////////////////GameOver
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curHP <= 0)
        {GameManager.instance.PoseDeathS(); S_Die = true; GameManager.instance.S_Die = true;}
        //print("S_Die" + S_Die);
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curHP <= 0)
        {GameManager.instance.PoseDeathK(); K_Die = true; GameManager.instance.K_Die = true;}
        //print("K_Die" + K_Die);
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curHP <= 0)
        {GameManager.instance.PoseDeathF(); F_Die = true; GameManager.instance.F_Die = true;}
        //print("F_Die" + F_Die);
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_curHP > 0){S_Die = false; GameManager.instance.S_Die = false;}
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_curHP > 0){K_Die = false; GameManager.instance.K_Die = false;}
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_curHP > 0){F_Die = false; GameManager.instance.F_Die = false;}
        /////////////////////////////////////////////////////////////////////////////////
        #region Status
        //Paralisi
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_paralysisResistance <= 0)
        {GameManager.instance.StunF();}
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_paralysisResistance <= 0)
        {GameManager.instance.StunK();}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_paralysisResistance <= 0)
        {GameManager.instance.StunS();}
        //Poison
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_poisonResistance <= 0)
        {GameManager.instance.PoisonF();
        isDamaging = true;
        elapsedTime = 0.0f;
        if (isDamaging)
        {
            elapsedTime += Time.deltaTime;
            PlayerStats.instance.F_curHP -= damagePerSecond;
            if (elapsedTime >= duration)
            {
                // Il periodo di danno è terminato
                isDamaging = false;
            }
        }}
        if(GameManager.instance.S_Unlock && PlayerStats.instance.S_poisonResistance <= 0)
        {GameManager.instance.PoisonS();
        isDamaging = true;
        elapsedTime = 0.0f;
        if (isDamaging)
        {
            elapsedTime += Time.deltaTime;
            PlayerStats.instance.S_curHP -= damagePerSecond;
            if (elapsedTime >= duration)
            {
                // Il periodo di danno è terminato
                isDamaging = false;
            }
        }
        }
        if(GameManager.instance.K_Unlock && PlayerStats.instance.K_poisonResistance <= 0)
        {GameManager.instance.PoisonK();isDamaging = true;
        elapsedTime = 0.0f;
        if (isDamaging)
        {
            elapsedTime += Time.deltaTime;
            PlayerStats.instance.K_curHP -= damagePerSecond;
            if (elapsedTime >= duration)
            {
                // Il periodo di danno è terminato
                isDamaging = false;
            }
        }}
        //Rust/Silence
        if(GameManager.instance.F_Unlock && PlayerStats.instance.F_rustResistance <= 0)
        {GameManager.instance.RustF();
        //Attiva funzione di rust
        }
        if(GameManager.instance.K_Unlock && PlayerStats.instance.F_rustResistance <= 0)
        {GameManager.instance.RustK();
        //Attiva funzione di rust
        }
        if(GameManager.instance.S_Unlock && PlayerStats.instance.F_rustResistance <= 0)
        {GameManager.instance.RustS();
        //Attiva funzione di rust
        }

        #endregion
        if(EnemyinArena <= 0){StartCoroutine(EndBattle());}
        ////////////
        CharacterID = GameManager.instance.CharacterID;
        ////////
        if(WinEnd){if(Input.GetMouseButtonDown(0)){StartCoroutine(RetunBattle());}}
        if(F_Die && K_Die && S_Die )
        {StartCoroutine(GameOver());}   
        if(Ending){if(Input.GetMouseButtonDown(0)){StartCoroutine(ReturnMainMenu());}} 
        /////////////
        if(isIndicator)
        {
            CamPlayer = false;
            highlightedObjectIndicator.SetActive(true);
            inputCTR = true;
            // Input per diminuire il valore
            if (Input.GetKeyDown(KeyCode.A)){DecreaseValue();}

            // Input per aumentare il valore
            if (Input.GetKeyDown(KeyCode.D)){IncreaseValue();}

            // Input per Confermare
            if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire1"))
            {CamBack(); SelectionENM();}

            // Input per testare la rimozione di un'unità
            if (Input.GetKeyDown(KeyCode.R)){RemoveUnitAtIndex(currentIndex);}

            // Assicurati che l'indice sia all'interno dei limiti dell'array
            currentIndex = Mathf.Clamp(currentIndex, 0, objectsToHighlight.Length - 1);

            // Evidenzia l'oggetto corrente
            //HighlightCurrentObject();

            // Aggiorna la posizione dell'indicatore dell'oggetto evidenziato
            UpdateIndicatorPosition();
        }

    }
    #region Indicatore per evidenziare i nemici
    public void Character(int ord)
    {
        GameManager.instance.ChStopB();
        GameManager.instance.NotChange();
        ATK_Ch = ord; isIndicator = true;
    }

    public void CamBack()
    {
        CamPlayer = true;
        switch(CharacterID)
        {
            case 1:
            vCam.Follow = FAct.transform;
            break;
            case 2:
            vCam.Follow = KAct.transform;
            break;
            case 3:
            vCam.Follow = SAct.transform;
            break;    
        }
    }
    
    void SelectionENM()
    {
        switch(ATK_Ch)
        {
            case 0:
            ch_FAc.target = objectsToHighlight[currentIndex];
            if(ch_FAc.target != null)
            {ch_FAc.target.transform.position = objectsToHighlight[currentIndex].transform.position;}
            ch_FAc.order = 1;
            break;
            case 1:
            ch_KAc.target = objectsToHighlight[currentIndex];
            if(ch_KAc.target != null)
            {ch_KAc.target.transform.position = objectsToHighlight[currentIndex].transform.position;}
            ch_KAc.order = 1;
            break;
            case 2:
            ch_SAc.target = objectsToHighlight[currentIndex];
            if(ch_SAc.target != null)
            {ch_SAc.target.transform.position = objectsToHighlight[currentIndex].transform.position;}
            ch_SAc.order = 1;
            break;
        }
        
        GameManager.instance.Change();
        GameManager.instance.ChCanM();
        GameManager.instance.stopInput = false;
        inputCTR = false; 
        highlightedObjectIndicator.SetActive(false); 
        isIndicator = false;
    }

    public void Escape(){StartCoroutine(EscapeBattle());}
    IEnumerator EscapeBattle()
    {   
    GameManager.instance.StartGame = false;
    CharacterMove.instance.inputCTR = true;
    CharacterMove.instance.Idle();
    GameManager.instance.FadeIn();
    AudioManager.instance.CrossFadeOUTAudio(1);
    yield return new WaitForSeconds(2f);
    foreach (GameObject arenaObject in ActiveObj){arenaObject.SetActive(true);}
    if(GameManager.instance.K_Unlock){ch_KAc.IDAction = 0;}
    if(GameManager.instance.S_Unlock){ch_SAc.IDAction = 0;}
    if(GameManager.instance.F_Unlock){ch_FAc.IDAction = 0;}
    GameManager.instance.money -= 300;
    GameManager.instance.Exploration();
    GameManager.instance.Change();
    GameManager.instance.RecalculateCharacter();
    EscapePoint();
    GameManager.instance.FadeOut();
    }
     public void EscapePoint()
    {
    GameManager.instance.battle = false;
    if(GameManager.instance.F_Unlock){FAct.transform.position = GameManager.instance.savedPositionEscape.position;}
    if(GameManager.instance.K_Unlock){KAct.transform.position = GameManager.instance.savedPositionEscape.position;}
    if(GameManager.instance.S_Unlock){SAct.transform.position = GameManager.instance.savedPositionEscape.position;}
    GameManager.instance.StopWin();
    GameManager.instance.ChCanM();
    GameManager.instance.ActiveMinimap();
    AudioManager.instance.CrossFadeINAudio(WhatMusicAB);
    }

    void HighlightCurrentObject()
    {
        // Disattiva tutti gli oggetti
        foreach (var obj in objectsToHighlight)
        {
            obj.SetActive(false);
        }

        // Attiva l'oggetto corrente
        if (objectsToHighlight.Length > 0)
        {
            objectsToHighlight[currentIndex].SetActive(true);
        }
    }

    void UpdateIndicatorPosition()
    {
        // Posiziona l'indicatore nell'oggetto corrente
        if (highlightedObjectIndicator != null && objectsToHighlight.Length > 0)
        {
            highlightedObjectIndicator.transform.position = objectsToHighlight[currentIndex].transform.position;
            if(!CamPlayer){vCam.Follow = objectsToHighlight[currentIndex].transform;}
        }
    }

    void IncreaseValue()
    {
        currentIndex++;
        if (currentIndex >= objectsToHighlight.Length)
        {
            // Se supera il massimo, riporta l'indice a 0
            currentIndex = 0;
        }
    }

    void DecreaseValue()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            // Se scende al di sotto del minimo, riporta l'indice al massimo
            currentIndex = objectsToHighlight.Length - 1;
        }
    }

    void RemoveUnitAtIndex(int index)
{
    if (index >= 0 && index < objectsToHighlight.Length)
    {
        GameObject removedObject = objectsToHighlight[index];

        // Rimuovi l'oggetto dall'array
        List<GameObject> tempList = objectsToHighlight.ToList();
        tempList.RemoveAt(index);
        objectsToHighlight = tempList.ToArray();

        // Distruisci l'oggetto rimosso
        Destroy(removedObject);
    }
}
#endregion




    IEnumerator GameOver()
    {
        inputCTR = true;
        AudioManager.instance.StopMFX(1);
       yield return new WaitForSeconds(2f);
        AudioManager.instance.PlayMFX(2);

       GameOverBox.SetActive(true);
       Ending = true;
    }

    IEnumerator ReturnMainMenu()
    {   
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(2f);
    GameManager.instance.StartGame = true;
    SceneManager.LoadScene (sceneName:"MainMenu");
    GameManager.instance.DestroyManager();
    }
    

    // Metodo per iniziare il danno nel tempo
    public void StartDamaging()
    {
        isDamaging = true;
        elapsedTime = 0.0f;
        InvokeRepeating("ApplyDamage", 0.0f, 1.0f);
    }

    // Metodo per interrompere il danno nel tempo
    public void StopDamaging()
    {
        isDamaging = false;
        CancelInvoke("ApplyDamage");
    }
IEnumerator StartAI()
    {
        yield return new WaitForSeconds(3f);
        if(GameManager.instance.K_Unlock){ch_KAc.order = 1;}
        if(GameManager.instance.S_Unlock){ch_SAc.order = 2;}
        if(GameManager.instance.F_Unlock){ch_FAc.order = 3;}
    }
IEnumerator EndBattle()
    {
        GameManager.instance.NotTouchOption = true;
        GameManager.instance.ChStop();
        AudioManager.instance.CrossFadeOUTAudio(1);
        yield return new WaitForSeconds(3f);
        GameManager.instance.battle = true;
        GameManager.instance.notChange = false;
        if(win)
        {Win.gameObject.SetActive(true);
        RandomReward();
        AudioManager.instance.PlaySFX(7);
        GameManager.instance.NotChange(); 
        GameManager.instance.PoseWin();
        if(GameManager.instance.F_Unlock){Stats.F_GainExperience(result);}
        if(GameManager.instance.S_Unlock){Stats.S_GainExperience(result);}
        if(GameManager.instance.K_Unlock){Stats.K_GainExperience(result);}
        GameManager.instance.AddTomoney(Money);
        PlayerStats.instance.EnemyDefeatArea(GameManager.instance.IdENM);
        //LVCH.sceneName = GameManager.instance.sceneName;
        //Reward();
        win = false;}
        WinEnd = true;
    }
    private void ToggleTimeScale()
    {
        if (Time.timeScale == 1){Time.timeScale = 0.01f;}
        else{Time.timeScale = 1;}
    }
     IEnumerator RetunBattle()
    {   
    GameManager.instance.StartGame = false;
    CharacterMove.instance.inputCTR = true;
    CharacterMove.instance.Idle();
    GameManager.instance.FadeIn();
    AudioManager.instance.CrossFadeOUTAudio(1);
    yield return new WaitForSeconds(2f);
    GameManager.instance.NotTouchOption = false;
    foreach (GameObject arenaObject in ActiveObj){arenaObject.SetActive(true);}
    if(GameManager.instance.K_Unlock){ch_KAc.IDAction = 0;}
    if(GameManager.instance.S_Unlock){ch_SAc.IDAction = 0;}
    if(GameManager.instance.F_Unlock){ch_FAc.IDAction = 0;}
    GameManager.instance.Exploration();
    GameManager.instance.Change();
    GameManager.instance.RecalculateCharacter();
    if(isTimeline){ResetCamera();}
    else if(!isTimeline){SpawnB();}
    GameManager.instance.FadeOut();
    }

    public  void ResetCamera()
    {
    virtualCamera = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    virtualCamera.Follow =  pointView.transform;
    if(GameManager.instance.F_Unlock)
    {FAct.transform.position = ActorFork.transform.position;
    if(F_isRight){FAct.transform.localScale = new Vector3(1, 1,1);}
    else if(!F_isRight){FAct.transform.localScale = new Vector3(-1, 1,1);}
    }
    if(GameManager.instance.S_Unlock)
    {SAct.transform.position = ActorSpoon.transform.position;
    if(S_isRight){SAct.transform.localScale = new Vector3(1, 1,1);}
    else if(!S_isRight){SAct.transform.localScale = new Vector3(-1, 1,1);}
    }
    if(GameManager.instance.K_Unlock)
    {KAct.transform.position = ActorKnife.transform.position;
    if(K_isRight){KAct.transform.localScale = new Vector3(1, 1,1);}
    else if(!K_isRight){KAct.transform.localScale = new Vector3(-1, 1,1);}
    ThisBattle.SetActive(false);
    }
    GameManager.instance.ChCanM();
    Destroy(this);
    }
    public void SpawnB()
    {
    GameManager.instance.battle = false;
    if(GameManager.instance.F_Unlock){FAct.transform.position = savedPosition;}
    if(GameManager.instance.K_Unlock){KAct.transform.position = savedPosition;}
    if(GameManager.instance.S_Unlock){SAct.transform.position = savedPosition;}
    foreach (GameObject arenaObject in Enemies){arenaObject.SetActive(false);}
    GameManager.instance.StopWin();
    GameManager.instance.ChCanM();
    GameManager.instance.ActiveMinimap();
    AudioManager.instance.CrossFadeINAudio(WhatMusicAB);
    ThisBattle.SetActive(false);
    }
    //public void EnemiesActive(int ID){Enemies[ID].SetActive(false);}
    private void RandomReward()
    {
        int randomNumber = Random.Range(10, 20);
        int randomNumberM = Random.Range(10, 50);
       // int randomNumberItem = Random.Range(1, 100);
        result = Mathf.RoundToInt(randomNumber);
        Money = Mathf.RoundToInt(randomNumberM);
        //ItemN = Mathf.RoundToInt(randomNumberItem);
       // Debug.Log("Numero casuale: " + result);
        Debug.Log("Numero casuale: " + Money);
        //Debug.Log("Numero casuale: " + ItemN);
    }
    /*private void Reward()
    {
        if(ItemN <= 20)//20% Di possibilità
        {Inventory.instance.AddItem(Rewards[1], specificQuant);}
        else if(ItemN <= 50)//50% Di possibilità
        {Inventory.instance.AddItem(Rewards[2], specificQuant);  
        InventoryB.instance.AddItem(Rewards[2], specificQuant);}
         else if(ItemN <= 80)//80% Di possibilità
        {Inventory.instance.AddItem(Rewards[3], specificQuant);  
        InventoryB.instance.AddItem(Rewards[3], specificQuant);}
    }*/
}