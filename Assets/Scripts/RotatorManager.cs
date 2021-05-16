using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorManager : MonoBehaviour
{

    bool toCheckForRotation = false;
    [SerializeField] float RotationSpeed = 1;
    [SerializeField] FloatVariable InputValue;
    Vector3 RotationAxis = new Vector3(0, 0, 1);

    void OnEnable()
    {
        InputManager.OnInputUpdate += SetRotateState;
    }

    void Update()
    {
        if(toCheckForRotation)
        {
            transform.Rotate(RotationAxis * InputValue.value * RotationSpeed * Time.deltaTime );
        }
    }

    void SetRotateState(bool checkState)
    {
        toCheckForRotation = checkState;
    }

    void OnDisable()
    {
        InputManager.OnInputUpdate -= SetRotateState;
    }


}
