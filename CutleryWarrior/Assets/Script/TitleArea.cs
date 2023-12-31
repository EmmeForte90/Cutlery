using System.Collections;
using UnityEngine;
public class TitleArea : MonoBehaviour
{
    public GameObject Activator;
    public GameObject Title;
    public GameObject Container;
    public bool interaction = false;
    private bool HaveButton = false;
    public int lifeTime;
    public bool DestroyObj = false;
    public bool needSFX = false;
    public void Start()
    {if(Title != null){Title.gameObject.SetActive(false);}}
    void Update(){if(HaveButton){if(Input.GetMouseButtonDown(0) || Input.GetButton("Fire1")){continueGame();}}} 
    public void OnTriggerEnter(Collider other) 
    {if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {
    if(interaction){//Devi premere il pulsante
    HaveButton = true;Title.gameObject.SetActive(true);
    GameManager.instance.NotTouchOption = true;
    GameManager.instance.notChange = true;
    GameManager.instance.ChStop();}
    //
    else if (!interaction){StartCoroutine(CoordinateActor());}//Si attiva in automatico quando collide   
    }}

    public void continueGame()
    {
    GameManager.instance.ChCanM();
    GameManager.instance.NotTouchOption = false;
    GameManager.instance.notChange = false;
    if(!DestroyObj){Title.gameObject.SetActive(false);}
    else if(DestroyObj){Destroy(Container);Destroy(Activator);}
    }
    IEnumerator CoordinateActor()
    {
    Title.gameObject.SetActive(true);
    if(needSFX){AudioManager.instance.PlaySFX(13);}
    yield return new WaitForSeconds(lifeTime);
    GameManager.instance.ChCanM();
    GameManager.instance.NotTouchOption = false;
    GameManager.instance.notChange = false;
    Destroy(Title);
    Destroy(Container);
    Destroy(Activator);
    }
}