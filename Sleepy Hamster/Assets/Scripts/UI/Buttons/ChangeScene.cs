using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 0.5f;

    private Button _sceneChangeButton;

    public string SceneName => _sceneName;

    private void Awake()
    {
        _sceneChangeButton = GetComponent<Button>();
        _sceneChangeButton.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadDelay(_sceneName));
    }

    IEnumerator LoadDelay(string sceneName)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(_sceneName);
    }
}
