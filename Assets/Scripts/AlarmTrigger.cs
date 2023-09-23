using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private AlarmAudioChanger _audioChanger;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _audioChanger.Play();            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _audioChanger.Stop();            
    }
}
