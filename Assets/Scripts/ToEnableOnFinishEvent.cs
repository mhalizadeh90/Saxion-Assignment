using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToEnableOnFinishEvent : MonoBehaviour
{
    [SerializeField] GameObject objectToEnable;

    void Awake()
    {
        objectToEnable.SetActive(false);
    }

    void OnEnable()
    {
        FinishEvent.OnBallReachFinishPoint += ShowFinishPanel;
    }

    void ShowFinishPanel()
    {
        objectToEnable.SetActive(true);
    }

    void OnDisable()
    {
        FinishEvent.OnBallReachFinishPoint -= ShowFinishPanel;
    }
}
