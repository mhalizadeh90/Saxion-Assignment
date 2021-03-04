using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollisionEventTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem ParticleSystem;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (ParticleSystem)
        {
            ParticleSystem.transform.position = collision.transform.position;
            ParticleSystem.Play();
        }
        OnPlayerHitSpikes?.Invoke();
    }

    public static Action OnPlayerHitSpikes;
}
