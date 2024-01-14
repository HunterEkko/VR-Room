using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public GameObject hourObj, minuteObj, secondObj;
    private float lastSecond;
    // 1秒 -> 時針轉6度
    // 1秒 -> 分針轉0.1度
    // 1分鐘 -> 時針轉0.5度
    void Start()
    {
        secondObj.transform.Rotate(Vector3.up, DateTime.Now.Second * 6);
        minuteObj.transform.Rotate(Vector3.up, DateTime.Now.Minute * 6 + DateTime.Now.Second * 0.1f);
        hourObj.transform.Rotate(Vector3.up, DateTime.Now.Hour * 30 + DateTime.Now.Minute * 0.5f);
        lastSecond = DateTime.Now.Second;
    }
    void Update()
    {
        ClockRotation();
    }
    void ClockRotation()
    {
        if (DateTime.Now.Second != lastSecond)
        {
            lastSecond = DateTime.Now.Second;
            secondObj.transform.Rotate(Vector3.up, 6);
            minuteObj.transform.Rotate(Vector3.up, 0.1f);
            if (lastSecond == 0)
            {
                hourObj.transform.Rotate(Vector3.up, 0.5f);
            }
            // Debug.Log(DateTime.Now.TimeOfDay);
        }
    }
}
