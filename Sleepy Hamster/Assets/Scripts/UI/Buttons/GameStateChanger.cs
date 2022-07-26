using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameStateChanger : MonoBehaviour
{
    [SerializeField] private GameObject _panetToOpen;
    [SerializeField] private GameObject _panelToClose;
    [SerializeField] private float _timeScale;

    private Button _pauseButton;

    private void Awake()
    {
        _pauseButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(ButtonBehaviour);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(ButtonBehaviour);
    }

    private void ButtonBehaviour()
    {
        PauseGame(_panetToOpen, _panelToClose, _timeScale);
    }

    private void PauseGame(GameObject panelToOpen, GameObject panelToClose, float timeScale)
    {
        panelToClose.SetActive(false);
        panelToOpen.SetActive(true);
        Time.timeScale = timeScale;
    }
}
