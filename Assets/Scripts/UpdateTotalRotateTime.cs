using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTotalRotateTime : MonoBehaviour
{
    [SerializeField] FloatVariable totalRotateMoveTime;
    bool toStartCountingRotateTime = false;

    void Awake()
    {
        totalRotateMoveTime.value = 0;
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
        if (toStartCountingRotateTime)
            totalRotateMoveTime.value += Time.deltaTime;
    }

    void OnDisable()
    {
        InputManager.OnInputUpdate -= updateTotalRotateMoveTimeText;
    }
}
