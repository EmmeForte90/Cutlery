using UnityEngine;
using Cinemachine;

public class CambioFollow : MonoBehaviour
{
   private CinemachineVirtualCamera virtualCamera;
    private Transform originalFollowTarget;
    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;

    public Transform[] targets;
    public float transitionDuration = 2.0f;

    private int currentTargetIndex = 0;
    private float transitionTimer = 0.0f;
    private bool isTransitioning = false;

    void Start()
    {
        virtualCamera = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>();

        // Imposta la rotazione desiderata.
        virtualCamera.transform.rotation = Quaternion.Euler(18f, -90f, 0f);

        // Salva la posizione e la rotazione originali della camera.
        originalCameraPosition = virtualCamera.transform.position;
        originalCameraRotation = virtualCamera.transform.rotation;
    }

    void Update()
    {
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
        // Salva la posizione e la rotazione correnti della camera.
        originalCameraPosition = virtualCamera.transform.position;
        originalCameraRotation = virtualCamera.transform.rotation;

        // Imposta il follow su null per interrompere il tracking.
        virtualCamera.Follow = null;
        transitionTimer = 0.0f;
        isTransitioning = true;

        // Passa al successivo target nell'array.
        currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
    }

    public void ResetCamera()
    {
        // Ripristina la posizione e la rotazione originali della camera.
        virtualCamera.transform.position = originalCameraPosition;
        virtualCamera.transform.rotation = originalCameraRotation;
        // Imposta nuovamente il follow al target originale.
        virtualCamera.Follow = originalFollowTarget;
    }
}