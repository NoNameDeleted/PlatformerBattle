using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed = 1.5f;
    [SerializeField] private float _jumpForce = 3f;

    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Space = nameof(Jump);

    public event Action<float> DirectionChange;
    public event Action StopMoving;

    private void Update()
    {
        if (Input.GetButton(Horizontal))
        {
            Run();
        }
        else
        {
            StandStill();
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

    private void StandStill()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
}
