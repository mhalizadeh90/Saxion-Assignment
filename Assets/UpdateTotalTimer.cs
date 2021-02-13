using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTotalTimer : MonoBehaviour
{
    bool toStopCounter = false;

    float timeCounter = 0;
    float delayCounter;
    Text timeText;

    const float timeStep = 1;

    void Awake()
    {
        timeText = GetComponent<Text>();
        timeText.text = "0";
    }

    void Update()
    {
        if (toStopCounter)
            return;

        delayCounter += Time.deltaTime;
        if(delayCounter >= timeStep)
        {
            timeCounter += timeStep;
            timeText.text = timeCounter.ToString();
            delayCounter = 0;
        }

    }
}
