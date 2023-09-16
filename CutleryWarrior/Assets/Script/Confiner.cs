using UnityEngine;
using Cinemachine;

public class Confiner : MonoBehaviour
{
    public Collider BoxConfiner;    
    private CinemachineConfiner confiner;
    private CinemachineVirtualCamera vCam;    
    
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    { vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner.m_BoundingVolume  = null; 
    confiner.m_BoundingVolume  = BoxConfiner;}
    }
}