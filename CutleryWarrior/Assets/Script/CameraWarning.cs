using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class CameraWarning : MonoBehaviour
{    
    public int IdEvent;
    public GameObject This;
    public GameObject Enemy;
    private GameObject  Player;
    public GameObject  triangle;
    public GameObject Box;
    [TextArea(3, 10)]    
    public string ContentD;
    private bool canpress = false;
    public TextMeshProUGUI dialogueText; 
    private CinemachineVirtualCamera vcam; // La telecamera virtuale Cinemachine
    public static CameraWarning instance;

    public void Take(){Destroy(gameObject);}

    void Start()
    {
        Player = GameManager.instance.player;       
        vcam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    }
    void Update(){if(canpress){
        if(Input.GetButtonDown("Fire1")){Box.SetActive(false);
        vcam.Follow = Player.transform;
        GameManager.instance.ChCanM();
        PlayerStats.instance.EventDesertEnd(IdEvent);
        Destroy(This);}}}

    public void OnTriggerEnter(Collider collision)
    {
        // Controlliamo se il player ha toccato il collider
        if (collision.gameObject.CompareTag("F_Player")||
        collision.gameObject.CompareTag("K_Player")||
        collision.gameObject.CompareTag("S_Player"))
        {StartCoroutine(ChangeAreaF());}
    }

    IEnumerator ChangeAreaF()
    {
        GameManager.instance.NotChange();
        AudioManager.instance.PlayUFX(7);
        GameManager.instance.ChStop();
        GameManager.instance.Allarm();
        yield return new WaitForSeconds(2f);
        GameManager.instance.StopAllarm();
        vcam.Follow = Enemy.transform;
        dialogueText.text = ContentD.ToString();
        Box.SetActive(true);
        yield return new WaitForSeconds(2f);
        triangle.SetActive(true);
        canpress = true;
    }
}
