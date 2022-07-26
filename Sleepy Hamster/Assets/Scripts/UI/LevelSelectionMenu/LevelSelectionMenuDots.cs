using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionMenuDots : MonoBehaviour
{
    [SerializeField] private LevelTypes _levelTypes;
    [SerializeField] private Dot _dotTempLate;

    private List<Dot> _allDots = new List<Dot>();
    private int _currentSelectedDotIndex = 0;

    private void OnEnable()
    {
        _levelTypes.SelectedLevelTypeChanged += ChangeSelectedDot;
    }

    private void OnDisable()
    {
        _levelTypes.SelectedLevelTypeChanged -= ChangeSelectedDot;
    }

    private void Start()
    {
        CreateDots(_levelTypes.LevelTypesCount, _dotTempLate);

        foreach (var dot in _allDots)
        {
            dot.Deselect();
        }

        ChangeSelectedDot(_currentSelectedDotIndex);
    }

    private void CreateDots(int numberOfDots, Dot dotTemplate)
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            Dot newDot = Instantiate(dotTemplate, transform);
            _allDots.Add(newDot);
        }
    }

    private void ChangeSelectedDot(int currentSelectedIndex)
    {
        if (_allDots.Count != 0)
        {
            _allDots[_currentSelectedDotIndex].Deselect();
            _currentSelectedDotIndex = currentSelectedIndex;
            _allDots[_currentSelectedDotIndex].Select();
        }
    }
}
