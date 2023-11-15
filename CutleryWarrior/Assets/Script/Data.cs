using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public bool HaveData = false;
    public GameObject Continue;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerStats.instance != null){if(PlayerStats.instance.HaveData){HaveData = true;}
        else if(!PlayerStats.instance.HaveData){HaveData = false;}}
        if(PlayerStats.instance == null){print("NothingData");}
        if(HaveData){StartCoroutine(BoxDel());}else if(!HaveData){Continue.SetActive(false);}
    }
    IEnumerator BoxDel()
    {yield return new WaitForSeconds(10f);
    Continue.SetActive(true);}

    
}
