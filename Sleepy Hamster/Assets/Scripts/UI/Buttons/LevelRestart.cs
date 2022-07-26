using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelRestart : MonoBehaviour
{
    private Button _restartLevelButton;

    private void Awake()
    {
        _restartLevelButton = GetComponent<Button>();
        _restartLevelButton.onClick.AddListener(RestartLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
