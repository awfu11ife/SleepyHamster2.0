using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SetSoundToggles : MonoBehaviour
{
    private string _key;
    private Toggle _soundToggle;

    private void Awake()
    {
        _key = gameObject.name;
        _soundToggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        var data = SaveLoadData.Load<SaveData.SoundsData>(_key);

        _soundToggle.isOn = data.IsButtonMute;
    }

    public void SaveData()
    {
            SaveLoadData.Save(_key, GetSaveSnapshot());
    }

    private SaveData.SoundsData GetSaveSnapshot()
    {
        var data = new SaveData.SoundsData()
        {
            IsButtonMute = _soundToggle.isOn
        };

        return data;
    }
}
