using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTransformOnLooseEvent : MonoBehaviour
{
    Vector2 StartPosition;
    Vector3 StartRotation;
    void Awake()
    {
        StartPosition = transform.position;
        StartRotation = transform.rotation.eulerAngles;
    }

    void OnEnable()
    {
        SpikeCollisionEventTrigger.OnPlayerHitSpikes += ResetLocation;
    }

    void ResetLocation()
    {
        transform.position = StartPosition;
        transform.rotation = Quaternion.Euler(StartRotation);
    }

    void OnDisable()
    {
        SpikeCollisionEventTrigger.OnPlayerHitSpikes -= ResetLocation;
    }

}
