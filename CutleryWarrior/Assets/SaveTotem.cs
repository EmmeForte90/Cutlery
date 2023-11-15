using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTotem : MonoBehaviour
{
    public Vector3 savedPosition;
    public string NameScene;
    private SwitchCharacter Switch;
    //private PlayerStats Dati;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    public void Start()
        {
        if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
        //if (Dati == null) {Dati = GameObject.Find("Stats").GetComponent<PlayerStats>();} 
        if(GameManager.instance.F_Unlock){Fork = GameObject.Find("F_Player").transform;}
        if(GameManager.instance.S_Unlock){Spoon = GameObject.Find("S_Player").transform;}
        if(GameManager.instance.K_Unlock){Knife = GameObject.Find("K_Player").transform;}
        }
    public void Update()
    {
    if(Switch.isElement1Active){Player = Spoon;}
    else if(Switch.isElement2Active){Player = Fork;} 
    else if(Switch.isElement3Active){Player = Knife;} 
    }

    private void OnTriggerEnter(Collider collision)
    {
    if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
    {            
        if(GameManager.instance.F_Unlock){
        PlayerStats.instance.F_curHP = PlayerStats.instance.F_HP;
        PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        //
        if(GameManager.instance.K_Unlock){
        PlayerStats.instance.K_curHP = PlayerStats.instance.K_HP;
        PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        //
        if(GameManager.instance.S_Unlock){
        PlayerStats.instance.S_curHP = PlayerStats.instance.S_HP;
        PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}
        
        savedPosition = Player.transform.position; 
        GameManager.instance.savedPosition = savedPosition;
        PlayerStats.instance.savedPosition = savedPosition;
        PlayerStats.instance.HaveData = true;
        PlayerStats.instance.NameScene = NameScene;
        PlayerStats.instance.UpdateInventorySaving();
        //SaveManager.instance.SalvaDati(Dati);
        print("Hai salvato");
    }
    }
}