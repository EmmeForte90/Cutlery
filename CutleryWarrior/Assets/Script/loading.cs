using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loading : MonoBehaviour
{
    private string sceneName;
    public int IDPorta;
    //public bool Loading = false;
    public SceneEvent sceneEvent;


    public void Start()
    {
    //sceneEvent = GetComponent<SceneEvent>();
    if(PlayerStats.instance.NameScene != null){sceneName = PlayerStats.instance.NameScene; 
    IDPorta = PlayerStats.instance.IdSpawn;}
    else {IDPorta = 0;}
    StartCoroutine(StartLoad());
    sceneEvent.onSceneChange.AddListener(ChangeScene);
    }
    private void ChangeScene()
    {
    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {SceneManager.sceneLoaded -= OnSceneLoaded;}
    IEnumerator StartLoad()
    {    
    yield return new WaitForSeconds(3f);
    sceneEvent.InvokeOnSceneChange();
    }  
    
    
    IEnumerator WaitForSceneLoad()
    {   
    GameManager.instance.StartGame = false;
    CharacterMove.instance.inputCTR = true;
    CharacterMove.instance.Idle();
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(2f);
    SwitchCharacter.instance.ActiveCH();
    GameManager.instance.IDPorta = IDPorta;
    sceneEvent.InvokeOnSceneChange();
    CharacterMove.instance.isRun = false;
    yield return new WaitForSeconds(2f);
    CharacterMove.instance.inputCTR = false; 
    //GameManager.instance.FadeOut();
    yield return new WaitForSeconds(2f);
    }
}