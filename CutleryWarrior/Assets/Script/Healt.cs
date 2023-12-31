using System.Collections;
using UnityEngine;
public class Healt : MonoBehaviour
{
    #region Header
    public GameObject OBJ;
    public float restore = 10;
    public bool isSkill = true;
    public bool isMana = false;
    public bool one = true;
    public Skill itemInfo;
    public float lifeTime = 2f;
    public static Healt instance;
    #endregion
    void OnEnable()
    {
        if (instance == null){instance = this;}
        if (isSkill){restore = itemInfo.damage;}
        //print("lanciato");
        StartCoroutine(Deactivate());
    }

    public void OnTriggerEnter(Collider other)
    {
        if(one)
        {
        if(other.CompareTag("F_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        if(!isMana){PlayerStats.instance.F_curHP += restore;}
        else if(isMana){PlayerStats.instance.F_curMP += restore;}
        one = false;
        }
        if(other.CompareTag("K_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        if(!isMana){PlayerStats.instance.K_curHP += restore;}
        else if(isMana){PlayerStats.instance.K_curMP += restore;}
        one = false;        
        }
        if(other.CompareTag("S_Player"))
        {
        AudioManager.instance.PlayUFX(9);
        if(!isMana){PlayerStats.instance.S_curHP += restore;}
        else if(isMana){PlayerStats.instance.S_curMP += restore;}
        one = false;
        }
        }
        StartCoroutine(Deactivate());
    }

     private IEnumerator Deactivate()
    {
    yield return new WaitForSeconds(lifeTime);
    OBJ.SetActive(false);
    }
}