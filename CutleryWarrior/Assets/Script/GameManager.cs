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
    private GameObject player;
    public static bool GameManagerExist;
        
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

    [Header("Stats")]

    [Header("Fork")]

    [SerializeField] public int LVF = 0;

    [SerializeField] public float HpF = 0;
    [SerializeField] public float StaminaF = 0;
    [SerializeField] public float MpF = 0;
    [SerializeField] public float ExpF = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMF;

  

    [Header("Spoon")]

    [SerializeField] public int LVS = 0;

    [SerializeField] public float HpS = 0;
    [SerializeField] public float StaminaS = 0;
    [SerializeField] public float MpS = 0;
    [SerializeField] public float ExpS = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMS;


    [Header("Knife")]
    [SerializeField] public int LVK = 0;
    [SerializeField] public float HpK = 0;
    [SerializeField] public float StaminaK = 0;
    [SerializeField] public float MpK = 0;
    [SerializeField] public float ExpK = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMK;
    [SerializeField] GameObject ExpObjectM;

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
        player = GameObject.FindGameObjectWithTag("Player");
        if(!battle)
        {vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;}
        if(StartGame)
        {AudioManager.instance.PlayMFX(0);}


    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
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
            CharacterMove.instance.Stop();
            CharacterMove.instance.Idle();
            stopInput = true;
            CharacterMove.instance.inputCTR = true;
            Pause.gameObject.SetActive(true);
            CameraZoom.instance.ZoomIn();
            AudioManager.instance.PlayUFX(1);
        }
        else if(Input.GetButtonDown("Pause") && stopInput)
        {
            stopInput = false;
            Pause.gameObject.SetActive(false);
            CharacterMove.instance.inputCTR = false;
            CameraZoom.instance.ZoomOut();
            AudioManager.instance.PlayUFX(1);
        } 
    }
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

