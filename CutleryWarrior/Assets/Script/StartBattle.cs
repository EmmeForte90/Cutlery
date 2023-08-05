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
    //public GameObject StartIntermezzo; // Variabile per il player
    public GameObject ReadyForBattle; // Variabile per il player
    public GameObject DuelManagerO; // Variabile per il player
    //private int result;
    public static StartBattle instance;
[Header("Stats")]

    [Header("Fork")]

    private GameObject ForkActive;
    private ForkInput F_Script;
    public GameObject F_point; // Variabile per il player

    [Header("Spoon")]

    private GameObject SpoonActive;
    private SpoonInput S_Script;
    public GameObject S_point; // Variabile per il player

 [Header("Knife")]

    private GameObject KnifeActive;
    private KnifeInput K_Script;
    public GameObject K_point; // Variabile per il player

 [Header("Enemy")]
    public SimpleEnemy E_Script;
    public DuelManager Duel_Script;
    public void Start()
    {
        if (instance == null){instance = this;}

        // Genera un numero casuale tra 1 e 2
        //float randomNumber = Random.Range(1f, 2f);

        // Converte il numero in intero
        //result = Mathf.RoundToInt(randomNumber);

         // Stampa il risultato nella console
        //Debug.Log("Numero casuale: " + result);

        Duel_Script.inputCTR = true;
        F_Script = GameObject.Find("F_Player").GetComponent<ForkInput>();
        K_Script = GameObject.Find("S_Player").GetComponent<KnifeInput>();
        S_Script = GameObject.Find("K_Player").GetComponent<SpoonInput>();
        ////////////////////////
        ForkActive = GameObject.Find("F_Player");
        SpoonActive = GameObject.Find("S_Player");
        KnifeActive = GameObject.Find("K_Player");
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
        yield return new WaitForSeconds(2f);
        ReadyForBattle.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        ReadyForBattle.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Duel_Script.inputCTR = false;
    }
    
}
