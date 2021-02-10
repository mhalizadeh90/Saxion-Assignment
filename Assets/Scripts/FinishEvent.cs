using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEvent : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnBallReachFinishPoint?.Invoke();
        print("Player Reached Finished");
    }

    public static Action OnBallReachFinishPoint;
}
