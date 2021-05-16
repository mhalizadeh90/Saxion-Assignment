using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalChangeColorShape : MonoBehaviour
{
    [SerializeField] ShapeTypes NewShape;


    void OnTriggerEnter2D(Collider2D collision)
    {
        OnSwitchShapePortalEnter?.Invoke(NewShape);
    }

    public static Action<ShapeTypes> OnSwitchShapePortalEnter;
}
