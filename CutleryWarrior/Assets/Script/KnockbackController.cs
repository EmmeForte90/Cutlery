using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackController : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyKnockback(Vector3 direction)
    {
        // Avvia la coroutine per applicare il knockback con la durata specificata
        StartCoroutine(KnockbackRoutine(direction));
    }

    private IEnumerator KnockbackRoutine(Vector3 direction)
    {
        // Normalizza la direzione per ottenere una forza costante
        direction.Normalize();

        // Applica una forza di knockback al Rigidbody nella direzione opposta
        rb.AddForce(-direction * knockbackForce, ForceMode.Impulse);

        // Attendi per la durata del knockback
        yield return new WaitForSeconds(knockbackDuration);

        // Ripristina la posizione del personaggio
        rb.velocity = Vector3.zero;
    }
}