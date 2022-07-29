using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelRestart : MonoBehaviour
{
    [SerializeField] private float _delayBeforeRestart = 0.1f;
    private Button _restartLevelButton;

    private void Awake()
    {
        _restartLevelButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _restartLevelButton.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        _restartLevelButton.onClick.RemoveListener(RestartLevel);
    }

    private void RestartLevel()
    {
        StartCoroutine(DelayBeforeRestart());
    }

    private IEnumerator DelayBeforeRestart()
    {
        yield return new WaitForSeconds(_delayBeforeRestart);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
