using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSizability : MonoBehaviour
{
    Vector3 defaultScale;
    bool isScaled = false;

    void Awake()
    {
        defaultScale = transform.localScale;
    }

    void OnEnable()
    {
        PortalChangeSizer.OnSwitchSizePortalEnter += ChangeScale;
        SpikeCollisionEventTrigger.OnPlayerHitSpikes += DefaultScale;
    }
    void ChangeScale(float NewScale)
    {
        if (isScaled)
            transform.localScale = defaultScale; 
        else
            transform.localScale = new Vector3(NewScale, NewScale, NewScale);

        isScaled = !isScaled;

        print("Scale Changed");
    }

    void DefaultScale()
    {
        transform.localScale = defaultScale;
        isScaled = false;
        print("Default is back");
    }



    void OnDisable()
    {
        PortalChangeSizer.OnSwitchSizePortalEnter -= ChangeScale;
        SpikeCollisionEventTrigger.OnPlayerHitSpikes -= DefaultScale;
    }


}
