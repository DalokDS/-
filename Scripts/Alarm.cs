using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;

    private Coroutine _increaseVolume;
    private Coroutine _decreaseVolume;

    private float _maxVolume = 1f;
    private float _minVolume = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void IncreaseVolume()
    {
        TryStopCoroutine(_decreaseVolume);

        if (_audioSource.volume == 0)
            _audioSource.Play();

        _increaseVolume = StartCoroutine(SetVolume(_maxVolume));
    }

    public void DecreaseVolume()
    {
        TryStopCoroutine(_increaseVolume);
        _decreaseVolume = StartCoroutine(SetVolume(_minVolume));
    }

    private bool TryStopCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
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