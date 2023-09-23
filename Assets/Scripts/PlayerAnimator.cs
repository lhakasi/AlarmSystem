using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Speed = nameof(Speed);
    
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_rigidbody2D.velocity.magnitude > 0)
        {
            if (_playerMovement.HorizontalInput > 0)
                _spriteRenderer.flipX = false;
            else
                _spriteRenderer.flipX = true;
        }

        _animator.SetFloat(Speed, Mathf.Abs(_playerMovement.HorizontalInput));
    }
}