using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTotalTimer : MonoBehaviour
{
    bool toStopCounter = false;
    [SerializeField] FloatVariable timeCounter;

    void Awake()
    {
        timeCounter.value = 0;
    }

    void OnEnable()
    {
        FinishEvent.OnBallReachFinishPoint += StopCounter;
    }

    void Update()
    {
        if (toStopCounter)
            return;

        timeCounter.value += Time.deltaTime;
    }

    void StopCounter()
    {
        toStopCounter = true;
    }


    void OnDisable()
    {
        FinishEvent.OnBallReachFinishPoint -= StopCounter;
    }
}
