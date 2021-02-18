using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Audio Clips")]
    [SerializeField] AudioClip RotateSFX;
    [SerializeField] AudioClip ClickSFX;
    [SerializeField] AudioClip WinSFX;
    [SerializeField] AudioClip LooseSFX;
    [SerializeField] AudioClip SpikeOutSFX;

    [Header("Audio Source Reference")]
    [SerializeField] AudioSource musicPlayer;
    [SerializeField] AudioSource bounceSFXPlayer;
    [SerializeField] AudioSource ButtonPlayer;
    [SerializeField] AudioSource GameOverPlayer;
    [SerializeField] AudioSource SpikePlayer;

    [Space]
    [SerializeField] FloatVariable inputSlider;
    bool ToSetSliderPitch;

    void OnEnable()
    {
        FinishEvent.OnBallReachFinishPoint += PlayWinSFX;
        FinishEvent.OnBallReachFinishPoint += StopMusicPlayer;
        SpikeCollisionEventTrigger.OnPlayerHitSpikes += PlayDeathSFX;
        GroundHitEffectEventTrigger.OnHitTheGroundEffect += PlayBounceSFX;
        InputManager.OnInputUpdate += PlayRotateSFX;
        SpikeDynamicController.OnSpikesOut += PlaySpikeOut;
    }

    void PlayBounceSFX()
    {
        bounceSFXPlayer.Play();
    }



    void Update()
    {
        if(ToSetSliderPitch)
        {
            ButtonPlayer.pitch = Mathf.Abs(inputSlider.value)+0.4f;
        }
    }

    void PlayWinSFX()
    {
        GameOverPlayer.clip = WinSFX;
        GameOverPlayer.Play();
    }

    void PlayDeathSFX()
    {
        GameOverPlayer.clip = LooseSFX;
        GameOverPlayer.Play();
    }

    void PlaySpikeOut()
    {
        SpikePlayer.clip = SpikeOutSFX;
        SpikePlayer.Play();
    }

    void PlayRotateSFX(bool toStartRotation)
    {
        if(toStartRotation)
        {
            ButtonPlayer.clip = RotateSFX;
            ButtonPlayer.loop = true;
            ButtonPlayer.Play();

            ToSetSliderPitch = true;
        }
        else
        {
            ButtonPlayer.loop = false;
            ButtonPlayer.Stop();
            ButtonPlayer.pitch = 1;
            ToSetSliderPitch = false;
        }
    }

    void StopMusicPlayer()
    {
        musicPlayer.Stop();
    }

    void OnDisable()
    {
        FinishEvent.OnBallReachFinishPoint -= PlayWinSFX;
        FinishEvent.OnBallReachFinishPoint -= StopMusicPlayer;
        SpikeCollisionEventTrigger.OnPlayerHitSpikes -= PlayDeathSFX;
        SpikeDynamicController.OnSpikesOut -= PlaySpikeOut;
        GroundHitEffectEventTrigger.OnHitTheGroundEffect -= PlayBounceSFX;
        InputManager.OnInputUpdate -= PlayRotateSFX;
    }
}
