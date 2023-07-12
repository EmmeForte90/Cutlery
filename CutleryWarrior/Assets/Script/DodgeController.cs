using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeController : MonoBehaviour
{
    public float DodgeForce = 10f;
    public float DodgeDuration = 0.5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyDodge(Vector3 direction)
    {
        // Avvia la coroutine per applicare il knockback con la durata specificata
        StartCoroutine(DodgeCor(direction));
    }

    private IEnumerator DodgeCor(Vector3 direction)
    {
        // Normalizza la direzione per ottenere una forza costante
        direction.Normalize();

        // Applica una forza di knockback al Rigidbody nella direzione opposta
        if(InputBattle.instance.transform.localScale.x == 1)
        {
        rb.AddForce(direction * DodgeForce, ForceMode.Impulse);
        }else  if(InputBattle.instance.transform.localScale.x == -1)
        {
        rb.AddForce(-direction * DodgeForce, ForceMode.Impulse);
        }else  if(InputBattle.instance.transform.localScale.x == 0)
        {
        rb.AddForce(direction * DodgeForce, ForceMode.Impulse);
        }

        // Attendi per la durata del knockback
        yield return new WaitForSeconds(DodgeDuration);

        // Ripristina la posizione del personaggio
        rb.velocity = Vector3.zero;
    }
}