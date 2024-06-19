using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : GoToSceneButton
{
    public GameObject GameOverMenu;

    private void Start()
    {
        GameManager.Instance.OnGameOver += OnGameOver;
        GameOverMenu.SetActive(false);
    }

    private void OnGameOver(bool value)
    {
        GameOverMenu.SetActive(true);
    }
}
