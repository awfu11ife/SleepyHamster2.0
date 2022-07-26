using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIStar : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
    }

    public void Fill()
    {
        StartCoroutine(Filling(0, 1, _lerpDuration, Filling));
    }

    private IEnumerator Filling(float startValue, float endValue, float duraton, UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;
        float nextValue;

        while(elapsed < duraton)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duraton);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void Filling(float value)
    {
        _image.fillAmount = value;
    }
}
