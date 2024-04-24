using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Mover _mover;
    [SerializeField] private Vector2 _attackRectangle = new Vector2(0.16f, 0.1f);
    [SerializeField] private float _attackRange = 0.16f;
    [SerializeField] private int _damageAmount = 10;

    private readonly string Fire1 = nameof(Fire1);

    private Collider2D[] _colliders;
    private Vector2 _direction = new Vector2(1, 0);

    public event Action StartAttack;

    private void OnEnable()
    {
        _mover.DirectionChange += SetDirection;
    }

    private void OnDisable()
    {
        _mover.DirectionChange -= SetDirection;
    }

    private void Update()
    {
        if (Input.GetButtonDown(Fire1))
        {
            Attack();
            StartAttack?.Invoke();
        }
    }

    private void Attack()
    {
        Vector2 position = transform.position;
        Vector2 pointA = position + new Vector2(_attackRange - (_attackRectangle.x / 2), _attackRectangle.y / 2) * _direction;
        Vector2 pointB = position + new Vector2(_attackRange + (_attackRectangle.x / 2), _attackRectangle.y / -2) * _direction;
        _colliders = Physics2D.OverlapAreaAll(pointA, pointB, _enemyMask);

        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damageAmount);
            }
        }
    }

    private void SetDirection(float direction)
    {
        _direction = new Vector2(direction, 0);
    }
}
