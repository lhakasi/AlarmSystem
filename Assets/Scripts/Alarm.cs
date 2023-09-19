using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _targetVolume;
    [SerializeField] private float _duration;
    private float _startVolume = 0;
    private float _runningTime;

    private AudioSource _melody;
    private bool _isFadingOut;

    void Start()
    {
        _melody = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _runningTime = 0;
            _melody.volume = _startVolume;
            _melody.Play();

            _isFadingOut = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _runningTime = 0;
            _startVolume = _melody.volume;

            _isFadingOut = true;
        }
    }

    void Update()
    {        
        if (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            _melody.volume = Mathf.Lerp(_startVolume, _runningTime, normalizeRunningTime);

            if( _isFadingOut )            
                _melody.volume = Mathf.Lerp(_startVolume, 0, normalizeRunningTime);          

            if (_melody.volume == 0)
                _melody.Stop();
        }
    }
}
