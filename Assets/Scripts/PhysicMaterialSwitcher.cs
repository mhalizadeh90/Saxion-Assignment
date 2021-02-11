using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicMaterialSwitcher : MonoBehaviour
{
    [SerializeField] PhysicMaterialConfig PhysicMaterialConfig;
    [SerializeField] Vector2Variable playerVelocity;
    [SerializeField] BoolVariable isGrounded;
    [SerializeField] float yVelocityThresholdForNoBounciness = 1;
    [SerializeField] float xVelocityThresholdForNoBounciness = 0.1f;
    Rigidbody2D rb2D;
    bool toCheckForVelocity;
    PhysicsMaterial2D lastPhysicMaterial;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lastPhysicMaterial = rb2D.sharedMaterial; 
    }

    void OnEnable()
    {
        GroundHitEffectEventTrigger.OnHitTheGroundEffect += StartToCheckForSmallBounciness;
    }

    void StartToCheckForSmallBounciness()
    {
        toCheckForVelocity = true;
    }

    void SetNoBouncinessMaterial()
    {
        lastPhysicMaterial = rb2D.sharedMaterial;
        rb2D.sharedMaterial = PhysicMaterialConfig.NoBouncinessNoFriction;
    }

    void SetToDefaultMaterial()
    {
        rb2D.sharedMaterial = lastPhysicMaterial;
    }

    void Update()
    {
        //TODO: Check When Should I Set Physics Material To The Default
        if(toCheckForVelocity)
        {
            if (!isGrounded.value) return;
            if (Mathf.Abs(playerVelocity.value.x) > xVelocityThresholdForNoBounciness) return;
            if(Mathf.Abs(playerVelocity.value.y) > yVelocityThresholdForNoBounciness)  return;

            SetNoBouncinessMaterial();
            toCheckForVelocity = false;
            print("Switch To No Bounciness. [playerVelocity.value.x]: "+ playerVelocity.value.x+" . [playerVelocity.value.y]: "+ playerVelocity.value.y);

        }
    }

    void OnDisable()
    {
        GroundHitEffectEventTrigger.OnHitTheGroundEffect -= StartToCheckForSmallBounciness;
    }
}
