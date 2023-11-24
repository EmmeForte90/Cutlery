using System.Collections;
using UnityEngine;

public class HideObj : MonoBehaviour
{
    public GameObject VFX;
    public float lifeTime = 1f;

    public void OnEnable(){StartCoroutine(PlayCombo());}
    private IEnumerator PlayCombo()
    {
        yield return new WaitForSeconds(lifeTime);
        VFX.SetActive(false);
    }
}