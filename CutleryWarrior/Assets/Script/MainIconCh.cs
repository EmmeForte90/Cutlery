using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainIconCh : MonoBehaviour
{
    public Transform MinimapCam;
	private float MinimapSize = 9f;
	private bool Take = false;
	Vector3 TempV3;
    public  void Awake(){StartCoroutine(FindMinimap());}

	private IEnumerator FindMinimap()
    {
        yield return new WaitForSeconds(2f);
		Take = true;
    }
	public void Update () {
		if(Take){
		TempV3 = transform.parent.transform.position;
		TempV3.y = transform.position.y;
		transform.position = TempV3;}
	}
	public void LateUpdate () {
		if(Take){
		transform.position = new Vector3 (
		Mathf.Clamp(transform.position.x, MinimapCam.position.x-MinimapSize, MinimapSize+MinimapCam.position.x),
		transform.position.y,
		Mathf.Clamp(transform.position.z, MinimapCam.position.z-MinimapSize, MinimapSize+MinimapCam.position.z)
		);
	}}
}