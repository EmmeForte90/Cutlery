using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public int lifeTime = 0;
    public GameObject title;
    void Start(){StartCoroutine(Destroy());}
    IEnumerator Destroy(){yield return new WaitForSeconds(lifeTime); Destroy(title.gameObject);}
}