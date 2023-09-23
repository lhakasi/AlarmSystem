using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmAudioChanger : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _interpolationValue;
    [SerializeField] private float _delay;

    private float _startVolume = 0;

    private Coroutine _fading;
    private AudioSource _melody;

    private void Start()
    {
        _melody = GetComponent<AudioSource>();
        _melody.volume = _startVolume;
    }

    public void Play() => 
        Restart(_maxVolume);    
    
    public void Stop() => 
        Restart(_minVolume);    

    private void Restart(float targetVolume)
    {
        if (_fading != null)
            StopCoroutine(_fading);

        _fading = StartCoroutine(Fading(targetVolume));
    }

    private IEnumerator Fading(float targetVolume)
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        
        if (!_melody.isPlaying)
            _melody.Play();

        while (_melody.volume != targetVolume)
        {
            _melody.volume = Mathf.MoveTowards(_melody.volume, targetVolume, _interpolationValue);

            if (_melody.volume <= 0)
                _melody.Stop();

            yield return delay;
        }
    }
}
