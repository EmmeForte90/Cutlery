using System.Collections;
using UnityEngine;
using Spine.Unity;


public class KnockbackController : MonoBehaviour
{
    /*public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;
    private bool stopKnock = false;
    public AnimationManager Anm;
    [SpineAnimation][SerializeField] string knockbackAnimationName;
    [SpineAnimation][SerializeField] string upKnockbackAnimationName;

    private Vector3 moveDirection;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;

        if (!stopKnock)
        {
            ApplyKnockback(moveDirection);
        }

        StartCoroutine(EndKnock());
    }

    public void ApplyKnockback(Vector3 direction)
    {
        // Avvia la coroutine per applicare il knockback con la durata specificata
        StartCoroutine(KnockbackRoutine(direction));
    }

    private IEnumerator KnockbackRoutine(Vector3 direction)
    {
        // Normalizza la direzione per ottenere una forza costante
        direction.Normalize();

        Anm.PlayAnimationLoop(knockbackAnimationName);

        // Calcola la velocità di knockback
        moveDirection = -direction * knockbackForce;

        // Attendi per la durata del knockback
        yield return new WaitForSeconds(knockbackDuration);

        // Ripristina la velocità del personaggio
        moveDirection = Vector3.zero;

        // Ferma l'animazione di knockback
        Anm.PlayAnimation(upKnockbackAnimationName);

        stopKnock = true;
    }

    private IEnumerator EndKnock()
    {
        yield return new WaitForSeconds(knockbackDuration + 1f);

        // Ripristina lo stato di knockback
        stopKnock = false;

        // Esegui altre azioni se necessario
        GameManager.instance.StopWin();
    }

    private void Update()
    {
        // Muovi il personaggio usando il Character Controller
        characterController.Move(moveDirection * Time.deltaTime);
    }*/
}