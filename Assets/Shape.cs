using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shape : MonoBehaviour
{
    [SerializeField] ShapeTypes DefaultShape;
    [HideInInspector] public ShapeTypes currentShape;

    void Awake()
    {
        currentShape = DefaultShape;
    }

    void Start()
    {
        SelectShape(currentShape);
    }



    void SelectShape(ShapeTypes shape)
    {
        switch (shape)
        {
            case ShapeTypes.Circle:
                // Select Shape Circle
                break;
            case ShapeTypes.Squere:
                // Select Shape Circle
                break;
            case ShapeTypes.Triangle:
                // Select Shape Circle
                break;
            default:
                break;
        }
    }
}


public enum ShapeTypes
{
    Circle, Squere, Triangle
}