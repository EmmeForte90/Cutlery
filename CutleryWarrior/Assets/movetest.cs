using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetest : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Velocità di movimento del personaggio
    public float runSpeed = 8.0f; // Velocità di movimento del personaggio
    public bool isRun = false;
    public float gravity = 9.81f;  // Gravità personalizzata, puoi regolarla come desideri
    private CharacterController characterController; // Riferimento al CharacterController

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Calcola la direzione del movimento in base agli input dell'utente
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        if(Input.GetButton("Fire3")){isRun = true;} 
        if (Input.GetButtonUp("Fire3")){isRun = false;} 

        // Trasforma la direzione del movimento in base alla rotazione del personaggio
        moveDirection = transform.TransformDirection(moveDirection);

        // Applica la velocità di movimento
        if(!isRun){characterController.Move(moveDirection * moveSpeed * Time.deltaTime);}
        else if(isRun){characterController.Move(moveDirection * runSpeed * Time.deltaTime);}


        // Gestisci la gravità
        if (!characterController.isGrounded)
        {
            // Applica la gravità personalizzata se necessario
            Vector3 gravityVector = new Vector3(0, -gravity, 0);
            characterController.Move(gravityVector * Time.deltaTime);
        }
    }
}