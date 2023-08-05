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
    public string spawnPointTag = "SpawnPoint";
    private CinemachineVirtualCamera vCam;
    public bool camFollowPlayer = true;
    //private GameObject player;
    private SceneEvent sceneEvent;
    public string sceneName;
    // Start is called before the first frame update
       
    public float stoppingDistance = 1f;
    public Vector3 savedPosition;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    private SwitchCharacter Switch;
   

    public void Start()
    {
    if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
    // Recuperiamo il riferimento allo script dell'evento di cambio scena
    sceneEvent = GetComponent<SceneEvent>();
    // Aggiungiamo un listener all'evento di cambio scena
    sceneEvent.onSceneChange.AddListener(ChangeScene);
    Fork = GameObject.Find("F_Player").transform;
    Spoon = GameObject.Find("S_Player").transform;
    Knife = GameObject.Find("K_Player").transform;
    
    }
    public void Update()
    {
        if(Switch.isElement1Active)
        {Player = Spoon;}
        else if(Switch.isElement2Active)
        {Player = Fork;} 
        else if(Switch.isElement3Active)
        {Player = Knife;} 

    if ((transform.position - Player.transform.position).sqrMagnitude < stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position;}
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
    /*if (player != null)
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
    }*/
    //GameplayManager.instance.StopFade();    
}

// Coroutine per attendere il caricamento della scena
IEnumerator WaitForSceneLoad()
{   
    GameManager.instance.ChStop();
    yield return new WaitForSeconds(2f);
    GameManager.instance.battle = true;
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(2f);
    // Invochiamo l'evento di cambio scena
    sceneEvent.InvokeOnSceneChange();
}
private void Flip()
    {
        if (Player.localScale.x > 0f)
        {
            transform.localScale = new Vector3(1, 1,1);
    
        }else if (Player.localScale.x < 0f)
        {
            transform.localScale = new Vector3(-1, 1,1);

        }
    }
// Metodo eseguito quando il player entra nel trigger
public void OnTriggerStay(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {
        GameManager.instance.savedPosition = savedPosition;
        GameManager.instance.ChStop();
         // Troviamo il game object del player
        //player = GameObject.FindGameObjectWithTag("Player");
        // Mostriamo il testo del dialogo se necessario
        StartCoroutine(WaitForSceneLoad()); 
    }
}
 

public void OnTriggerEnter(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {
        GameManager.instance.savedPosition = savedPosition;
        GameManager.instance.ChStop();
        CameraZoom.instance.ZoomIn();
         // Troviamo il game object del player
        //player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitForSceneLoad());
}
}

public void OnTriggerExit(Collider other)
{
    // Controlliamo se il player ha toccato il collider
    if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    { 
        GameManager.instance.savedPosition = savedPosition;
        GameManager.instance.ChStop();
        // Troviamo il game object del player
        //player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitForSceneLoad());     
}}

#if(UNITY_EDITOR)
#region Gizmos
private void OnDrawGizmos()
    {
    Gizmos.color = Color.red;
    // disegna un Gizmo che rappresenta il Raycast
    //Gizmos.DrawLine(transform.position, transform.position + new Vector3(transform.localScale.x, 0, 0) * wallDistance);
    //Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
#endregion
#endif

}