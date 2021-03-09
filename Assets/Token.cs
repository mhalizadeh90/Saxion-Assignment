using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Token : MonoBehaviour
{
    public int TokenIndex;
    public TokenNeighbour[] NeighborIndexes;
    Collider2D tokenCollider;

    void Awake()
    {
        tokenCollider = GetComponent<Collider2D>();
    }

    void OnEnable()
    {
        SpikeCollisionEventTrigger.OnPlayerHitSpikes += ResetColider;
    }
    void Start()
    {
        OnTokenStart?.Invoke(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnTokenActivated?.Invoke(this);
        TokenActivationEffects();
        tokenCollider.enabled = false;
    }

    void ResetColider()
    {
        tokenCollider.enabled = true;
    }

    void TokenActivationEffects()
    {
        //TODO: WORK ON SFX + PARTICLE + CHANGING TOKEN SPRITE + ANY JUICY STUFF
    }


    void OnDisable()
    {
        SpikeCollisionEventTrigger.OnPlayerHitSpikes -= ResetColider;
    }
    public static Action<Token> OnTokenActivated;
    public static Action<Token> OnTokenStart;

}
