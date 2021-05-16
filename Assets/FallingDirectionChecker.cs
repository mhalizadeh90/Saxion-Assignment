using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDirectionChecker : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] Transform GroundDirection;
    [SerializeField] bool CheckForRotateDirection;
    bool ToChangeSlider = false;
    bool isGrounded;
    Vector2 FallingDirection;


    void OnEnable()
    {
        InputManager.OnInputUpdate += SliderChange;
    }

    void Update()
    {
        print("FallingDirection: " + FallingDirection);

        if (ToChangeSlider && CheckForRotateDirection && !isGrounded)
            UpdateFallingDirection();
    }

    void SliderChange(bool sliderUpdate)
    {
        if(sliderUpdate == false)
            ToChangeSlider = true;
    }

    private void UpdateFallingDirection()
    {
        FallingDirection = (GroundDirection.position - transform.position).normalized;
        
        print("FallingDirection: " + FallingDirection);
        
        if (Vector2.Distance(FallingDirection, Vector2.down) > 0.1f)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed);
        }
        else
        {
            ToChangeSlider = false;
        }
    }

    void OnDisable()
    {
        InputManager.OnInputUpdate -= SliderChange;
    }
}