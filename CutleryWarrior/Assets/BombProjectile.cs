using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    public GameObject target; // Assegna il target nell'Inspector
    public GameObject landingPointPrefab; // Assegna il target nell'Inspector
    public int attackDamage = 5;
    public bool Take = true;
    public float velocita = 5f;
    public float accelerazioneGravitazionale = 9.8f;
    private bool isAscending = true;
    private Rigidbody rb;
     private CharacterMove F_Script;
    private CharacterFollow ch_FAc;
    private CharacterMove K_Script;
    private CharacterFollow ch_KAc;
    private CharacterMove S_Script;
    private CharacterFollow ch_SAc;
    public static BombProjectile instance;


    private void OnEnable() {if (instance == null){instance = this;}
        if(GameManager.instance.S_Unlock){ch_SAc = GameManager.instance.S_Hero.GetComponent<CharacterFollow>();}
        if(GameManager.instance.F_Unlock){ch_FAc = GameManager.instance.F_Hero.GetComponent<CharacterFollow>();}
        if(GameManager.instance.K_Unlock){ch_KAc = GameManager.instance.K_Hero.GetComponent<CharacterFollow>();}
        //
        if(GameManager.instance.S_Unlock){S_Script = GameManager.instance.S_Hero.GetComponent<CharacterMove>();}
        if(GameManager.instance.F_Unlock){F_Script = GameManager.instance.F_Hero.GetComponent<CharacterMove>();}
        if(GameManager.instance.K_Unlock){K_Script = GameManager.instance.K_Hero.GetComponent<CharacterMove>();}
        }
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
    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("F_Player")){ForkD();} 
        else if (collision.gameObject.CompareTag("K_Player")){KnifeD();} 
        else if (collision.gameObject.CompareTag("S_Player")){SpoonD();} 
        else if (collision.gameObject.CompareTag("Ground"))
        {if (landingPointPrefab != null){Instantiate(landingPointPrefab, transform.position, transform.rotation);}}
    }
    public void ForkD()
    {
        if(Take){
        if(GameManager.instance.F_Unlock){F_Script.TakeDamage(attackDamage);}
        if(GameManager.instance.F_Unlock && !ch_FAc.isGuard){ch_FAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.F_Unlock && ch_FAc.isGuard){ch_FAc.TakeDamage(5);}   
        AudioManager.instance.PlayUFX(9);
        //Debug.Log("danno +"+ attackDamage);
        if (landingPointPrefab != null){Instantiate(landingPointPrefab, transform.position, transform.rotation);}
        Take = false;}
         Destroy(target);
            Destroy(gameObject);
    }
    public void KnifeD()
    {
        if(Take){
        if(GameManager.instance.K_Unlock){K_Script.TakeDamage(attackDamage);}
        if(GameManager.instance.K_Unlock && !ch_KAc.isGuard){ch_KAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.K_Unlock && ch_KAc.isGuard){ch_KAc.TakeDamage(5);}        
        AudioManager.instance.PlayUFX(9);
        //Debug.Log("danno +"+ attackDamage);
        if (landingPointPrefab != null){Instantiate(landingPointPrefab, transform.position, transform.rotation);}
        Take = false;}
         Destroy(target);
            Destroy(gameObject);
    }
    public void SpoonD()
    {
        if(Take){
        if(GameManager.instance.S_Unlock){S_Script.TakeDamage(attackDamage);}
        if(GameManager.instance.S_Unlock){ch_SAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.S_Unlock && ch_SAc.isGuard){ch_SAc.Guard();}
        AudioManager.instance.PlayUFX(9);
        //Debug.Log("danno +"+ attackDamage);
        if (landingPointPrefab != null){Instantiate(landingPointPrefab, transform.position, transform.rotation);}
        Take = false;}
         Destroy(target);
            Destroy(gameObject);
    }
}