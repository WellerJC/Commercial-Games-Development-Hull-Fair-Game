using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const int hours = 24, minutes = 60;

    public float dayDuration = 30f;

    float totalTime = 131;
    float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        currentTime = totalTime % dayDuration ;
    }

    public float GetHour()
    {
        return currentTime * hours/ dayDuration;
    }

    public float GetMinute()
    {
        return (currentTime * hours * minutes/ dayDuration)  % minutes;
    }

    public string Clock24Hour()
    {
        Debug.Log(currentTime);
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinute()).ToString("00");
    }
}
