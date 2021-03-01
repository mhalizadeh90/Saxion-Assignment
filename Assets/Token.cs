using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Token : MonoBehaviour
{
    public int TokenIndex;
    public int[] NeighborIndexes;
    Collider2D tokenCollider;

    void Awake()
    {
        tokenCollider = GetComponent<Collider2D>();
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

    void TokenActivationEffects()
    {
        //TODO: WORK ON SFX + PARTICLE + CHANGING TOKEN SPRITE + ANY JUICY STUFF
        print("To Show Token Activation Effects");
    }

    public static Action<Token> OnTokenActivated;
    public static Action<Token> OnTokenStart;

}
