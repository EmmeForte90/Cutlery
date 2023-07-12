using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTimeScale : MonoBehaviour
{
     public float customTimeScale = 1f;
    private float originalTimeScale;
    public bool scaleT = false;
    public static CustomTimeScale instance;
    private void Start()
    { 
        if (instance == null)
        {
            instance = this;
        }    
        scaleT = true;
    }

    void Update()
    {
        if(scaleT)
        { Time.timeScale = customTimeScale;}
        else if(!scaleT)
        { Time.timeScale = Time.timeScale = originalTimeScale;}
    }

}

