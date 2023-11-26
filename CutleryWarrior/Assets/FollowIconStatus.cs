using UnityEngine;
public class FollowIconStatus : MonoBehaviour
{
    public GameObject Icon;
	public GameObject Character;
    void Update()
    {Icon.transform.position = new Vector3(Character.transform.position.x, Icon.transform.position.y, Character.transform.position.z);}
}