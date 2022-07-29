using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanStateChanger : MonoBehaviour
{
    [SerializeField] private GameObject _fanWind;
    private bool _isActive;

    private void Start()
    {
        _isActive = _fanWind.activeSelf;
    }

    private void OnMouseDown()
    {
        _isActive = !_isActive;
        _fanWind.SetActive(_isActive);
    }
}
