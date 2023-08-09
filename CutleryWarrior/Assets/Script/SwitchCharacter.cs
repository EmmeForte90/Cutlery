using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Cinemachine;

public class SwitchCharacter : MonoBehaviour
{
    public bool battle = false;

 [Header("Stats")]

    [Header("Fork")]

    private ManagerCharacter ForkActive;

    [Header("Spoon")]

    private ManagerCharacter SpoonActive;

    [Header("Knife")]

    private ManagerCharacter KnifeActive;

    public static SwitchCharacter instance;
    public bool isElement1Active = false;
    public bool isElement2Active = true;
    public bool isElement3Active = false;
    private CinemachineVirtualCamera vCam;
    private GameObject player;
    public UIRotationSwitcher rotationSwitcher;
    public void Update(){if (Input.GetKeyDown(KeyCode.Space)){StartCoroutine(CoordinateActor());}}
    public void Start(){inizial();}
    public void Awake(){if (instance == null){instance = this;}}

    #region ChangeCharacter
    public void inizial()
    {
            player = GameObject.FindGameObjectWithTag("Player");  
            TakeCharacters();
            
            vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
            vCam.Follow = ForkActive.transform;
    }



public void Flip()
    {
        if (ForkActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (ForkActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        
        ///
        if (KnifeActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (KnifeActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        
        ///
        if (SpoonActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (SpoonActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        
    }


     public void TakeCharacters()
    {
        ForkActive = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();
        SpoonActive = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();
        KnifeActive = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();
        //
        switch(rotationSwitcher.CharacterID)
        {
            case 1:
            
            ForkActive.SwitchScriptsPlayer();
            KnifeActive.SwitchScriptsActor();
            SpoonActive.SwitchScriptsActor();
            
            break;
            case 2:
            
            ForkActive.SwitchScriptsActor();
            KnifeActive.SwitchScriptsPlayer();
            SpoonActive.SwitchScriptsActor();
            
            break;
            case 3:
            
            ForkActive.SwitchScriptsActor();
            KnifeActive.SwitchScriptsActor();
            SpoonActive.SwitchScriptsPlayer();
            
            break;
        }
    }
    public void ActiveCH()
    {
        ForkActive.gameObject.SetActive(true);
        KnifeActive.gameObject.SetActive(true);
        SpoonActive.gameObject.SetActive(true);
    }

    IEnumerator CoordinateActor()
    {
        // Switcha tra gli elementi
    if (isElement1Active)
    {
        ForkActive.SwitchScriptsPlayer();
        KnifeActive.SwitchScriptsActor();
        SpoonActive.SwitchScriptsActor();
        
        rotationSwitcher.CharacterID = 1;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("F_Player");
        
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;
        
        //////////////////////////////
        isElement1Active = false;
        isElement2Active = true;
    }
    else if (isElement2Active)
    {   
        ForkActive.SwitchScriptsActor();
        KnifeActive.SwitchScriptsPlayer();
        SpoonActive.SwitchScriptsActor();

        rotationSwitcher.CharacterID = 2;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("K_Player");
        
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;
        
        //////////////////////////////
        isElement2Active = false;
        isElement3Active = true;
    }
    else if (isElement3Active)
    {
        ForkActive.SwitchScriptsActor();
        KnifeActive.SwitchScriptsActor();
        SpoonActive.SwitchScriptsPlayer();
        
        rotationSwitcher.CharacterID = 3;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("S_Player");

        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;

        //////////////////////////////
        isElement3Active = false;
        isElement1Active = true;
    }
    }
#endregion
}
