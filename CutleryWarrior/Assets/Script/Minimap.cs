using System.Collections;
using UnityEngine;

public class Minimap : MonoBehaviour {

	public GameObject player;
    //public SwitchCharacter rotationSwitcher;
	public GameObject ForkActive;
	public GameObject SpoonActive;
	public GameObject KnifeActive;
	public GameManager GM;
    public Camera unityCamera; // La camera di Unity
	public void Update()
{
    switch (GM.CharacterID)
    {
        case 1:
            player.transform.position = ForkActive.transform.position;
            unityCamera.transform.position = new Vector3(player.transform.position.x, unityCamera.transform.position.y, player.transform.position.z);
            break;
        case 2:
            player.transform.position = KnifeActive.transform.position;
            unityCamera.transform.position = new Vector3(player.transform.position.x, unityCamera.transform.position.y, player.transform.position.z);
            break;
        case 3:
            player.transform.position = SpoonActive.transform.position;
            unityCamera.transform.position = new Vector3(player.transform.position.x, unityCamera.transform.position.y, player.transform.position.z);
            break;
    }

    Vector3 newPosition = player.transform.position;
    newPosition.y = transform.position.y;
    transform.position = newPosition;
    //transform.rotation = Quaternion.Euler(90f, player.transform.eulerAngles.y, 0f);
}
}