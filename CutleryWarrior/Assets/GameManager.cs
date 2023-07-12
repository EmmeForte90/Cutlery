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
  
    [Header("Stats")]

    [Header("Fork")]

    [SerializeField] public int LVF = 0;

    [SerializeField] public float HpF = 0;
    [SerializeField] public float StaminaF = 0;
    [SerializeField] public float MpF = 0;
    [SerializeField] public float ExpF = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMF;

    public GameObject ForkActive;
    public GameObject ForckActor;

    [Header("Spoon")]

    [SerializeField] public int LVS = 0;

    [SerializeField] public float HpS = 0;
    [SerializeField] public float StaminaS = 0;
    [SerializeField] public float MpS = 0;
    [SerializeField] public float ExpS = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMS;

    public GameObject SpoonActive;
    public GameObject SpoonActor;

    [Header("Knife")]
    [SerializeField] public int LVK = 0;
    [SerializeField] public float HpK = 0;
    [SerializeField] public float StaminaK = 0;
    [SerializeField] public float MpK = 0;
    [SerializeField] public float ExpK = 0;
    [SerializeField] public TextMeshProUGUI ExpTextMK;
    [SerializeField] GameObject ExpObjectM;

    public GameObject KnifeActive;
    public GameObject KnifeActor;
    public static GameManager instance;
    public bool isElement1Active = false;
    public bool isElement2Active = true;
    public bool isElement3Active = false;
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
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;
        ForckActor.gameObject.SetActive(false);
        ForkActive.gameObject.SetActive(true);
        KnifeActive.gameObject.SetActive(false);
        KnifeActor.gameObject.SetActive(true);
        SpoonActive.gameObject.SetActive(false);
        SpoonActor.gameObject.SetActive(true);
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SwitchElement();
            StartCoroutine(CoordinateActor());
        }    


    if(!battle){
       if (Input.GetButtonDown("Pause") && !stopInput)
        {
            CharacterMove.instance.Stop();
            CharacterMove.instance.Idle();
            stopInput = true;
            CharacterMove.instance.inputCTR = true;
            Pause.gameObject.SetActive(true);
            CameraZoom.instance.ZoomIn();
        }
        else if(Input.GetButtonDown("Pause") && stopInput)
        {
            stopInput = false;
            Pause.gameObject.SetActive(false);
            CharacterMove.instance.inputCTR = false;
            CameraZoom.instance.ZoomOut();
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

#region ChangeCharacter
IEnumerator CoordinateActor()
    {
        // Switcha tra gli elementi
    if (isElement1Active)
    {
        ForkActive.gameObject.SetActive(true);
        KnifeActor.gameObject.SetActive(true);
        SpoonActor.gameObject.SetActive(true);
        ForkActive.transform.position = ForckActor.transform.position;
        SpoonActor.transform.position = SpoonActive.transform.position;
        KnifeActor.transform.position = KnifeActive.transform.position;
        yield return new WaitForSeconds(0.01f);
        ForckActor.gameObject.SetActive(false);
        KnifeActive.gameObject.SetActive(false);
        SpoonActive.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;
        //////////////////////////////
        isElement1Active = false;
        isElement2Active = true;
    }
    else if (isElement2Active)
    {   
        ForckActor.gameObject.SetActive(true);
        KnifeActive.gameObject.SetActive(true);
        SpoonActor.gameObject.SetActive(true);
        KnifeActive.transform.position = KnifeActor.transform.position;
        SpoonActor.transform.position = SpoonActive.transform.position;
        ForckActor.transform.position = ForkActive.transform.position;
        yield return new WaitForSeconds(0.1f);
        ForkActive.gameObject.SetActive(false);
        KnifeActor.gameObject.SetActive(false);
        SpoonActive.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;
        //////////////////////////////
        isElement2Active = false;
        isElement3Active = true;
    }
    else if (isElement3Active)
    {
        ForckActor.gameObject.SetActive(true);
        KnifeActor.gameObject.SetActive(true);
        SpoonActive.gameObject.SetActive(true);
        SpoonActive.transform.position = SpoonActor.transform.position;
        KnifeActor.transform.position = KnifeActive.transform.position;
        ForckActor.transform.position = ForkActive.transform.position;
        yield return new WaitForSeconds(0.01f);
        ForkActive.gameObject.SetActive(false);
        KnifeActive.gameObject.SetActive(false);
        SpoonActor.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;
        //////////////////////////////
        isElement3Active = false;
        isElement1Active = true;
    }
    }
#endregion

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

