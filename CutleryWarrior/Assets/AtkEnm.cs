using System.Collections;
using UnityEngine;

public class AtkEnm : MonoBehaviour
{
    private CharacterMove F_Script;
    private CharacterFollow ch_FAc;
    private CharacterMove K_Script;
    private CharacterFollow ch_KAc;
    private CharacterMove S_Script;
    private CharacterFollow ch_SAc;
    public bool canATK = true;
    public int attackDamage = 5;
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
    public void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("F_Player")){ForkD();} 
        else if (collision.gameObject.CompareTag("K_Player")){KnifeD();} 
        else if (collision.gameObject.CompareTag("S_Player")){SpoonD();} 
    }
    public void ForkD()
    {
        if(GameManager.instance.F_Unlock && !F_Script.isDodging && canATK){F_Script.TakeDamage(attackDamage); canATK = false;}
        else if(GameManager.instance.F_Unlock && F_Script.isDodging && canATK){canATK = false;}
        if(GameManager.instance.F_Unlock && !ch_FAc.isGuard && canATK){ch_FAc.TakeDamage(attackDamage); canATK = false;}
        else if(GameManager.instance.F_Unlock && ch_FAc.isGuard && canATK){ch_FAc.TakeDamage(5); canATK = false;}   
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
        StartCoroutine(StumpKTime());
    }
    public void KnifeD()
    {
        if(GameManager.instance.K_Unlock && canATK){K_Script.TakeDamage(attackDamage); canATK = false;}
        if(GameManager.instance.K_Unlock && !ch_KAc.isGuard && canATK){ch_KAc.TakeDamage(attackDamage); canATK = false;}
        else if(GameManager.instance.K_Unlock && ch_KAc.isGuard && canATK){ch_KAc.TakeDamage(5); canATK = false;}        
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
        StartCoroutine(StumpKTime());
    }
    public void SpoonD()
    {
        if(GameManager.instance.S_Unlock && !S_Script.isDefence && canATK){S_Script.TakeDamage(attackDamage); canATK = false;}
        else if(GameManager.instance.S_Unlock && S_Script.isDefence && canATK){canATK = false;}
        if(GameManager.instance.S_Unlock && !ch_SAc.isGuard && canATK){ch_SAc.TakeDamage(attackDamage); canATK = false;}
        else if(GameManager.instance.S_Unlock && ch_SAc.isGuard && canATK){ canATK = false;}
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
        StartCoroutine(StumpKTime());
    }

    private IEnumerator StumpKTime()
    {
    yield return new WaitForSeconds(0.5f);
    canATK = true;
    }
}