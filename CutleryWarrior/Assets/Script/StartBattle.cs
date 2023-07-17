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
    private int result;
    public static StartBattle instance;
[Header("Stats")]

    [Header("Fork")]

    public GameObject ForkActive;
    public GameObject ForckActor;
    public InputBattle F_Script;

    [Header("Spoon")]

    public GameObject SpoonActive;
    public GameObject SpoonActor;
    public InputBattle S_Script;

 [Header("Knife")]

    public GameObject KnifeActive;
    public GameObject KnifeActor;
    public InputBattle K_Script;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        // Genera un numero casuale tra 1 e 2
        //float randomNumber = Random.Range(1f, 2f);

        // Converte il numero in intero
        //result = Mathf.RoundToInt(randomNumber);

         // Stampa il risultato nella console
        //Debug.Log("Numero casuale: " + result);

        F_Script.inputCTR = true;
        K_Script.inputCTR = true;
        S_Script.inputCTR = true;

        ForkActive.transform.localScale = new Vector3(1, 1,1);
        KnifeActive.transform.localScale = new Vector3(1, 1,1);
        SpoonActive.transform.localScale = new Vector3(1, 1,1);
       
        ForckActor.transform.localScale = new Vector3(1, 1,1);
        KnifeActor.transform.localScale = new Vector3(1, 1,1);
        SpoonActor.transform.localScale = new Vector3(1, 1,1);

    //StartIntermezzo.gameObject.SetActive(true);
        StartCoroutine(DuringInter());
    }

IEnumerator DuringInter()
    {

        GameManager.instance.FadeOut();
        //StartIntermezzo.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        ReadyForBattle.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        ReadyForBattle.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        F_Script.inputCTR = false;
        K_Script.inputCTR = false;
        S_Script.inputCTR = false;
    }
    
}
