using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFinishEvent : MonoBehaviour
{
    void OnEnable()
    {
        FinishEvent.OnBallReachFinishPoint += DisablePlayer;
    }

    void DisablePlayer()
    {
        Destroy(this.gameObject);
    }

    void OnDisable()
    {
        FinishEvent.OnBallReachFinishPoint -= DisablePlayer;
    }

}
