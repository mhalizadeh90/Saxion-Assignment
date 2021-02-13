using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    float defaultGravity;
    Rigidbody2D ballRB2D;


    void Awake()
    {
        ballRB2D = GetComponent<Rigidbody2D>();
        defaultGravity = ballRB2D.gravityScale;
    }


    void OnEnable()
    {
        InputManager.OnInputUpdate += SetGravityState;
    }

    void SetGravityState(bool isMapRotating)
    {
        if(isMapRotating)
        {
            ballRB2D.gravityScale = 0;
            ballRB2D.velocity = Vector2.zero;
        }
        else
        {
            ballRB2D.gravityScale = defaultGravity;
        }
    }

    void OnDisable()
    {
        InputManager.OnInputUpdate -= SetGravityState;
    }

}
