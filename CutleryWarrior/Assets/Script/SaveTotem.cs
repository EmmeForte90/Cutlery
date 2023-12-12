using UnityEngine;

public class SaveTotem : MonoBehaviour
{
    public GameObject savedPosition;
    public string NameScene;
    public int IDSpawn;
    public GameObject VFXTake;
    public GameObject LoadVFX;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    private SaveManager Save;
    private bool isSave = true;
    public void Start()
        {
        if(GameManager.instance.F_Unlock){Fork = GameManager.instance.F_Hero.transform;}
        if(GameManager.instance.S_Unlock){Spoon = GameManager.instance.S_Hero.transform;}
        if(GameManager.instance.K_Unlock){Knife = GameManager.instance.K_Hero.transform;}
        }
    public void Update()
    {
    if (Save == null && isSave)
    {Save = GameObject.FindGameObjectWithTag("Save").GetComponent<SaveManager>(); isSave = false;} 
    Chose();
    }

    public void Chose()
    {
        switch(GameManager.instance.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock)
            {
                Fork = GameManager.instance.F_Hero.transform;
                Player = GameManager.instance.F_Hero.transform;
            }
            Player = Fork.transform;
            break;
            case 2:
            if(GameManager.instance.K_Unlock)
            {
                Knife = GameManager.instance.K_Hero.transform;
                Player = GameManager.instance.K_Hero.transform; 
            }  
            Player = Knife.transform;
            break;
            case 3:
            if(GameManager.instance.S_Unlock)
            {
                Spoon = GameManager.instance.S_Hero.transform;
                Player = GameManager.instance.S_Hero.transform;
            }
            Player = Spoon.transform;
            break;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
    if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
    {      
        Instantiate(VFXTake, transform.position, transform.rotation);
        AudioManager.instance.PlaySFX(12);
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
        
        //savedPosition.transform.position = Player.transform.position; 
        GameManager.instance.savedPosition = savedPosition.transform.position;
        
        PlayerStats.instance.savedPosition = savedPosition.transform.position;
        PlayerStats.instance.HaveData = true;
        PlayerStats.instance.NameScene = NameScene;
        PlayerStats.instance.IdSpawn = IDSpawn;
        PlayerStats.instance.UpdateInventorySaving();
        Save.SaveGame();
        LoadVFX.SetActive(true);
        Invoke("EndingLoad", 5);
        print("Hai salvato");
    }
    }
    public void EndingLoad(){LoadVFX.SetActive(false);}

    /*public void Saving()
    {
            Save.SaveGame
            (
            PlayerStats.instance.questDatabase,
            PlayerStats.instance.I_itemList,
            PlayerStats.instance.I_quantityList,
            PlayerStats.instance.IBattle_itemList,
            PlayerStats.instance.IBattle_quantityList,
            PlayerStats.instance.F_itemList,
            PlayerStats.instance.F_quantityList,
            PlayerStats.instance.S_itemList,
            PlayerStats.instance.S_quantityList,
            PlayerStats.instance.K_itemList,
            PlayerStats.instance.K_quantityList,
            PlayerStats.instance.Key_itemList,
            PlayerStats.instance.Key_quantityList,
            PlayerStats.instance.Quest_itemList,
            PlayerStats.instance.Quest_quantityList
            );

    }*/
}