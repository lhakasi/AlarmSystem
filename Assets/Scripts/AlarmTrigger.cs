using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action PlayerEntered;
    public event Action PlayerExited;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            PlayerEntered.Invoke();            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            PlayerExited.Invoke();            
    }
}
