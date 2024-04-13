using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeed = 1.5f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _hitForce = 6f;

    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Space = nameof(Jump);
    private readonly string Fire1 = nameof(Fire1);

    public event Action<float> DirectionChange;
    public event Action StopMoving;
    public event Action StartAttack;

    private void OnEnable()
    {
        _player.GetDamage += GetHit;
    }

    private void OnDisable()
    {
        _player.GetDamage -= GetHit;
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

        if (Input.GetButtonDown(Fire1))
        {
            Attack();
            StartAttack?.Invoke();
        }
    }

    public bool IsGrounded
    {
        get
        {
            float circleRadius = 0.1f;
            Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, circleRadius);

            return collider.Length > 1;
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

    private void Attack()
    {

    }

    private void GetHit(Vector3 hitPosition)
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce((transform.position - hitPosition) * _hitForce, ForceMode2D.Impulse);
    }
}
