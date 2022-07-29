using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ShowStarsProgerss : MonoBehaviour
{
    [SerializeField] private Sprite _threeStars;
    [SerializeField] private Sprite _twoStars;
    [SerializeField] private Sprite _oneStar;
    [SerializeField] private Sprite _nonStars;

    private Image _image; 
    private int _collectedStars = 0;
    private string _sceneToTransitName;

    private void Awake()
    {
        _sceneToTransitName = GetComponentInParent<ChangeScene>().SceneName;
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        LoadData();
        SetStarsAmount(_collectedStars);
    }

    private void LoadData()
    {
        var data = SaveLoadData.Load<SaveData.LevelProgressData>(_sceneToTransitName);

        _collectedStars = data.NumberOfCollectedStars;
    }

    private void SetStarsAmount(int collectedStarsAmount)
    {
        switch (collectedStarsAmount)
        {
            case 0:
                ChangeSprite(_nonStars);
                break;
            case 1:
                ChangeSprite(_oneStar);
                break;
            case 2:
                ChangeSprite(_twoStars);
                break;
            case 3:
                ChangeSprite(_threeStars);
                break;
            default:
                ChangeSprite(_nonStars);
                break;
        }
    }

    private void ChangeSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
