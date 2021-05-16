using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTotalRotateMove : MonoBehaviour
{
    [SerializeField] FloatVariable totalRotateMove;


    void Awake()
    {
        totalRotateMove.value = 0;
    }
    void OnEnable()
    {
        InputManager.OnInputUpdate += updateTotalRotateMoveText;
    }

    void updateTotalRotateMoveText(bool isButtonHold)
    {
        if (!isButtonHold)
            return;

        totalRotateMove.value++;
    }

    void OnDisable()
    {
        InputManager.OnInputUpdate -= updateTotalRotateMoveText;
    }
}
