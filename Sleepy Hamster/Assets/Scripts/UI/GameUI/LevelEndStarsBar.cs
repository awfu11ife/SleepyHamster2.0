using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndStarsBar : MonoBehaviour
{
    [SerializeField] private StarsView _starsView;
    [SerializeField] private UIStar _uIStarTemplate;
    [SerializeField] private float _delayBeforeStarAppears;

    private List<UIStar> _uIStars = new List<UIStar>();

    private void Start()
    {
        StartCoroutine(DeleyBeforeStarAppears(_starsView.CurrentCollectedStarsAmount));
    }

    private IEnumerator DeleyBeforeStarAppears(int numberOFCollectedStars)
    {
        for (int i = 0; i < numberOFCollectedStars; i++)
        {
            yield return new WaitForSeconds(_delayBeforeStarAppears);
            AddStar();
        }
    }

    private void AddStar()
    {
        UIStar newStar = Instantiate(_uIStarTemplate, transform);
        _uIStars.Add(newStar);
        newStar.Fill();
    }
}
