using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBorders : MonoBehaviour
{
    [SerializeField] private float _delayBeforeLevelRestart;
    [SerializeField] private NutEater _eatNut;
    private bool _levelComplited = false;
    private WaitForSeconds _restartDelay;

    private void OnEnable()
    {
        _eatNut.NutEaten += DisableLevelBorders;
    }

    private void OnDisable()
    {
        _eatNut.NutEaten -= DisableLevelBorders;
    }

    private void Start()
    {
        _restartDelay = new WaitForSeconds(_delayBeforeLevelRestart);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out LevelBordersCross levelBordersCross))
        {
            levelBordersCross.DisableObject();
            StartCoroutine(RestartLevel());
        }
    }

    private IEnumerator RestartLevel()
    {
        yield return _restartDelay;

        if (_levelComplited == false)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DisableLevelBorders()
    {
        _levelComplited = true;
    }
}
