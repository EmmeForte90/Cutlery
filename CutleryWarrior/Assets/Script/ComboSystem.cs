using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ComboSystem : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    private int comboCount = 0;
    private bool canAttack = true;
    public float comboCooldown = 1.0f; // Tempo di cooldown tra le combo in secondi

    private void Update()
    {
        if (canAttack && Input.GetMouseButtonDown(1)) // Sostituisci "Fire1" con il tuo input desiderato
        {
            comboCount = (comboCount % 3) + 1;
            PlayComboAnimation("Battle/attack_" + comboCount.ToString());
            canAttack = false;
            StartCoroutine(ComboCooldown());
        }
    }

    private void PlayComboAnimation(string animationName)
    {
        if (skeletonAnimation != null)
        {
            skeletonAnimation.AnimationState.SetAnimation(0, animationName, false);
            // Assicurati che "Attack1", "Attack2", ecc. siano i nomi delle tue animazioni in Spine.
        }
    }

    private IEnumerator ComboCooldown()
    {
        yield return new WaitForSeconds(comboCooldown);
        canAttack = true;
    }
}