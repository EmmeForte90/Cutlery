using System.Collections;
using UnityEngine;
public class TitleArea : MonoBehaviour
{
    public GameObject Title;
    public int lifeTime = 0;
    public bool DestroyObj = false;
    public void Start()
    {if(Title != null){Title.gameObject.SetActive(false); StartCoroutine(CoordinateActor());}
    else if(Title == null){print("Nothing title");}}
    public void OnTriggerEnter(Collider other) 
    {if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {
    if(Title != null){Title.gameObject.SetActive(true);         
    StartCoroutine(CoordinateActor());}
    else if(Title == null){print("Nothing title");}}}
    IEnumerator CoordinateActor()
    {
    yield return new WaitForSeconds(2);
    AudioManager.instance.PlaySFX(13);
    yield return new WaitForSeconds(lifeTime);
    if(!DestroyObj){Title.gameObject.SetActive(false);}
    else if(DestroyObj){if(Title != null){Destroy(Title);}}}
}