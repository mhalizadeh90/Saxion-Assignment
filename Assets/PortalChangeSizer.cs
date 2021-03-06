using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalChangeSizer : MonoBehaviour
{
    [SerializeField] float NewScaleSize;
    void OnTriggerEnter2D(Collider2D collision)
    {
        OnSwitchSizePortalEnter?.Invoke(NewScaleSize);
    }

    public static Action<float> OnSwitchSizePortalEnter;
}
