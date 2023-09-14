using System.Collections;
using UnityEngine;
public class TitleArea : MonoBehaviour
{
    public GameObject Title;
    public int lifeTime = 0;
    public bool DestroyObj = false;
    public void Start(){Title.gameObject.SetActive(false);}
    public void OnTriggerEnter(Collider other) 
    {if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {if(Title != null){Title.gameObject.SetActive(true); StartCoroutine(CoordinateActor());}}}
    IEnumerator CoordinateActor()
    {yield return new WaitForSeconds(lifeTime);
    if(!DestroyObj){Title.gameObject.SetActive(false);}
    else if(DestroyObj){if(Title != null){Destroy(Title);}}}
}