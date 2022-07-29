using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelTypesHolder : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _selectedLevelTypeChanged;

    private LevelType[] _allLevelTypes;
    private int _activeLevelTypeIndex = 0;

    public int LevelTypesCount => _allLevelTypes.Length;

    public event UnityAction<int> SelectedLevelTypeChanged
    {
        add => _selectedLevelTypeChanged.AddListener(value);
        remove => _selectedLevelTypeChanged.RemoveListener(value);
    }

    private void Awake()
    {
        _allLevelTypes = gameObject.GetComponentsInChildren<LevelType>();

        foreach (var image in _allLevelTypes)
        {
            image.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        ChangeLevelType(_activeLevelTypeIndex);
    }

    public void ChangeLevelType(int step)
    {
        _activeLevelTypeIndex = Mathf.Clamp(_activeLevelTypeIndex, 0, _allLevelTypes.Length - 1);
        _allLevelTypes[_activeLevelTypeIndex].gameObject.SetActive(false);

        _activeLevelTypeIndex = Mathf.Clamp(_activeLevelTypeIndex + step, 0, _allLevelTypes.Length - 1);
        _allLevelTypes[_activeLevelTypeIndex].gameObject.SetActive(true);

        _selectedLevelTypeChanged?.Invoke(_activeLevelTypeIndex);
    }
}
