using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSwitch : MonoBehaviour
{
    [SerializeField] Lights SwitchLight;
    [SerializeField] ShapeTypes RequiredShapeKey;
    [SerializeField] Transform ChargeSlider;
    [SerializeField] float ChargeSpeed;
    [SerializeField] float DechargeSpeed;
    [SerializeField] float MaxChargeYScale;

    [SerializeField]float currentCharge = 0;
    bool isPlayerOnChargingZone = false;
    bool isFullyCharged;
    Vector2 SliderScale;
    Shape playerShape;
    Rigidbody2D playerRB2D;

    void Awake()
    {
        SliderScale = ChargeSlider.localScale;
        playerShape = new Shape();
    }


    void Update()
    {
        if (isPlayerOnChargingZone)
            Charge();
        else
            Decharge();

        SetSliderScaleBasedOnCharge();

        TriggerSwitchEvents();
    }

    private void TriggerSwitchEvents()
    {
        if (currentCharge >= 1 && !isFullyCharged)
        {
            isFullyCharged = true;
            OnFullyCharged?.Invoke(SwitchLight);
        }
        else if (currentCharge <= 0 && isFullyCharged)
        {
            isFullyCharged = false;
            OnFullyDeCharged?.Invoke(SwitchLight);
        }
    }

    private void SetSliderScaleBasedOnCharge()
    {
        SliderScale.y = (currentCharge * MaxChargeYScale) / 1f;
        ChargeSlider.localScale = SliderScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerShape = collision.GetComponent<Shape>();
        if (!playerRB2D)
            playerRB2D = collision.GetComponent<Rigidbody2D>();

        if (playerShape && playerShape.currentShape == RequiredShapeKey)
        {
            isPlayerOnChargingZone = true;
            // TODO: HEAR CHARGIN SFX + PARTICLE
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOnChargingZone = false;
    }

    void Charge()
    {
        if (currentCharge<1)
        {
            currentCharge += Time.deltaTime * ChargeSpeed;
        }
    }

    void Decharge()
    {
        if (currentCharge > 0)
        {
            print("decharge");
            currentCharge -= Time.deltaTime * DechargeSpeed;
        }
    }

    void OnDisable()
    {
        
    }

    public static Action<Lights> OnFullyCharged;
    public static Action<Lights> OnFullyDeCharged;

}
