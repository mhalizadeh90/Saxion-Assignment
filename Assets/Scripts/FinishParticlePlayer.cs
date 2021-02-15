using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishParticlePlayer : MonoBehaviour
{
    ParticleSystem winParticle;
    
    void Awake()
    {
        winParticle = GetComponent<ParticleSystem>();
    }

    void OnEnable()
    {
        FinishEvent.OnBallReachFinishPoint += PlayWinParticle;
    }

    void PlayWinParticle()
    {
        winParticle.Play();
    }

    void OnDisable()
    {
        FinishEvent.OnBallReachFinishPoint -= PlayWinParticle;
    }

}
