using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbitcreator : MonoBehaviour
{
    LineRenderer lineRenderer;
    AudioSource audioSource;
    [SerializeField] Vector2Variable centerPositionOfToken;

    [Range(3,50)][SerializeField] int OrbitSegments = 20;
    [SerializeField] float xAxis = 5;
    [SerializeField] float yAxis = 3;
    [Range(0,1)][SerializeField] float delayInDrawingCircle = 0.1f;
    
    Vector3[] points;
    Vector2 originPositionOffset;
    Vector2 circleCenterPoint;
    WaitForSeconds delayTimeInDrawCircle;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = OrbitSegments + 1;
        delayTimeInDrawCircle = new WaitForSeconds(delayInDrawingCircle);
        points = new Vector3[OrbitSegments + 1];
        originPositionOffset = transform.position;
        circleCenterPoint = new Vector2(originPositionOffset.x , originPositionOffset.y + yAxis);

        CalculateOrbit();
    }

    void OnEnable()
    {
        TokenManager.OnAllTokensActivated += StartDrawOrbit;
    }

    void Start()
    {
        centerPositionOfToken.value = circleCenterPoint;
    }

    void StartDrawOrbit()
    {
        StartCoroutine(DrawOrbit());
    }

    IEnumerator DrawOrbit()
    {
        
        for (int i = 0; i < OrbitSegments; i++)
        {
            lineRenderer.SetPosition(i, points[i]);
            for (int j = i+1; j < OrbitSegments; j++)
            {
                lineRenderer.SetPosition(j, points[i]);
            }
            lineRenderer.SetPosition(OrbitSegments, points[i]);

            yield return delayTimeInDrawCircle;
            audioSource.Play();

        }
        lineRenderer.SetPosition(OrbitSegments, points[0]);
        print("Now orbit finished");
        OnOrbitDrawn?.Invoke();
    }

    void CalculateOrbit()
    {
        for (int i = 0; i < OrbitSegments; i++)
        {
            float angle = ((float)i / (float)OrbitSegments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * xAxis + originPositionOffset.x;
            float y = (originPositionOffset.y + yAxis) - Mathf.Cos(angle) * yAxis  ;

            points[i] = new Vector3(x, y, 0);
        }

        points[OrbitSegments] = points[0];
    }


    void OnDisable()
    {
        TokenManager.OnAllTokensActivated -= StartDrawOrbit;
    }

    public static Action OnOrbitDrawn;
}
