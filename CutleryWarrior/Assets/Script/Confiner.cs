using UnityEngine;
using Cinemachine;

public class Confiner : MonoBehaviour
{
    public Collider BoxConfiner;    
    private CinemachineConfiner confiner;
    private CinemachineVirtualCamera vCam;    
    public bool canImp = false;
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    { vCam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner = GameManager.instance.vcam.GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner.m_BoundingVolume  = null; 
    confiner.m_BoundingVolume  = BoxConfiner;
    if(canImp){AnimationManager.instance.canImp = true;}} else if(!canImp){ AnimationManager.instance.canImp = false;}
    }
     public void OnTriggerStay(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    { vCam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner = GameManager.instance.vcam.GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner.m_BoundingVolume  = null; 
    confiner.m_BoundingVolume  = BoxConfiner;
    if(canImp){AnimationManager.instance.canImp = true;}} else if(!canImp){ AnimationManager.instance.canImp = false;}
    }
}