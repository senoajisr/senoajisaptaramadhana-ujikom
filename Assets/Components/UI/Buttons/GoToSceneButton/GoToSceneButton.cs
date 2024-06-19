using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneButton : MonoBehaviour
{
    public string SceneName;

    public void OnPressed()
    {
        SceneManager.LoadScene(SceneName);
    }
}
