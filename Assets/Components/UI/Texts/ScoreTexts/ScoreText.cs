using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    
    void Start()
    {
        SetText(GameManager.Instance.GameScore);
        GameManager.Instance.ScoreChanged += OnScoreChanged;
    }

    public void OnScoreChanged(int score)
    {
        SetText(score);
    }

    private void SetText(int score)
    {
        tmp.text = "Score: " + score.ToString();
    }
}
