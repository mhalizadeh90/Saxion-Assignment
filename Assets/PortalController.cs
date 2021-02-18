using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] ParticleSystem teleportParticle;
    [SerializeField] Transform Destination;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(teleportParticle)    teleportParticle.Play();

        OnEnteringPortal?.Invoke(Destination.position);
    }

    public static Action<Vector2> OnEnteringPortal;
}
