using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneChanger : MonoBehaviour
{
    private const string AnimationTrigger = "Start";

    [SerializeField] private string _sceneName;
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 0.5f;
    private WaitForSeconds _transitionLenght;

    private Button _sceneChangeButton;

    public string SceneName => _sceneName;

    private void Awake()
    {
        _sceneChangeButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _sceneChangeButton.onClick.AddListener(LoadScene);
    }

    private void OnDisable()
    {
        _sceneChangeButton.onClick.RemoveListener(LoadScene);
    }

    private void Start()
    {
        _transitionLenght = new WaitForSeconds(_transitionTime);
    }

    private void LoadScene()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadDelay(_sceneName));
    }

    IEnumerator LoadDelay(string sceneName)
    {
        _transition.SetTrigger(AnimationTrigger);

        yield return _transitionTime;

        SceneManager.LoadScene(_sceneName);
    }
}
