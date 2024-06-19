using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action<int> OnTimerReduced;
    public Action<int> OnScoreChanged;
    public Action<bool> OnPaused;
    public Action<bool> OnGameOver;

    public int GameTimer = 60;
    public bool _gameOver = false;
    public bool GameOver
    {
        get { return _gameOver; }
        set {
            _gameOver = value;
            OnGameOver?.Invoke(value);
        }
    }
    public bool _gamePause = false;
    public bool GamePause
    {
        get { return _gamePause; }
        set {
            _gamePause = value;
            OnPaused?.Invoke(value);
        }
    }
    private int _gameScore = 0;
    public int GameScore
    {
        get { return _gameScore; }
        set {
            _gameScore = value;
            OnScoreChanged?.Invoke(_gameScore);
        }
    }


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

    private void Update()
    {
        PauseGameOnEsc();
    }

    private void PauseGameOnEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause = !GamePause;
        }
    }

    private void TimerReduce()
    {
        if (GamePause) return;

        if (GameTimer <= 0)
        {
            GameOver = true;
            GamePause = true;
            CancelInvoke(nameof(TimerReduce));
            return;
        }

        GameTimer--;
        OnTimerReduced?.Invoke(GameTimer);
    }
}
