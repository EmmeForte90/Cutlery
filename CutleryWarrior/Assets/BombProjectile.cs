using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    public GameObject target; // Assegna il target nell'Inspector
    public GameObject landingPointPrefab; // Assegna il target nell'Inspector
    public float velocita = 5f;
    public float accelerazioneGravitazionale = 9.8f;
    private bool isAscending = true;
    private Rigidbody rb;
    public static BombProjectile instance;


    private void OnEnable() {if (instance == null){instance = this;}}
    //target = GameObject.FindGameObjectWithTag("Target");}

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
            //Salva questa logica per un altro tipo di attacco magari per un altro boss
            //target = GameObject.FindGameObjectWithTag("Target");
            
            //Debug.LogError("Il target non è stato assegnato alla bomba.");
            //return;
        }
    }
}