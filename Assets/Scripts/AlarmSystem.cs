using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _targetVolume;
    [SerializeField] private float _duration;

    private float _startVolume = 0;
    private float _runningTime;

    private AudioSource _melody;

    private bool _isFadingOut;

    private void Start()
    {
        _melody = GetComponent<AudioSource>();
        _melody.volume = _startVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _runningTime = 0;
            _startVolume = _melody.volume;

            _isFadingOut = false;

            StartCoroutine(FadeAudio());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _runningTime = 0;
            _startVolume = _melody.volume;

            _isFadingOut = true;

            if (!_melody.isPlaying)
                StopCoroutine(FadeAudio());
        }
    }

    private IEnumerator FadeAudio()
    {
        while (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            if (!_melody.isPlaying)
                _melody.Play();

            _melody.volume = Mathf.Lerp(_startVolume, _targetVolume, normalizeRunningTime);

            if (_isFadingOut)
                _melody.volume = Mathf.Lerp(_startVolume, 0, normalizeRunningTime);

            if (_melody.volume == 0)
                _melody.Stop();

            yield return null;
        }
    }
}
