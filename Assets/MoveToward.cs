using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    [SerializeField] bool EnableOnStart = true;
    [SerializeField] bool Loop = false;
    [SerializeField] Transform StartPosition;
    [SerializeField] Transform EndPosition;
    [SerializeField] float DelayBetweenLoop = 1;
    WaitForSeconds delayBetweenLoop;
    [SerializeField] float MoveSpeed;

    void Awake()
    {
        delayBetweenLoop = new WaitForSeconds(DelayBetweenLoop);
    }

    void Start()
    {
        if (EnableOnStart)
            MoveTowardDestination();
    }

    void MoveTowardDestination()
    {
        StartCoroutine(moveToward());
    }

    IEnumerator moveToward()
    {
       
        if(Loop)
        {
            while (true)
            {
                while (Vector2.Distance(transform.position, EndPosition.position) > 0.01f)
                {

                    transform.position = Vector2.Lerp(transform.position, EndPosition.position, Time.deltaTime * MoveSpeed);
                    yield return null;
                }

                OnDoorIsLocked?.Invoke();
                transform.position = EndPosition.position;
                yield return delayBetweenLoop;

                while (Vector2.Distance(transform.position, StartPosition.position) > 0.01f)
                {
                    transform.position = Vector2.Lerp(transform.position, StartPosition.position, Time.deltaTime * MoveSpeed);
                    yield return null;
                }

                OnDoorIsLocked?.Invoke();
                transform.position = StartPosition.position;
                yield return delayBetweenLoop;

            }
        }
        else
        {
            while (Vector2.Distance(transform.position, EndPosition.position) > 0.01f)
            {
                OnDoorIsLocked?.Invoke();

                transform.position = Vector2.Lerp(transform.position, EndPosition.position, Time.deltaTime * MoveSpeed);
                yield return null;
            }
        }
    }

    public static Action OnDoorIsLocked;
}
