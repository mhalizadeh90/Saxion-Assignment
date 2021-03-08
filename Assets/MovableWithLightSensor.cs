using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWithLightSensor : MonoBehaviour
{
    [SerializeField] Lights Light;
    [SerializeField] OpenState DefaultState;
    [SerializeField] Transform OpenPosition;
    [SerializeField] Transform ClosePosition;

    OpenState currentPositionState;

    void Awake()
    {
        currentPositionState = DefaultState;

        InitializeDoorState();
    }

    void OnEnable()
    {
        LightSensor.OnLightSensorTriggered += ChangeSwitchState;
        SpikeCollisionEventTrigger.OnPlayerHitSpikes += InitializeDoorState;
    }

    private void InitializeDoorState()
    {
        if (DefaultState == OpenState.Open)
            Open();
        else if (DefaultState == OpenState.Close)
            Close();
    }


    void Open()
    {
        // print("Open State");
        transform.position = OpenPosition.position;
        currentPositionState = OpenState.Open;
    }

    void Close()
    {
        // print("Close State");
        transform.position = ClosePosition.position;
        currentPositionState = OpenState.Close;
    }

    void ChangeSwitchState(Lights light)
    {
        if (light != Light)
            return;

        if (currentPositionState == OpenState.Open)
        {
            Close();
            //TODO: SFX & EFFECTS FOR CLOSING DOOR 
        }
        else if (currentPositionState == OpenState.Close)
        {
            Open();
            //TODO: SFX & EFFECTS FOR OPENING DOOR 
        }
    }

    void OnDisable()
    {
        LightSensor.OnLightSensorTriggered -= ChangeSwitchState;
        SpikeCollisionEventTrigger.OnPlayerHitSpikes -= InitializeDoorState;
    }
}
