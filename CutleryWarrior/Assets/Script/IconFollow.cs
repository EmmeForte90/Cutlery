using System.Collections;
using UnityEngine;
public class IconFollow : MonoBehaviour
{
    [SerializeField] GameObject Ic;
    [SerializeField] GameObject Ch;

    private Transform MinimapCam;
	private float MinimapSize = 9f;
	private bool Take = false;
    public bool important = false;
	private Vector3 TempV3;
    private Vector3 icPosition;
    private Vector3 chPosition;
    public  void Awake(){StartCoroutine(FindMinimap());}
    private IEnumerator FindMinimap()
    {
        yield return new WaitForSeconds(1);
		MinimapCam = GameManager.instance.Minimap.transform;
		Take = true;
    }
    public void Update()
    {
        if(Take){
        if(!important){
        icPosition = Ic.transform.position; // Get the current position of the Ic GameObject
        chPosition = Ch.transform.position; // Get the current position of the Ch GameObject

        // Set the position of Ic to match Ch on the X and Z axes, while keeping its Y position intact
        icPosition.x = chPosition.x;
        icPosition.z = chPosition.z;

        Ic.transform.position = icPosition; // Apply the updated position to the Ic GameObject
        } 
        else if(important)
        {
		TempV3.x = Ch.transform.position.x;
		TempV3.z = Ch.transform.position.z;
        TempV3.y = Ic.transform.position.y;
		transform.position = TempV3;
        }}
    }

    
	public void LateUpdate () 
    {
		if(Take){
            if(important)
        {
		transform.position = new Vector3 (
		Mathf.Clamp(transform.position.x, MinimapCam.position.x-MinimapSize, MinimapSize+MinimapCam.position.x),
		transform.position.y,
		Mathf.Clamp(transform.position.z, MinimapCam.position.z-MinimapSize, MinimapSize+MinimapCam.position.z)
		);
	}}
    }
}