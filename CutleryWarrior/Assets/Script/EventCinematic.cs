using System.Collections;
using UnityEngine;
using Cinemachine;

public class EventCinematic : MonoBehaviour
{
    public int IdEvent;
    //private SwitchCharacter Switch;    
    public GameObject PointView;
    public bool Viewcam = false;
    [Header("Oggetto da attivare")]
    [Tooltip("Se hai un oggetto che deve restare attivo dopo l'evento")]
    public bool HavePersistOBJ = false;
    public GameObject PersistOBJ;
    public float TimeWait;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    public GameObject[] DeactiveObj; 

    private CinemachineVirtualCamera vcam; // La telecamera virtuale Cinemachine
     public void Start()
    {
    vcam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    if(GameManager.instance.F_Unlock){Fork = GameManager.instance.F_Hero.transform;}
    if(GameManager.instance.S_Unlock){Spoon = GameManager.instance.S_Hero.transform;}
    if(GameManager.instance.K_Unlock){Knife = GameManager.instance.K_Hero.transform;}
    }
    public void Take(){if(HavePersistOBJ){PersistOBJ.SetActive(true);}Destroy(gameObject); }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && GameManager.instance.CharacterID == 1)
    {Touch();}
    else if (other.CompareTag("K_Player") && GameManager.instance.CharacterID == 2)
    {Touch();}
    else if (other.CompareTag("S_Player") && GameManager.instance.CharacterID == 3)
    {Touch();}
    }
    public void Touch()
    {   
        //AudioManager.instance.CrossFadeOUTAudio(0);
        GameManager.instance.NotChange();
        AudioManager.instance.PlayUFX(7);
        GameManager.instance.ChStop();
        GameManager.instance.Allarm();
        CameraZoom.instance.ZoomIn();
        if(Viewcam){vcam.Follow = PointView.transform;}
        //AudioManager.instance.CrossFadeINAudio(1);
        StartCoroutine(WaitForSceneLoad());
    }
    IEnumerator WaitForSceneLoad()
    {   
    if(HavePersistOBJ){PersistOBJ.SetActive(true);}
    yield return new WaitForSeconds(TimeWait);
    GameManager.instance.StopAllarm();
    GameManager.instance.Change();
    GameManager.instance.ChCanM();
    if(Viewcam){vcam.Follow = Player.transform;}
    PlayerStats.instance.EventDesertEnd(IdEvent);
    foreach (GameObject arenaObject in DeactiveObj){arenaObject.SetActive(false);}
    }
}