using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollector : MonoBehaviour
{
    [SerializeField]private EatNut _eatNut;

    public bool IsAbleToCollect { get; private set; }

    private void OnEnable()
    {
        _eatNut.NutEaten += SetDisableToCollect;
    }

    private void OnDisable()
    {
        _eatNut.NutEaten -= SetDisableToCollect;
    }

    private void Start()
    {
        IsAbleToCollect = true;
    }

    private void SetDisableToCollect()
    {
        IsAbleToCollect = false;
    }
}
