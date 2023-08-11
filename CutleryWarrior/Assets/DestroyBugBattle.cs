using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBugBattle : MonoBehaviour
{
    private DuelManager DM;
    public void Start()
    {DM = GameObject.Find("Script").GetComponent<DuelManager>();
    DM.EnemyinArena -= 1; Destroy(gameObject);}
}