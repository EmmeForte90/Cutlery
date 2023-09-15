using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour {

	public GameObject player;
    public SwitchCharacter rotationSwitcher;
	public GameObject ForkActive;
	public GameObject SpoonActive;
	public GameObject KnifeActive;
	public void Awake(){StartCoroutine(CoordinateActor());}
	public void LateUpdate()
	{
		switch(rotationSwitcher.ConInt)
        {
            case 1:
			player.transform.position = ForkActive.transform.position;
            break;
            case 2:
			player.transform.position = KnifeActive.transform.position;
            break;
            case 3:
			player.transform.position = SpoonActive.transform.position;
            break;
        }
		Vector3 newPosition = player.transform.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;
		//transform.rotation = Quaternion.Euler(90f, player.transform.eulerAngles.y, 0f);
	}

	IEnumerator CoordinateActor()
    {  yield return new WaitForSeconds(0.2f);
	player.transform.position = ForkActive.transform.position;
	}
}