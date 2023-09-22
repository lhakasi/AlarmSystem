using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        _rigidbody2D.velocity = new Vector2(horizontalInput * _speed, _rigidbody2D.velocity.y);

        bool flipped = horizontalInput < 0;

        _animator.SetBool("isMovingRight", flipped ? false : true);              

        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));        

        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput * _speed));
    }
}
