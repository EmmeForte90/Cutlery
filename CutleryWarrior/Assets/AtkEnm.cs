using UnityEngine;
public class AtkEnm : MonoBehaviour
{
    private CharacterMove F_Script;
    private CharacterFollow ch_FAc;
    private CharacterMove K_Script;
    private CharacterFollow ch_KAc;
    private CharacterMove S_Script;
    private CharacterFollow ch_SAc;
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
        if(GameManager.instance.F_Unlock && !F_Script.isDodging){F_Script.TakeDamage(attackDamage);}
        else if(GameManager.instance.F_Unlock && F_Script.isDodging){}
        if(GameManager.instance.F_Unlock && !ch_FAc.isGuard){ch_FAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.F_Unlock && ch_FAc.isGuard){ch_FAc.TakeDamage(5);}   
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
    }
    public void KnifeD()
    {
        if(GameManager.instance.K_Unlock){K_Script.TakeDamage(attackDamage);}
        if(GameManager.instance.K_Unlock && !ch_KAc.isGuard){ch_KAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.K_Unlock && ch_KAc.isGuard){ch_KAc.TakeDamage(5);}        
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
    }
    public void SpoonD()
    {
        if(GameManager.instance.S_Unlock && !S_Script.isDefence){S_Script.TakeDamage(attackDamage);}
        else if(GameManager.instance.S_Unlock && S_Script.isDefence){}
        if(GameManager.instance.S_Unlock && !ch_SAc.isGuard){ch_SAc.TakeDamage(attackDamage);}
        else if(GameManager.instance.S_Unlock && ch_SAc.isGuard){}
        AudioManager.instance.PlayUFX(9);
        Debug.Log("danno +"+ attackDamage);
    }
}