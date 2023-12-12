using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTimelineWithTime : MonoBehaviour
{
    public float lifeTime = 0;
    public GameObject title;
    void Start(){StartCoroutine(Destroy());}
    IEnumerator Destroy()
    {yield return new WaitForSeconds(lifeTime); title.SetActive(true);}
}
