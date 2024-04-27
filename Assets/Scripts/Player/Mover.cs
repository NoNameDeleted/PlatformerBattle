using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _moveSpeed = 1.5f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _hitForce = 6f;

    private Rigidbody2D _rigidbody;

    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Space = nameof(Jump);

    public event Action<float> DirectionChange;
    public event Action StopMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _player.GetDamage += OnGetHit;
    }

    private void OnDisable()
    {
        _player.GetDamage -= OnGetHit;
    }

    private void Update()
    {
        if (Input.GetButton(Horizontal))
        {
            Run();
        }
        else
        {
            StopMoving?.Invoke();
        }

        if (IsGrounded && Input.GetButtonDown(Space))
        {
            Jump();
        } 
    }

    public bool IsGrounded
    {
        get
        {
            float circleRadius = 0.1f;
            Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, circleRadius, _groundMask);

            return collider.Length > 0;
        }
    }

    private void Run()
    {
        float direction = Input.GetAxis(Horizontal);
        float distance = direction * _moveSpeed;

        _rigidbody.velocity = new Vector2(distance, _rigidbody.velocity.y);

        DirectionChange?.Invoke(direction);
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnGetHit(Vector3 hitPosition)
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce((transform.position - hitPosition) * _hitForce, ForceMode2D.Impulse);
    }
}
