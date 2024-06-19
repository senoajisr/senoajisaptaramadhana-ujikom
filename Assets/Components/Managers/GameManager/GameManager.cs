using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action<int> TimerReduced;

    public int GameTimer = 60;

    public static GameManager Instance;

    private void Awake()
    {
        OnlyInstance();
    }

    private void Start()
    {
        InvokeRepeating(nameof(TimerReduce), 1, 1);
    }

    private void OnlyInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    private void TimerReduce()
    {
        if (GameTimer <= 0)
        {
            CancelInvoke(nameof(TimerReduce));
            return;
        }

        GameTimer--;
        TimerReduced.Invoke(GameTimer);
    }
}
