using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowMouse : MonoBehaviour
{
    private float velocitaMovimento = 20f; // Velocità di movimento dell'oggetto.
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        // Impedisci la rotazione dell'oggetto quando viene spostato con il mouse.
        rigidBody.freezeRotation = true;
    }

    void Update()
    {
        // Input da tastiera per il movimento.
        float movimentoOrizzontale = Input.GetAxis("Vertical");
        float movimentoVerticale = Input.GetAxis("Horizontal");

        // Calcola la direzione di movimento.
        Vector3 direzioneMovimento = new Vector3(movimentoOrizzontale, 0.0f, movimentoVerticale);

        // Normalizza la direzione per evitare il movimento diagonale più veloce.
        direzioneMovimento.Normalize();

        // Calcola la velocità di traslazione basata sulla direzione e sulla velocità.
        Vector3 velocitaTraslazione = direzioneMovimento * velocitaMovimento;

        // Applica la velocità di traslazione all'oggetto solo sugli assi X e Z.
        rigidBody.velocity = new Vector3(velocitaTraslazione.x, rigidBody.velocity.y, velocitaTraslazione.z);
    }
}