using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTotalRotateMove : MonoBehaviour
{
    Text moveText;
    int totalRotateMove = 0;
    void Awake()
    {
        moveText = GetComponent<Text>();
        moveText.text = "0";
    }

    void OnEnable()
    {
        InputManager.OnInputUpdate += updateTotalRotateMoveText;
    }

    void updateTotalRotateMoveText(bool isButtonHold)
    {
        if (!isButtonHold)
            return;

        print("Move Count");
        totalRotateMove++;
        moveText.text = totalRotateMove.ToString();
    }

    void OnDisable()
    {
        InputManager.OnInputUpdate -= updateTotalRotateMoveText;
    }
}
