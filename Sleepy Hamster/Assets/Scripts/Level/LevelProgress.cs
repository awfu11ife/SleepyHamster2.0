using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private StarsView _starsView;
    [SerializeField] private EatNut _eatNut;

    private int _numberOfCollectedStars;
    private string _key;

    private void Awake()
    {
        _key = SceneManager.GetActiveScene().name;
    }

    private void OnEnable()
    {
        _eatNut.NutEaten += SaveData;
    }

    private void OnDisable()
    {
        _eatNut.NutEaten -= SaveData;
    }

    private void SaveData()
    {
        _numberOfCollectedStars = _starsView.CurrentCollectedStarsAmount;
        var data = SaveLoadData.Load<SaveData.LevelProgressData>(_key);

        if (data.NumberOfCollectedStars <= _numberOfCollectedStars)
            SaveLoadData.Save(_key, GetSaveSnapshot());
    }

    private SaveData.LevelProgressData GetSaveSnapshot()
    {
        var data = new SaveData.LevelProgressData()
        {
            NumberOfCollectedStars = _numberOfCollectedStars
        };

        return data;
    }
}
