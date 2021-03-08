using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalChangeSizer : MonoBehaviour
{
    [SerializeField] float NewScaleSize;
    [SerializeField] float RechargePortalTime = 2;
    Collider2D portalCollider;

    void Awake()
    {
        portalCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnSwitchSizePortalEnter?.Invoke(NewScaleSize);
        portalCollider.enabled = false;
        Invoke("ReChargePortal", RechargePortalTime);
    }

    void ReChargePortal()
    {
        portalCollider.enabled = true;
    }

    public static Action<float> OnSwitchSizePortalEnter;
}
