using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffectOnCamera : MonoBehaviour
{
    [Header("Zoom Effect")]
    [SerializeField] bool EnableZoomEffect;
    [SerializeField] FloatVariable SliderValue;
    [SerializeField] float ResetZoomEffectSpeed = 2;
    bool isPixelateEffectSetToDefault;
    bool isCameraSetToDefaultZoom;

    [Header("Pixelate Effect")]
    [SerializeField] bool EnablePixalateEffect;
    [SerializeField] Assets.Pixelation.Scripts.Pixelation pixelationEffector;
    [SerializeField] float ResetPixelateEffectSpeed = 100;

    bool toStartEffect = false;
    bool isTheEffectApplied = false;
    float defaultCameraZoom;
    const float PixelateMax = 100;
    const float PixelateMin = 512;
    const float sliderOffset = PixelateMin - PixelateMax;

    Camera mainCamera;
    float SliderAbsValue;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
        defaultCameraZoom = mainCamera.orthographicSize;

        if (!SliderValue) EnableZoomEffect = false;
        if (!pixelationEffector) EnablePixalateEffect = false;

    }
    void OnEnable()
    {
        InputManager.OnInputUpdate += SetEnableStateOfCameraEffect;
        
    }

    void Update()
    {
        if (!SliderValue)
            return;

        if (toStartEffect)
        {
            SliderAbsValue = Mathf.Abs(SliderValue.value);
        
            if(EnableZoomEffect)
                mainCamera.orthographicSize = SliderAbsValue + defaultCameraZoom;

            if(EnablePixalateEffect)
                pixelationEffector.BlockCount = Mathf.Clamp(SliderAbsValue * sliderOffset,PixelateMax,PixelateMin);

            isTheEffectApplied = true;
        }
        else
        {
            if(isTheEffectApplied)
            {
                if(EnableZoomEffect)
                {
                    isCameraSetToDefaultZoom = mainCamera.orthographicSize <= defaultCameraZoom;
                    if (!isCameraSetToDefaultZoom) mainCamera.orthographicSize -= Time.deltaTime * ResetZoomEffectSpeed;
                }

                if (EnablePixalateEffect)
                {
                    isPixelateEffectSetToDefault = pixelationEffector.BlockCount >= PixelateMin;
                    if (!isPixelateEffectSetToDefault) pixelationEffector.BlockCount += Time.deltaTime * ResetPixelateEffectSpeed;
                }

                if ((!EnableZoomEffect || isCameraSetToDefaultZoom) && (!EnablePixalateEffect || isPixelateEffectSetToDefault))
                {
                    isTheEffectApplied = false;
                }

            }
        }
    }


    void SetEnableStateOfCameraEffect(bool isRotatingButtonHold)
    {
        toStartEffect = isRotatingButtonHold;
    }

    void OnDisable()
    {
        InputManager.OnInputUpdate -= SetEnableStateOfCameraEffect;
    }

}
