using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    
    void Start()
    {
        SetText(GameManager.Instance.GameTimer);
        GameManager.Instance.TimerReduced += OnTimerReduced;
    }

    public void OnTimerReduced(int time)
    {
        SetText(time);
    }

    private void SetText(int time)
    {
        tmp.text = "Timer: " + time.ToString();
    }
}
