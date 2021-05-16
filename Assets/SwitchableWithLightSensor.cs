using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OpenState { Open, Close }

public class SwitchableWithLightSensor : MonoBehaviour
{
    [SerializeField] Lights Light;
    [SerializeField] OpenState DefaultState;
    OpenState currentSwitchState;
    Collider2D itemCollider;
    DissolveController dissolveController;

    void Awake()
    {
        currentSwitchState = DefaultState;
        itemCollider = GetComponent<Collider2D>();
        dissolveController = GetComponent<DissolveController>();

        InitializeDoorState();
    }

    private void InitializeDoorState()
    {
        if (DefaultState == OpenState.Open)
            Open();
        else if (DefaultState == OpenState.Close)
            Close();
    }

    void OnEnable()
    {
        LightSensor.OnLightSensorTriggered += ChangeSwitchState;
        SpikeCollisionEventTrigger.OnPlayerHitSpikes += InitializeDoorState;
        MultipleSwitchManager.OnAllSwitchesActivated += OpenSwitchState;
        MultipleSwitchManager.OnSwitchDiactivated += CloseSwitchState;
        MagnetSwitch.OnFullyCharged += OpenSwitchState;
        MagnetSwitch.OnFullyDeCharged += CloseSwitchState;

    }



    void ChangeSwitchState(Lights light)
    {
        if (light != Light)
            return;

        if (currentSwitchState == OpenState.Open)
        {
            Close();
            //TODO: SFX & EFFECTS FOR DISABLING DOOR OR TRAP
        }
        else if (currentSwitchState == OpenState.Close)
        {
            Open();
            //TODO: SFX & EFFECTS FOR ENABLING DOOR OR TRAP
        }
    }

    void OpenSwitchState(Lights light)
    {
        if (light == Light)     Open();
    }

    void CloseSwitchState(Lights light)
    {
        if (light == Light) Close();
    }

    void Open()
    {
       // print("Open State");
        itemCollider.enabled = false;
        currentSwitchState = OpenState.Open;
        dissolveController.isDissolving = true;

    }

    void Close()
    {
       // print("Close State");
        itemCollider.enabled = true;
        currentSwitchState = OpenState.Close;
        dissolveController.isDissolving = false;
    }

    void OnDisable()
    {
        LightSensor.OnLightSensorTriggered -= ChangeSwitchState;
        SpikeCollisionEventTrigger.OnPlayerHitSpikes -= InitializeDoorState;
        MultipleSwitchManager.OnAllSwitchesActivated -= OpenSwitchState;
        MultipleSwitchManager.OnSwitchDiactivated -= CloseSwitchState;
        MagnetSwitch.OnFullyCharged -= OpenSwitchState;
        MagnetSwitch.OnFullyDeCharged -= CloseSwitchState;
    }
}
