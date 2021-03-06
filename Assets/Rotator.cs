using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] bool toRotateStepByStep;
    [SerializeField] float RotateSpeed = 2;
    [Header("Rotate Steps by Steps")]
    [SerializeField] float DelayBetweenRotateAngle = 2;


    void Start()
    {
        StartCoroutine(StartRotation());
    }

    IEnumerator StartRotation()
    {
        WaitForSeconds DelayBetweenSteps =  new WaitForSeconds(DelayBetweenRotateAngle);
        float counter = 0;
       
        while (toRotateStepByStep)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeed);
            counter += Time.deltaTime;
            yield return null;

            if (counter>= DelayBetweenRotateAngle)
            {
                counter = 0;
                yield return DelayBetweenSteps;
            }
        }

        while (!toRotateStepByStep)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeed);
            yield return null;
        }
    }
}
