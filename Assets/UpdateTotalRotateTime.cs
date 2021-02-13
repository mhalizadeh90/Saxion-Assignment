using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTotalRotateTime : MonoBehaviour
{
    Text rotateTimerText;
    float totalRotateMoveTime = 0;

    bool toStartCountingRotateTime = false;
    float timeCounter = 0;

    const float timeStep = 0.1f;

    void Awake()
    {
        rotateTimerText = GetComponent<Text>();
        rotateTimerText.text = "0";
    }

    void OnEnable()
    {
        InputManager.OnInputUpdate += updateTotalRotateMoveTimeText;
    }

    void updateTotalRotateMoveTimeText(bool isButtonHold)
    {
        toStartCountingRotateTime = isButtonHold;
    }

    void Update()
    {
        if(toStartCountingRotateTime)
        {
            timeCounter += Time.deltaTime;

            if(timeCounter >= timeStep)
            {
                totalRotateMoveTime += timeStep;
                timeCounter = 0;

                rotateTimerText.text = totalRotateMoveTime.ToString();
            }
        }
        else
        {
            timeCounter = 0;
        }
    }

    void OnDisable()
    {
        InputManager.OnInputUpdate -= updateTotalRotateMoveTimeText;
    }
}
