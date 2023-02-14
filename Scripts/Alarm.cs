using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;

    private Coroutine _setVolume;

    private float _maxVolume = 1f;
    private float _minVolume = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void IncreaseVolume()
    {
        TryStopSettingVolume();

        if (_audioSource.volume == 0)
            _audioSource.Play();

        _setVolume = StartCoroutine(SetVolume(_maxVolume));
    }

    public void DecreaseVolume()
    {
        TryStopSettingVolume();
        _setVolume = StartCoroutine(SetVolume(_minVolume));
    }

    private bool TryStopSettingVolume()
    {
        if (_setVolume != null)
        {
            StopCoroutine(_setVolume);
            return true;
        }

        return false;
    }

    private IEnumerator SetVolume(float value)
    {
        while (_audioSource.volume != value)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, value, Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }
}