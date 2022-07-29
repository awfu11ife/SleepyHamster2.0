using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RopeDestroyer : MonoBehaviour
{
    [SerializeField] private Color _disableoColor;
    [SerializeField] private float _disableTime;

    private float _step = .01f;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void DisableRope()
    {
        SetLinksDisableToCut();
        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve()
    {
        float currentTime = 0;

        while (_lineRenderer.material.color.a > 0)
        {
            _lineRenderer.material.color = Color.Lerp(_lineRenderer.material.color, _disableoColor, currentTime / _disableTime);
            currentTime += _step;
            yield return null;
        }

        DisableLinks();
    }

    private void DisableLinks()
    {
        foreach (var child in GetComponentsInChildren<Link>())
        {
            child.gameObject.SetActive(false);
        }
    }

    private void SetLinksDisableToCut()
    {
        foreach (var child in GetComponentsInChildren<Link>())
        {
            child.SetDisableToCut();
        }
    }
}
