﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class timeController : MonoBehaviour
{
    public Text timerText;
    public float startTime;
    
    void Start()
    {
        startTime = Time.time;
	}
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("F2");

        timerText.text = minutes + ":" + seconds;
    }
}
