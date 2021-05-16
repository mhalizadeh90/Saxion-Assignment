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

    bool toStartEffect = false;
    bool isTheEffectApplied = false;
    float defaultCameraZoom;
    float sliderOffset;

    Camera mainCamera;
    float SliderAbsValue;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
        defaultCameraZoom = mainCamera.orthographicSize;
    }

    void OnEnable()
    {
        InputManager.OnInputUpdate += SetEnableStateOfCameraEffect;
    }

    void Update()
    {
        if (toStartEffect)
        {
            SliderAbsValue = Mathf.Abs(SliderValue.value);

            if (EnableZoomEffect)
                mainCamera.orthographicSize =  Mathf.Lerp(mainCamera.orthographicSize, (SliderAbsValue + defaultCameraZoom), Time.deltaTime * StartZoomEffectSpeed);

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

                if ((!EnableZoomEffect || isCameraSetToDefaultZoom))
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
