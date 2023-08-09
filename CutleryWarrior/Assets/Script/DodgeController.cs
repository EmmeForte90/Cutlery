using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeController : MonoBehaviour
{
    public float DodgeForce = 10f;
    public float DodgeDuration = 0.5f;
    public GameObject Character;
    private Rigidbody rb;

    public void Start()
    {rb = GetComponent<Rigidbody>();}

    public void ApplyDodge(Vector3 direction)
    {StartCoroutine(DodgeCor(direction));}
    private IEnumerator DodgeCor(Vector3 direction)
    {
        direction.Normalize();
        if(Character.transform.localScale.x == 1)
        {rb.AddForce(direction * DodgeForce, ForceMode.Impulse);}
        else  if(Character.transform.localScale.x == -1)
        {rb.AddForce(-direction * DodgeForce, ForceMode.Impulse);}
        else  if(Character.transform.localScale.x == 0)
        {rb.AddForce(direction * DodgeForce, ForceMode.Impulse);}
        yield return new WaitForSeconds(DodgeDuration);
        rb.velocity = Vector3.zero;
    }
}