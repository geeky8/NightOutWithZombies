using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class timeController : MonoBehaviour
{
    public Text timerText;
    public float startTime;
    public static float score;
    public bool submitted = false;
    public int min;
    public int sec;
    public static int time;
    public static int sc;

    void Start()
    {
        startTime = Time.time;
        Time.timeScale = 0f;
    }

    public void Submit()
    {
        submitted = true;
        Time.timeScale = 1f;
    }

    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("F2");

        timerText.text = minutes + ":" + seconds;
        score = t;

        time = min * 60 + sec;
    }

    public static void Leaderboard()
    {
        sc = (int)score;
        PlayFabManager.SendLeaderboard(sc);
    }
}
