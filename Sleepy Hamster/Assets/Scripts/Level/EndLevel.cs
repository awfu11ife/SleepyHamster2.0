using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private NutEater _eatNut;
    [SerializeField] private float _timeBeforePanelOpen;

    [SerializeField] private Image _backGround;
    [SerializeField] private float _fillindDuration;

    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameObject _endLevelStarsBar;
    [SerializeField] private float _buttonsEnableDuration;

    private void OnEnable()
    {
        _eatNut.NutEaten += FillBackGround;
    }

    private void OnDisable()
    {
        _eatNut.NutEaten -= FillBackGround;
    }

    private void FillBackGround()
    {
        StartCoroutine(LevelEndDelay());
    }

    private void SetActiveButtons()
    {
        _buttons.SetActive(true);
        StartCoroutine(ChangeAlpha(0, 1, _buttonsEnableDuration));
    }

    private void SetActiveStarsBar()
    {
        _endLevelStarsBar.SetActive(true);
    }

    private IEnumerator LevelEndDelay()
    {
        yield return new WaitForSeconds(_timeBeforePanelOpen);
        _backGround.gameObject.SetActive(true);

        SetActiveButtons();
        SetActiveStarsBar();
    }

    private IEnumerator ChangeAlpha(float startValue, float endValue, float duration)
    {

        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _buttons.GetComponent<CanvasGroup>().alpha = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }

        _backGround.fillAmount = 1;
    }
}
