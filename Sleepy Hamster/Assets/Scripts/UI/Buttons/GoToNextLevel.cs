using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Button))]
public class GoToNextLevel : MonoBehaviour
{
    private Button _nextLevelButton;
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 0.5f;

    private void Awake()
    {
        _nextLevelButton = GetComponent<Button>();
        _nextLevelButton.onClick.AddListener(ChangeToNextLevel);
    }

    private void ChangeToNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastSceneIndex = SceneManager.sceneCount - 1;

        if (currentSceneIndex < lastSceneIndex)
            LoadDelay(currentSceneIndex + 1);
    }

    IEnumerator LoadDelay(int sceneIndex)
    {
        Time.timeScale = 1;
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
