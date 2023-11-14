using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;  // Velocità del proiettile
    private GameObject player;  // Riferimento al giocatore
    public GameObject OBJ;
    private int resultP;
    public float lifeTime = 1f;
    private CharacterMove F_Script;
    private CharacterFollow ch_FAc;
    private CharacterMove K_Script;
    private CharacterFollow ch_KAc;
    private CharacterMove S_Script;
    private CharacterFollow ch_SAc;
    public int attackDamage = 5;
    public GameObject hitEffect;

    public void Awake()
    {
        if(GameManager.instance.S_Unlock){ch_SAc = GameObject.Find("S_Player").GetComponent<CharacterFollow>();}
        if(GameManager.instance.F_Unlock){ch_FAc = GameObject.Find("F_Player").GetComponent<CharacterFollow>();}
        if(GameManager.instance.K_Unlock){ch_KAc = GameObject.Find("K_Player").GetComponent<CharacterFollow>();}
        //
        if(GameManager.instance.S_Unlock){S_Script = GameObject.Find("S_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.F_Unlock){F_Script = GameObject.Find("F_Player").GetComponent<CharacterMove>();}
        if(GameManager.instance.K_Unlock){K_Script = GameObject.Find("K_Player").GetComponent<CharacterMove>();}
    }

    private Vector3 lastKnownPlayerPosition;  // Ultime coordinate conosciute del giocatore

    private void Start()
    {
        Destroy(OBJ, lifeTime);
        Choise();
        switch(resultP)
        {
            case 0:
        player = GameObject.FindGameObjectWithTag("F_Player");  // Trova il giocatore per tag
            break;
            case 1:
        player = GameObject.FindGameObjectWithTag("S_Player");  // Trova il giocatore per tag
            break;
            case 2:
        player = GameObject.FindGameObjectWithTag("K_Player");  // Trova il giocatore per tag
            break;
        } 
        lastKnownPlayerPosition = player.transform.position;  // Aggiorna le coordinate conosciute del giocatore
    }

    private void Choise()
    {
        // Genera un numero casuale tra 1 e 3
        if(GameManager.instance.F_Unlock &&
        GameManager.instance.S_Unlock &&
        GameManager.instance.K_Unlock){
        int randomNumber = Random.Range(0, 2);
        resultP = Mathf.RoundToInt(randomNumber);} 
        else if(GameManager.instance.F_Unlock &&
        !GameManager.instance.S_Unlock &&
        !GameManager.instance.K_Unlock){
        resultP = 0;}
        //Debug.Log("Numero casuale: " + result);
        //Debug.Log(ID + "ha Preso" + result);
        switch(resultP)
        {
            case 0:
            if(GameManager.instance.F_Unlock){player = GameManager.instance.F_Hero;}
            else if(!GameManager.instance.F_Unlock){Choise();}
            break;
            case 1:
            if(GameManager.instance.K_Unlock){player =  GameManager.instance.K_Hero;}
            else if(!GameManager.instance.K_Unlock){Choise();}
            break;
            case 2:
            if(GameManager.instance.S_Unlock){player =  GameManager.instance.S_Hero;}
            else if(!GameManager.instance.S_Unlock){Choise();}
            break;
        } 
    }

    private void Update()
    {
        if (player == null)
        {
            Destroy(OBJ);  // Se il giocatore non è più presente, distruggi il proiettile
            return;
        }

        Vector3 direction = (lastKnownPlayerPosition - transform.position).normalized;  // Calcola la direzione verso il giocatore

        transform.Translate(direction * speed * Time.deltaTime, Space.World);  // Muovi il proiettile nella direzione del giocatore in uno spazio mondiale (3D).
    }

    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("F_Player")){ForkD();} 
        else if (collision.gameObject.CompareTag("K_Player")){KnifeD();} 
        else if (collision.gameObject.CompareTag("S_Player")){SpoonD();} 
        else if (collision.gameObject.CompareTag("Ground"))
        {if (hitEffect != null){Instantiate(hitEffect, transform.position, transform.rotation);}}
    }
    public void ForkD()
    {
        if(GameManager.instance.F_Unlock){F_Script.TakeDamage(attackDamage);}
        if(GameManager.instance.F_Unlock && !ch_FAc.isGuard){ch_FAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.F_Unlock && ch_FAc.isGuard){ch_FAc.TakeDamage(5);}   
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
        if (hitEffect != null){Instantiate(hitEffect, transform.position, transform.rotation);}
        Destroy(OBJ);
    }
    public void KnifeD()
    {
        if(GameManager.instance.K_Unlock){K_Script.TakeDamage(attackDamage);}
        if(GameManager.instance.K_Unlock && !ch_KAc.isGuard){ch_KAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.K_Unlock && ch_KAc.isGuard){ch_KAc.TakeDamage(5);}        
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
        if (hitEffect != null){Instantiate(hitEffect, transform.position, transform.rotation);}
        Destroy(OBJ);    
    }
    public void SpoonD()
    {
        if(GameManager.instance.S_Unlock && !S_Script.isDefence){S_Script.TakeDamage(attackDamage);}
        else if(GameManager.instance.S_Unlock && S_Script.isDefence){}
        if(GameManager.instance.S_Unlock && !ch_SAc.isGuard){ch_SAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.S_Unlock && ch_SAc.isGuard){}
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
        if (hitEffect != null){Instantiate(hitEffect, transform.position, transform.rotation);}
        Destroy(OBJ);
    }
}