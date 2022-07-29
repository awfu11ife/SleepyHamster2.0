using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelRestarter : MonoBehaviour
{
    [SerializeField] private float _delayBeforeRestart = 0.1f;
    private Button _restartLevelButton;
    private WaitForSeconds _restartDelay;

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

    private void Start()
    {
        _restartDelay = new WaitForSeconds(_delayBeforeRestart);
    }

    private void RestartLevel()
    {
        StartCoroutine(DelayBeforeRestart());
    }

    private IEnumerator DelayBeforeRestart()
    {
        yield return _restartDelay;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
