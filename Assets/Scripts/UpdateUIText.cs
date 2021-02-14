using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIText : MonoBehaviour
{
    [SerializeField] FloatVariable sourceValue;
    [SerializeField] bool UpdateOnStart = true;
    [SerializeField] bool toRoundNumber = false;
    Text textToUpdate;

    void Awake()
    {
        textToUpdate = GetComponent<Text>();
    }

    void Start()
    {
        float value = sourceValue.value;
       
        if (toRoundNumber)
            value = Mathf.Round(value * 10) / 10;

        textToUpdate.text = value.ToString();
    }
}
