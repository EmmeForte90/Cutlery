using UnityEngine;

public class MinerManager : MonoBehaviour
{
    public GameObject Door;
    public GameObject MainFire;
    public Animator Door_L;
    public Animator Door_R;
    public GameObject[] DeactivateOBJAfterBoss;

    public void Update()
    {
        if(PlayerStats.instance.SwitchMiniera == 4)
        {
            MainFire.SetActive(true);
            Door_L.Play("Door_L");
            Door_R.Play("Door_R");
        }
        if(PlayerStats.instance.MinerBoss){foreach (GameObject arenaObjectN in DeactivateOBJAfterBoss){arenaObjectN.SetActive(false);}}
    }
}