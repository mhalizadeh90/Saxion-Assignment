using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDynamicController : MonoBehaviour
{
    public enum SpikeRotation
    {
        Upward, DownWard, LeftWard, RightWard
    }
    [SerializeField] bool isSpikeCycleEnabled = true;
    [SerializeField] SpikeRotation currentSpikeRotation;
    [Space]
    [SerializeField] float SpikesOutDuration;
    [SerializeField] float SpikesInDuration;
    [SerializeField] float MoveSpeed;
    [Space]
    [SerializeField] float MoveOutLenght;

    Vector2 SpikesInPosition;
    Vector2 SpikesOutPosition;

    WaitForSeconds SpikesOutDurationDelay;
    WaitForSeconds SpikesInDurationDelay;

    void Awake()
    {
        SpikesOutPosition = transform.localPosition;
        SpikesInPosition = GetSpikeInPosition(currentSpikeRotation, SpikesOutPosition);
     
        // Disable At the begining (spikes in)
        transform.localPosition = SpikesInPosition;
        SpikesOutDurationDelay = new WaitForSeconds(SpikesOutDuration);
        SpikesInDurationDelay = new WaitForSeconds(SpikesInDuration);
    }

    void Start()
    {
        if (isSpikeCycleEnabled)
            StartSpikeCycle();
    }

    void StartSpikeCycle()
    {
        StartCoroutine(SpikeCycle());
    }

    IEnumerator SpikeCycle()
    {
        while (isSpikeCycleEnabled)
        {
            #region SpikesOut

            while (Vector2.Distance(transform.localPosition, SpikesOutPosition) > 0.1f)
            {
                transform.localPosition = Vector2.Lerp(transform.localPosition, SpikesOutPosition, Time.deltaTime * MoveSpeed);
                yield return null;
            }
            transform.localPosition = SpikesOutPosition;
            OnSpikesOut?.Invoke();

            #endregion

            yield return SpikesOutDurationDelay;

            #region SpikesIn

            while (Vector2.Distance(transform.localPosition, SpikesInPosition) > 0.1f)
            {
                transform.localPosition = Vector2.Lerp(transform.localPosition, SpikesInPosition, Time.deltaTime * MoveSpeed);
                yield return null;
            }
            transform.localPosition = SpikesInPosition;

            #endregion

            yield return SpikesInDurationDelay;
        }


    }

    Vector2 GetSpikeInPosition(SpikeRotation spikerotation, Vector2 SpikeOutPosition)
    {
        Vector2 spikeInPosition = SpikeOutPosition;

        switch (spikerotation)
        {
            case SpikeRotation.Upward:
                spikeInPosition.y -= MoveOutLenght;
                break;
            case SpikeRotation.DownWard:
                spikeInPosition.y += MoveOutLenght;
                break;
            case SpikeRotation.LeftWard:
                spikeInPosition.x += MoveOutLenght;
                break;
            case SpikeRotation.RightWard:
                spikeInPosition.x -= MoveOutLenght;
                break;
            default:
                break;
        }

        return spikeInPosition;
    }
   
    public static Action OnSpikesOut;

}
