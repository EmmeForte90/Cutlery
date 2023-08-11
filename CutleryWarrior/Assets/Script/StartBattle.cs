using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class StartBattle : MonoBehaviour
{
    public GameObject ReadyForBattle; // Variabile per il player
    public GameObject DuelManagerO; // Variabile per il player
    public static StartBattle instance;
    private SwitchCharacter Switch;
    private CinemachineVirtualCamera vCam;
    private GameObject player;
    [Header("Stats")]

    [Header("Fork")]
    private GameObject ForkActive;
    private CharacterMove F_Script;
    public GameObject F_point; // Variabile per il player
    private ChangeHeroSkin Skin_F;

    [Header("Spoon")]
    private GameObject SpoonActive;
    private CharacterMove S_Script;
    public GameObject S_point; // Variabile per il player
    private ChangeHeroSkin Skin_S;

    [Header("Knife")]
    private GameObject KnifeActive;
    private CharacterMove K_Script;
    public GameObject K_point; // Variabile per il player
    private ChangeHeroSkin Skin_K;

    [Header("Enemy")]
    public SimpleEnemy E_Script;
    public DuelManager Duel_Script;

    public void Awake()
    {
        if (instance == null){instance = this;}
        if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();;} 
        GameManager.instance.battle = true;
        GameManager.instance.ChStop();
        GameManager.instance.TakeCamera();
        F_Script = GameObject.Find("F_Player").GetComponent<CharacterMove>();
        K_Script = GameObject.Find("K_Player").GetComponent<CharacterMove>();
        S_Script = GameObject.Find("S_Player").GetComponent<CharacterMove>();
        Skin_F = GameObject.Find("F_Player").GetComponent<ChangeHeroSkin>();
        Skin_K = GameObject.Find("K_Player").GetComponent<ChangeHeroSkin>();
        Skin_S = GameObject.Find("S_Player").GetComponent<ChangeHeroSkin>();
        GameManager.instance.Battle();
        Skin_S.UpdateCharacterSkin();
		Skin_S.UpdateCombinedSkin();
        Skin_F.UpdateCharacterSkin();
		Skin_F.UpdateCombinedSkin();
        Skin_K.UpdateCharacterSkin();
		Skin_K.UpdateCombinedSkin(); 
        GameManager.instance.Posebattle();
        ForkActive = GameObject.Find("F_Player");
        SpoonActive = GameObject.Find("S_Player");
        KnifeActive = GameObject.Find("K_Player");
    }
    public void Start()
    {
        // Genera un numero casuale tra 1 e 2
        //float randomNumber = Random.Range(1f, 2f);

        // Converte il numero in intero
        //result = Mathf.RoundToInt(randomNumber);

         // Stampa il risultato nella console
        //Debug.Log("Numero casuale: " + result);
        ForkActive.transform.position = F_point.transform.position;
        KnifeActive.transform.position = K_point.transform.position;
        SpoonActive.transform.position = S_point.transform.position;
        ////////////////////////
        ForkActive.transform.localScale = new Vector3(1, 1,1);
        KnifeActive.transform.localScale = new Vector3(1, 1,1);
        SpoonActive.transform.localScale = new Vector3(1, 1,1);
        ////////////////////////
        StartCoroutine(DuringInter());
    }

IEnumerator DuringInter()
    {
        GameManager.instance.FadeOut();
        yield return new WaitForSeconds(1f);
        ReadyForBattle.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        ReadyForBattle.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.ChCanM();
        if(Switch.isElement1Active)
        {
            vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>();
            player = GameObject.FindWithTag("S_Player"); 
            vCam.Follow = player.transform;
        }else if(Switch.isElement2Active)
        {
            vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
            player = GameObject.FindWithTag("F_Player"); 
            vCam.Follow = player.transform;
            
        }else if(Switch.isElement3Active)
        {
            vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>();
            player = GameObject.FindWithTag("K_Player");  
            vCam.Follow = player.transform;
            
        }
        GameManager.instance.Change();
        GameManager.instance.ChCanM();
        Duel_Script.inputCTR = false;
    }
    
}
