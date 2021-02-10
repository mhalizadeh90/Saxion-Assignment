using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    Slider InputSlider;
    [SerializeField] FloatVariable InputValue;
    bool IsSliderHold;

    void Awake()
    {
        InputSlider = GetComponent<Slider>();
        ResetInputValue();
    }



    public void ResetInputValue(float defaultValue = 0)
    {
        InputValue.value = defaultValue;
        InputSlider.value = defaultValue;
        IsSliderHold = false;
        OnInputUpdate?.Invoke(false);
        //print("Reset");
    }

    public void UpdateSliderValue()
    {
        InputValue.value = InputSlider.value;
        
        if(!IsSliderHold)
        {
            OnInputUpdate?.Invoke(true);
            IsSliderHold = true;
            //print("Update");
        }
    }

    public static Action<bool> OnInputUpdate;

}
