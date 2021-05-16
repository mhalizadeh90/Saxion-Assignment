using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGOOnEnter : MonoBehaviour
{
    [SerializeField] GameObject[] ObjectToEnable;

    void Awake()
    {
        SetObjectEnableState(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SetObjectEnableState(true);

        Destroy(this.gameObject, 0.1f);
    }

    void SetObjectEnableState(bool state)
    {
        if (ObjectToEnable == null)
            return;

        for (int i = 0; i < ObjectToEnable.Length; i++)
        {
            if (ObjectToEnable[i])
                ObjectToEnable[i].SetActive(state);
        }

    }
}
