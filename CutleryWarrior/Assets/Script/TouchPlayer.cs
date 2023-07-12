using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Cinemachine;

public class TouchPlayer : MonoBehaviour
{
    // Riferimento all'evento di cambio scena
private SceneEvent sceneEvent;
public string spawnPointTag = "SpawnPoint";
private CinemachineVirtualCamera vCam;
public bool camFollowPlayer = true;
private GameObject player;

public string sceneName;
    // Start is called before the first frame update

    [Header("Audio")]
    [HideInInspector] public float basePitch = 1f;
    [HideInInspector] public float randomPitchOffset = 0.1f;
    [SerializeField] public AudioClip[] listmusic; // array di AudioClip contenente tutti i suoni che si vogliono riprodurre
    private AudioSource[] bgm; // array di AudioSource che conterrà gli oggetti AudioSource creati
    public AudioMixer SFX;
    private bool bgmActive = false;

    void Start()
    {
         // Recuperiamo il riferimento allo script dell'evento di cambio scena
    sceneEvent = GetComponent<SceneEvent>();
    // Aggiungiamo un listener all'evento di cambio scena
    sceneEvent.onSceneChange.AddListener(ChangeScene);
    }

    private void ChangeScene()
{
    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    SceneManager.sceneLoaded += OnSceneLoaded;
}

// Metodo eseguito quando la scena è stata caricata
private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    //GameplayManager.instance.FadeIn();
    SceneManager.sceneLoaded -= OnSceneLoaded;
    if (player != null)
    {
        CharacterMove.instance.inputCTR = false;
        CharacterMove.instance.Idle();
        CharacterMove.instance.Stop();

        if(camFollowPlayer)
        {
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;
        }
        // Troviamo il game object del punto di spawn
        GameObject spawnPoint = GameObject.FindWithTag(spawnPointTag);
        if (spawnPoint != null)
        {
            // Muoviamo il player al punto di spawn
            player.transform.position = spawnPoint.transform.position;
            //yield return new WaitForSeconds(3f);
        }
    }
    //GameplayManager.instance.StopFade();    
}

// Coroutine per attendere il caricamento della scena
IEnumerator WaitForSceneLoad()
{   
    //GameplayManager.instance.FadeOut();
    CharacterMove.instance.inputCTR = true;
    CharacterMove.instance.Idle();
    CharacterMove.instance.Stop();
    yield return new WaitForSeconds(2f);
    GameManager.instance.battle = true;
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(2f);
    // Invochiamo l'evento di cambio scena
    sceneEvent.InvokeOnSceneChange();
    
}

// Metodo eseguito quando il player entra nel trigger
private void OnTriggerStay(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("Player"))
    {
         // Troviamo il game object del player
        player = GameObject.FindGameObjectWithTag("Player");
        // Mostriamo il testo del dialogo se necessario
                    StartCoroutine(WaitForSceneLoad());

       
    }
}
 public void StopMFX(int soundToPlay)
    {
        if (bgmActive)
        {
            bgm[soundToPlay].Stop();
            bgmActive = false;
        }
    }

public void PlayMFX(int soundToPlay)
    {
        bgm[soundToPlay].Stop();
        // Imposta la pitch dell'AudioSource in base ai valori specificati.
        bgm[soundToPlay].pitch = basePitch + Random.Range(-randomPitchOffset, randomPitchOffset); 
        bgm[soundToPlay].Play();
    }


private void OnTriggerEnter(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("Player"))
    {
        CharacterMove.instance.Idle();
        CharacterMove.instance.Stop();
        CameraZoom.instance.ZoomIn();
         // Troviamo il game object del player
        player = GameObject.FindGameObjectWithTag("Player");
                    StartCoroutine(WaitForSceneLoad());

}
}

private void OnTriggerExit(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("Player"))
    { 
        CharacterMove.instance.Idle();
        CharacterMove.instance.Stop();
        // Troviamo il game object del player
         player = GameObject.FindGameObjectWithTag("Player");
                    StartCoroutine(WaitForSceneLoad());


        
       
}
}
}