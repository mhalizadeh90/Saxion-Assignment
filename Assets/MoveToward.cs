using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    [SerializeField] bool EnableOnStart = true;
    [SerializeField] Transform Destination;
    [SerializeField] float MoveSpeed;
    Vector2 DestinationPosition;

    void Awake()
    {
        DestinationPosition = Destination.localPosition;
    }

    void Start()
    {
        if (EnableOnStart)
            MoveTowardDestination();
    }

    void MoveTowardDestination()
    {
        StartCoroutine(moveToward());
    }

    IEnumerator moveToward()
    {
        OnDoorIsLocked?.Invoke();

        while (Vector2.Distance(transform.localPosition, DestinationPosition)>0.01f)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, DestinationPosition, Time.deltaTime * MoveSpeed);
            yield return null;
        }

        transform.localPosition = DestinationPosition;
    }

    public static Action OnDoorIsLocked;
}
