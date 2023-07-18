using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Cinemachine;

public class LevelChanger : MonoBehaviour
{
   // Variabili per memorizzare la scena attuale e la posizione del player
//public string spawnPointTag = "SpawnPoint";
public string sceneName;
// Riferimento all'evento di cambio scena
public int IDPorta;
private SceneEvent sceneEvent;
// Riferimento al game object del player
private GameObject player;

private void Start()
{
    sceneEvent = GetComponent<SceneEvent>();
    sceneEvent.onSceneChange.AddListener(ChangeScene);
}

// Metodo per cambiare scena
private void ChangeScene()
{
    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    SceneManager.sceneLoaded += OnSceneLoaded;
}

// Metodo eseguito quando la scena è stata caricata
private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    SceneManager.sceneLoaded -= OnSceneLoaded;
    /*if (player != null)
    {
        //GameObject spawnPoint = GameObject.FindWithTag(spawnPointTag);
        if (spawnPoint != null)
        {player.transform.position = spawnPoint.transform.position;}
    }*/
}

// Coroutine per attendere il caricamento della scena
IEnumerator WaitForSceneLoad()
{   
    GameManager.instance.StartGame = false;
    CharacterMove.instance.inputCTR = true;
    CharacterMove.instance.Idle();
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(2f);
    GameManager.instance.IDPorta = IDPorta;
    sceneEvent.InvokeOnSceneChange();
    CharacterMove.instance.isRun = false;
    yield return new WaitForSeconds(2f);
    CharacterMove.instance.inputCTR = false; 
    GameManager.instance.FadeOut();
    yield return new WaitForSeconds(2f);
}

// Metodo eseguito quando il player entra nel trigger
private void OnTriggerStay(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("Player"))
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitForSceneLoad()); 
    }
}



private void OnTriggerEnter(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("Player"))
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitForSceneLoad());
}}

private void OnTriggerExit(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("Player"))
    {player = GameObject.FindGameObjectWithTag("Player");}
}

}