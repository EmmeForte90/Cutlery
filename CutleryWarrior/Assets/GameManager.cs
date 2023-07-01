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
    [SerializeField] public int Hp = 0;
    [SerializeField] public int Exp = 0;
    [SerializeField] public TextMeshProUGUI ExpTextM;
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
        
        //Lo Exp aumenta
        ExpTextM.text = Exp.ToString();    

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
        Exp += pointsToAdd;
        //Lo money aumenta
        ExpTextM.text = Exp.ToString();    
        //il testo dello money viene aggiornato
    }

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






}

