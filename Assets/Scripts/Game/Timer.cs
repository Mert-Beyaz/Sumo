using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float _Time;
    public TextMeshProUGUI TimeText;
    void Start()
    {
        _Time = 60;
        TimeText.text = "" + (int)_Time;
    }

    void Update()
    {
        if (_Time > 0)
        {
            _Time -= Time.deltaTime;
            TimeText.text = "" + (int)_Time;
        }
        
    }
}
