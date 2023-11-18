using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FollowMouse : MonoBehaviour
{
    private float velocitaMovimento = 20f; // Velocità di movimento dell'oggetto.
    private Rigidbody rigidBody;
    [Tooltip("che indicatore è? 0.Skill 1.Ordini 2.Item")]
    [Range(0, 2)]
    public int WhatIs;  
    public GameObject indicator;    
    [HideInInspector]public int Character;
    public ChargeSkill Fork;
    public Transform T_F;
    public ChargeSkill Knife;
    public Transform T_K;
    public ChargeSkill Spoon;
    public Transform T_S;
    public CharacterFollow AI_F;
    public CharacterFollow AI_K;
    public CharacterFollow AI_S;
    public SwitchCharacter Sch;
    public GameObject ptPoint;
    public GameObject FPoint;
    public GameObject KPoint;
    public GameObject SPoint;

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
        GameManager.instance.StopBattle();
    }
    public void CharacterC(int Ch){Character = Ch;}

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
            rigidBody.velocity = new Vector3(0f, 0f, 0f);
            GameManager.instance.CloseLittleM();
            ///////////////////////////////////////////////
            ///
            switch(WhatIs)
            {
            case 0:
            ptPoint.transform.position = transform.position;
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
            break;}
            break;
            ////////////////////////
            case 1:
            if(GameManager.instance.F_Unlock && Character == 0)
            {AI_F.order = 3; FPoint.transform.position = transform.position;}
            else
            if(GameManager.instance.K_Unlock && Character == 1)
            {AI_K.order = 3; KPoint.transform.position = transform.position;}
            else
            if(GameManager.instance.S_Unlock && Character == 2)
            {AI_S.order = 3; SPoint.transform.position = transform.position;}
            //
            if(Sch.isElement1Active){vCam.Follow = T_S.transform;}
            else
            if(Sch.isElement2Active){vCam.Follow = T_F.transform;}
            else
            if(Sch.isElement3Active){vCam.Follow = T_K.transform;}
            break;
            ////////////////////////
            case 2:
            ptPoint.transform.position = transform.position;
            switch(Character)
            {
            case 0:
            if(GameManager.instance.F_Unlock){Fork.ActiveItem();
            vCam.Follow = Fork.transform;}
            break;
            case 1:
            if(GameManager.instance.K_Unlock){Knife.ActiveItem();
             vCam.Follow = Knife.transform;}
            break;
            case 2:
            if(GameManager.instance.S_Unlock){Spoon.ActiveItem();
             vCam.Follow = Spoon.transform;}
            break;}
            break;
            }
            indicator.SetActive(false); 
        }
}
}