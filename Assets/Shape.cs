using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shape : MonoBehaviour
{
    [SerializeField] ShapeTypes DefaultShape;
    [HideInInspector] public ShapeTypes currentShape;
    [SerializeField] Color RedShapeColor;
    [SerializeField] Color YellowShapeColor;
    [SerializeField] Color GreenShapeColor;
    [SerializeField] Color BlueShapeColor;

    SpriteRenderer spRenderer;

    void Awake()
    {
        currentShape = DefaultShape;
        spRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        PortalChangeColorShape.OnSwitchShapePortalEnter += SelectShape;
    }
    void Start()
    {
        SelectShape(currentShape);
    }



    void SelectShape(ShapeTypes shape)
    {
        currentShape = shape;

        switch (shape)
        {
            case ShapeTypes.YellowShape:
                spRenderer.color = YellowShapeColor;
                break;
            case ShapeTypes.RedShape:
                spRenderer.color = RedShapeColor;
                break;
            case ShapeTypes.BlueShape:
                spRenderer.color = BlueShapeColor;
                break;
            case ShapeTypes.GreenShape:
                spRenderer.color = GreenShapeColor;
                break;
        }
    }

    void OnDisable()
    {
        PortalChangeColorShape.OnSwitchShapePortalEnter -= SelectShape;
    }
}


public enum ShapeTypes
{
    YellowShape, RedShape, BlueShape, GreenShape
}