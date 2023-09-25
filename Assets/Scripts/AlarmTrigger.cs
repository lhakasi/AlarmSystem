using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action OnTriggerEnter;
    public event Action OnTriggerExit;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            OnTriggerEnter.Invoke();            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            OnTriggerExit.Invoke();            
    }
}
