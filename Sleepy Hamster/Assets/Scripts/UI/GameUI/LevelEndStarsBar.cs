using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndStarsBar : MonoBehaviour
{
    [SerializeField] private StarsHolder _starsView;
    [SerializeField] private UIStar _uIStarTemplate;
    [SerializeField] private float _delayBeforeStarAppears;
    private WaitForSeconds _starDelay;

    private List<UIStar> _uIStars = new List<UIStar>();

    private void Start()
    {
        _starDelay = new WaitForSeconds(_delayBeforeStarAppears);
        StartCoroutine(DeleyBeforeStarAppears(_starsView.CurrentCollectedStarsAmount));
    }

    private IEnumerator DeleyBeforeStarAppears(int numberOFCollectedStars)
    {
        for (int i = 0; i < numberOFCollectedStars; i++)
        {
            yield return _starDelay;
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
