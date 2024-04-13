using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Patroler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private float _speed = 1f;

    public event Action<float> DirectionChange;

    private int _currentWaypoint;
    private Vector2 _currentTarget;

    private void Start()
    {
        _currentTarget = _waypoints[_currentWaypoint].position;
    }

    private void Update()
    {
        if (transform.position.x == _waypoints[_currentWaypoint].position.x)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

            _currentTarget = _waypoints[_currentWaypoint].position;
            DirectionChange?.Invoke(_currentTarget.x - transform.position.x);
        }

        transform.position = Vector2.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _currentTarget = player.transform.position;
            DirectionChange?.Invoke(_currentTarget.x - transform.position.x);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _currentTarget = _waypoints[_currentWaypoint].position;
            DirectionChange?.Invoke(_currentTarget.x - transform.position.x);
        }
    }
}
