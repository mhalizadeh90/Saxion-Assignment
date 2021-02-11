using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherPhysicInfo : MonoBehaviour
{
    [SerializeField] Vector2Variable playerVelocity;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float DistanceToGround;
    [SerializeField] BoolVariable isGrounded;
    
    [Header("Test For Raycast Line")]
    public bool toShowDrawLine;

    int GroundLayerID;

    void Awake()
    {
        GroundLayerID = LayerMask.GetMask("Ground");

    }
    void FixedUpdate()
    {
        if(toShowDrawLine)
            Debug.DrawRay(transform.position, Vector2.down * DistanceToGround, Color.red);

        playerVelocity.value = rb2D.velocity;
        isGrounded.value = Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround, GroundLayerID);
    }
}
