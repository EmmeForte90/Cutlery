using UnityEngine;

public class BombProjectile : MonoBehaviour
{
   public GameObject target; // Assegna il target nell'Inspector
    //public float launchForce = 10f; // Forza di lancio iniziale
    //public float gravity = 9.8f; // Gravità
    //public bool randomDirection = false; // Se true, i valori del vettore di lancio sono randomici
    public GameObject landingPointPrefab; // Assegna il target nell'Inspector
     public float velocita = 5f;
    public float accelerazioneGravitazionale = 9.8f;
    //public float speed = 5f;
    //public float ascendSpeed = 2f;
    //public float ascendHeight = 10f;

    private bool isAscending = true;

    private Rigidbody rb;

     private void OnEnable() {
        target = GameObject.FindGameObjectWithTag("Target");
    }

    void Update()
    {
        if (target != null)
        {
             
        // Calcola la direzione verso il target
        Vector3 direzione = (target.transform.position - transform.position).normalized;

        // Calcola il vettore di spostamento
        Vector3 spostamento = direzione * velocita * Time.deltaTime;

        // Applica la gravità
        spostamento.y -= accelerazioneGravitazionale * Time.deltaTime;

        // Sposta la bomba
        transform.Translate(spostamento);

        // Controlla se la bomba ha raggiunto il target
        if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
        {
            // La bomba ha raggiunto il target, puoi gestire l'esplosione o qualsiasi altra logica qui
            Debug.Log("Boom! La bomba ha colpito il target.");
            if (landingPointPrefab != null){Instantiate(landingPointPrefab, transform.position, transform.rotation);}
            Destroy(target);
            Destroy(gameObject);
        }
        } else if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Target");
            //Debug.LogError("Il target non è stato assegnato alla bomba.");
            //return;
        }

    }


    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("Ground"))
        {if (landingPointPrefab != null){Instantiate(landingPointPrefab, transform.position, transform.rotation);}}
        Destroy(gameObject);
    }
}