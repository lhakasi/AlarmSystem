using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    public float HorizontalInput { get; private set; }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(HorizontalInput * _speed, _rigidbody2D.velocity.y);        
    }    
}
