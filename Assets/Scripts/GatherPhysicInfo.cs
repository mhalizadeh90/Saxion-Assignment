using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherPhysicInfo : MonoBehaviour
{
    [SerializeField] Vector2Variable playerVelocity;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float DistanceToGround;
    
    [Header("Test For Raycast Line")]
    public bool toShowDrawLine;

    int GroundLayerID;

    void Awake()
    {
        GroundLayerID = LayerMask.GetMask("Ground");
    }


    void FixedUpdate()
    {
        playerVelocity.value = rb2D.velocity;
    }


}
