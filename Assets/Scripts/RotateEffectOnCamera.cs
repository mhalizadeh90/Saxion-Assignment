using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffectOnCamera : MonoBehaviour
{
    [Header("Zoom Effect")]
    [SerializeField] bool EnableZoomEffect;
    [SerializeField] FloatVariable SliderValue;
    [SerializeField] float ResetZoomEffectSpeed = 2;
    [SerializeField] float StartZoomEffectSpeed = 2;
    bool isPixelateEffectSetToDefault;
    bool isCameraSetToDefaultZoom;

    [Header("Blurry Effect")]
    [SerializeField] bool EnableBlurryEffect;
    [SerializeField] CameraFilterPack_Blur_Blurry blurryEffect;
  //  [SerializeField] Assets.Pixelation.Scripts.Pixelation pixelationEffector;
    [SerializeField] float ResetBlurryEffectSpeed = 100;
    [SerializeField] float StartBlurryEffectSpeed = 100;
    [SerializeField] float BlurryMax = 5;
    float BlurryMin = 0;

    bool toStartEffect = false;
    bool isTheEffectApplied = false;
    float defaultCameraZoom;
    float sliderOffset;

    Camera mainCamera;
    float SliderAbsValue;

    void Awake()
    {
        sliderOffset = BlurryMax - BlurryMin;
        mainCamera = GetComponent<Camera>();
        defaultCameraZoom = mainCamera.orthographicSize;

        if (!SliderValue) EnableZoomEffect = false;
        if (!blurryEffect) EnableBlurryEffect = false;

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

            if (EnableZoomEffect)
                mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, (SliderAbsValue + defaultCameraZoom), Time.deltaTime * StartZoomEffectSpeed);
            // mainCamera.orthographicSize =  SliderAbsValue + defaultCameraZoom;

            if (EnableBlurryEffect)
                blurryEffect.Amount = Mathf.Lerp(blurryEffect.Amount, SliderAbsValue * sliderOffset,Time.deltaTime* StartBlurryEffectSpeed);
            // pixelationEffector.BlockCount = Mathf.Clamp(SliderAbsValue * sliderOffset,PixelateMax,PixelateMin);

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

                if (EnableBlurryEffect)
                {
                    isPixelateEffectSetToDefault = blurryEffect.Amount >= BlurryMin;
                    if (!isPixelateEffectSetToDefault) blurryEffect.Amount += Time.deltaTime * ResetBlurryEffectSpeed;
                }

                if ((!EnableZoomEffect || isCameraSetToDefaultZoom) && (!EnableBlurryEffect || isPixelateEffectSetToDefault))
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
