using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEvent : MonoBehaviour
{
    Collider2D finishCollider;
    SpriteRenderer finishSpriteRenderer;
    [SerializeField] Vector2Variable centerPosition;

    void Awake()
    {
        finishCollider = GetComponent<Collider2D>();
        finishSpriteRenderer = GetComponent<SpriteRenderer>();
        finishCollider.enabled = false;
        finishSpriteRenderer.enabled = false;
    }

    void OnEnable()
    {
        Orbitcreator.OnOrbitDrawn += EnableFinishLineActivationState;
        TokenManager.OnAllLineDrawn += EnableFinishLineActivationState;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnBallReachFinishPoint?.Invoke();
        print("Player Reached Finished");
    }

    void EnableFinishLineActivationState()
    {
        transform.position = centerPosition.value;
        finishCollider.enabled = true;
        finishSpriteRenderer.enabled = true;
        //TODO: SHOW ANY PARTICLE OR EFFECTS HERE
    }



    void OnDisable()
    {
        Orbitcreator.OnOrbitDrawn -= EnableFinishLineActivationState;
        TokenManager.OnAllLineDrawn -= EnableFinishLineActivationState;
    }
    public static Action OnBallReachFinishPoint;
}
