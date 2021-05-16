using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultipleSwitchManager : MonoBehaviour
{
    [SerializeField] Lights ColorToSwitch;
    [SerializeField] List<SwitchID> SwitchIDKeys;

    [SerializeField]List<SwitchID> ActiveSwitches;

    void Awake()
    {
        ActiveSwitches = new List<SwitchID>();
    }

    void OnEnable()
    {
        switchTrigger.OnSwitchActivatedChange += ChangeSwitchActivation;
    }


    void ChangeSwitchActivation(Lights switchColor, SwitchID switchID, bool activationState)
    {
        if (switchColor != ColorToSwitch)
            return;

        if (activationState && (ActiveSwitches.IndexOf(switchID) < 0))
        {
            ActiveSwitches.Add(switchID);

            if (SwitchIDKeys.Count == ActiveSwitches.Count)
                OnAllSwitchesActivated?.Invoke(ColorToSwitch);
        }

        if (!activationState && (ActiveSwitches.IndexOf(switchID) >= 0))
        {
            ActiveSwitches.Remove(switchID);
            OnSwitchDiactivated?.Invoke(ColorToSwitch);
        }
    }

    void OnDisable()
    {
        switchTrigger.OnSwitchActivatedChange -= ChangeSwitchActivation;
    }

    public static Action<Lights> OnAllSwitchesActivated;
    public static Action<Lights> OnSwitchDiactivated;
}
