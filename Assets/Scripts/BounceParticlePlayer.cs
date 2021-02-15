using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceParticlePlayer : MonoBehaviour
{
    ParticleSystem bounceParticle;

    void Awake()
    {
        bounceParticle = GetComponent<ParticleSystem>();
    }

    void OnEnable()
    {
        GroundHitEffectEventTrigger.OnHitTheGroundEffect += PlayParticle;
    }

    void PlayParticle()
    {
        bounceParticle.Play();
    }

    void OnDisable()
    {
        GroundHitEffectEventTrigger.OnHitTheGroundEffect -= PlayParticle;
    }
}
