using System.Collections;
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
    public void OnEnable()
    {
    AI_Ch = GameManager.instance.F_Hero.GetComponent<CharacterFollow>();
    target = AI_Ch.target;
    if(target != null){lastKnownPlayerPosition = target.transform.position;}
    else if(target == null){OBJ.SetActive(false);}
    StartCoroutine(Deactivate());
    //print("target" + target);
    }
    private IEnumerator Deactivate()
    {
    yield return new WaitForSeconds(lifeTime);
    OBJ.SetActive(false);
    }
    private void Update()
    {
        if (target == null)
        {
            OBJ.SetActive(false);// Se il giocatore non è più presente, distruggi il proiettile
            return;
        }
        Vector3 direction = (lastKnownPlayerPosition - transform.position).normalized;  // Calcola la direzione verso il giocatore
        transform.Translate(direction * speed * Time.deltaTime, Space.World);  // Muovi il proiettile nella direzione del giocatore in uno spazio mondiale (3D).
    }
    public void OnDisable()
    {
        AudioManager.instance.PlayUFX(9);
        if (hitEffect != null){hitEffect.SetActive(true); hitEffect.transform.position=transform.position;}
    }

    public void OnTriggerEnter(Collider collision)
    {   
        if(collision.CompareTag("Enemy") || collision.CompareTag("Collider"))
        {
        //print("Colpito" + target);
        OBJ.SetActive(false);
        }
    }
}
