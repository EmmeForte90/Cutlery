using UnityEngine;

public class VFXImpronte : MonoBehaviour
{
    public bool canImp = false;

    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    { if(canImp){AnimationManager.instance.canImp = true;}} else if(!canImp){ AnimationManager.instance.canImp = false;}
    }
     public void OnTriggerStay(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    {if(canImp){AnimationManager.instance.canImp = true;}} else if(!canImp){ AnimationManager.instance.canImp = false;}
    }
    public void OnTriggerExit(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    {AnimationManager.instance.canImp = false;}
    }
    
}