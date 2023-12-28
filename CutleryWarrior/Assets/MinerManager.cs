using UnityEngine;

public class MinerManager : MonoBehaviour
{
    public GameObject Door;
    public GameObject MainFire;
    public GameObject Fire_1, Fire_2, Fire_3, Fire_4;
    public Animator Door_L;
    public Animator Door_R;
    public GameObject[] DeactivateOBJAfterBoss;

    public void Update()
    {
        if(PlayerStats.instance.SwitchMiniera == 1){Fire_1.SetActive(true);}
        if(PlayerStats.instance.SwitchMiniera == 2){Fire_2.SetActive(true);}
        if(PlayerStats.instance.SwitchMiniera == 3){Fire_3.SetActive(true);}
        if(PlayerStats.instance.SwitchMiniera == 4)
        {
            Fire_4.SetActive(true);
            MainFire.SetActive(true);
            Door_L.Play("Door_L");
            Door_R.Play("Door_R");
        }
        if(PlayerStats.instance.MinerBoss)
        {foreach (GameObject arenaObjectN in DeactivateOBJAfterBoss){arenaObjectN.SetActive(false);}}
    }
}