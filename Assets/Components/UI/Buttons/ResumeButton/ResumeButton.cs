using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject PauseMenu;

    private void Start()
    {
        GameManager.Instance.OnPaused += OnPaused;
        PauseMenu.SetActive(false);
    }

    private void OnPaused(bool value)
    {
        if (GameManager.Instance.GameOver) return;
        PauseMenu.SetActive(value);
    }

    public void OnPressed()
    {
        PauseMenu.SetActive(false);
        GameManager.Instance.GamePause = false;
    }
}
