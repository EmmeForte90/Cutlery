using UnityEngine;
using Cinemachine;

public class CambioFollow : MonoBehaviour
{
   private CinemachineVirtualCamera virtualCamera;
    public Transform[] targets;
    public float transitionDuration = 2.0f;

    private int currentTargetIndex = 0;
    private float transitionTimer = 0.0f;
    private bool isTransitioning = false;

    void Start()
    {virtualCamera = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>();}

    void Update()
    {
        // Puoi chiamare questa funzione da un altro script o evento per iniziare la transizione.
        /*if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire1") && !isTransitioning)
        {
            StartTransition();
        }*/

         if (isTransitioning)
        {
            transitionTimer += Time.deltaTime;

            float t = Mathf.Clamp01(transitionTimer / transitionDuration);
            virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, targets[currentTargetIndex].position, t);
            virtualCamera.transform.rotation = Quaternion.Slerp(virtualCamera.transform.rotation, targets[currentTargetIndex].rotation, t);

            if (t >= 1.0f)
            {
                isTransitioning = false;
            }
        }
    }

    public void StartTransition()
    {
        virtualCamera.Follow = null;
        transitionTimer = 0.0f;
        isTransitioning = true;

        // Passa al successivo target nell'array.
        currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
    }
}