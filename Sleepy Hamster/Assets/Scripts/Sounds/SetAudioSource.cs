using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SetAudioSource : MonoBehaviour
{
    [SerializeField] private Keys _keys;

    private AudioSource _audioSource;
    private bool _isMute;
    private string _key;

    private enum Keys
    {
        SoundEffectsToggle,
        MusicToggle
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _key = _keys.ToString();
        LoadData();
    }

    public void UpdateAudioSource()
    {
        LoadData();
    }

    private void LoadData()
    {
        var data = SaveLoadData.Load<SaveData.SoundsData>(_key);

        _audioSource.mute = data.IsButtonMute;
    }

}
