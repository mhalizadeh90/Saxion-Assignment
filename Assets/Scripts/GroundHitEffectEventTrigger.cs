using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitEffectEventTrigger : MonoBehaviour
{
    [SerializeField] Vector2Variable playerVelocity;

    [SerializeField] float MaxHitVelocityToShowEffects = -10;

    [SerializeField]bool isEffectCooldownTimePassed;
    const float coolDownEffectTime = 0.1f;
    WaitForSeconds cooldownEffectTimeDelay;
    Vector2 LastVelocity;

    void Awake()
    {
        isEffectCooldownTimePassed = true;
        cooldownEffectTimeDelay = new WaitForSeconds(coolDownEffectTime);
    }

    void Start()
    {
        LastVelocity = playerVelocity.value;
    }

    void FixedUpdate()
    {
        if (!isEffectCooldownTimePassed) return;
        if (!IsWallHitVelocityFastEnoughtToShowEffects()) return;

        OnHitTheGroundEffect?.Invoke();
        StartCoroutine(StartCooldownEffect());
        //print("To Create Effects. [Velocity] = " + playerVelocity.value.y);
    }

    bool IsWallHitVelocityFastEnoughtToShowEffects()
    {
        bool result = Vector2.Distance(LastVelocity, playerVelocity.value) >= MaxHitVelocityToShowEffects;
        LastVelocity = playerVelocity.value;
        return result;
    }

    IEnumerator StartCooldownEffect()
    {
        isEffectCooldownTimePassed = false;
        yield return cooldownEffectTimeDelay;
        isEffectCooldownTimePassed = true;
    }

    public static Action OnHitTheGroundEffect;
}
