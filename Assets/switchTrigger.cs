using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SwitchID
{
    Switch1, Switch2, Switch3
}

public class switchTrigger : MonoBehaviour
{
    [SerializeField] SwitchID ID;
    [SerializeField] Lights SwitchLight;

    [SerializeField] bool isActiveOnDefault;
    SpriteRenderer spRenderer;

    void Awake()
    {
        spRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        SpikeCollisionEventTrigger.OnPlayerHitSpikes += InitializeSwitch;
    }

    void Start()
    {
        InitializeSwitch();
    }

    void InitializeSwitch()
    {
        if (isActiveOnDefault)
            ActiveSwitch();
        else
            DeActiveSwitch();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ActiveSwitch(); 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        DeActiveSwitch();
    }

    void ActiveSwitch()
    {
        OnSwitchActivatedChange?.Invoke(SwitchLight, ID, true);
        spRenderer.enabled = true;
    }

    void DeActiveSwitch()
    {
        OnSwitchActivatedChange?.Invoke(SwitchLight, ID, false);
        spRenderer.enabled = false;
    }


    void OnDisable()
    {
        SpikeCollisionEventTrigger.OnPlayerHitSpikes -= InitializeSwitch;
    }

    public static Action<Lights, SwitchID, bool> OnSwitchActivatedChange;
}
