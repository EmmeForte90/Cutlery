using UnityEngine;
public class StayInside : MonoBehaviour
{
    public Transform MinimapCam;
	public float MinimapSize;
	Vector3 TempV3;
    public  void Awake() {MinimapCam = GameObject.FindGameObjectWithTag("Minimap").transform;}
	public void Update () {
		TempV3 = transform.parent.transform.position;
		TempV3.y = transform.position.y;
		transform.position = TempV3;
	}
	public void LateUpdate () {
		transform.position = new Vector3 (
			Mathf.Clamp(transform.position.x, MinimapCam.position.x-MinimapSize, MinimapSize+MinimapCam.position.x),
			transform.position.y,
			Mathf.Clamp(transform.position.z, MinimapCam.position.z-MinimapSize, MinimapSize+MinimapCam.position.z)
		);
	}
}