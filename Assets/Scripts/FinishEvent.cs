using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEvent : MonoBehaviour
{
    Collider2D finishCollider;
    SpriteRenderer finishSpriteRenderer;

    void Awake()
    {
        finishCollider = GetComponent<Collider2D>();
        finishSpriteRenderer = GetComponent<SpriteRenderer>();
        finishCollider.enabled = false;
        finishSpriteRenderer.enabled = false;
    }

    void OnEnable()
    {
        TokenManager.OnAllTokensActivated += EnableFinishLineActivationState;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnBallReachFinishPoint?.Invoke();
        print("Player Reached Finished");
    }

    void EnableFinishLineActivationState()
    {
        finishCollider.enabled = true;
        finishSpriteRenderer.enabled = true;
        //TODO: SHOW ANY PARTICLE OR EFFECTS HERE
    }



    void OnDisable()
    {
        TokenManager.OnAllTokensActivated -= EnableFinishLineActivationState;
    }
    public static Action OnBallReachFinishPoint;
}
