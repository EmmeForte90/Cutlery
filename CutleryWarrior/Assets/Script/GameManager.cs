using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Cinemachine;
using TMPro;
using Spine.Unity.AttachmentTools;
using Spine.Unity;
using Spine;


public class GameManager : MonoBehaviour
{            
    public bool StartGame = false;
    private CinemachineVirtualCamera vCam;
    public GameObject player;
    public static bool GameManagerExist;
    
    public Vector3 savedPosition;

    [Header("Pause")]
    public bool stopInput = false;
    public bool battle = false;

    [SerializeField]  GameObject Pause;

    [Header("Fade")]
    [SerializeField] GameObject callFadeIn;
    [SerializeField] GameObject callFadeOut;

    [Header("Money")]
    [SerializeField] public int money = 0;
    [SerializeField] public TextMeshProUGUI moneyTextM;
    [SerializeField] GameObject moneyObjectM;
    public int IDPorta;
    public int IDCharacter;

    [Header("Stats")]

    [Header("Fork")]

    [SerializeField] public int LVF = 0;

    [SerializeField] public float HpF = 0;
    [SerializeField] public float StaminaF = 0;
    [SerializeField] public float MpF = 0;
    [SerializeField] public float ExpF = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMF;
    [SerializeField] CharacterMove ch_F;
      [SerializeField] ManagerCharacter Manager_F;


    [Header("Spoon")]

    [SerializeField] public int LVS = 0;

    [SerializeField] public float HpS = 0;
    [SerializeField] public float StaminaS = 0;
    [SerializeField] public float MpS = 0;
    [SerializeField] public float ExpS = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMS;
    [SerializeField] CharacterMove ch_S;
    [SerializeField] ManagerCharacter Manager_S;


    [Header("Knife")]
    [SerializeField] public int LVK = 0;
    [SerializeField] public float HpK = 0;
    [SerializeField] public float StaminaK = 0;
    [SerializeField] public float MpK = 0;
    [SerializeField] public float ExpK = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMK;
    [SerializeField] CharacterMove ch_K;
    [SerializeField] ManagerCharacter Manager_K;

    [SerializeField] GameObject ExpObjectM;
    public UIRotationSwitcher rotationSwitcher;

    public static GameManager instance;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
         if (GameManagerExist) //&& gameplayOff) 
        {
            Destroy(gameObject);
        }
        else 
        {
            GameManagerExist = true;
            DontDestroyOnLoad(gameObject); 
        }
        
        TakeCharacter();
        if(!battle)
        {vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;}
        if(StartGame)
        {AudioManager.instance.PlayMFX(0);}


    }
    // Start is called before the first frame update

    public void TakeCharacter()
    {
        switch(rotationSwitcher.CharacterID)
        {
            case 1:
            player = GameObject.FindGameObjectWithTag("F_Player");
            break;
            case 2:
            player = GameObject.FindGameObjectWithTag("K_Player");
            break;
            case 3:
            player = GameObject.FindGameObjectWithTag("S_Player");
            break;
        }}

        public void TakeCamera()
    {
        //CharacterMove.instance.TakeCamera();
    }   

    public void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    public void Update()
    {
        IDCharacter = rotationSwitcher.CharacterID;
        TakeCharacter();
        //Lo money aumenta
        moneyTextM.text = money.ToString(); 
        
        //L Exp aumenta
        /*ExpTextMF.text = ExpF.ToString();    
        ExpTextMS.text = ExpS.ToString();    
        ExpTextMK.text = ExpK.ToString();*/

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            //SwitchElement();
            StartCoroutine(CoordinateActor());
        } */


    if(!battle){
       if (Input.GetButtonDown("Pause") && !stopInput)
        {
            switch (rotationSwitcher.CharacterID)
    {
    case 1:
        ch_F.Stop();
        ch_F.Idle();
        stopInput = true;
        ch_F.inputCTR = true;
        Pause.gameObject.SetActive(true);
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);     
    break;
    case 2:
        ch_K.Stop();
        ch_K.Idle();
        stopInput = true;
        ch_K.inputCTR = true;
        Pause.gameObject.SetActive(true);
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);  
    break;
    case 3:
        ch_S.Stop();
        ch_S.Idle();
        stopInput = true;
        ch_S.inputCTR = true;
        Pause.gameObject.SetActive(true);
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.PlayUFX(1);   
    break;
    }       
           
        }
        else if(Input.GetButtonDown("Pause") && stopInput)
        {
            stopInput = false;
            Pause.gameObject.SetActive(false);
            CharacterMove.instance.inputCTR = false;
            switch (rotationSwitcher.CharacterID)
            {
            case 1:
                ch_F.inputCTR = false;    
            break;
            case 2:
                ch_K.inputCTR = false; 
            break;
            case 3:
                ch_S.inputCTR = false; 
            break;
            }  
            CameraZoom.instance.ZoomOut();
            AudioManager.instance.PlayUFX(1);
        } 
    }
    }

    public void ChMov()
    {
        ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        ch_K = GameObject.Find("S_Player").GetComponent<CharacterMove>();
        ch_S = GameObject.Find("K_Player").GetComponent<CharacterMove>();
    }

       public void ChStop()
    {
        ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        ch_K = GameObject.Find("S_Player").GetComponent<CharacterMove>();
        ch_S = GameObject.Find("K_Player").GetComponent<CharacterMove>();
        ch_F.inputCTR = false;
        ch_K.inputCTR = false;
        ch_S.inputCTR = false;
    }   

      public void ChInteract()
    {
        ch_F.Interact = true;
        ch_K.Interact = true;
        ch_S.Interact = true;
    }  

    public void ChInteractStop()
    {
        ch_F.Interact = false;
        ch_K.Interact = false;
        ch_S.Interact = false;
    }  
    public void ChCanM()
    {
        ch_F = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        ch_K = GameObject.Find("S_Player").GetComponent<CharacterMove>();
        ch_S = GameObject.Find("K_Player").GetComponent<CharacterMove>();
        ch_F.inputCTR = true;
        ch_K.inputCTR = true;
        ch_S.inputCTR = true;
    }
  

    public void AddTomoney(int pointsToAdd)
    {
        money += pointsToAdd;
        //Lo money aumenta
        moneyTextM.text = money.ToString();    
        //il testo dello money viene aggiornato
    }
 public void AddToExp(int pointsToAdd)
    {
        ExpF += pointsToAdd;
        ExpS += pointsToAdd;
        ExpK += pointsToAdd;

        //Lo money aumenta
        ExpTextMF.text = ExpF.ToString(); 
        ExpTextMS.text = ExpS.ToString();    
        ExpTextMK.text = ExpK.ToString();    
   
        //il testo dello money viene aggiornato
    }


#region Fade
public void FadeIn()
    {
    StartCoroutine(StartFadeIn());
    }

    public void FadeOut()
    {
    StartCoroutine(StartFadeOut());
    }


    IEnumerator StartFadeIn()
    {
        callFadeOut.gameObject.SetActive(false);
        callFadeIn.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
    }

    IEnumerator StartFadeOut()
    {        
        callFadeIn.gameObject.SetActive(false);
        callFadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        callFadeOut.gameObject.SetActive(false);

    }

#endregion

}

