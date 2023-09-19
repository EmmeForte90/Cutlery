using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FollowMouse : MonoBehaviour
{
    private float velocitaMovimento = 20f; // Velocità di movimento dell'oggetto.
    private Rigidbody rigidBody;
    public GameObject indicator;    
    [HideInInspector]public int Character;
    public ChargeSkill Fork;
    public ChargeSkill Knife;
    public ChargeSkill Spoon;
    public GameObject ptPoint;

    private CinemachineVirtualCamera vCam;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    public void OnEnable()
    {
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        vCam.Follow = indicator.transform;
    }

    void Update()
    {
        // Input da tastiera per il movimento.
        float movimentoOrizzontale = Input.GetAxis("Vertical");
        float movimentoVerticale = Input.GetAxis("Horizontal");

        // Calcola la direzione di movimento.
        Vector3 direzioneMovimento = new Vector3(-movimentoOrizzontale, 0.0f, movimentoVerticale);

        // Normalizza la direzione per evitare il movimento diagonale più veloce.
        direzioneMovimento.Normalize();

        // Calcola la velocità di traslazione basata sulla direzione e sulla velocità.
        Vector3 velocitaTraslazione = direzioneMovimento * velocitaMovimento;

        // Applica la velocità di traslazione all'oggetto solo sugli assi X e Z.
        rigidBody.velocity = new Vector3(velocitaTraslazione.x, rigidBody.velocity.y, velocitaTraslazione.z);

        if (Input.GetMouseButtonDown(0))
        {
            ptPoint.transform.position = transform.position;
            rigidBody.velocity = new Vector3(0f, 0f, 0f);
            GameManager.instance.CloseLittleM();
            switch(Character)
            {
            case 0:
            if(GameManager.instance.F_Unlock){Fork.ActiveSkill();
            vCam.Follow = Fork.transform;}
            break;
            case 1:
            if(GameManager.instance.K_Unlock){Knife.ActiveSkill();
             vCam.Follow = Knife.transform;}
            break;
            case 2:
            if(GameManager.instance.S_Unlock){Spoon.ActiveSkill();
             vCam.Follow = Spoon.transform;}
            break;
            }
            indicator.SetActive(false);
        }

    }
}