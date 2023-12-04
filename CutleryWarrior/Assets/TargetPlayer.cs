using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public Transform Player;
    private GameObject ForkActive;
	private GameObject SpoonActive;
	private GameObject KnifeActive;
     private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    public float RunSpeed = 4f; // Velocità di movimento del personaggio
    public float TouchDistance = 1f;

    public void Update()
    {
        TargetPlayer_Function();
        ChasePlayer();
    }

    public void TargetPlayer_Function()
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
     private void ChasePlayer()
    {
        float distanceToTarget = Vector3.Distance(transform.position, Player.transform.position);
        float currentZPosition = transform.position.z;

        if (Player != null && distanceToTarget > TouchDistance)
        {transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, RunSpeed * Time.deltaTime);}
    }
}
