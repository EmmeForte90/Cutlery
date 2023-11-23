using UnityEngine;

public class AiBullet : MonoBehaviour
{
    public float speed = 50f;  // Velocità del proiettile
    public GameObject OBJ;
    public float lifeTime = 1f;
    public GameObject target;
    private CharacterFollow AI_Ch;
    private Vector3 lastKnownPlayerPosition;  // Ultime coordinate conosciute del giocatore
    //public int attackDamage = 5;
    public GameObject hitEffect;
    //public bool Take = true;
    public void Awake()
    {
    AI_Ch = GameManager.instance.F_Hero.GetComponent<CharacterFollow>();
    target = AI_Ch.target;
    Destroy(OBJ, lifeTime);
    lastKnownPlayerPosition = target.transform.position;
    print("target" + target);
    }
    
    private void Update()
    {
        if (target == null)
        {
            Destroy(OBJ);  // Se il giocatore non è più presente, distruggi il proiettile
            return;
        }
        Vector3 direction = (lastKnownPlayerPosition - transform.position).normalized;  // Calcola la direzione verso il giocatore
        transform.Translate(direction * speed * Time.deltaTime, Space.World);  // Muovi il proiettile nella direzione del giocatore in uno spazio mondiale (3D).
    }

    public void OnTriggerEnter(Collider collision)
    {   
        if(collision.CompareTag("Enemy") || collision.CompareTag("Collider"))
        {
        if (hitEffect != null){Instantiate(hitEffect, transform.position, transform.rotation);}
        AudioManager.instance.PlayUFX(9);
        print("Colpito" + target);
        Destroy(OBJ);
        }
    }
}
