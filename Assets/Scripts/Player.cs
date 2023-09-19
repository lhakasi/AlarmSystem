using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D rb2d;
    private Animator _animator;    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontalInput * _speed, rb2d.velocity.y);

        bool flipped = horizontalInput < 0;

        _animator.SetBool("isMovingRight", flipped ? false : true);              

        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));        

        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput * _speed));
    }
}
