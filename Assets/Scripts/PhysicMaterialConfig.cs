using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Physics Material Config")]
public class PhysicMaterialConfig : ScriptableObject
{
    public PhysicsMaterial2D NoBouncinessNoFriction;
    public PhysicsMaterial2D SmallBouncinessNoFriction;
    public PhysicsMaterial2D MediumBouncinessNoFriction;
    public PhysicsMaterial2D HighBouncinessNoFriction;
}
