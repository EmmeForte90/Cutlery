using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    private GameObject player;
    public GameObject FAct;
    public GameObject KAct;
    public GameObject SAct;    
    public GameObject[] SpawnArr;    
    private int IDPorta;
public static StartScene instance;
void Awake()
{        
    if (instance == null){instance = this;}   
    if(!GameManager.instance.StartGame){   
    player = GameObject.FindWithTag("Player");
    IDPorta = GameManager.instance.IDPorta;
    Spawn(IDPorta);
    CharacterMove.instance.inputCTR = false; 
    GameManager.instance.FadeOut();}
}
   
    public void Spawn(int ID)
    {
        player.transform.position = SpawnArr[ID].transform.position;
        KAct.transform.position = SpawnArr[ID].transform.position;
        FAct.transform.position = SpawnArr[ID].transform.position;
        SAct.transform.position = SpawnArr[ID].transform.position;    
        }
   
}
