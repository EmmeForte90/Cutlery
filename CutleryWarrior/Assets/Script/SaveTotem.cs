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
        if(GameManager.instance.F_Unlock)
        {
            PlayerStats.instance.ResetStatF();
            if(PlayerStats.instance.Skill_F[0]){PlayerStats.instance.Skill_F_0.Utilizzi = PlayerStats.instance.Skill_F_0.UtilizziMAX;}
            if(PlayerStats.instance.Skill_F[1]){PlayerStats.instance.Skill_F_1.Utilizzi = PlayerStats.instance.Skill_F_1.UtilizziMAX;}
            if(PlayerStats.instance.Skill_F[2]){PlayerStats.instance.Skill_F_2.Utilizzi = PlayerStats.instance.Skill_F_2.UtilizziMAX;}
            if(PlayerStats.instance.Skill_F[3]){PlayerStats.instance.Skill_F_3.Utilizzi = PlayerStats.instance.Skill_F_3.UtilizziMAX;}
            if(PlayerStats.instance.Skill_F[4]){PlayerStats.instance.Skill_F_4.Utilizzi = PlayerStats.instance.Skill_F_4.UtilizziMAX;}
            if(PlayerStats.instance.Skill_F[5]){PlayerStats.instance.Skill_F_5.Utilizzi = PlayerStats.instance.Skill_F_5.UtilizziMAX;}
            if(PlayerStats.instance.Skill_F[6]){PlayerStats.instance.Skill_F_6.Utilizzi = PlayerStats.instance.Skill_F_6.UtilizziMAX;}
            if(PlayerStats.instance.Skill_F[7]){PlayerStats.instance.Skill_F_7.Utilizzi = PlayerStats.instance.Skill_F_7.UtilizziMAX;}
            if(PlayerStats.instance.Skill_F[8]){PlayerStats.instance.Skill_F_8.Utilizzi = PlayerStats.instance.Skill_F_8.UtilizziMAX;}
        }
        if(GameManager.instance.K_Unlock)
        {
            PlayerStats.instance.ResetStatK();
            if(PlayerStats.instance.Skill_K[0]){PlayerStats.instance.Skill_K_0.Utilizzi = PlayerStats.instance.Skill_K_0.UtilizziMAX;}
            if(PlayerStats.instance.Skill_K[1]){PlayerStats.instance.Skill_K_1.Utilizzi = PlayerStats.instance.Skill_K_1.UtilizziMAX;}
            if(PlayerStats.instance.Skill_K[2]){PlayerStats.instance.Skill_K_2.Utilizzi = PlayerStats.instance.Skill_K_2.UtilizziMAX;}
            if(PlayerStats.instance.Skill_K[3]){PlayerStats.instance.Skill_K_3.Utilizzi = PlayerStats.instance.Skill_K_3.UtilizziMAX;}
            if(PlayerStats.instance.Skill_K[4]){PlayerStats.instance.Skill_K_4.Utilizzi = PlayerStats.instance.Skill_K_4.UtilizziMAX;}
            if(PlayerStats.instance.Skill_K[5]){PlayerStats.instance.Skill_K_5.Utilizzi = PlayerStats.instance.Skill_K_5.UtilizziMAX;}
            if(PlayerStats.instance.Skill_K[6]){PlayerStats.instance.Skill_K_6.Utilizzi = PlayerStats.instance.Skill_K_6.UtilizziMAX;}
            if(PlayerStats.instance.Skill_K[7]){PlayerStats.instance.Skill_K_7.Utilizzi = PlayerStats.instance.Skill_K_7.UtilizziMAX;}
            if(PlayerStats.instance.Skill_K[8]){PlayerStats.instance.Skill_K_8.Utilizzi = PlayerStats.instance.Skill_K_8.UtilizziMAX;}
        }
        if(GameManager.instance.S_Unlock)
        {
            PlayerStats.instance.ResetStatS();
            if(PlayerStats.instance.Skill_S[0]){PlayerStats.instance.Skill_S_0.Utilizzi = PlayerStats.instance.Skill_S_0.UtilizziMAX;}
            if(PlayerStats.instance.Skill_S[1]){PlayerStats.instance.Skill_S_1.Utilizzi = PlayerStats.instance.Skill_S_1.UtilizziMAX;}
            if(PlayerStats.instance.Skill_S[2]){PlayerStats.instance.Skill_S_2.Utilizzi = PlayerStats.instance.Skill_S_2.UtilizziMAX;}
            if(PlayerStats.instance.Skill_S[3]){PlayerStats.instance.Skill_S_3.Utilizzi = PlayerStats.instance.Skill_S_3.UtilizziMAX;}
            if(PlayerStats.instance.Skill_S[4]){PlayerStats.instance.Skill_S_4.Utilizzi = PlayerStats.instance.Skill_S_4.UtilizziMAX;}
            if(PlayerStats.instance.Skill_S[5]){PlayerStats.instance.Skill_S_5.Utilizzi = PlayerStats.instance.Skill_S_5.UtilizziMAX;}
            if(PlayerStats.instance.Skill_S[6]){PlayerStats.instance.Skill_S_6.Utilizzi = PlayerStats.instance.Skill_S_6.UtilizziMAX;}
            if(PlayerStats.instance.Skill_S[7]){PlayerStats.instance.Skill_S_7.Utilizzi = PlayerStats.instance.Skill_S_7.UtilizziMAX;}
            if(PlayerStats.instance.Skill_S[8]){PlayerStats.instance.Skill_S_8.Utilizzi = PlayerStats.instance.Skill_S_8.UtilizziMAX;}
        }

        Save.SaveGame();
        LoadVFX.SetActive(true);
        Invoke("EndingLoad", 5);
        print("Hai salvato");
    }
    }
    public void EndingLoad(){LoadVFX.SetActive(false);}

}