using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensor : MonoBehaviour
{
    [SerializeField] Lights SensorLight;

    [Header("Raycast Properties")]
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float raycastLength;
    [SerializeField] bool IsDebuggingEnabled = true;

    Vector2 raycastDirection;
    int PlayerLayerID;
    bool isSwitchTriggered = false;

    void Awake()
    {
        PlayerLayerID = GetLayerId(PlayerLayer.value);
    }

    private int GetLayerId(LayerMask layerMask)
    {
        int Counter = 0;
        int Result = 1;


        if (layerMask.value == 1)
        {
            Result = 0;
        }
        else
        {
            do
            {
                Result *= 2;
                Counter++;
            } while (Result < layerMask.value);
        }

        return Result;
    }

    void FixedUpdate()
    {
        raycastDirection = (endPoint.position - startPoint.position).normalized;

        if (IsDebuggingEnabled)
            Debug.DrawRay(startPoint.position, raycastDirection * raycastLength, Color.blue);

        bool isLightSensorHitPlayer = (Physics2D.Raycast(startPoint.position, raycastDirection, raycastLength, PlayerLayerID).collider != null);
        
        if (isLightSensorHitPlayer && !isSwitchTriggered)
        {
            OnLightSensorTriggered?.Invoke(SensorLight);
            print(SensorLight + " is activated.");
        }

        isSwitchTriggered = isLightSensorHitPlayer;

    }

    public static Action<Lights> OnLightSensorTriggered;
}

public enum Lights
{
    Blue, Red, Green
}

