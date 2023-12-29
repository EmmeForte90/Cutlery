using System.Collections;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public int lifeTime = 0;
    public bool isDestroy = false;
    public GameObject title;
    void Start(){StartCoroutine(Destroy());}
    IEnumerator Destroy()
    {
    yield return new WaitForSeconds(lifeTime);
    if(isDestroy){Destroy(title);}
    else 
    {title.SetActive(false);}
    }
}