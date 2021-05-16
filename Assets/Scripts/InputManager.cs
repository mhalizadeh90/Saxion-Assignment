using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] FloatVariable InputValue;
    [Header("Screen Touch")]
    [SerializeField] bool IsScreenTouchEnable;
    [Header("Slider Touch")]
    [SerializeField] Slider InputSlider;
    Touch touch;
    float startTouchX;
    bool IsInputButtonHold;
    Camera mainCam;

    void Awake()
    {
        mainCam = FindObjectOfType<Camera>();
        InputValue.value = 0;
        
        if(InputSlider)
            InputSlider.value = 0;
        
        IsInputButtonHold = false;
    }

    void Update()
    {
        if (!IsScreenTouchEnable)
            return;

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchX = mainCam.ScreenToWorldPoint(touch.position).x; 
                    break;
                case TouchPhase.Moved:
                    UpdateTouchValue(mainCam.ScreenToWorldPoint(touch.position).x - startTouchX);
                    break;
                case TouchPhase.Ended:
                    ResetInputValue();
                    break;
            }

        }
    }


    public void ResetInputValue(float defaultValue = 0)
    {
        if(InputSlider)
            InputSlider.value = defaultValue;

        InputValue.value = defaultValue;
        IsInputButtonHold = false;
        OnInputUpdate?.Invoke(false);
    }

    public void UpdateSliderValue()
    {
        if(InputSlider)
            InputValue.value = InputSlider.value;
        
        if(!IsInputButtonHold)
        {
            OnInputUpdate?.Invoke(true);
            IsInputButtonHold = true;
        }
    }

    public void UpdateTouchValue(float touchInputValue)
    {
        InputValue.value = touchInputValue;

        if (!IsInputButtonHold)
        {
            OnInputUpdate?.Invoke(true);
            IsInputButtonHold = true;
        }
    }

    public static Action<bool> OnInputUpdate;

}
