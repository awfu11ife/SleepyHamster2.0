using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsBar : MonoBehaviour
{
    [SerializeField] private StarsView _starsView;
    [SerializeField] private UIStar _uIStarTemplate;

    private List<UIStar> _uIStars = new List<UIStar>();

    private void OnEnable()
    {
        _starsView.StarsAmountChanged += OnStarsAmountChanged;
    }

    private void OnDisable()
    {
        _starsView.StarsAmountChanged -= OnStarsAmountChanged;
    }

    private void OnStarsAmountChanged(int value)
    {
        if (_uIStars.Count < value)
        {
            int createStar = value - _uIStars.Count;

            for (int i = 0; i < createStar; i++)
            {
                AddStar();
            }
        }
    }

    private void AddStar()
    {
        UIStar newStar = Instantiate(_uIStarTemplate, transform);
        _uIStars.Add(newStar);
        newStar.Fill();
    }
}
