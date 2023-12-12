using UnityEngine;

public class VFXImpronte : MonoBehaviour
{
    public bool canImp = false;
    public int WhatSound = 0;

    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    { if(canImp){AnimationManager.instance.canImp = true; AnimationManager.instance.SoundImp(WhatSound);}} 
    else if(!canImp){ AnimationManager.instance.canImp = false; AnimationManager.instance.SoundImp(0);}
    }
     public void OnTriggerStay(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    { if(canImp){AnimationManager.instance.canImp = true; AnimationManager.instance.SoundImp(WhatSound);}} 
    else if(!canImp){ AnimationManager.instance.canImp = false; AnimationManager.instance.SoundImp(0);}
    }
    public void OnTriggerExit(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    {AnimationManager.instance.canImp = false; AnimationManager.instance.SoundImp(0);}
    }
    
}