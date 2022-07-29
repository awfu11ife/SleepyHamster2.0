using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StarsHolder : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _starsAmountChanged;

    private int _currentCollectedStarsAmount = 0;
    private Star[] _allStars;

    public int CurrentCollectedStarsAmount => _currentCollectedStarsAmount;

    public event UnityAction<int> StarsAmountChanged
    {
        add => _starsAmountChanged.AddListener(value);
        remove => _starsAmountChanged.RemoveListener(value);
    }

    private void OnEnable()
    {
        _allStars = gameObject.GetComponentsInChildren<Star>();

        foreach (var star in _allStars)
            star.Collected += OnStarCollected;
    }

    private void OnDisable()
    {
        foreach (var star in _allStars)
            star.Collected -= OnStarCollected;
    }

    private void OnStarCollected()
    {
        _currentCollectedStarsAmount++;
        _starsAmountChanged?.Invoke(_currentCollectedStarsAmount);
    }
}
