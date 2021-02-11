using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitEffectEventTrigger : MonoBehaviour
{
    [SerializeField] Vector2Variable playerVelocity;
    [SerializeField] BoolVariable isGrounded;

    [SerializeField] float MaxHitVelocityToShowEffects = -10;

    bool isEffectCooldownTimePassed;
    const float coolDownEffectTime = 0.1f;
    WaitForSeconds cooldownEffectTimeDelay;

    void Awake()
    {
        isEffectCooldownTimePassed = true;
        cooldownEffectTimeDelay = new WaitForSeconds(coolDownEffectTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded.value) return;
        if (!isEffectCooldownTimePassed) return;
        if (!IsFallenVelocityFastEnoughtToShowEffects()) return;


        OnHitTheGroundEffect?.Invoke();
        StartCoroutine(StartCooldownEffect());
        print("To Create Effects. [Velocity] = "+ playerVelocity.value.y);
    }

    bool IsFallenVelocityFastEnoughtToShowEffects()
    {
        return (playerVelocity.value.y <= MaxHitVelocityToShowEffects);
    }

    IEnumerator StartCooldownEffect()
    {
        isEffectCooldownTimePassed = false;
        yield return cooldownEffectTimeDelay;
        isEffectCooldownTimePassed = true;
    }

    public static Action OnHitTheGroundEffect;
}
